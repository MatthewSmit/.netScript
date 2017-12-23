using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Builtins;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptIntegerIndexedObject : ScriptObject
    {
        /// <inheritdoc />
        internal ScriptIntegerIndexedObject([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, TypeDescription typeDescription) :
            base(realm, prototype, true, SpecialObjectType.TypedArray)
        {
            Description = typeDescription;
        }

        /// <inheritdoc />
        internal override PropertyDescriptor GetOwnProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-integer-indexed-exotic-objects-getownproperty-p
            Debug.Assert(Agent.IsPropertyKey(property));
            if (property.IsString)
            {
                var numericIndex = Agent.CanonicalNumericIndexString((string)property);
                if (numericIndex.HasValue)
                {
                    var value = IntegerIndexedElementGet(numericIndex.Value);
                    if (value == ScriptValue.Undefined)
                    {
                        return null;
                    }

                    return new PropertyDescriptor(value, true, true, false);
                }
            }

            return base.GetOwnProperty(property);
        }

        /// <inheritdoc />
        public override bool HasProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-integer-indexed-exotic-objects-hasproperty-p
            Debug.Assert(Agent.IsPropertyKey(property));
            if (property.IsString)
            {
                var numericIndex = Agent.CanonicalNumericIndexString((string)property);
                if (numericIndex.HasValue)
                {
                    var buffer = ViewedArrayBuffer;
                    if (ArrayBufferIntrinsics.IsDetachedBuffer(buffer))
                    {
                        throw Agent.CreateTypeError();
                    }

                    if (!Agent.IsInteger(numericIndex.Value))
                    {
                        return false;
                    }

                    if (numericIndex.Value.IsNegative())
                    {
                        return false;
                    }

                    if (numericIndex.Value >= ArrayLength)
                    {
                        return false;
                    }

                    return true;
                }
            }

            return base.HasProperty(property);
        }

        /// <inheritdoc />
        internal override bool DefineOwnProperty(ScriptValue property, PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-integer-indexed-exotic-objects-defineownproperty-p-desc
            Debug.Assert(Agent.IsPropertyKey(property));
            if (property.IsString)
            {
                var numericIndex = Agent.CanonicalNumericIndexString((string)property);
                if (numericIndex.HasValue)
                {
                    if (!Agent.IsInteger(numericIndex.Value))
                    {
                        return false;
                    }
                    if (numericIndex.Value == 0 && numericIndex.Value.IsNegative())
                    {
                        return false;
                    }

                    if (numericIndex.Value < 0)
                    {
                        return false;
                    }

                    var length = ArrayLength;
                    if (numericIndex >= length)
                    {
                        return false;
                    }

                    if (descriptor.IsAccessorDescriptor)
                    {
                        return false;
                    }

                    if (descriptor.Configurable.HasValue && descriptor.Configurable)
                    {
                        return false;
                    }

                    if (descriptor.Enumerable.HasValue && !descriptor.Enumerable)
                    {
                        return false;
                    }

                    if (descriptor.Writable.HasValue && !descriptor.Writable)
                    {
                        return false;
                    }

                    if (descriptor.Value.HasValue)
                    {
                        var value = descriptor.Value.Value;
                        return IntegerIndexedElementSet(numericIndex.Value, value);
                    }

                    return true;
                }
            }

            return base.DefineOwnProperty(property, descriptor);
        }

        /// <inheritdoc />
        internal override ScriptValue Get(ScriptValue property, ScriptValue receiver)
        {
            //https://tc39.github.io/ecma262/#sec-integer-indexed-exotic-objects-get-p-receiver
            Debug.Assert(Agent.IsPropertyKey(property));
            if (property.IsString)
            {
                var numericIndex = Agent.CanonicalNumericIndexString((string)property);
                if (numericIndex.HasValue)
                {
                    return IntegerIndexedElementGet(numericIndex.Value);
                }
            }

            return base.Get(property, receiver);
        }

        /// <inheritdoc />
        internal override bool Set(ScriptValue property, ScriptValue value, ScriptValue receiver)
        {
            Debug.Assert(Agent.IsPropertyKey(property));

            if (property.IsString)
            {
                var numericIndex = Agent.CanonicalNumericIndexString((string)property);
                if (numericIndex.HasValue)
                {
                    return IntegerIndexedElementSet(numericIndex.Value, value);
                }
            }

            return base.Set(property, value, receiver);
        }

        /// <inheritdoc />
        internal override IEnumerable<ScriptValue> OwnPropertyKeys()
        {
            throw new NotImplementedException();
        }

        private bool IntegerIndexedElementSet(double index, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-integerindexedelementset
            var numberValue = Agent.ToNumber(value);
            var buffer = ViewedArrayBuffer;
            if (ArrayBufferIntrinsics.IsDetachedBuffer(buffer))
            {
                throw Agent.CreateTypeError();
            }

            if (!Agent.IsInteger(index))
            {
                return false;
            }

            if (index == 0 && index.IsNegative())
            {
                return false;
            }

            var length = ArrayLength;
            if (index < 0 || index >= length)
            {
                return false;
            }

            var indexedPosition = (long)index * Description.Size + ByteOffset;
            ArrayBufferIntrinsics.SetValueInBuffer(Agent, buffer, indexedPosition, Description, numberValue, true, OrderType.Unordered, Agent.LittleEndian);
            return true;
        }

        private ScriptValue IntegerIndexedElementGet(double index)
        {
            //https://tc39.github.io/ecma262/#sec-integerindexedelementget
            var buffer = ViewedArrayBuffer;
            if (ArrayBufferIntrinsics.IsDetachedBuffer(buffer))
            {
                throw Agent.CreateTypeError();
            }

            if (!Agent.IsInteger(index))
            {
                return ScriptValue.Undefined;
            }

            if (index == 0 && index.IsNegative())
            {
                return ScriptValue.Undefined;
            }

            var length = ArrayLength;
            if (index < 0 || index >= length)
            {
                return ScriptValue.Undefined;
            }

            var indexedPosition = (long)index * Description.Size + ByteOffset;
            return ArrayBufferIntrinsics.GetValueFromBuffer(Agent, buffer, indexedPosition, Description, true, OrderType.Unordered, Agent.LittleEndian);
        }

        public long ByteLength { get; set; }

        public long ByteOffset { get; set; }

        public long ArrayLength { get; set; }

        public ScriptObject ViewedArrayBuffer { get; set; }

        public TypeDescription Description { get; }
    }
}
