using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal class DeclarativeEnvironment : BaseEnvironment
    {
        internal sealed class Binding
        {
            public bool Initialised;
            public bool Deletable;
            public bool Strict;
            public ScriptValue Value;
            public bool Mutable;
        }

        [NotNull] private readonly Agent agent;
        [NotNull] private readonly Dictionary<ScriptValue, Binding> bindings = new Dictionary<ScriptValue, Binding>();

        public DeclarativeEnvironment([NotNull] Agent agent)
        {
            this.agent = agent;
        }

        public override bool HasBinding(ScriptValue name)
        {
            return bindings.ContainsKey(name);
        }

        public override void CreateMutableBinding(ScriptValue name, bool deletable)
        {
            Debug.Assert(!bindings.ContainsKey(name));
            bindings.Add(name, new Binding
            {
                Deletable = deletable,
                Mutable = true
            });
        }

        public override void CreateImmutableBinding(ScriptValue name, bool strict)
        {
            Debug.Assert(!bindings.ContainsKey(name));
            bindings.Add(name, new Binding
            {
                Strict = strict
            });
        }

        public override void InitialiseBinding(ScriptValue name, ScriptValue value)
        {
            var binding = bindings[name];
            Debug.Assert(!binding.Initialised);
            binding.Value = value;
            binding.Initialised = true;
        }

        public override void SetMutableBinding(ScriptValue name, ScriptValue value, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-declarative-environment-records-setmutablebinding-n-v-s
            if (!bindings.TryGetValue(name, out var binding))
            {
                if (strict)
                {
                    throw agent.CreateReferenceError();
                }

                CreateMutableBinding(name, true);
                InitialiseBinding(name, value);
            }
            else
            {
                if (binding.Strict)
                {
                    strict = true;
                }

                if (!binding.Initialised)
                {
                    throw agent.CreateReferenceError();
                }

                if (binding.Mutable)
                {
                    binding.Value = value;
                }
                else if (strict)
                {
                    throw agent.CreateTypeError();
                }
            }
        }

        public override ScriptValue GetBindingValue(ScriptValue name, bool strict)
        {
            var binding = bindings[name];
            if (!binding.Initialised)
            {
                throw agent.CreateReferenceError();
            }
            return binding.Value;
        }

        public override bool DeleteBinding(ScriptValue name)
        {
            //https://tc39.github.io/ecma262/#sec-declarative-environment-records-deletebinding-n

            if (!bindings[name].Deletable)
            {
                return false;
            }

            var result = bindings.Remove(name);
            Debug.Assert(result);
            return true;
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
            return ScriptValue.Undefined;
        }

        public override ScriptValue GetThisBinding()
        {
            throw new NotImplementedException();
        }

        public override ScriptValue GetSuperBase()
        {
            throw new NotImplementedException();
        }
    }
}