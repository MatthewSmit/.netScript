using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime;

namespace NetScript.Walkers
{
    internal static class TopLevelLexicallyScopedDeclarationsWalker
    {
        public static void Walk([NotNull] IEnumerable<BaseNode> statementList, [NotNull] List<IDeclaration> list)
        {
            foreach (var statement in statementList)
            {
                if (statement is FunctionDeclarationNode)
                {
                    continue;
                }
                if (statement is ClassDeclarationNode classDeclarationNode)
                {
                    list.Add(new DeclarationNode(classDeclarationNode));
                }
                else if (statement is VariableDeclarationNode variableDeclarationNode && variableDeclarationNode.Kind != VariableKind.Var)
                {
                    list.Add(new DeclarationNode(variableDeclarationNode));
                }
            }
        }
    }
}