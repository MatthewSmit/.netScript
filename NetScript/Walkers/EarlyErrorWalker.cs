using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            var lexicalNames = LexicallyDeclaredNamesWalker.Walk(program);
            if (ContainsDuplicate(lexicalNames))
            {
                throw agent.CreateSyntaxError();
            }

            foreach (var baseNode in program.Body)
            {
                Walk(agent, baseNode, isStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] BaseNode baseNode, bool isStrict)
        {
            switch (baseNode)
            {
                case DebuggerStatementNode _:
                case EmptyStatementNode _:
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
                    Walk(agent, assignmentExpression, isStrict);
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
                    Walk(agent, callExpression, isStrict);
                    break;

                case ClassDeclarationNode classDeclaration:
                    Walk(agent, classDeclaration, isStrict);
                    break;

                case ClassExpressionNode classExpression:
                    Walk(agent, classExpression, isStrict);
                    break;

                case ConditionalExpressionNode conditionalExpression:
                    //TODO
                    break;

                case ContinueStatementNode continueStatement:
                    //TODO
                    break;

                case DoWhileStatementNode doWhileStatement:
                    Walk(agent, doWhileStatement, isStrict);
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

                case FunctionExpressionNode functionExpression:
                    Walk(agent, functionExpression, isStrict);
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

                case LiteralNode literal:
                    Walk(agent, literal, isStrict);
                    break;

                case LogicalExpressionNode logicalExpression:
                    //TODO
                    break;

                case MemberExpressionNode memberExpression:
                    //TODO
                    break;

                case MethodDefinitionNode methodDefinition:
                    Walk(agent, methodDefinition, isStrict);
                    break;

                case NewExpressionNode newExpression:
                    //TODO
                    break;

                case ObjectExpressionNode objectExpression:
                    Walk(agent, objectExpression, isStrict);
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

                case YieldExpressionNode yieldExpression:
                    //TODO
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] AssignmentExpressionNode assignmentExpression, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-assignment-operators-static-semantics-early-errors
            if (assignmentExpression.Operator == Operator.Assignment)
            {
                if (assignmentExpression.Left is ArrayPatternNode)
                {
                }
                else if (assignmentExpression.Left is ObjectPatternNode)
                {
                }
                else
                {
                    if (!IsValidSimpleAssignmentTarget(agent, assignmentExpression.Left, isStrict))
                    {
                        throw agent.CreateSyntaxError();
                    }
                }
            }
            else
            {
                if (!IsValidSimpleAssignmentTarget(agent, assignmentExpression.Left, isStrict))
                {
                    throw agent.CreateSyntaxError();
                }
            }

            Walk(agent, assignmentExpression.Left, isStrict);
            Walk(agent, assignmentExpression.Right, isStrict);
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

        private static void Walk([NotNull] Agent agent, [NotNull] CallExpressionNode callExpression, bool isStrict)
        {
            if (callExpression.Callee is SuperNode)
            {
                //TODO
            }
            else
            {
                //TODO
                Walk(agent, callExpression.Callee, isStrict);
            }

            foreach (var argument in callExpression.Arguments)
            {
                if (argument != null)
                {
                    Walk(agent, argument, isStrict);
                }
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ClassDeclarationNode classDeclaration, bool isStrict)
        {
            WalkClass(agent, classDeclaration.Id, classDeclaration.SuperClass, classDeclaration.Body);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ClassExpressionNode classExpression, bool isStrict)
        {
            WalkClass(agent, classExpression.Id, classExpression.SuperClass, classExpression.Body);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] DoWhileStatementNode doWhileStatement, bool isStrict)
        {
            if (IsLabelledFunction(doWhileStatement.Body))
            {
                throw agent.CreateSyntaxError();
            }

            Walk(agent, doWhileStatement.Test, isStrict);
            Walk(agent, doWhileStatement.Body, isStrict);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ForStatementNode forStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ForInStatementNode forInStatement, bool isStrict)
        {
            //TODO

            Walk(agent, forInStatement.Left, isStrict);
            Walk(agent, forInStatement.Right, isStrict);
            Walk(agent, forInStatement.Body, isStrict);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ForOfStatementNode forOfStatement, bool isStrict)
        {
            //TODO
        }

        private static void Walk([NotNull] Agent agent, [NotNull] FunctionDeclarationNode functionDeclaration, bool isStrict)
        {
            if (functionDeclaration.Async)
            {
                WalkAsyncFunction(agent, functionDeclaration.Id, functionDeclaration.Parameters, functionDeclaration.Body, isStrict || new FunctionNode(functionDeclaration.Body).IsStrict);
            }
            else if (functionDeclaration.Generator)
            {
                WalkGeneratorFunction(agent, functionDeclaration.Id, functionDeclaration.Parameters, functionDeclaration.Body, isStrict || new FunctionNode(functionDeclaration.Body).IsStrict);
            }
            else
            {
                WalkFunction(agent, functionDeclaration.Id, functionDeclaration.Parameters, functionDeclaration.Body, isStrict || new FunctionNode(functionDeclaration.Body).IsStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] FunctionExpressionNode functionExpression, bool isStrict)
        {
            if (functionExpression.Async)
            {
                WalkAsyncFunction(agent, functionExpression.Id, functionExpression.Parameters, functionExpression.Body, isStrict || new FunctionNode(functionExpression.Body).IsStrict);
            }
            else if (functionExpression.Generator)
            {
                WalkGeneratorFunction(agent, functionExpression.Id, functionExpression.Parameters, functionExpression.Body, isStrict || new FunctionNode(functionExpression.Body).IsStrict);
            }
            else
            {
                WalkFunction(agent, functionExpression.Id, functionExpression.Parameters, functionExpression.Body, isStrict || new FunctionNode(functionExpression.Body).IsStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] IdentifierNode identifier, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-identifiers-static-semantics-early-errors
            if (isStrict)
            {
                switch (identifier.Name)
                {
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

        private static readonly Regex octalRegex = new Regex("^0[0-7]+$", RegexOptions.Compiled | RegexOptions.Singleline);

        private static void Walk([NotNull] Agent agent, [NotNull] LiteralNode literal, bool isStrict)
        {
            if (isStrict && literal.Value.IsDouble && octalRegex.IsMatch(literal.Raw))
            {
                throw agent.CreateSyntaxError();
            }

            if (isStrict && literal.Value.IsString)
            {
                for (var i = 0; i < literal.Raw.Length; i++)
                {
                    var c = literal.Raw[i];
                    if (c == '\\')
                    {
                        var next = literal.Raw[i + 1];
                        switch (next)
                        {
                            case 'n':
                            case 'r':
                            case 'x':
                            case 'u':
                            case 't':
                            case 'b':
                            case 'v':
                            case 'f':
                            case '\n':
                            case '\r':
                                i++;
                                break;
                            default:
                                if (next >= 48 && next <= 55)
                                {
                                    var nextNext = literal.Raw[i + 2];
                                    if (next == '0' && !char.IsDigit(nextNext))
                                    {
                                        i++;
                                        break;
                                    }

                                    throw agent.CreateSyntaxError();
                                }

                                i++;
                                break;
                        }
                    }
                }
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] MethodDefinitionNode methodDefinition, bool isStrict)
        {
            //TODO
            if (methodDefinition.Kind != PropertyKind.Constructor)
            {
                Walk(agent, methodDefinition.Key, isStrict);
                Walk(agent, methodDefinition.Value, isStrict);
            }
            else
            {
                Walk(agent, methodDefinition.Key, isStrict);
                if (methodDefinition.Value.Id != null)
                {
                    Walk(agent, methodDefinition.Value.Id, isStrict);
                }

                foreach (var parameter in methodDefinition.Value.Parameters)
                {
                    Walk(agent, parameter, isStrict);
                }

                Walk(agent, methodDefinition.Value.Body, isStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] ObjectExpressionNode objectExpression, bool isStrict)
        {
            //TODO

            foreach (var property in objectExpression.Properties)
            {
                Walk(agent, property, isStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] PropertyNode property, bool isStrict)
        {
            //TODO

            if (property.Kind == PropertyKind.Get || property.Kind == PropertyKind.Set)
            {
                if (property.Key is IdentifierNode)
                {
                }
                else
                {
                    Walk(agent, property.Key, isStrict);
                }
            }

            if (property.Value != null)
            {
                Walk(agent, property.Value, isStrict);
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
            if (variableDeclaration.Kind != VariableKind.Var)
            {
                //https://tc39.github.io/ecma262/#sec-let-and-const-declarations-static-semantics-early-errors
                var boundNames = BoundNamesWalker.Walk(variableDeclaration);
                if (ContainsDuplicate(boundNames))
                {
                    throw agent.CreateSyntaxError();
                }

                if (boundNames.Contains("let"))
                {
                    throw agent.CreateSyntaxError();
                }
            }

            foreach (var variableDeclarator in variableDeclaration.Declarations)
            {
                Walk(agent, variableDeclarator, isStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] VariableDeclaratorNode variableDeclarator, bool isStrict)
        {
            //TODO

            WalkBinding(agent, variableDeclarator.Id, isStrict);
            if (variableDeclarator.Init != null)
            {
                Walk(agent, variableDeclarator.Init, isStrict);
            }
        }

        private static void Walk([NotNull] Agent agent, [NotNull] WhileStatementNode whileStatement, bool isStrict)
        {
            if (IsLabelledFunction(whileStatement.Body))
            {
                throw agent.CreateSyntaxError();
            }

            Walk(agent, whileStatement.Test, isStrict);
            Walk(agent, whileStatement.Body, isStrict);
        }

        private static void Walk([NotNull] Agent agent, [NotNull] WithStatementNode withStatement, bool isStrict)
        {
            if (isStrict)
            {
                throw agent.CreateSyntaxError();
            }

            if (IsLabelledFunction(withStatement.Body))
            {
                throw agent.CreateSyntaxError();
            }

            Walk(agent, withStatement.Object, false);
            Walk(agent, withStatement.Body, false);
        }

        private static void WalkBinding([NotNull] Agent agent, [NotNull] BaseNode baseNode, bool isStrict)
        {
            switch (baseNode)
            {
                case IdentifierNode identifier:
                    if (isStrict && (string.Equals(identifier.Name, "arguments", StringComparison.Ordinal) || string.Equals(identifier.Name, "eval", StringComparison.Ordinal)))
                    {
                        throw agent.CreateSyntaxError();
                    }

                    Walk(agent, identifier, isStrict);
                    break;

                case ArrayPatternNode arrayPattern:
                    foreach (var element in arrayPattern.Elements)
                    {
                        if (element != null)
                        {
                            WalkBinding(agent, element, isStrict);
                        }
                    }
                    break;

                case ObjectPatternNode objectPattern:
                    foreach (var property in objectPattern.Properties)
                    {
                        WalkBinding(agent, property.Key, isStrict);
                        WalkBinding(agent, property.Value, isStrict);
                    }
                    break;

                case AssignmentPatternNode assignmentPattern:
                    WalkBinding(agent, assignmentPattern.Left, isStrict);
                    //TODO
                    break;

                case RestElementNode restElement:
                    WalkBinding(agent, restElement.Argument, isStrict);
                    break;

                default:
                    Walk(agent, baseNode, isStrict);
                    break;
            }
        }

        private static void WalkClass([NotNull] Agent agent, [CanBeNull] IdentifierNode id, [CanBeNull] ExpressionNode superClass, [NotNull] ClassBodyNode body)
        {
            //https://tc39.github.io/ecma262/#sec-class-definitions-static-semantics-early-errors

            if (id != null)
            {
                Walk(agent, id, true);
            }

            if (superClass == null)
            {
                var constructor = body.Body.FirstOrDefault(x => x.Kind == PropertyKind.Constructor);
                if (constructor != null)
                {
                    if (HasParameterSuper(constructor.Value.Parameters))
                    {
                        throw agent.CreateSyntaxError();
                    }
                    if (HasDirectSuper(constructor.Value.Body))
                    {
                        throw agent.CreateSyntaxError();
                    }
                }
            }

            foreach (var element in body.Body)
            {
                if (element.Kind != PropertyKind.Constructor)
                {
                    if (HasDirectSuper(element.Value.Body))
                    {
                        throw agent.CreateSyntaxError();
                    }
                }

                Walk(agent, element, true);
            }
        }

        private static void WalkFunction([NotNull] Agent agent, [CanBeNull] IdentifierNode id, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-static-semantics-early-errors

            if (isStrict)
            {
                if (ContainsDuplicate(BoundNamesWalker.Walk(parameters)))
                {
                    throw agent.CreateSyntaxError();
                }

                if (id != null && (id.Name == "eval" || id.Name == "arguments"))
                {
                    throw agent.CreateSyntaxError($"Cannot have a function named ${id.Name} in strict mode.");
                }
            }

            //TODO It is a Syntax Error if ContainsUseStrict of FunctionBody is true and IsSimpleParameterList of FormalParameters is false.
            //TODO It is a Syntax Error if any element of the BoundNames of FormalParameters also occurs in the LexicallyDeclaredNames of FunctionBody.
            //TODO It is a Syntax Error if FormalParameters Contains SuperProperty is true.
            //TODO It is a Syntax Error if FunctionBody Contains SuperProperty is true.
            if (HasParameterSuper(parameters))
            {
                throw agent.CreateSyntaxError();
            }
            if (HasDirectSuper(body))
            {
                throw agent.CreateSyntaxError();
            }

            if (id != null)
            {
                Walk(agent, id, isStrict);
            }

            foreach (var parameter in parameters)
            {
                WalkBinding(agent, parameter, isStrict);
            }

            Walk(agent, body, isStrict);
        }

        private static void WalkAsyncFunction([NotNull] Agent agent, [CanBeNull] IdentifierNode id, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-async-function-definitions-static-semantics-early-errors

            WalkFunction(agent, id, parameters, body, isStrict);

            //TODO It is a Syntax Error if FormalParameters Contains AwaitExpression is true.
        }

        private static void WalkGeneratorFunction([NotNull] Agent agent, [CanBeNull] IdentifierNode id, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, bool isStrict)
        {
            //https://tc39.github.io/ecma262/#sec-generator-function-definitions-static-semantics-early-errors

            WalkFunction(agent, id, parameters, body, isStrict);

            //It is a Syntax Error if FormalParameters Contains YieldExpression is true.
        }


        private static bool ContainsDuplicate([NotNull] IReadOnlyCollection<string> boundNames)
        {
            return new HashSet<string>(boundNames).Count != boundNames.Count;
        }

        private static bool HasDirectSuper([NotNull] BaseNode bodyNode)
        {
            //https://tc39.github.io/ecma262/#sec-method-definitions-static-semantics-hasdirectsuper
            return bodyNode is BlockStatementNode block &&
                   block.Body.Any(x => x is ExpressionStatementNode expressionStatement &&
                                       expressionStatement.Expression is CallExpressionNode callExpression &&
                                       callExpression.Callee is SuperNode);
        }

        private static bool HasParameterSuper([NotNull] IEnumerable<ExpressionNode> parameters)
        {
            return parameters.Any(x => x is AssignmentPatternNode assignmentPattern &&
                                       assignmentPattern.Right is CallExpressionNode callExpression &&
                                       callExpression.Callee is SuperNode);
        }

        private static bool IsLabelledFunction(BaseNode statement)
        {
            //https://tc39.github.io/ecma262/#sec-islabelledfunction
            if (statement is LabelledStatementNode labelledStatement)
            {
                if (labelledStatement.Body is FunctionDeclarationNode)
                {
                    return true;
                }

                return IsLabelledFunction(labelledStatement.Body);
            }

            return false;
        }

        private static bool IsValidSimpleAssignmentTarget(Agent agent, [NotNull] ExpressionNode expression, bool isStrict)
        {
            switch (expression)
            {
                case ThisExpressionNode _:
                case LiteralNode _:
                    return false;

                case MemberExpressionNode _:
                    return true;

                case IdentifierNode identifier:
                    if (isStrict && (string.Equals(identifier.Name, "eval", StringComparison.Ordinal) || string.Equals(identifier.Name, "arguments", StringComparison.Ordinal)))
                    {
                        return false;
                    }

                    return true;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}