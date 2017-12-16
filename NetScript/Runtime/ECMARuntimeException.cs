using System;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal abstract class ECMARuntimeException : Exception
    {
        protected ECMARuntimeException()
        {
        }

        protected ECMARuntimeException(string target)
        {
            Target = target;
        }

        [CanBeNull]
        public string Target { get; }

        public ScriptValue? Value { get; set; }
    }
}