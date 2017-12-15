using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;

namespace NetScript.Walkers
{
    internal static class TopLevelVarDeclaredNamesWalker
    {
        public static void Walk([NotNull] IEnumerable<BaseNode> statementList, [NotNull] List<string> list)
        {
            foreach (var statement in statementList)
            {
                if (statement is FunctionDeclarationNode functionDeclaration)
                {
                    foreach (var boundName in BoundNamesWalker.Walk(functionDeclaration))
                    {
                        list.Add(boundName);
                    }
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
                    VarDeclaredNamesWalker.Walk(statement, list);
                }
            }
        }

        private static void Walk([NotNull] LabelledStatementNode labelledStatement, [NotNull] List<string> list)
        {
            switch (labelledStatement.Body)
            {
                case FunctionDeclarationNode functionDeclaration:
                    BoundNamesWalker.Walk(functionDeclaration, list);
                    break;
                case LabelledStatementNode childLabelledStatement:
                    Walk(childLabelledStatement, list);
                    break;
                default:
                    VarDeclaredNamesWalker.Walk(labelledStatement.Body, list);
                    break;
            }
        }
    }
}