using System;
using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime;

namespace NetScript.Walkers
{
    internal static class EarlyErrorWalker
    {
        public static void Walk([NotNull] Agent agent, [NotNull] ProgramNode program, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-scripts-static-semantics-early-errors
            //TODO
//            var lexicalNames = LexicallyDeclaredNamesWalker.Walk(program);
//            if (lexicalNames.Count > 0)
//            {
//                throw new NotImplementedException();
//            }

            foreach (var baseNode in program.Body)
            {
                Walk(agent, baseNode, isStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] BaseNode baseNode, bool isStrict)
        {
            switch (baseNode)
            {
                case LiteralNode _:
                case MetaPropertyNode _:
                case ReturnStatementNode _:
                case ThrowStatementNode _:
                    break;

                case ArrayExpressionNode arrayExpression:
                    //TODO
                    break;

                case ArrowFunctionExpressionNode arrowFunctionExpression:
                    //TODO
                    break;

                case AssignmentExpressionNode assignmentExpression:
                    //TODO
                    break;

                case BinaryExpressionNode binaryExpression:
                    //TODO
                    break;

                case BlockStatementNode blockStatement:
                    Walk(agent, blockStatement, isStrict);
                    break;

                case BreakStatementNode breakStatement:
                    //TODO
                    break;

                case CallExpressionNode callExpression:
                    //TODO
                    break;

                case ClassDeclarationNode classDeclaration:
                    //TODO
                    break;

                case ConditionalExpressionNode conditionalExpression:
                    //TODO
                    break;

                case DoWhileStatementNode doWhileStatement:
                    //TODO
                    break;

                case EmptyStatementNode _:
                    break;

                case ExpressionStatementNode expressionStatement:
                    Walk(agent, expressionStatement.Expression, isStrict);
                    break;

                case ForStatementNode forStatement:
                    Walk(agent, forStatement, isStrict);
                    break;

                case ForInStatementNode forInStatement:
                    Walk(agent, forInStatement, isStrict);
                    break;

                case ForOfStatementNode forOfStatement:
                    Walk(agent, forOfStatement, isStrict);
                    break;

                case FunctionDeclarationNode functionDeclaration:
                    Walk(agent, functionDeclaration, isStrict);
                    break;

                case IdentifierNode identifier:
                    Walk(agent, identifier, isStrict);
                    break;

                case IfStatementNode ifStatement:
                    Walk(agent, ifStatement.Test, isStrict);
                    Walk(agent, ifStatement.Consequent, isStrict);
                    if (ifStatement.Alternate != null)
                    {
                        Walk(agent, ifStatement.Alternate, isStrict);
                    }
                    break;

                case LabelledStatementNode labelledStatement:
                    if (labelledStatement.Body is FunctionDeclarationNode)
                    {
                        throw agent.CreateSyntaxError("Function declarations cannot be after labelled statements at " + labelledStatement.Location);
                    }

                    Walk(agent, labelledStatement.Body, isStrict);
                    break;

                case LogicalExpressionNode logicalExpression:
                    //TODO
                    break;

                case MemberExpressionNode memberExpression:
                    //TODO
                    break;

                case NewExpressionNode newExpression:
                    //TODO
                    break;

                case ObjectExpressionNode objectExpression:
                    //TODO
                    break;

                case SequenceExpressionNode sequenceExpression:
                    //TODO
                    break;

                case SwitchStatementNode switchStatement:
                    Walk(agent, switchStatement, isStrict);
                    break;

                case ThisExpressionNode thisExpression:
                    //TODO
                    break;

                case TryStatementNode tryStatement:
                    Walk(agent, tryStatement, isStrict);
                    break;

                case UnaryExpressionNode unaryExpression:
                    Walk(agent, unaryExpression, isStrict);
                    break;

                case UpdateExpressionNode updateExpression:
                    Walk(agent, updateExpression, isStrict);
                    break;

                case VariableDeclarationNode variableDeclaration:
                    Walk(agent, variableDeclaration, isStrict);
                    break;

                case WhileStatementNode whileStatement:
                    Walk(agent, whileStatement, isStrict);
                    break;

                case WithStatementNode withStatement:
                    Walk(agent, withStatement, isStrict);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] BlockStatementNode blockStatement, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-block-static-semantics-early-errors

            var lexicalNames = LexicallyDeclaredNamesWalker.Walk(blockStatement);
            if (lexicalNames.Count > 0)
            {
                var set = new HashSet<string>();
                var variableNames = VarDeclaredNamesWalker.Walk(blockStatement);

                foreach (var name in lexicalNames)
                {
                    if (!set.Add(name))
                    {
                        throw agent.CreateSyntaxError("Duplicate lexical declaration at " + blockStatement.Location);
                    }
                }

                foreach (var name in variableNames)
                {
                    if (!set.Add(name))
                    {
                        throw agent.CreateSyntaxError("Variable declaration when a lexical declaration already exists at " + blockStatement.Location);
                    }
                }
            }

            foreach (var node in blockStatement.Body)
            {
                Walk(agent, node, isStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ForStatementNode forStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ForInStatementNode forInStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ForOfStatementNode forOfStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] FunctionDeclarationNode functionDeclaration, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-static-semantics-early-errors
            //TODO

            Walk(agent, functionDeclaration.Body, isStrict || new FunctionNode(functionDeclaration.Body).IsStrict);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] IdentifierNode identifier, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-identifiers-static-semantics-early-errors
            if (isStrict)
            {
                switch (identifier.Name)
                {
                    case "arguments":
                    case "eval":
                    case "yield":
                    case "implements":
                    case "interface":
                    case "let":
                    case "package":
                    case "private":
                    case "protected":
                    case "public":
                    case "static":
                        throw agent.CreateSyntaxError();
                }
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] SwitchStatementNode switchStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] TryStatementNode tryStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] UnaryExpressionNode unaryExpression, bool isStrict)
        {
            switch (unaryExpression.Operator)
            {
                case Operator.Delete:
                    if (isStrict && unaryExpression.Argument is IdentifierNode)
                    {
                        throw agent.CreateSyntaxError();
                    }
                    break;

                case Operator.Void:
                    //TODO
                    break;

                case Operator.TypeOf:
                    //TODO
                    break;

                case Operator.Addition:
                    //TODO
                    break;

                case Operator.Subtraction:
                    //TODO
                    break;

                case Operator.BitwiseNot:
                    //TODO
                    break;

                case Operator.LogicalNot:
                    //TODO
                    break;

                default:
                    throw new IndexOutOfRangeException();
            }

            Walk(agent, unaryExpression.Argument, isStrict);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] UpdateExpressionNode updateExpression, bool isStrict)
        {
            switch (updateExpression.Operator)
            {
                case Operator.Increment:
                    //TODO
                    break;

                case Operator.IncrementPostfix:
                    //TODO
                    break;

                case Operator.Decrement:
                    //TODO
                    break;

                case Operator.DecrementPostfix:
                    //TODO
                    break;

                default:
                    throw new IndexOutOfRangeException();
            }

            Walk(agent, updateExpression.Argument, isStrict);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] VariableDeclarationNode variableDeclaration, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] WhileStatementNode whileStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] WithStatementNode withStatement, bool isStrict)
        {
            //TODO
        }
    }
}