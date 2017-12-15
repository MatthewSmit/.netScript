using System;

namespace NetScript.Runtime
{
    internal sealed class ReturnException : Exception
    {
        public ReturnException(ScriptValue value)
        {
            Value = value;
        }

        public ScriptValue Value { get; }
    }
}
