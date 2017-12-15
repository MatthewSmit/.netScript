using System.Collections.Generic;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed class ScriptArguments
    {
        private readonly IReadOnlyList<ScriptValue> arguments;

        internal ScriptArguments([NotNull] ScriptFunctionObject function, ScriptValue thisValue, ScriptObject newTarget, IReadOnlyList<ScriptValue> arguments)
        {
            Function = function;
            Agent = function.Agent;
            ThisValue = thisValue;
            NewTarget = newTarget;
            this.arguments = arguments;
        }

        public ScriptValue this[int index] => index >= 0 && index < arguments.Count ? arguments[index] : ScriptValue.Undefined;

        public int Count => arguments.Count;

        [NotNull]
        public ScriptFunctionObject Function { get; }

        [NotNull]
        public Agent Agent { get; }

        public ScriptValue ThisValue { get; }
        public ScriptObject NewTarget { get; }
    }
}
