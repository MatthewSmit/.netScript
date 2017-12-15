using System;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal struct ValueReference
    {
        private readonly ScriptValue value;
        private readonly Reference reference;

        private ValueReference(ScriptValue value)
        {
            this.value = value;
            reference = default;
            IsReference = false;
            IsValue = true;
        }

        private ValueReference(Reference reference)
        {
            value = default;
            this.reference = reference;
            IsReference = true;
            IsValue = false;
        }

        public ScriptValue Value
        {
            get
            {
                if (!IsValue)
                    throw new NullReferenceException();
                return value;
            }
        }

        public Reference Reference
        {
            get
            {
                if (!IsReference)
                    throw new NullReferenceException();
                return reference;
            }
        }

        public bool IsReference { get; }
        public bool IsValue { get; }

        public static implicit operator ValueReference(ScriptObject value)
        {
            return new ValueReference(value);
        }

        public static implicit operator ValueReference(ScriptValue value)
        {
            return new ValueReference(value);
        }

        public static implicit operator ValueReference(Reference reference)
        {
            return new ValueReference(reference);
        }
    }
}
