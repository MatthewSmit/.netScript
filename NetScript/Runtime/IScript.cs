using System.Collections.Generic;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal interface IScript
    {
        ScriptValue Evaluate([NotNull] ExecutionContext context);

        void HandleEarlyErrors([NotNull] Agent agent, bool strictEval);
        void HandleEvalEarlyErrors([NotNull] Agent agent, bool inFunction, bool inMethod, bool inDerivedConstructor);

        bool Strict { get; }

        [NotNull] [ItemNotNull] IList<string> LexicallyDeclaredNames { get; }
        [NotNull] [ItemNotNull] IList<IDeclaration> LexicallyScopedDeclarations { get; }
        [NotNull] [ItemNotNull] IList<string> VarDeclaredNames { get; }
        [NotNull] [ItemNotNull] IList<IDeclaration> VarScopedDeclarations { get; }
    }
}