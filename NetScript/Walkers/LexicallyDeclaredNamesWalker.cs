using System;
using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;

namespace NetScript.Walkers
{
    internal static class LexicallyDeclaredNamesWalker
    {
        [NotNull]
        public static IReadOnlyList<string> Walk([NotNull] BaseNode node)
        {
            var list = new List<string>();
            Walk(node, list);
            return list;
        }

        public static void Walk([NotNull] ProgramNode program, [NotNull] IList<string> list)
        {
            TopLevelLexicallyDeclaredNamesWalker.Walk(program.Body, list);
        }

        public static void Walk([NotNull] BaseNode node, [NotNull] IList<string> list)
        {
            switch (node)
            {
                case BlockStatementNode blockStatement:
                    Walk(blockStatement, list);
                    break;

                case ProgramNode program:
                    Walk(program, list);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private static void Walk([NotNull] BlockStatementNode blockStatement, [NotNull] IList<string> list)
        {
            foreach (var baseNode in blockStatement.Body)
            {
                if (baseNode is LabelledStatementNode labelledStatement)
                {
                    if (labelledStatement.Body is FunctionDeclarationNode functionDeclaration)
                    {
                        BoundNamesWalker.Walk(functionDeclaration, list);
                    }
                }
                else if (baseNode is FunctionDeclarationNode functionDeclaration)
                {
                    BoundNamesWalker.Walk(functionDeclaration, list);
                }
                else if (baseNode is ClassDeclarationNode classDeclaration)
                {
                    BoundNamesWalker.Walk(classDeclaration, list);
                }
                else if (baseNode is VariableDeclarationNode variableDeclaration && variableDeclaration.Kind != VariableKind.Var)
                {
                    BoundNamesWalker.Walk(variableDeclaration, list);
                }
            }
        }

        public static void WalkFunctionBody([NotNull] BaseNode node, [NotNull] IList<string> list)
        {
            if (node is BlockStatementNode block)
            {
                TopLevelLexicallyDeclaredNamesWalker.Walk(block.Body, list);
            }
        }

        [NotNull]
        public static List<string> WalkFunctionBody([NotNull] BaseNode node)
        {
            var list = new List<string>();
            WalkFunctionBody(node, list);
            return list;
        }
    }
}