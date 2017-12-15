using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal sealed class PropertyDescriptor
    {
        public PropertyDescriptor()
        {
        }

        public PropertyDescriptor([CanBeNull] ScriptObject get, [CanBeNull] ScriptObject set, bool enumerable, bool configurable)
        {
            Get = get;
            Set = set;
            Enumerable = enumerable;
            Configurable = configurable;
        }

        public PropertyDescriptor([CanBeNull] ScriptObject get, [CanBeNull] ScriptObject set, Trinary enumerable, Trinary configurable)
        {
            Get = get;
            Set = set;
            Enumerable = enumerable;
            Configurable = configurable;
        }

        public PropertyDescriptor(ScriptValue value, bool writable, bool enumerable, bool configurable)
        {
            Value = value;
            Writable = writable;
            Enumerable = enumerable;
            Configurable = configurable;
        }

        public PropertyDescriptor(ScriptValue value, Trinary writable, Trinary enumerable, Trinary configurable)
        {
            Value = value;
            Writable = writable;
            Enumerable = enumerable;
            Configurable = configurable;
        }

        public PropertyDescriptor(ScriptValue value)
        {
            Value = value;
        }

        [NotNull]
        public PropertyDescriptor Copy()
        {
            return new PropertyDescriptor
            {
                Value = Value,
                Get = Get,
                Set = Set,
                Writable = Writable,
                Enumerable = Enumerable,
                Configurable = Configurable
            };
        }

        public bool IsAccessorDescriptor => Get != null || Set != null;

        public bool IsDataDescriptor => Value.HasValue || Writable.HasValue;

        public bool IsGenericDescriptor => !IsAccessorDescriptor && !IsDataDescriptor;

        public ScriptValue? Value { get; set; }
        [CanBeNull]        public ScriptObject Get { get; set; }
        [CanBeNull]        public ScriptObject Set { get; set; }
        public Trinary Writable { get; set; }
        public Trinary Enumerable { get; set; }
        public Trinary Configurable { get; set; }
    }
}