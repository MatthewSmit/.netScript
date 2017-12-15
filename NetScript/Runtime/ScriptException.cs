using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed class ScriptException : Exception
    {
        public ScriptException()
        {
        }

        public ScriptException(ScriptValue value) :
            base(GetValueMessage(value))
        {
            Value = value;
        }

        internal ScriptException(ScriptValue value, [NotNull] Exception internalException) :
            base(GetValueMessage(value), internalException)
        {
            Value = value;
        }

        [CanBeNull]
        private static string GetValueMessage(ScriptValue value)
        {
            if (value.IsObject)
            {
                var obj = (ScriptObject)value;
                value = obj.Get("message", obj);
            }

            if (value == ScriptValue.Undefined || value == ScriptValue.Null)
            {
                return null;
            }

            return value.ToString();
        }

        public ScriptValue Value { get; }
    }
}