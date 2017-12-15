using System;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal sealed class BreakException : Exception
    {
        public BreakException()
        {
        }

        public BreakException(string target)
        {
            Target = target;
        }

        [CanBeNull]
        public string Target { get; }
    }
}