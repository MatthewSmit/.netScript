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
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override bool HasProperty(ScriptValue property)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        internal override bool DefineOwnProperty(ScriptValue property, PropertyDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        internal override ScriptValue Get(ScriptValue property, ScriptValue reciever)
        {
            throw new NotImplementedException();
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

            var offset = ByteOffset;
            var elementSize = Description.Size;
            var indexedPosition = (ulong)index * elementSize + offset;
            ArrayBufferIntrinsics.SetValueInBuffer(Agent, buffer, indexedPosition, Description, numberValue, true, OrderType.Unordered, Agent.LittleEndian);
            return true;
        }

        public ulong ByteLength { get; set; }

        public ulong ByteOffset { get; set; }

        public ulong ArrayLength { get; set; }

        public ScriptObject ViewedArrayBuffer { get; set; }

        public TypeDescription Description { get; }
    }
}
