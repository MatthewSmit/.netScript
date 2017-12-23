using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal sealed class ObjectEnvironment : BaseEnvironment
    {
        private readonly bool withEnvironment;

        public ObjectEnvironment([NotNull] ScriptObject bindingObject, bool withEnvironment)
        {
            BindingObject = bindingObject;
            this.withEnvironment = withEnvironment;
        }

        public override bool HasBinding(ScriptValue name)
        {
            var foundBinding = BindingObject.HasProperty(name);
            if (!foundBinding)
            {
                return false;
            }

            if (!withEnvironment)
            {
                return true;
            }

            var unscopables = BindingObject.Get(Symbol.Unscopables);
            if (unscopables.IsObject)
            {
                var blocked = Agent.ToBoolean(((ScriptObject)unscopables).Get(name));
                if (blocked)
                {
                    return false;
                }
            }

            return true;
        }

        public override void CreateMutableBinding(ScriptValue name, bool deletable)
        {
            //https://tc39.github.io/ecma262/#sec-object-environment-records-createmutablebinding-n-d
            BindingObject.Agent.DefinePropertyOrThrow(BindingObject, name, new PropertyDescriptor(ScriptValue.Undefined, true, true, deletable));
        }

        public override void CreateImmutableBinding(ScriptValue name, bool strict)
        {
            throw new NotImplementedException();
        }

        public override void InitialiseBinding(ScriptValue name, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-object-environment-records-initializebinding-n-v
            SetMutableBinding(name, value, false);
        }

        public override void SetMutableBinding(ScriptValue name, ScriptValue value, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-object-environment-records-setmutablebinding-n-v-s
            BindingObject.Agent.Set(BindingObject, name, value, strict);
        }

        public override ScriptValue GetBindingValue(ScriptValue name, bool strict)
        {
            var value = BindingObject.HasProperty(name);
            if (!value)
            {
                if (strict)
                {
                    throw BindingObject.Agent.CreateReferenceError();
                }

                return ScriptValue.Undefined;
            }

            return BindingObject.Get(name, BindingObject);
        }

        public override bool DeleteBinding(ScriptValue name)
        {
            //https://tc39.github.io/ecma262/#sec-object-environment-records-deletebinding-n
            return BindingObject.Delete(name);
        }

        public override bool HasThisBinding()
        {
            return false;
        }

        public override bool HasSuperBinding()
        {
            return false;
        }

        public override ScriptValue WithBaseObject()
        {
            throw new NotImplementedException();
        }

        public override ScriptValue GetThisBinding()
        {
            throw new NotImplementedException();
        }

        public override ScriptValue GetSuperBase()
        {
            throw new NotImplementedException();
        }

        [NotNull]
        public ScriptObject BindingObject { get; }
    }
}