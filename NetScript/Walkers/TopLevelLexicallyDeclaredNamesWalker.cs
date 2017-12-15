using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;

namespace NetScript.Walkers
{
    internal static class TopLevelLexicallyDeclaredNamesWalker
    {
        public static void Walk([NotNull] IEnumerable<BaseNode> statementList, [NotNull] IList<string> list)
        {
            foreach (var statement in statementList)
            {
                if (statement is FunctionDeclarationNode)
                {
                    continue;
                }
                if (statement is ClassDeclarationNode classDeclarationNode)
                {
                    BoundNamesWalker.Walk(classDeclarationNode, list);
                }
                else if (statement is VariableDeclarationNode variableDeclarationNode && variableDeclarationNode.Kind != VariableKind.Var)
                {
                    BoundNamesWalker.Walk(variableDeclarationNode, list);
                }
            }
        }
    }
}