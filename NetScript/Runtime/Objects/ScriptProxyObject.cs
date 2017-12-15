using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptProxyObject : ScriptObject
    {
        internal ScriptProxyObject([NotNull] Agent agent, [NotNull] ScriptObject target, [NotNull] ScriptObject handler) :
            base(agent, null, false, SpecialObjectType.None)
        {
            ProxyTarget = target;
            ProxyHandler = handler;
        }

        internal override ScriptObject GetPrototypeOf()
        {
            throw new NotImplementedException();
        }

        internal override bool SetPrototypeOf(ScriptObject prototype)
        {
            throw new NotImplementedException();
        }

        internal override bool PreventExtensions()
        {
            throw new NotImplementedException();
        }

        internal override PropertyDescriptor GetOwnProperty(ScriptValue property)
        {
            throw new NotImplementedException();
        }

        internal override bool DefineOwnProperty(ScriptValue property, PropertyDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public override bool HasProperty(ScriptValue property)
        {
            throw new NotImplementedException();
        }

        internal override ScriptValue Get(ScriptValue property, ScriptValue reciever)
        {
            throw new NotImplementedException();
        }

        internal override bool Set(ScriptValue property, ScriptValue value, ScriptValue receiver)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-set-p-v-receiver
            Debug.Assert(Agent.IsPropertyKey(property));
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }

            var trap = Agent.GetMethod(ProxyHandler, "set");
            if (trap == null)
            {
                return ProxyTarget.Set(property, value, receiver);
            }

            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget, property, value, receiver));
            if (!booleanTrapResult)
            {
                return false;
            }

            var targetDescriptor = ProxyTarget.GetOwnProperty(property);
            if (targetDescriptor != null && !targetDescriptor.Configurable)
            {
                if (targetDescriptor.IsDataDescriptor && !targetDescriptor.Writable)
                {
                    Debug.Assert(targetDescriptor.Value != null, "targetDescriptor.Value != null");
                    if (!value.SameValue(targetDescriptor.Value.Value))
                    {
                        throw Agent.CreateTypeError();
                    }
                }
                else if (targetDescriptor.IsAccessorDescriptor)
                {
                    if (targetDescriptor.Set == null)
                    {
                        throw Agent.CreateTypeError();
                    }
                }
            }

            return true;
        }

        internal override bool Delete(ScriptValue property)
        {
            throw new NotImplementedException();
        }

        internal override IEnumerable<ScriptValue> OwnPropertyKeys()
        {
            throw new NotImplementedException();
        }

        internal override ScriptValue Call(ScriptValue thisValue, IReadOnlyList<ScriptValue> arguments)
        {
            throw new NotImplementedException();
        }

        internal override ScriptValue Construct(IReadOnlyList<ScriptValue> arguments, ScriptObject newTarget)
        {
            throw new NotImplementedException();
        }

        [NotNull]
        public ScriptObject ProxyTarget { get; }
        [CanBeNull]
        public ScriptObject ProxyHandler { get; }

        public override bool IsExtensible
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsCallable => ProxyTarget.IsCallable;
        public override bool IsConstructable => ProxyTarget.IsConstructable;
    }
}
