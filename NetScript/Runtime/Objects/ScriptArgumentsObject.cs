using System.Diagnostics;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptArgumentsObject : ScriptObject
    {
        internal ScriptArgumentsObject([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, bool extensible) :
            base(realm, prototype, extensible, SpecialObjectType.ArgumentsObject)
        {
        }

        internal override bool DefineOwnProperty(ScriptValue property, PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-arguments-exotic-objects-defineownproperty-p-desc

            var isMapped = ParameterMap.HasOwnProperty(property);
            var newArgumentDescriptor = descriptor;
            if (isMapped && descriptor.IsDataDescriptor)
            {
                if (!descriptor.Value.HasValue && descriptor.Writable.HasValue && !descriptor.Writable)
                {
                    newArgumentDescriptor = new PropertyDescriptor(ParameterMap.Get(property), descriptor.Writable, descriptor.Enumerable, descriptor.Configurable);
                }
            }

            var allowed = base.DefineOwnProperty(property, newArgumentDescriptor);
            if (!allowed)
            {
                return false;
            }

            if (isMapped)
            {
                if (descriptor.IsAccessorDescriptor)
                {
                    ParameterMap.Delete(property);
                }
                else
                {
                    if (descriptor.Value.HasValue)
                    {
                        var setStatus = Agent.Set(ParameterMap, property, descriptor.Value.Value, false);
                        Debug.Assert(setStatus);
                    }

                    if (descriptor.Writable.HasValue && !descriptor.Writable)
                    {
                        ParameterMap.Delete(property);
                    }
                }
            }

            return true;
        }

        internal override PropertyDescriptor GetOwnProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-arguments-exotic-objects-getownproperty-p

            var descriptor = base.GetOwnProperty(property);
            if (descriptor == null)
            {
                return null;
            }

            var isMapped = ParameterMap.HasOwnProperty(property);
            if (isMapped)
            {
                descriptor.Value = ParameterMap.Get(property, ParameterMap);
            }

            return descriptor;
        }

        internal override ScriptValue Get(ScriptValue property, ScriptValue reciever)
        {
            //https://tc39.github.io/ecma262/#sec-arguments-exotic-objects-get-p-receiver
            var isMapped = ParameterMap.HasOwnProperty(property);
            if (!isMapped)
            {
                return base.Get(property, reciever);
            }

            return ParameterMap.Get(property, ParameterMap);
        }

        internal override bool Set(ScriptValue property, ScriptValue value, ScriptValue receiver)
        {
            //https://tc39.github.io/ecma262/#sec-arguments-exotic-objects-set-p-v-receiver

            var isMapped = false;
            if (this == receiver)
            {
                isMapped = ParameterMap.HasOwnProperty(property);
            }

            if (isMapped)
            {
                var setStatus = Agent.Set(ParameterMap, property, value, false);
                Debug.Assert(setStatus);
            }

            return base.Set(property, value, receiver);
        }

        internal override bool Delete(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-arguments-exotic-objects-delete-p

            var isMapped = ParameterMap.HasOwnProperty(property);
            var result = base.Delete(property);
            if (result && isMapped)
            {
                ParameterMap.Delete(property);
            }

            return result;
        }

        public ScriptObject ParameterMap { get; set; }
    }
}
