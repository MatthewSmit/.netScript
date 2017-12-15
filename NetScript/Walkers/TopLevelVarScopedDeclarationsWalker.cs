using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime;

namespace NetScript.Walkers
{
    internal static class TopLevelVarScopedDeclarationsWalker
    {
        public static void Walk([NotNull] IEnumerable<BaseNode> statementList, List<IDeclaration> list)
        {
            foreach (var statement in statementList)
            {
                if (statement is FunctionDeclarationNode functionDeclaration)
                {
                    list.Add(new DeclarationNode(functionDeclaration));
                }
                else if (statement is ClassDeclarationNode || statement is VariableDeclarationNode variableDeclaration && variableDeclaration.Kind != VariableKind.Var)
                {
                }
                else if (statement is LabelledStatementNode labelledStatement)
                {
                    Walk(labelledStatement, list);
                }
                else
                {
                    VarScopedDeclarationsWalker.Walk(statement, list);
                }
            }
        }

        private static void Walk([NotNull] LabelledStatementNode labelledStatement, List<IDeclaration> list)
        {
            switch (labelledStatement.Body)
            {
                case FunctionDeclarationNode functionDeclaration:
                    list.Add(new DeclarationNode(functionDeclaration));
                    break;
                case LabelledStatementNode childLabelledStatement:
                    Walk(childLabelledStatement, list);
                    break;
                default:
                    VarScopedDeclarationsWalker.Walk(labelledStatement.Body, list);
                    break;
            }
        }
    }
}