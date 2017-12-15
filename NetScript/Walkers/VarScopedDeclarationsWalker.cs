using System;
using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime;

namespace NetScript.Walkers
{
    internal static class VarScopedDeclarationsWalker
    {
        [NotNull]
        public static IReadOnlyList<IDeclaration> Walk([NotNull] ProgramNode node)
        {
            var list = new List<IDeclaration>();
            Walk(node, list);
            return list;
        }

        [NotNull]
        public static IReadOnlyList<IDeclaration> WalkFunctionBody([NotNull] BaseNode node)
        {
            if (node is BlockStatementNode block)
            {
                var list = new List<IDeclaration>();
                TopLevelVarScopedDeclarationsWalker.Walk(block.Body, list);
                return list;
            }

            return Array.Empty<IDeclaration>();
        }

        public static void Walk([NotNull] ProgramNode node, [NotNull] List<IDeclaration> list)
        {
            TopLevelVarScopedDeclarationsWalker.Walk(node.Body, list);
        }

        public static void Walk([NotNull] BaseNode statement, [NotNull] List<IDeclaration> list)
        {
            switch (statement)
            {
                case BreakStatementNode _:
                case ContinueStatementNode _:
                case DebuggerStatementNode _:
                case EmptyStatementNode _:
                case ExpressionStatementNode _:
                case FunctionDeclarationNode _:
                case ReturnStatementNode _:
                case ThrowStatementNode _:
                    return;

                case BlockStatementNode blockStatement:
                    foreach (var node in blockStatement.Body)
                    {
                        Walk(node, list);
                    }
                    break;

                case DoWhileStatementNode doWhileStatement:
                    Walk(doWhileStatement.Body, list);
                    break;

                case ForStatementNode forStatement:
                {
                    if (forStatement.Init is VariableDeclarationNode forBinding)
                    {
                        Walk(forBinding, list);
                    }

                    Walk(forStatement.Body, list);
                    break;
                }

                case ForInStatementNode forInStatement:
                {
                    if (forInStatement.Left is VariableDeclarationNode forBinding)
                    {
                        Walk(forBinding, list);
                    }

                    Walk(forInStatement.Body, list);
                    break;
                }

                case ForOfStatementNode forOfStatement:
                {
                    if (forOfStatement.Left is VariableDeclarationNode forBinding)
                    {
                        Walk(forBinding, list);
                    }

                    Walk(forOfStatement.Body, list);
                    break;
                }

                case IfStatementNode ifStatement:
                    Walk(ifStatement.Consequent, list);
                    if (ifStatement.Alternate != null)
                    {
                        Walk(ifStatement.Alternate, list);
                    }
                    break;

                case LabelledStatementNode labelledStatement:
                    if (!(labelledStatement.Body is FunctionDeclarationNode))
                    {
                        Walk(labelledStatement.Body, list);
                    }
                    break;

                case SwitchStatementNode switchStatement:
                    foreach (var switchCase in switchStatement.Cases)
                    {
                        foreach (var node in switchCase.Consequent)
                        {
                            Walk(node, list);
                        }
                    }

                    break;

                case TryStatementNode tryStatement:
                    Walk(tryStatement.Block, list);
                    if (tryStatement.Handler != null)
                    {
                        Walk(tryStatement.Handler.Body, list);
                    }
                    if (tryStatement.Finaliser != null)
                    {
                        Walk(tryStatement.Finaliser, list);
                    }
                    break;

                case VariableDeclarationNode variableDeclaration:
                    if (variableDeclaration.Kind != VariableKind.Var)
                        return;

                    foreach (var declaration in variableDeclaration.Declarations)
                    {
                        list.Add(new DeclarationNode(declaration));
                    }

                    break;

                case WhileStatementNode whileStatement:
                    Walk(whileStatement.Body, list);
                    break;

                case WithStatementNode withStatement:
                    Walk(withStatement.Body, list);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}