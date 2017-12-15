using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal sealed class GlobalEnvironment : BaseEnvironment
    {
        [NotNull] private readonly Agent agent;
        [NotNull] private readonly ObjectEnvironment objectRecord;
        [NotNull] private readonly ScriptObject globalThisValue;
        [NotNull] private readonly DeclarativeEnvironment declarativeRecord;
        [NotNull] private readonly HashSet<ScriptValue> variableNames = new HashSet<ScriptValue>();

        public GlobalEnvironment([NotNull] Agent agent, [NotNull] ScriptObject globalObject, [NotNull] ScriptObject thisValue)
        {
            //https://tc39.github.io/ecma262/#sec-newglobalenvironment
            objectRecord = new ObjectEnvironment(globalObject, false);
            this.agent = agent;
            globalThisValue = thisValue;
            declarativeRecord = new DeclarativeEnvironment(agent);
        }

        public override bool HasBinding(ScriptValue name)
        {
            return declarativeRecord.HasBinding(name) || objectRecord.HasBinding(name);
        }

        public override void CreateMutableBinding(ScriptValue name, bool deletable)
        {
            if (declarativeRecord.HasBinding(name))
                throw agent.CreateTypeError();
            declarativeRecord.CreateMutableBinding(name, deletable);
        }

        public override void CreateImmutableBinding(ScriptValue name, bool strict)
        {
            throw new NotImplementedException();
        }

        public override void InitialiseBinding(ScriptValue name, ScriptValue value)
        {
            if (declarativeRecord.HasBinding(name))
                declarativeRecord.InitialiseBinding(name, value);
            else
            {
                Debug.Assert(objectRecord.HasBinding(name));
                objectRecord.InitialiseBinding(name, value);
            }
        }

        public override void SetMutableBinding(ScriptValue name, ScriptValue value, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-global-environment-records-setmutablebinding-n-v-s
            if (declarativeRecord.HasBinding(name))
            {
                declarativeRecord.SetMutableBinding(name, value, strict);
            }
            else
            {
                objectRecord.SetMutableBinding(name, value, strict);
            }
        }

        public override ScriptValue GetBindingValue(ScriptValue name, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-global-environment-records-getbindingvalue-n-s
            if (declarativeRecord.HasBinding(name))
            {
                return declarativeRecord.GetBindingValue(name, strict);
            }

            return objectRecord.GetBindingValue(name, strict);
        }

        public override bool DeleteBinding(ScriptValue name)
        {
            //https://tc39.github.io/ecma262/#sec-global-environment-records-deletebinding-n
            if (declarativeRecord.HasBinding(name))
            {
                return declarativeRecord.DeleteBinding(name);
            }

            var globalObject = objectRecord.BindingObject;
            var existingProp = globalObject.HasOwnProperty(name);
            if (existingProp)
            {
                var status = objectRecord.DeleteBinding(name);
                if (status)
                {
                    variableNames.Remove(name);
                }

                return status;
            }

            return true;
        }

        public override bool HasThisBinding()
        {
            return true;
        }

        public override bool HasSuperBinding()
        {
            throw new NotImplementedException();
        }

        public override ScriptValue WithBaseObject()
        {
            return ScriptValue.Undefined;
        }

        public override ScriptValue GetThisBinding()
        {
            return globalThisValue;
        }

        public override ScriptValue GetSuperBase()
        {
            throw new NotImplementedException();
        }

        public bool HasVarDeclaration([NotNull] string name)
        {
            return variableNames.Contains(name);
        }

        public bool HasLexicalDeclaration([NotNull] string name)
        {
            return declarativeRecord.HasBinding(name);
        }

        public bool HasRestrictedGlobalProperty([NotNull] string name)
        {
            var globalObject = objectRecord.BindingObject;
            var existingProperty = globalObject.GetOwnProperty(name);
            if (existingProperty == null)
                return false;
            return !existingProperty.Configurable;
        }

        public bool CanDeclareGlobalVar([NotNull] string name)
        {
            //https://tc39.github.io/ecma262/#sec-candeclareglobalvar
            var globalObject = objectRecord.BindingObject;
            var hasProperty = globalObject.HasOwnProperty(name);
            return hasProperty || globalObject.IsExtensible;
        }

        public bool CanDeclareGlobalFunction([NotNull] string name)
        {
            //https://tc39.github.io/ecma262/#sec-candeclareglobalfunction
            var globalObject = objectRecord.BindingObject;
            var existingProperty = globalObject.GetOwnProperty(name);
            if (existingProperty == null)
            {
                return globalObject.IsExtensible;
            }

            if (existingProperty.Configurable)
            {
                return true;
            }

            return existingProperty.IsDataDescriptor && existingProperty.Writable && existingProperty.Enumerable;
        }

        public void CreateGlobalVarBinding([NotNull] string name, bool deletable)
        {
            //https://tc39.github.io/ecma262/#sec-createglobalvarbinding
            var globalObject = objectRecord.BindingObject;
            var hasProperty = globalObject.HasOwnProperty(name);
            var extensible = globalObject.IsExtensible;

            if (!hasProperty && extensible)
            {
                objectRecord.CreateMutableBinding(name, deletable);
                objectRecord.InitialiseBinding(name, ScriptValue.Undefined);
            }

            variableNames.Add(name);
        }

        public void CreateGlobalFunctionBinding([NotNull] string name, ScriptValue value, bool deletable)
        {
            //https://tc39.github.io/ecma262/#sec-createglobalfunctionbinding
            var globalObject = objectRecord.BindingObject;
            var existingProperty = globalObject.GetOwnProperty(name);
            PropertyDescriptor descriptor;
            if (existingProperty == null || existingProperty.Configurable)
            {
                descriptor = new PropertyDescriptor(value, true, true, deletable);
            }
            else
            {
                descriptor = new PropertyDescriptor(value);
            }

            agent.DefinePropertyOrThrow(globalObject, name, descriptor);
            //TODO? Record that the binding for N in ObjRec has been initialized.
            agent.Set(globalObject, name, value, false);
            variableNames.Add(name);
        }
    }
}