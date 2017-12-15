using System.Collections.Generic;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal interface IDeclaration
    {
        ScriptFunctionObject InstantiateFunctionObject([NotNull] Agent agent, [NotNull] LexicalEnvironment environment);

        [NotNull]
        [ItemNotNull]
        IEnumerable<string> BoundNames { get; }
        bool IsFunction { get; }
        bool IsVariable { get; }
        bool IsConstant { get; }
    }
}