using System.Collections.Generic;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Walkers;

namespace NetScript.Runtime
{
    internal sealed class FunctionNode : IFunction
    {
        [NotNull] private readonly BaseNode code;

        public FunctionNode([NotNull] BaseNode code)
        {
            this.code = code;
        }

        public ScriptValue Run(ExecutionContext executionContext)
        {
            if (code is BlockStatementNode block)
            {
                try
                {
                    EvaluateWalker.Walk(block.Body, executionContext);
                    return ScriptValue.Undefined;
                }
                catch (ReturnException e)
                {
                    return e.Value;
                }
            }

            var expressionReference = EvaluateWalker.Walk(code, executionContext);
            return executionContext.Realm.Agent.GetValue(expressionReference);
        }

        public IReadOnlyList<string> VariableNames => VarDeclaredNamesWalker.WalkFunctionBody(code);

        public IReadOnlyList<IDeclaration> VariableDeclarations => VarScopedDeclarationsWalker.WalkFunctionBody(code);

        public IReadOnlyList<string> LexicalNames => LexicallyDeclaredNamesWalker.WalkFunctionBody(code);

        public IReadOnlyList<IDeclaration> LexicalDeclarations => LexicallyScopedDeclarationsWalker.WalkFunctionBody(code);

        public bool IsStrict
        {
            get
            {
                if (code is BlockStatementNode block)
                {
                    return block.Body.Count > 0 &&
                           block.Body[0] is ExpressionStatementNode expression &&
                           expression.Expression is LiteralNode literal &&
                           literal.Value.IsString &&
                           literal.Value.AsString == "use strict";
                }

                return false;
            }
        }
    }
}
