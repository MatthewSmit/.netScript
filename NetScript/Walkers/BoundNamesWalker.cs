using System;
using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;

namespace NetScript.Walkers
{
    internal static class BoundNamesWalker
    {
        [NotNull]
        public static IReadOnlyList<string> Walk([NotNull] BaseNode node)
        {
            var list = new List<string>();
            Walk(node, list);
            return list;
        }

        [NotNull]
        public static IReadOnlyList<string> Walk([NotNull] IEnumerable<ExpressionNode> functionDeclaration)
        {
            var list = new List<string>();
            foreach (var expression in functionDeclaration)
            {
                Walk(expression, list);
            }
            return list;
        }

        public static void Walk([NotNull] BaseNode node, [NotNull] IList<string> list)
        {
            switch (node)
            {
                case ArrayPatternNode arrayPattern:
                    Walk(arrayPattern, list);
                    break;
                case AssignmentPatternNode assignmentPattern:
                    Walk(assignmentPattern, list);
                    break;
                case ClassDeclarationNode classDeclaration:
                    Walk(classDeclaration, list);
                    break;
                case FunctionDeclarationNode functionDeclaration:
                    Walk(functionDeclaration, list);
                    break;
                case IdentifierNode identifier:
                    Walk(identifier, list);
                    break;
                case ObjectPatternNode objectPattern:
                    Walk(objectPattern, list);
                    break;
                case RestElementNode restElement:
                    Walk(restElement.Argument, list);
                    break;
                case VariableDeclarationNode variableDeclaration:
                    Walk(variableDeclaration, list);
                    break;
                case VariableDeclaratorNode variableDeclarator:
                    Walk(variableDeclarator, list);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static void Walk([NotNull] ArrayPatternNode arrayPattern, [NotNull] IList<string> list)
        {
            foreach (var element in arrayPattern.Elements)
            {
                Walk(element, list);
            }
        }

        public static void Walk([NotNull] AssignmentPatternNode assignmentPattern, [NotNull] IList<string> list)
        {
            if (assignmentPattern.Left is IdentifierNode identifierNode)
            {
                list.Add(identifierNode.Name);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static void Walk([NotNull] ClassDeclarationNode classDeclaration, [NotNull] IList<string> list)
        {
            if (classDeclaration.Id != null)
                list.Add(classDeclaration.Id.Name);
        }

        public static void Walk([NotNull] FunctionDeclarationNode functionDeclaration, [NotNull] IList<string> list)
        {
            if (functionDeclaration.Id != null)
                list.Add(functionDeclaration.Id.Name);
        }

        public static void Walk([NotNull] IdentifierNode identifier, [NotNull] IList<string> list)
        {
            list.Add(identifier.Name);
        }

        public static void Walk([NotNull] ObjectPatternNode objectPattern, [NotNull] IList<string> list)
        {
            foreach (var element in objectPattern.Properties)
            {
                if (!element.Shorthand && element.Kind == PropertyKind.Initialise)
                {
                    Walk(((AssignmentPatternNode)element.Value).Left, list);
                }
                else
                {
                    Walk(element.Key, list);
                }
            }
        }

        public static void Walk([NotNull] VariableDeclarationNode variableDeclaration, [NotNull] IList<string> list)
        {
            foreach (var variableDeclaratorNode in variableDeclaration.Declarations)
            {
                if (variableDeclaratorNode.Id is IdentifierNode identifierNode)
                {
                    list.Add(identifierNode.Name);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

            if (variableDeclarator.Id is IdentifierNode identifierNode)
            {
                list.Add(identifierNode.Name);
            }
            else
            {
                throw new NotImplementedException();
            }
    }
}