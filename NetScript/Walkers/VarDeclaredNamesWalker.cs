using System;
using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;

namespace NetScript.Walkers
{
    internal static class VarDeclaredNamesWalker
    {
        [NotNull]
        public static IReadOnlyList<string> Walk([NotNull] BaseNode node)
        {
            var list = new List<string>();
            Walk(node, list);
            return list;
        }

        [NotNull]
        public static IReadOnlyList<string> WalkFunctionBody([NotNull] BaseNode node)
        {
            if (node is BlockStatementNode block)
            {
                var list = new List<string>();
                TopLevelVarDeclaredNamesWalker.Walk(block.Body, list);
                return list;
            }

            return Array.Empty<string>();
        }

        public static void Walk([NotNull] ProgramNode node, [NotNull] List<string> list)
        {
            TopLevelVarDeclaredNamesWalker.Walk(node.Body, list);
        }

        public static void Walk([NotNull] BaseNode statement, [NotNull] List<string> list)
        {
            switch (statement)
            {
                case BreakStatementNode _:
                case ClassDeclarationNode _:
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

                    list.AddRange(BoundNamesWalker.Walk(variableDeclaration));

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