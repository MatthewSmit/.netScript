﻿using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal sealed class PropertyDescriptor
    {
        public PropertyDescriptor()
        {
        }

        public PropertyDescriptor(ScriptValue? get, ScriptValue? set, bool enumerable, bool configurable)
        {
            Get = get;
            Set = set;
            Enumerable = enumerable;
            Configurable = configurable;
        }

        public PropertyDescriptor(ScriptValue? get, ScriptValue? set, Trinary enumerable, Trinary configurable)
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

        public void CompletePropertyDescriptor()
        {
            //https://tc39.github.io/ecma262/#sec-completepropertydescriptor
            if (IsGenericDescriptor || IsDataDescriptor)
            {
                if (!Value.HasValue)
                {
                    Value = ScriptValue.Undefined;
                }

                if (!Writable.HasValue)
                {
                    Writable = false;
                }
            }

            if (!Enumerable.HasValue)
            {
                Enumerable = false;
            }

            if (!Configurable.HasValue)
            {
                Configurable = false;
            }
        }

        public bool IsAccessorDescriptor => Get != null || Set != null;

        public bool IsDataDescriptor => Value.HasValue || Writable.HasValue;

        public bool IsGenericDescriptor => !IsAccessorDescriptor && !IsDataDescriptor;

        public ScriptValue? Value { get; set; }
        [CanBeNull]        public ScriptValue? Get { get; set; }
        [CanBeNull]        public ScriptValue? Set { get; set; }
        public Trinary Writable { get; set; }
        public Trinary Enumerable { get; set; }
        public Trinary Configurable { get; set; }
    }
}