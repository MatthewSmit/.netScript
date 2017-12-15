using System;
using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime;

namespace NetScript.Walkers
{
    internal static class LexicallyScopedDeclarationsWalker
    {
        public static void Walk([NotNull] ProgramNode node, [NotNull] List<IDeclaration> list)
        {
            TopLevelLexicallyScopedDeclarationsWalker.Walk(node.Body, list);
        }

        [NotNull]
        public static IReadOnlyList<IDeclaration> Walk([NotNull] IReadOnlyList<BaseNode> nodes)
        {
            var list = new List<IDeclaration>();
            Walk(nodes, list);
            return list;
        }

        public static void Walk([NotNull] IReadOnlyList<BaseNode> nodes, IList<IDeclaration> list)
        {
            foreach (var baseNode in nodes)
            {
                switch (baseNode)
                {
                    case ClassDeclarationNode classDeclaration:
                        list.Add(new DeclarationNode(classDeclaration));
                        break;
                    case FunctionDeclarationNode functionDeclaration:
                        list.Add(new DeclarationNode(functionDeclaration));
                        break;
                    case LabelledStatementNode labelledStatement:
                    {
                        if (labelledStatement.Body is FunctionDeclarationNode functionDeclaration)
                        {
                            list.Add(new DeclarationNode(functionDeclaration));
                        }
                        break;
                    }
                    case SwitchCaseNode switchCase:
                        Walk(switchCase.Consequent, list);
                        break;
                    case VariableDeclarationNode variableDeclaration:
                        if (variableDeclaration.Kind != VariableKind.Var)
                        {
                            list.Add(new DeclarationNode(variableDeclaration));
                        }
                        break;
                }
            }
        }

        [NotNull]
        public static List<IDeclaration> WalkFunctionBody([NotNull] BaseNode node)
        {
            var list = new List<IDeclaration>();
            WalkFunctionBody(node, list);
            return list;
        }

        public static void WalkFunctionBody([NotNull] BaseNode node, [NotNull] List<IDeclaration> list)
        {
            if (node is BlockStatementNode block)
            {
                TopLevelLexicallyScopedDeclarationsWalker.Walk(block.Body, list);
            }
        }
    }
}