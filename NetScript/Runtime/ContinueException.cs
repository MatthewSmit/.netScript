using System;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal sealed class ContinueException : Exception
    {
        public ContinueException()
        {
        }

        public ContinueException(string target)
        {
            Target = target;
        }

        [CanBeNull]
        public string Target { get; }
    }
}