using System;
using System.Collections.Generic;
using System.Linq;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Walkers;

namespace NetScript.Runtime
{
    internal sealed class NodeScript : IScript
    {
        [NotNull] private readonly ProgramNode node;

        public NodeScript([NotNull] ProgramNode node)
        {
            this.node = node;
        }

        public ScriptValue Evaluate(ExecutionContext context)
        {
            return EvaluateWalker.Walk(node.Body, context).Value;
        }

        public void HandleEarlyErrors(Agent agent, bool strictEval)
        {
            EarlyErrorWalker.Walk(agent, node, strictEval || Strict);
        }

        public void HandleEvalEarlyErrors(Agent agent, bool inFunction, bool inMethod, bool inDerivedConstructor)
        {
            FindReturns(agent, node.Body);

            if (inFunction && inMethod && inDerivedConstructor)
            {
                return;
            }

            foreach (var baseNode in node.Body.OfType<ExpressionStatementNode>())
            {
                HandleEvalEarlyErrors(agent, baseNode.Expression, inFunction, inMethod, inDerivedConstructor);
            }
        }

        private static void HandleEvalEarlyErrors([NotNull] Agent agent, [NotNull] ExpressionNode expression, bool inFunction, bool inMethod, bool inDerivedConstructor)
        {
            switch (expression)
            {
                case ArrowFunctionExpressionNode _:
                case FunctionExpressionNode _:
                case IdentifierNode _:
                case LiteralNode _:
                case ThisExpressionNode _:
                    break;

                case ArrayExpressionNode arrayExpression:
                    foreach (var element in arrayExpression.Elements)
                    {
                        HandleEvalEarlyErrors(agent, element, inFunction, inMethod, inDerivedConstructor);
                    }
                    break;

                case AssignmentExpressionNode assignmentExpression:
                    HandleEvalEarlyErrors(agent, assignmentExpression.Left, inFunction, inMethod, inDerivedConstructor);
                    HandleEvalEarlyErrors(agent, assignmentExpression.Right, inFunction, inMethod, inDerivedConstructor);
                    break;

                case BinaryExpressionNode binaryExpression:
                    HandleEvalEarlyErrors(agent, binaryExpression.Left, inFunction, inMethod, inDerivedConstructor);
                    HandleEvalEarlyErrors(agent, binaryExpression.Right, inFunction, inMethod, inDerivedConstructor);
                    break;

                case CallExpressionNode callExpression:
                    if (callExpression.Callee is SuperNode)
                    {
                        if (!inDerivedConstructor)
                        {
                            throw agent.CreateSyntaxError();
                        }
                    }
                    else
                    {
                        HandleEvalEarlyErrors(agent, callExpression.Callee, inFunction, inMethod, inDerivedConstructor);
                    }

                    foreach (var argument in callExpression.Arguments)
                    {
                        HandleEvalEarlyErrors(agent, argument, inFunction, inMethod, inDerivedConstructor);
                    }
                    break;

                case ConditionalExpressionNode conditionalExpression:
                    HandleEvalEarlyErrors(agent, conditionalExpression.Test, inFunction, inMethod, inDerivedConstructor);
                    HandleEvalEarlyErrors(agent, conditionalExpression.Consequent, inFunction, inMethod, inDerivedConstructor);
                    HandleEvalEarlyErrors(agent, conditionalExpression.Alternate, inFunction, inMethod, inDerivedConstructor);
                    break;

                case LogicalExpressionNode logicalExpression:
                    HandleEvalEarlyErrors(agent, logicalExpression.Left, inFunction, inMethod, inDerivedConstructor);
                    HandleEvalEarlyErrors(agent, logicalExpression.Right, inFunction, inMethod, inDerivedConstructor);
                    break;

                case MemberExpressionNode memberExpression:
                    if (memberExpression.Object is SuperNode)
                    {
                        if (!inMethod)
                        {
                            throw agent.CreateSyntaxError();
                        }
                    }
                    else
                    {
                        HandleEvalEarlyErrors(agent, memberExpression.Object, inFunction, inMethod, inDerivedConstructor);
                    }
                    HandleEvalEarlyErrors(agent, memberExpression.Property, inFunction, inMethod, inDerivedConstructor);
                    break;

                case MetaPropertyNode metaProperty:
                    if (metaProperty.Meta.Name == "new" && metaProperty.Property.Name == "target")
                    {
                        if (!inFunction)
                        {
                            throw agent.CreateSyntaxError();
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    break;

                case NewExpressionNode newExpression:
                    HandleEvalEarlyErrors(agent, newExpression.Callee, inFunction, inMethod, inDerivedConstructor);
                    foreach (var argument in newExpression.Arguments)
                    {
                        HandleEvalEarlyErrors(agent, argument, inFunction, inMethod, inDerivedConstructor);
                    }

                    break;

                case ObjectExpressionNode objectExpression:
                    foreach (var property in objectExpression.Properties)
                    {
                        if (property.Value != null)
                        {
                            HandleEvalEarlyErrors(agent, property.Value, inFunction, inMethod, inDerivedConstructor);
                        }
                    }

                    break;

                case SequenceExpressionNode sequenceExpression:
                    foreach (var childExpression in sequenceExpression.Expressions)
                    {
                        HandleEvalEarlyErrors(agent, childExpression, inFunction, inMethod, inDerivedConstructor);
                    }
                    break;

                case UnaryExpressionNode unaryExpression:
                    HandleEvalEarlyErrors(agent, unaryExpression.Argument, inFunction, inMethod, inDerivedConstructor);
                    break;

                case UpdateExpressionNode updateExpression:
                    HandleEvalEarlyErrors(agent, updateExpression.Argument, inFunction, inMethod, inDerivedConstructor);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private static void FindReturns([NotNull] Agent agent, [NotNull] IEnumerable<BaseNode> nodes)
        {
            foreach (var baseNode in nodes)
            {
                FindReturns(agent, baseNode);
            }
        }

        private static void FindReturns([NotNull] Agent agent, [NotNull] BaseNode baseNode)
        {
            switch (baseNode)
            {
                case ReturnStatementNode _:
                    throw agent.CreateSyntaxError();

                case BlockStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case IfStatementNode node:
                    FindReturns(agent, node.Consequent);
                    if (node.Alternate != null)
                    {
                        FindReturns(agent, node.Alternate);
                    }
                    break;

                case ForStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case ForInStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case ForOfStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case WhileStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case DoWhileStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case WithStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case LabelledStatementNode node:
                    FindReturns(agent, node.Body);
                    break;

                case TryStatementNode node:
                    FindReturns(agent, node.Block.Body);
                    if (node.Handler != null)
                    {
                        FindReturns(agent, node.Handler.Body);
                    }
                    if (node.Finaliser != null)
                    {
                        FindReturns(agent, node.Finaliser.Body);
                    }
                    break;
            }
        }

        public bool Strict => node.Body.Count > 0 &&
                              node.Body[0] is ExpressionStatementNode expression &&
                              expression.Expression is LiteralNode literal &&
                              literal.Value.IsString &&
                              literal.Value.AsString == "use strict";

        public IList<string> LexicallyDeclaredNames
        {
            get
            {
                var list = new List<string>();
                LexicallyDeclaredNamesWalker.Walk(node, list);
                return list;
            }
        }

        public IList<IDeclaration> LexicallyScopedDeclarations
        {
            get
            {
                var list = new List<IDeclaration>();
                LexicallyScopedDeclarationsWalker.Walk(node, list);
                return list;
            }
        }

        public IList<string> VarDeclaredNames
        {
            get
            {
                var list = new List<string>();
                VarDeclaredNamesWalker.Walk(node, list);
                return list;
            }
        }

        public IList<IDeclaration> VarScopedDeclarations
        {
            get
            {
                var list = new List<IDeclaration>();
                VarScopedDeclarationsWalker.Walk(node, list);
                return list;
            }
        }

        [NotNull]
        public ProgramNode Node => node;
    }
}