using System.Collections.Generic;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal interface IFunction
    {
        ScriptValue Run([NotNull] ExecutionContext executionContext);

        [NotNull]
        IReadOnlyList<string> VariableNames { get; }
        [NotNull]
        IReadOnlyList<IDeclaration> VariableDeclarations { get; }
        [NotNull]
        IReadOnlyList<string> LexicalNames { get; }
        [NotNull]
        IReadOnlyList<IDeclaration> LexicalDeclarations { get; }

        bool IsStrict { get; }
    }
}
