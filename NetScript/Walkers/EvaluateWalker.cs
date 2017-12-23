using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime;
using NetScript.Runtime.Builtins;
using NetScript.Runtime.Objects;

namespace NetScript.Walkers
{
    internal static class EvaluateWalker
    {
        public static ValueReference Walk([NotNull] IEnumerable<BaseNode> statementList, [NotNull] ExecutionContext context)
        {
            ValueReference result = default;
            try
            {
                foreach (var statement in statementList)
                {
                    var tmp = Walk(statement, context);
                    if (tmp.IsValue)
                    {
                        result = tmp;
                    }
                }
            }
            catch (ECMARuntimeException e)
            {
                if (result.IsValue)
                {
                    e.Value = result.Value;
                }
                throw;
            }
            return result;
        }

        public static ValueReference Walk([NotNull] BaseNode baseNode, [NotNull] ExecutionContext context)
        {
            switch (baseNode)
            {
                case ExpressionNode expression:
                    return Walk(expression, context);

                case BlockStatementNode blockStatement:
                    return Walk(blockStatement, context);
                case BreakStatementNode breakStatement:
                    return Walk(breakStatement, context);
                case ClassDeclarationNode classDeclaration:
                    return Walk(classDeclaration, context);
                case ContinueStatementNode continueStatement:
                    return Walk(continueStatement, context);
                case DoWhileStatementNode doWhileStatement:
                    return Walk(doWhileStatement, context);
                case EmptyStatementNode _:
                    return default;
                case ExpressionStatementNode expressionStatement:
                    return Walk(expressionStatement, context);
                case ForStatementNode forStatement:
                    return Walk(forStatement, context);
                case ForInStatementNode forInStatement:
                    return Walk(forInStatement, context);
                case ForOfStatementNode forOfStatement:
                    return Walk(forOfStatement, context);
                case FunctionDeclarationNode functionDeclaration:
                    return Walk(functionDeclaration, context);
                case IfStatementNode ifStatement:
                    return Walk(ifStatement, context);
                case LabelledStatementNode labelledStatement:
                    return Walk(labelledStatement, context);
                case ReturnStatementNode returnStatement:
                    return Walk(returnStatement, context);
                case SwitchStatementNode switchStatement:
                    return Walk(switchStatement, context);
                case ThrowStatementNode throwStatement:
                    return Walk(throwStatement, context);
                case TryStatementNode tryStatement:
                    return Walk(tryStatement, context);
                case VariableDeclarationNode variableDeclaration:
                    return Walk(variableDeclaration, context);
                case WhileStatementNode whileStatement:
                    return Walk(whileStatement, context);
                case WithStatementNode withStatement:
                    return Walk(withStatement, context);

                default:
                    throw new NotImplementedException();
            }
        }

        private static ValueReference Walk([NotNull] BaseNode baseNode, [NotNull] ExecutionContext context, ICollection<string> labelSet)
        {
            switch (baseNode)
            {
                case DoWhileStatementNode doWhileStatement:
                    return Walk(doWhileStatement, context, labelSet);
                case ForStatementNode forStatement:
                    return Walk(forStatement, context, labelSet);
                case ForInStatementNode forInStatement:
                    return Walk(forInStatement, context, labelSet);
                case ForOfStatementNode forOfStatement:
                    return Walk(forOfStatement, context, labelSet);
                case LabelledStatementNode labelledStatement:
                    return Walk(labelledStatement, context, labelSet);
                case SwitchStatementNode switchStatement:
                    throw new NotImplementedException();
                case WhileStatementNode whileStatement:
                    return Walk(whileStatement, context, labelSet);
                default:
                    return Walk(baseNode, context);
            }
        }

        private static ValueReference Walk([NotNull] BlockStatementNode blockStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-block-runtime-semantics-evaluation
            if (blockStatement.Body.Count == 0)
            {
                return default;
            }

            var agent = context.Realm.Agent;
            var oldEnvironment = context.LexicalEnvironment;
            var blockEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(agent, oldEnvironment);

            BlockDeclarationInstantiation(context, blockStatement.Body, blockEnvironment);
            Debug.Assert(context == agent.RunningExecutionContext);
            context.LexicalEnvironment = blockEnvironment;
            try
            {
                return Walk(blockStatement.Body, context);
            }
            finally
            {
                context.LexicalEnvironment = oldEnvironment;
            }
        }

        private static ValueReference Walk([NotNull] BreakStatementNode breakStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-break-statement-runtime-semantics-evaluation
            if (breakStatement.Label != null)
            {
                throw new BreakException(breakStatement.Label.Name);
            }
            throw new BreakException();
        }

        private static ValueReference Walk([NotNull] ClassDeclarationNode classDeclaration, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-class-definitions-runtime-semantics-evaluation

            //https://tc39.github.io/ecma262/#sec-runtime-semantics-bindingclassdeclarationevaluation

            var className = classDeclaration.Id.Name;
            var value = ClassDefinitionEvaluation(classDeclaration.SuperClass, classDeclaration.Body, className, context);
            var hasNameProperty = value.HasOwnProperty("name");
            if (!hasNameProperty)
            {
                context.Realm.Agent.SetFunctionName(value, className);
            }

            var environment = context.LexicalEnvironment;
            InitialiseBoundName(context.Realm.Agent, className, value, environment);
            return ScriptValue.Undefined;
        }

        private static ValueReference Walk([NotNull] ContinueStatementNode continueStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-continue-statement-runtime-semantics-evaluation
            if (continueStatement.Label != null)
            {
                throw new ContinueException(continueStatement.Label.Name);
            }
            throw new ContinueException();
        }

        private static ValueReference Walk([NotNull] DoWhileStatementNode doWhileStatement, [NotNull] ExecutionContext context, [CanBeNull] ICollection<string> labelSet = null)
        {
            //https://tc39.github.io/ecma262/#sec-do-while-statement-runtime-semantics-labelledevaluation
            var agent = context.Realm.Agent;
            var value = ScriptValue.Undefined;

            while (true)
            {
                try
                {
                    var result = Walk(doWhileStatement.Body, context);
                    if (result.IsValue)
                    {
                        value = result.Value;
                    }
                }
                catch (BreakException e)
                {
                    if (e.Target != null && (labelSet == null || !labelSet.Contains(e.Target)))
                    {
                        throw;
                    }

                    if (e.Value.HasValue)
                    {
                        value = e.Value.Value;
                    }

                    return value;
                }
                catch (ContinueException e)
                {
                    //https://tc39.github.io/ecma262/#sec-loopcontinues
                    if (e.Target != null && (labelSet == null || !labelSet.Contains(e.Target)))
                    {
                        throw;
                    }

                    if (e.Value.HasValue)
                    {
                        value = e.Value.Value;
                    }
                }

                var expressionReference = Walk(doWhileStatement.Test, context);
                var expressionValue = agent.GetValue(expressionReference);
                if (!Agent.RealToBoolean(expressionValue))
                {
                    return value;
                }
            }
        }

        private static ValueReference Walk([NotNull] ExpressionStatementNode expressionStatement, [NotNull] ExecutionContext context)
        {
            return context.Realm.Agent.GetValue(Walk(expressionStatement.Expression, context));
        }

        private static ValueReference Walk([NotNull] ForStatementNode forStatement, [NotNull] ExecutionContext context, [CanBeNull] ICollection<string> labelSet = null)
        {
            //https://tc39.github.io/ecma262/#sec-for-statement-runtime-semantics-labelledevaluation
            var agent = context.Realm.Agent;

            if (forStatement.Init is VariableDeclarationNode variableDeclaration)
            {
                if (variableDeclaration.Kind == VariableKind.Var)
                {
                    Walk(variableDeclaration, context, true);
                }
                else
                {
                    var oldEnvironment = context.LexicalEnvironment;
                    var loopEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(agent, oldEnvironment);
                    var loopEnvironmentRecord = loopEnvironment.Environment;
                    var isConst = variableDeclaration.Kind == VariableKind.Const;
                    var boundNames = BoundNamesWalker.Walk(variableDeclaration);
                    foreach (var declarationName in boundNames)
                    {
                        if (isConst)
                        {
                            loopEnvironmentRecord.CreateImmutableBinding(declarationName, true);
                        }
                        else
                        {
                            loopEnvironmentRecord.CreateMutableBinding(declarationName, false);
                        }
                    }

                    context.LexicalEnvironment = loopEnvironment;
                    try
                    {
                        Walk(variableDeclaration, context, true);
                        var perIterationLets = isConst ? Array.Empty<string>() : boundNames;
                        return ForBodyEvaluation(context, forStatement.Test, forStatement.Update, forStatement.Body, perIterationLets, labelSet);
                    }
                    finally
                    {
                        context.LexicalEnvironment = oldEnvironment;
                    }
                }
            }
            else if (forStatement.Init != null)
            {
                var result = Walk(forStatement.Init, context);
                agent.GetValue(result);
            }

            return ForBodyEvaluation(context, forStatement.Test, forStatement.Update, forStatement.Body, Array.Empty<string>(), labelSet);
        }

        private static ValueReference Walk([NotNull] ForInStatementNode forInStatement, [NotNull] ExecutionContext context, [CanBeNull] ICollection<string> labelSet = null)
        {
            IReadOnlyList<string> tdzNames = Array.Empty<string>();

            if (forInStatement.Left is VariableDeclarationNode variableDeclaration && variableDeclaration.Kind != VariableKind.Var)
            {
                tdzNames = BoundNamesWalker.Walk(variableDeclaration);
            }

            var obj = ForInHeadEvaluation(context, tdzNames, forInStatement.Right);
            if (obj == null)
            {
                return ScriptValue.Undefined;
            }

            return ForInBodyEvaluation(context, forInStatement.Left, forInStatement.Body, obj, labelSet);
        }

        private static ValueReference Walk([NotNull] ForOfStatementNode forOfStatement, [NotNull] ExecutionContext context, [CanBeNull] ICollection<string> labelSet = null)
        {
            IReadOnlyList<string> tdzNames = Array.Empty<string>();

            if (forOfStatement.Left is VariableDeclarationNode variableDeclaration && variableDeclaration.Kind != VariableKind.Var)
            {
                tdzNames = BoundNamesWalker.Walk(variableDeclaration);
            }

            var iteratorRecord = ForOfHeadEvaluation(context, tdzNames, forOfStatement.Right);
            return ForOfBodyEvaluation(context, forOfStatement.Left, forOfStatement.Body, iteratorRecord, labelSet);
        }

        private static ValueReference Walk([NotNull] FunctionDeclarationNode functionDeclaration, [NotNull] ExecutionContext context)
        {
            return default;
        }

        private static ValueReference Walk([NotNull] IfStatementNode ifStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-if-statement-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            var expressionReference = Walk(ifStatement.Test, context);
            var result = agent.GetValue(expressionReference);

            var expressionValue = Agent.RealToBoolean(result);

            try
            {
                ValueReference ifResult;
                if (expressionValue)
                {
                    ifResult = Walk(ifStatement.Consequent, context);
                }
                else if (ifStatement.Alternate == null)
                {
                    ifResult = ScriptValue.Undefined;
                }
                else
                {
                    ifResult = Walk(ifStatement.Alternate, context);
                }

                if (ifResult.IsValue)
                {
                    return ifResult.Value;
                }

                return ScriptValue.Undefined;
            }
            catch (ECMARuntimeException e)
            {
                if (!e.Value.HasValue)
                {
                    e.Value = ScriptValue.Undefined;
                }

                throw;
            }
        }

        private static ValueReference Walk([NotNull] LabelledStatementNode labelledStatement, [NotNull] ExecutionContext context, [CanBeNull] ICollection<string> labelSet = null)
        {
            //https://tc39.github.io/ecma262/#sec-labelled-statements-runtime-semantics-evaluation

            if (labelSet == null)
            {
                labelSet = new HashSet<string>
                {
                    labelledStatement.Label.Name
                };
            }
            else
            {
                labelSet.Add(labelledStatement.Label.Name);
            }

            try
            {
                return Walk(labelledStatement.Body, context, labelSet);
            }
            catch (BreakException e)
            {
                if (e.Target == labelledStatement.Label.Name)
                {
                    return default;
                }

                throw;
            }
        }

        private static ValueReference Walk([NotNull] ReturnStatementNode returnStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-return-statement-runtime-semantics-evaluation
            if (returnStatement.Argument == null)
            {
                throw new ReturnException(ScriptValue.Undefined);
            }

            var expressionReference = Walk(returnStatement.Argument, context);
            var expressionValue = context.Realm.Agent.GetValue(expressionReference);
            throw new ReturnException(expressionValue);
        }

        private static ValueReference Walk([NotNull] SwitchStatementNode switchStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-switch-statement-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            var expressionReference = Walk(switchStatement.Discriminant, context);
            var switchValue = agent.GetValue(expressionReference);
            var oldEnvironment = context.LexicalEnvironment;
            var blockEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(agent, oldEnvironment);
            BlockDeclarationInstantiation(context, switchStatement.Cases, blockEnvironment);
            context.LexicalEnvironment = blockEnvironment;
            try
            {
                //https://tc39.github.io/ecma262/#sec-runtime-semantics-caseblockevaluation

                SwitchCaseNode defaultNode = null;

                var value = ScriptValue.Undefined;
                var found = false;
                foreach (var switchCase in switchStatement.Cases)
                {
                    if (switchCase.Test == null)
                    {
                        Debug.Assert(defaultNode == null);
                        defaultNode = switchCase;
                    }
                    else
                    {
                        if (!found)
                        {
                            found = CaseClauseIsSelected(switchCase, switchValue, context);
                        }

                        if (found)
                        {
                            try
                            {
                                var result = Walk(switchCase.Consequent, context);
                                if (result.IsValue)
                                {
                                    value = result.Value;
                                }
                            }
                            catch (BreakException)
                            {
                                return value;
                            }
                        }
                    }
                }

                if (found)
                {
                    return value;
                }

                if (defaultNode != null)
                {
                    try
                    {
                        var result = Walk(defaultNode.Consequent, context);
                        if (result.IsValue)
                        {
                            value = result.Value;
                        }
                    }
                    catch (BreakException)
                    {
                        return value;
                    }
                }

                return value;
            }
            finally
            {
                context.LexicalEnvironment = oldEnvironment;
            }
        }

        private static ValueReference Walk([NotNull] ThrowStatementNode throwStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-throw-statement-runtime-semantics-evaluation
            var expressionReference = Walk(throwStatement.Argument, context);
            var expressionValue = context.Realm.Agent.GetValue(expressionReference);
            throw new ScriptException(expressionValue);
        }

        private static ValueReference Walk([NotNull] TryStatementNode tryStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-try-statement-runtime-semantics-evaluation

            try
            {
                return Walk(tryStatement.Block, context);
            }
            catch (ScriptException e)
            {
                if (tryStatement.Handler != null)
                {
                    return CatchClauseEvaluation(tryStatement.Handler, e.Value, context);
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (tryStatement.Finaliser != null)
                {
                    Walk(tryStatement.Finaliser, context);
                }
            }
        }

        private static ValueReference Walk([NotNull] VariableDeclarationNode variableDeclaration, [NotNull] ExecutionContext context, bool returnValue = false)
        {
            var agent = context.Realm.Agent;
            ValueReference result = default;

            foreach (var variableDeclarator in variableDeclaration.Declarations)
            {
                if (variableDeclaration.Kind == VariableKind.Var)
                {
                    //https://tc39.github.io/ecma262/#sec-variable-statement-runtime-semantics-evaluation
                    if (variableDeclarator.Id is IdentifierNode variableId)
                    {
                        if (variableDeclarator.Init == null)
                        {
                            result = default;
                        }
                        else
                        {
                            var bindingId = variableId.Name;
                            var lhs = agent.ResolveBinding(bindingId);
                            var rhs = Walk(variableDeclarator.Init, context);
                            var value = agent.GetValue(rhs);
                            if (IsAnonymousFunctionDefinition(variableDeclarator.Init))
                            {
                                var hasNameProperty = value.HasOwnProperty("name");
                                if (!hasNameProperty)
                                {
                                    agent.SetFunctionName((ScriptObject)value, bindingId);
                                }
                            }

                            result = (ScriptValue)agent.PutValue(lhs, value);
                        }
                    }
                    else
                    {
                        var rhs = Walk(variableDeclarator.Init, context);
                        var value = agent.GetValue(rhs);
                        BindingInitialisation(agent, variableDeclarator.Id, value, null);
                    }
                }
                else
                {
                    //https://tc39.github.io/ecma262/#sec-let-and-const-declarations-runtime-semantics-evaluation
                    if (variableDeclarator.Id is IdentifierNode variableId)
                    {
                        var bindingId = variableId.Name;
                        var lhs = agent.ResolveBinding(bindingId);
                        if (variableDeclarator.Init == null)
                        {
                            Agent.InitialiseReferencedBinding(lhs, ScriptValue.Undefined);
                        }
                        else
                        {
                            var rhs = Walk(variableDeclarator.Init, context);
                            var value = agent.GetValue(rhs);
                            if (IsAnonymousFunctionDefinition(variableDeclarator.Init))
                            {
                                var hasNameProperty = value.HasOwnProperty("name");
                                if (!hasNameProperty)
                                {
                                    agent.SetFunctionName((ScriptObject)value, bindingId);
                                }
                            }
                            Agent.InitialiseReferencedBinding(lhs, value);
                        }
                    }
                    else
                    {
                        var rhs = Walk(variableDeclarator.Init, context);
                        var value = agent.GetValue(rhs);
                        BindingInitialisation(agent, variableDeclarator.Id, value, context.LexicalEnvironment);
                    }
                }
            }

            return returnValue ? result : default;
        }

        private static ValueReference Walk([NotNull] WhileStatementNode whileStatement, [NotNull] ExecutionContext context, [CanBeNull] ICollection<string> labelSet = null)
        {
            //https://tc39.github.io/ecma262/#sec-while-statement-runtime-semantics-labelledevaluation
            var agent = context.Realm.Agent;
            var value = ScriptValue.Undefined;

            while (true)
            {
                var expressionReference = Walk(whileStatement.Test, context);
                var expressionValue = agent.GetValue(expressionReference);
                if (!Agent.RealToBoolean(expressionValue))
                {
                    return value;
                }

                try
                {
                    var result = Walk(whileStatement.Body, context);
                    if (result.IsValue)
                    {
                        value = result.Value;
                    }
                }
                catch (BreakException e)
                {
                    if (e.Target != null && (labelSet == null || !labelSet.Contains(e.Target)))
                    {
                        throw;
                    }

                    if (e.Value.HasValue)
                    {
                        value = e.Value.Value;
                    }

                    return value;
                }
                catch (ContinueException e)
                {
                    //https://tc39.github.io/ecma262/#sec-loopcontinues
                    if (e.Target != null && (labelSet == null || !labelSet.Contains(e.Target)))
                    {
                        throw;
                    }

                    if (e.Value.HasValue)
                    {
                        value = e.Value.Value;
                    }
                }
            }
        }

        private static ValueReference Walk([NotNull] WithStatementNode withStatement, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-with-statement-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            var value = Walk(withStatement.Object, context);
            var obj = agent.ToObject(agent.GetValue(value));
            var oldEnvironment = context.LexicalEnvironment;
            var newEnvironment = LexicalEnvironment.NewObjectEnvironment(obj, oldEnvironment, true);
            context.LexicalEnvironment = newEnvironment;
            try
            {
                return Walk(withStatement.Body, context);
            }
            finally
            {
                context.LexicalEnvironment = oldEnvironment;
            }
        }


        private static ValueReference Walk([NotNull] ExpressionNode expression, [NotNull] ExecutionContext context)
        {
            switch (expression)
            {
                case ArrayExpressionNode arrayExpression:
                    return Walk(arrayExpression, context);
                case ArrowFunctionExpressionNode arrowFunctionExpression:
                    return Walk(arrowFunctionExpression, context);
                case AssignmentExpressionNode assignmentExpression:
                    return Walk(assignmentExpression, context);
                case BinaryExpressionNode binaryExpression:
                    return Walk(binaryExpression, context);
                case CallExpressionNode callExpression:
                    return Walk(callExpression, context);
                case ClassExpressionNode classExpression:
                    return Walk(classExpression, context);
                case ConditionalExpressionNode conditionalExpression:
                    return Walk(conditionalExpression, context);
                case FunctionExpressionNode functionExpression:
                    return Walk(functionExpression, context);
                case IdentifierNode identifier:
                    return Walk(identifier, context);
                case LiteralNode literal:
                    return Walk(literal, context);
                case LogicalExpressionNode logicalExpression:
                    return Walk(logicalExpression, context);
                case MemberExpressionNode memberExpression:
                    return Walk(memberExpression, context);
                case MetaPropertyNode metaProperty:
                    return Walk(metaProperty, context);
                case NewExpressionNode newExpression:
                    return Walk(newExpression, context);
                case ObjectExpressionNode objectExpression:
                    return Walk(objectExpression, context);
                case SequenceExpressionNode sequenceExpression:
                    return Walk(sequenceExpression, context);
                case ThisExpressionNode thisExpression:
                    return Walk(thisExpression, context);
                case UnaryExpressionNode unaryExpression:
                    return Walk(unaryExpression, context);
                case UpdateExpressionNode updateExpression:
                    return Walk(updateExpression, context);
                default:
                    throw new NotImplementedException();
            }
        }

        private static ScriptValue Walk([NotNull] ArrayExpressionNode arrayExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-array-initializer-runtime-semantics-evaluation
            var agent = context.Realm.Agent;
            var array = ArrayIntrinsics.ArrayCreate(agent, 0);

            var length = 0u;
            foreach (var element in arrayExpression.Elements)
            {
                if (element == null)
                {
                    length++;
                }
                else if (element is SpreadElementNode spreadElement)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var initialReference = Walk(element, context);
                    var initialValue = agent.GetValue(initialReference);
                    var created = array.CreateDataProperty(length.ToString(), initialValue);
                    Debug.Assert(created);
                    length++;
                }
            }

            agent.Set(array, "length", length, false);

            return array;
        }

        private static ScriptValue Walk([NotNull] ArrowFunctionExpressionNode arrowFunctionExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-arrow-function-definitions-runtime-semantics-evaluation

            if (arrowFunctionExpression.Async)
            {
                throw new NotImplementedException();
            }

            return context.Realm.Agent.FunctionCreate(FunctionKind.Arrow, arrowFunctionExpression.Parameters, arrowFunctionExpression.Body, context.LexicalEnvironment, context.Strict);
        }

        private static ScriptValue Walk([NotNull] AssignmentExpressionNode assignmentExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-assignment-operators-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            if (assignmentExpression.Operator == Operator.Assignment)
            {
                if (!(assignmentExpression.Left is ObjectExpressionNode) && !(assignmentExpression.Left is ArrayExpressionNode))
                {
                    var leftReference = Walk(assignmentExpression.Left, context);
                    var rightReference = Walk(assignmentExpression.Right, context);

                    var rightValue = agent.GetValue(rightReference);
                    if (IsAnonymousFunctionDefinition(assignmentExpression.Right) && assignmentExpression.Left is IdentifierNode)
                    {
                        var hasNameProperty = rightValue.HasOwnProperty("name");
                        if (!hasNameProperty)
                        {
                            agent.SetFunctionName((ScriptObject)rightValue, leftReference.Reference.ReferencedName);
                        }
                    }

                    agent.PutValue(leftReference, rightValue);

                    return rightValue;
                }
                else
                {
                    //Let assignmentPattern be the result of reparsing LeftHandSideExpression as an AssignmentPattern.
                    //Let rref be the result of evaluating AssignmentExpression.
                    //Let rval be ? GetValue(rref).
                    //Perform ? DestructuringAssignmentEvaluation of assignmentPattern using rval as the argument.
                    //Return rval.
                    throw new NotImplementedException();
                }
            }
            else
            {
                var leftReference = Walk(assignmentExpression.Left, context);
                var leftValue = agent.GetValue(leftReference);
                var rightReference = Walk(assignmentExpression.Right, context);
                var rightValue = agent.GetValue(rightReference);

                ScriptValue result;
                switch (assignmentExpression.Operator)
                {
                    case Operator.AdditionAssignment:
                        result = Addition(leftValue, rightValue, agent);
                        break;
                    case Operator.SubtractionAssignment:
                        result = Subtraction(leftValue, rightValue, agent);
                        break;
                    case Operator.MultiplicationAssignment:
                        result = Multiplication(leftValue, rightValue, agent);
                        break;
                    case Operator.DivisionAssignment:
                        result = Division(leftValue, rightValue, agent);
                        break;
                    case Operator.ModulusAssignment:
                        result = Modulus(leftValue, rightValue, agent);
                        break;
                    case Operator.PowerAssignment:
                        result = Exponentiation(leftValue, rightValue, agent);
                        break;
                    case Operator.LeftShiftAssignment:
                        result = LeftShift(leftValue, rightValue, agent);
                        break;
                    case Operator.RightShiftAssignment:
                        result = RightShift(leftValue, rightValue, agent);
                        break;
                    case Operator.RightShiftUnsignedAssignment:
                        result = RightShiftUnsigned(leftValue, rightValue, agent);
                        break;
                    case Operator.BitwiseAndAssignment:
                        result = BitwiseAnd(leftValue, rightValue, agent);
                        break;
                    case Operator.BitwiseOrAssignment:
                        result = BitwiseOr(leftValue, rightValue, agent);
                        break;
                    case Operator.BitwiseXOrAssignment:
                        result = BitwiseXOr(leftValue, rightValue, agent);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                agent.PutValue(leftReference, result);
                return result;
            }
        }

        private static ScriptValue Walk([NotNull] BinaryExpressionNode binaryExpression, [NotNull] ExecutionContext context)
        {
            var agent = context.Realm.Agent;

            var leftReference = Walk(binaryExpression.Left, context);
            var leftValue = agent.GetValue(leftReference);

            var rightReference = Walk(binaryExpression.Right, context);
            var rightValue = agent.GetValue(rightReference);

            switch (binaryExpression.Operator)
            {
                case Operator.Addition:
                    return Addition(leftValue, rightValue, agent);
                case Operator.Subtraction:
                    return Subtraction(leftValue, rightValue, agent);
                case Operator.Multiplication:
                    return Multiplication(leftValue, rightValue, agent);
                case Operator.Division:
                    return Division(leftValue, rightValue, agent);
                case Operator.Modulus:
                    return Modulus(leftValue, rightValue, agent);
                case Operator.Power:
                    return Exponentiation(leftValue, rightValue, agent);
                case Operator.LeftShift:
                    return LeftShift(leftValue, rightValue, agent);
                case Operator.RightShift:
                    return RightShift(leftValue, rightValue, agent);
                case Operator.RightShiftUnsigned:
                    return RightShiftUnsigned(leftValue, rightValue, agent);
                case Operator.BitwiseAnd:
                    return BitwiseAnd(leftValue, rightValue, agent);
                case Operator.BitwiseOr:
                    return BitwiseOr(leftValue, rightValue, agent);
                case Operator.BitwiseXOr:
                    return BitwiseXOr(leftValue, rightValue, agent);
                case Operator.Equals:
                    return agent.AbstractEquality(leftValue, rightValue);
                case Operator.StrictEquals:
                    return Agent.StrictEquality(leftValue, rightValue);
                case Operator.NotEquals:
                    return !agent.AbstractEquality(leftValue, rightValue);
                case Operator.StrictNotEquals:
                    return !Agent.StrictEquality(leftValue, rightValue);
                case Operator.LessThan:
                    return LessThan(leftValue, rightValue, agent);
                case Operator.LessEquals:
                    return LessEquals(leftValue, rightValue, agent);
                case Operator.GreaterThan:
                    return GreaterThan(leftValue, rightValue, agent);
                case Operator.GreaterEquals:
                    return GreaterEquals(leftValue, rightValue, agent);
                case Operator.In:
                    return InOperator(leftValue, rightValue, agent);
                case Operator.InstanceOf:
                    return InstanceOfOperator(leftValue, rightValue, agent);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static ScriptValue Walk([NotNull] CallExpressionNode callExpression, [NotNull] ExecutionContext context)
        {
            if (callExpression.Callee is SuperNode)
            {
                SuperCall(callExpression.Arguments, context);
                return ScriptValue.Undefined;
            }

            //https://tc39.github.io/ecma262/#sec-function-calls-runtime-semantics-evaluation
            var agent = context.Realm.Agent;
            var reference = Walk(callExpression.Callee, context);
            var function = agent.GetValue(reference);

            if (reference.IsReference && !reference.Reference.IsPropertyReference && reference.Reference.ReferencedName == "eval")
            {
                if (function.Equals(context.Realm.Eval))
                {
                    var argList = ArgumentListEvaluation(callExpression.Arguments, context);
                    if (argList.Count == 0)
                    {
                        return ScriptValue.Undefined;
                    }

                    var evalText = argList[0];
                    var strictCaller = context.Strict;
                    var evalRealm = context.Realm;
                    agent.HostEnsureCanCompileStrings(evalRealm, evalRealm);
                    return agent.PerformEval(evalText, evalRealm, strictCaller, true);
                }
            }

            var tailCall = IsInTailPosition(callExpression, context);
            return EvaluateCall(function, reference, callExpression.Arguments, tailCall, context);
        }

        private static ScriptValue Walk([NotNull] ClassExpressionNode classExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-class-definitions-runtime-semantics-evaluation
            var className = classExpression.Id?.Name;
            var value = ClassDefinitionEvaluation(classExpression.SuperClass, classExpression.Body, className, context);
            if (className != null)
            {
                var hasNameProperty = value.HasOwnProperty("name");
                if (!hasNameProperty)
                {
                    context.Realm.Agent.SetFunctionName(value, className);
                }
            }

            return value;
        }

        private static ScriptValue Walk([NotNull] ConditionalExpressionNode conditionalExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-conditional-operator-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            var testReference = Walk(conditionalExpression.Test, context);
            var testValue = Agent.RealToBoolean(agent.GetValue(testReference));

            var valueReference = Walk(testValue ? conditionalExpression.Consequent : conditionalExpression.Alternate, context);
            return agent.GetValue(valueReference);
        }

        private static ScriptValue Walk([NotNull] FunctionExpressionNode functionExpression, [NotNull] ExecutionContext context)
        {
            var agent = context.Realm.Agent;

            if (functionExpression.Async)
            {
                throw new NotImplementedException();
            }

            var strict = context.Strict;
            var scope = context.LexicalEnvironment;

            if (functionExpression.Id != null)
            {
                scope = LexicalEnvironment.NewDeclarativeEnvironment(agent, scope);
                scope.Environment.CreateImmutableBinding(functionExpression.Id.Name, false);
            }

            ScriptFunctionObject closure;
            if (functionExpression.Generator)
            {
                //https://tc39.github.io/ecma262/#sec-generator-function-definitions-runtime-semantics-evaluation

                closure = agent.GeneratorFunctionCreate(FunctionKind.Normal, functionExpression.Parameters, functionExpression.Body, scope, strict);
                var prototype = agent.ObjectCreate(context.Realm.GeneratorPrototype);
                agent.DefinePropertyOrThrow(closure, "prototype", new PropertyDescriptor(prototype, true, false, false));
            }
            else
            {
                //https://tc39.github.io/ecma262/#sec-function-definitions-runtime-semantics-evaluation

                closure = agent.FunctionCreate(FunctionKind.Normal, functionExpression.Parameters, functionExpression.Body, scope, strict);
                agent.MakeConstructor(closure);
            }

            if (functionExpression.Id != null)
            {
                var name = functionExpression.Id.Name;
                agent.SetFunctionName(closure, name);

                scope.Environment.InitialiseBinding(name, closure);
            }

            return closure;
        }

        private static Reference Walk([NotNull] IdentifierNode identifier, [NotNull] ExecutionContext context)
        {
            return context.Realm.Agent.ResolveBinding(identifier.Name);
        }

        private static ScriptValue Walk([NotNull] LiteralNode literal, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-literals-runtime-semantics-evaluation
            switch (literal.Value.Type)
            {
                case LiteralValue.LiteralType.Null:
                    return ScriptValue.Null;
                case LiteralValue.LiteralType.Boolean:
                    return literal.Value.AsBoolean;
                case LiteralValue.LiteralType.Double:
                    return literal.Value.AsDouble;
                case LiteralValue.LiteralType.String:
                    return literal.Value.AsString;
                case LiteralValue.LiteralType.Regex:
                    return RegExpIntrinsics.RegExpCreate(context.Realm.Agent, literal.Value.AsRegex.Pattern, literal.Value.AsRegex.Flags);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static ScriptValue Walk([NotNull] LogicalExpressionNode logicalExpression, [NotNull] ExecutionContext context)
        {
            var agent = context.Realm.Agent;

            var leftReference = Walk(logicalExpression.Left, context);
            var leftValue = agent.GetValue(leftReference);
            var leftBool = Agent.RealToBoolean(leftValue);

            if (logicalExpression.Operator == Operator.LogicalAnd && !leftBool ||
                logicalExpression.Operator == Operator.LogicalOr && leftBool)
            {
                return leftValue;
            }

            var rightReference = Walk(logicalExpression.Right, context);
            return agent.GetValue(rightReference);
        }

        private static Reference Walk([NotNull] MemberExpressionNode memberExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-property-accessors-runtime-semantics-evaluation
            if (memberExpression.Object is SuperNode)
            {
                return EvaluateSuperMember(memberExpression, context);
            }

            var agent = context.Realm.Agent;

            var baseReference = Walk(memberExpression.Object, context);
            var baseValue = agent.GetValue(baseReference);

            ScriptValue propertyKey;
            if (memberExpression.Computed)
            {
                var propertyNameReference = Walk(memberExpression.Property, context);
                var propertyNameValue = agent.GetValue(propertyNameReference);

                baseValue = agent.RequireObjectCoercible(baseValue);
                propertyKey = agent.ToPropertyKey(propertyNameValue);
            }
            else
            {
                baseValue = agent.RequireObjectCoercible(baseValue);

                propertyKey = ((IdentifierNode)memberExpression.Property).Name;
            }
            var strict = context.Strict;
            return new Reference(baseValue, propertyKey, strict);
        }

        private static ScriptValue Walk([NotNull] MetaPropertyNode metaProperty, [NotNull] ExecutionContext context)
        {
            if (metaProperty.Meta.Name == "new" && metaProperty.Property.Name == "target")
            {
                //https://tc39.github.io/ecma262/#sec-meta-properties-runtime-semantics-evaluation
                return context.GetNewTarget();
            }

            throw new NotImplementedException();
        }

        private static ScriptValue Walk([NotNull] NewExpressionNode newExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-new-operator-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            var reference = Walk(newExpression.Callee, context);
            var constructor = agent.GetValue(reference);
            var argumentList = newExpression.Arguments == null ? Array.Empty<ScriptValue>() : ArgumentListEvaluation(newExpression.Arguments, context);

            if (!Agent.IsConstructor(constructor))
            {
                throw agent.CreateTypeError();
            }

            return Agent.Construct((ScriptObject)constructor, argumentList);
        }

        private static ScriptValue Walk([NotNull] ObjectExpressionNode objectExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-object-initializer-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            var obj = agent.ObjectCreate(context.Realm.ObjectPrototype);

            foreach (var property in objectExpression.Properties)
            {
                PropertyDefinitionEvaluation(context, property.Method ? PropertyKind.Method : property.Kind, property.Computed, property.Key, property.Value, obj, true);
            }

            return obj;
        }

        private static ScriptValue Walk([NotNull] SequenceExpressionNode sequenceExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-comma-operator-runtime-semantics-evaluation
            var result = ScriptValue.Undefined;
            foreach (var expression in sequenceExpression.Expressions)
            {
                var reference = Walk(expression, context);
                result = context.Realm.Agent.GetValue(reference);
            }

            return result;
        }

        private static ScriptValue Walk([NotNull] ThisExpressionNode thisExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-this-keyword-runtime-semantics-evaluation

            var environmentRecord = context.GetThisEnvironment();
            return environmentRecord.GetThisBinding();
        }

        private static ScriptValue Walk([NotNull] UnaryExpressionNode unaryExpression, [NotNull] ExecutionContext context)
        {
            var agent = context.Realm.Agent;
            var reference = Walk(unaryExpression.Argument, context);

            switch (unaryExpression.Operator)
            {
                case Operator.Addition:
                    //https://tc39.github.io/ecma262/#sec-unary-plus-operator-runtime-semantics-evaluation
                    return agent.ToNumber(agent.GetValue(reference));

                case Operator.Subtraction:
                    //https://tc39.github.io/ecma262/#sec-unary-minus-operator-runtime-semantics-evaluation
                    return -agent.ToNumber(agent.GetValue(reference));

                case Operator.BitwiseNot:
                {
                    //https://tc39.github.io/ecma262/#sec-bitwise-not-operator-runtime-semantics-evaluation
                    var oldValue = agent.ToInt32(agent.GetValue(reference));
                    return ~oldValue;
                }

                case Operator.LogicalNot:
                {
                    //https://tc39.github.io/ecma262/#sec-logical-not-operator-runtime-semantics-evaluation
                    var oldValue = Agent.RealToBoolean(agent.GetValue(reference));
                    return !oldValue;
                }

                case Operator.Delete:
                    return DeleteEvaluation(agent, reference);

                case Operator.Void:
                {
                    //https://tc39.github.io/ecma262/#sec-void-operator-runtime-semantics-evaluation
                    agent.GetValue(reference);
                    return ScriptValue.Undefined;
                }

                case Operator.TypeOf:
                    return TypeofEvaluation(agent, reference);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static ScriptValue Walk([NotNull] UpdateExpressionNode updateExpression, [NotNull] ExecutionContext context)
        {
            var agent = context.Realm.Agent;
            var expression = Walk(updateExpression.Argument, context);

            switch (updateExpression.Operator)
            {
                case Operator.IncrementPostfix:
                {
                    //https://tc39.github.io/ecma262/#sec-postfix-increment-operator-runtime-semantics-evaluation
                    var oldValue = agent.ToNumber(agent.GetValue(expression));
                    var newValue = oldValue + 1;
                    agent.PutValue(expression, newValue);
                    return oldValue;
                }

                case Operator.DecrementPostfix:
                {
                    //https://tc39.github.io/ecma262/#sec-postfix-decrement-operator-runtime-semantics-evaluation
                    var oldValue = agent.ToNumber(agent.GetValue(expression));
                    var newValue = oldValue - 1;
                    agent.PutValue(expression, newValue);
                    return oldValue;
                }

                case Operator.Increment:
                {
                    //https://tc39.github.io/ecma262/#sec-prefix-increment-operator-runtime-semantics-evaluation
                    var oldValue = agent.ToNumber(agent.GetValue(expression));
                    var newValue = oldValue + 1;
                    agent.PutValue(expression, newValue);
                    return newValue;
                }

                case Operator.Decrement:
                {
                    //https://tc39.github.io/ecma262/#sec-prefix-decrement-operator-runtime-semantics-evaluation
                    var oldValue = agent.ToNumber(agent.GetValue(expression));
                    var newValue = oldValue - 1;
                    agent.PutValue(expression, newValue);
                    return newValue;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        [NotNull]
        private static IReadOnlyList<ScriptValue> ArgumentListEvaluation([NotNull] IEnumerable<ExpressionNode> arguments, [NotNull] ExecutionContext context)
        {
            var agent = context.Realm.Agent;
            var list = new List<ScriptValue>();

            foreach (var argument in arguments)
            {
                if (argument is SpreadElementNode spread)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var reference = Walk(argument, context);
                    var value = agent.GetValue(reference);
                    list.Add(value);
                }
            }

            return list;
        }

        private static void BindingInitialisation([NotNull] Agent agent, [NotNull] ExpressionNode binding, ScriptValue value, [CanBeNull] LexicalEnvironment environment)
        {
            if (binding is IdentifierNode identifier)
            {
                //https://tc39.github.io/ecma262/#sec-identifiers-runtime-semantics-bindinginitialization
                InitialiseBoundName(agent, identifier.Name, value, environment);
            }
            else if (binding is ArrayPatternNode arrayPattern)
            {
                //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-bindinginitialization
                var iteratorRecord = agent.GetIterator(value);
                try
                {
                    IteratorBindingInitialisation(agent, arrayPattern.Elements, ref iteratorRecord, environment);
                }
                catch (ScriptException)
                {
                    if (!iteratorRecord.Done)
                    {
                        agent.IteratorClose(iteratorRecord);
                    }
                    throw;
                }
                if (!iteratorRecord.Done)
                {
                    agent.IteratorClose(iteratorRecord);
                }
            }
            else if (binding is ObjectPatternNode objectPattern)
            {
                //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-bindinginitialization
                agent.RequireObjectCoercible(value);
                foreach (var property in objectPattern.Properties)
                {
                    var name = EvaluatePropertyName(property.Computed, property.Key, agent.RunningExecutionContext);
                    if (!property.Shorthand && property.Kind == PropertyKind.Initialise)
                    {
                        KeyedBindingInitialisation(agent, property.Value, value, environment, name);
                    }
                    else if (property.Key == property.Value)
                    {
                        KeyedBindingInitialisationSingle(agent, (IdentifierNode)property.Key, null, value, environment, name);
                    }
                    else if (property.Value is IdentifierNode)
                    {
                        KeyedBindingInitialisationSingle(agent, (IdentifierNode)property.Key, property.Value, value, environment, name);
                    }
                    else
                    {
                        var assignmentPattern = (AssignmentPatternNode)property.Value;
                        if (assignmentPattern.Left is IdentifierNode patternIdentifier)
                        {
                            KeyedBindingInitialisationSingle(agent, patternIdentifier, assignmentPattern.Right, value, environment, name);
                        }
                        else
                        {
                            KeyedBindingInitialisationBinding(agent, assignmentPattern.Left, assignmentPattern.Right, value, environment, name);
                        }
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static void IteratorBindingInitialisation([NotNull] Agent agent, [NotNull] IEnumerable<ExpressionNode> elements, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-iteratorbindinginitialization
            foreach (var element in elements)
            {
                if (element == null)
                {
                    IteratorDestructuringAssignmentEvaluation(agent, ref iteratorRecord);
                }
                else if (element is RestElementNode restElement)
                {
                    IteratorBindingInitialisationRest(agent, restElement.Argument, ref iteratorRecord, environment);
                }
                else if (element is IdentifierNode identifier)
                {
                    IteratorBindingInitialisationSingleName(agent, identifier.Name, null, ref iteratorRecord, environment);
                }
                else if (element is AssignmentPatternNode assignmentPattern)
                {
                    if (assignmentPattern.Left is IdentifierNode assignmentIdentifier)
                    {
                        IteratorBindingInitialisationSingleName(agent, assignmentIdentifier.Name, assignmentPattern.Right, ref iteratorRecord, environment);
                    }
                    else
                    {
                        IteratorBindingInitialisationBindingPattern(agent, assignmentPattern.Left, assignmentPattern.Right, ref iteratorRecord, environment);
                    }
                }
                else if (element is ArrayPatternNode arrayPattern)
                {
                    IteratorBindingInitialisationBindingPattern(agent, arrayPattern, null, ref iteratorRecord, environment);
                }
                else if (element is ObjectPatternNode objectPattern)
                {
                    IteratorBindingInitialisationBindingPattern(agent, objectPattern, null, ref iteratorRecord, environment);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private static void IteratorDestructuringAssignmentEvaluation(Agent agent, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord)
        {
            if (!iteratorRecord.Done)
            {
                ScriptValue next;
                try
                {
                    next = agent.IteratorStep(iteratorRecord);
                }
                catch (ScriptException)
                {
                    iteratorRecord.Done = true;
                    throw;
                }

                if (next.IsBoolean && !(bool)next)
                {
                    iteratorRecord.Done = true;
                }
            }
        }

        private static void BindingInstantiation([NotNull] VariableDeclarationNode variableDeclaration, [NotNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-bindinginstantiation
            var environmentRecord = environment.Environment;
            Debug.Assert(environmentRecord is DeclarativeEnvironment);

            foreach (var name in BoundNamesWalker.Walk(variableDeclaration))
            {
                if (variableDeclaration.Kind == VariableKind.Const)
                {
                    environmentRecord.CreateImmutableBinding(name, true);
                }
                else
                {
                    environmentRecord.CreateMutableBinding(name, false);
                }
            }
        }

        private static void BlockDeclarationInstantiation([NotNull] ExecutionContext context, [NotNull] IReadOnlyList<BaseNode> code, [NotNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-blockdeclarationinstantiation
            var agent = context.Realm.Agent;

            var environmentRecord = environment.Environment;
            Debug.Assert(environmentRecord is DeclarativeEnvironment);
            var declarations = LexicallyScopedDeclarationsWalker.Walk(code);
            foreach (var declaration in declarations)
            {
                foreach (var declarationName in declaration.BoundNames)
                {
                    if (declaration.IsConstant)
                    {
                        environmentRecord.CreateImmutableBinding(declarationName, true);
                    }
                    else
                    {
                        environmentRecord.CreateMutableBinding(declarationName, false);
                    }
                }

                if (declaration.IsFunction)
                {
                    var functionName = declaration.BoundNames.Single();
                    var functionObject = declaration.InstantiateFunctionObject(agent, environment);
                    environmentRecord.InitialiseBinding(functionName, functionObject);
                }
            }
        }

        private static bool CaseClauseIsSelected([NotNull] SwitchCaseNode switchCase, ScriptValue input, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-caseclauseisselected
            Debug.Assert(switchCase.Test != null, "switchCase.Test != null");
            var expressionReference = Walk(switchCase.Test, context);
            var clauseSelector = context.Realm.Agent.GetValue(expressionReference);
            return Agent.StrictEquality(input, clauseSelector);
        }

        private static ValueReference CatchClauseEvaluation([NotNull] CatchClauseNode catchClause, ScriptValue thrownValue, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-catchclauseevaluation
            var oldEnvironment = context.LexicalEnvironment;
            var catchEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(context.Realm.Agent, oldEnvironment);
            var catchEnvironmentRecord = catchEnvironment.Environment;

            foreach (var argumentName in BoundNamesWalker.Walk(catchClause.Param))
            {
                catchEnvironmentRecord.CreateMutableBinding(argumentName, false);
            }

            Debug.Assert(context == context.Realm.Agent.RunningExecutionContext);
            context.LexicalEnvironment = catchEnvironment;
            try
            {
                BindingInitialisation(context.Realm.Agent, catchClause.Param, thrownValue, catchEnvironment);
                return Walk(catchClause.Body, context);
            }
            finally
            {
                context.LexicalEnvironment = oldEnvironment;
            }
        }

        [NotNull]
        private static ScriptObject ClassDefinitionEvaluation([CanBeNull] ExpressionNode classHeritage, [NotNull] ClassBodyNode classBody, [CanBeNull] string className, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-classdefinitionevaluation
            var agent = context.Realm.Agent;

            var lexicalEnvironment = context.LexicalEnvironment;
            var classScope = LexicalEnvironment.NewDeclarativeEnvironment(agent, lexicalEnvironment);
            var classScopeEnvironmentRecord = classScope.Environment;
            if (className != null)
            {
                classScopeEnvironmentRecord.CreateImmutableBinding(className, true);
            }

            ScriptObject prototypeParent;
            ScriptObject constructorParent;
            if (classHeritage == null)
            {
                prototypeParent = agent.Realm.ObjectPrototype;
                constructorParent = agent.Realm.FunctionPrototype;
            }
            else
            {
                ScriptValue superClass;
                try
                {
                    context.LexicalEnvironment = classScope;
                    superClass = agent.GetValue(Walk(classHeritage, context));
                }
                finally
                {
                    context.LexicalEnvironment = lexicalEnvironment;
                }

                if (superClass == ScriptValue.Null)
                {
                    prototypeParent = null;
                    constructorParent = agent.Realm.FunctionPrototype;
                }
                else if (!Agent.IsConstructor(superClass))
                {
                    throw agent.CreateTypeError();
                }
                else
                {
                    var tmp = ((ScriptObject)superClass).Get("prototype");
                    if (tmp == ScriptValue.Null)
                    {
                        prototypeParent = null;
                    }
                    else if (tmp.IsObject)
                    {
                        prototypeParent = (ScriptObject)tmp;
                    }
                    else
                    {
                        throw agent.CreateTypeError();
                    }

                    constructorParent = (ScriptObject)superClass;
                }
            }

            var prototype = agent.ObjectCreate(prototypeParent);
            var constructor = classBody.Body.SingleOrDefault(x => x.Kind == PropertyKind.Constructor);
            if (constructor == null)
            {
                if (classHeritage != null)
                {
                    //Set constructor to the result of parsing the source text
                    //constructor(... args){ super (...args);}
                    //using the syntactic grammar with the goal symbol MethodDefinition[~Yield, ~Await].
                    constructor = new MethodDefinitionNode(default,
                        PropertyKind.Constructor,
                        false,
                        new IdentifierNode(default, "constructor"),
                        new FunctionExpressionNode(default,
                            false,
                            false,
                            null,
                            new ExpressionNode[]
                            {
                                new RestElementNode(default, new IdentifierNode(default, "args"))
                            },
                            new BlockStatementNode(default, new BaseNode[]
                            {
                                new ExpressionStatementNode(default, new CallExpressionNode(default, new SuperNode(default), new ExpressionNode[]
                                {
                                    new SpreadElementNode(default, new IdentifierNode(default, "args"))
                                }))
                            })));
                }
                else
                {
                    //Set constructor to the result of parsing the source text
                    //constructor( ){ }
                    //using the syntactic grammar with the goal symbol MethodDefinition[~Yield, ~Await].
                    constructor = new MethodDefinitionNode(default,
                        PropertyKind.Constructor,
                        false,
                        new IdentifierNode(default, "constructor"),
                        new FunctionExpressionNode(default,
                            false,
                            false,
                            null,
                            Array.Empty<ExpressionNode>(),
                            new BlockStatementNode(default, Array.Empty<BaseNode>())));
                }
            }

            context.LexicalEnvironment = classScope;
            var constructorInfo = DefineMethod(context, constructor.Computed, constructor.Key, constructor.Value, prototype, constructorParent);
            var function = constructorInfo.Closure;
            if (classHeritage != null)
            {
                function.ConstructorKind = ConstructorKind.Derived;
            }

            agent.MakeConstructor(function, false, prototype);
            Agent.MakeClassConstructor(function);
            Agent.CreateMethodProperty(prototype, "constructor", function);

            try
            {
                foreach (var method in classBody.Body.Where(x => x.Kind != PropertyKind.Constructor))
                {
                    if (!method.Static)
                    {
                        PropertyDefinitionEvaluation(context, method.Kind, method.Computed, method.Key, method.Value, prototype, false);
                    }
                    else
                    {
                        PropertyDefinitionEvaluation(context, method.Kind, method.Computed, method.Key, method.Value, function, false);
                    }
                }
            }
            finally
            {
                context.LexicalEnvironment = lexicalEnvironment;
            }

            if (className != null)
            {
                classScopeEnvironmentRecord.InitialiseBinding(className, function);
            }

            return function;
        }

        private static void CreatePerIterationEnvironment([NotNull] ExecutionContext context, [NotNull] IReadOnlyCollection<string> perIterationBindings)
        {
            //https://tc39.github.io/ecma262/#sec-createperiterationenvironment

            if (perIterationBindings.Count > 0)
            {
                var lastIterationEnvironment = context.LexicalEnvironment;
                var lastIterationEnvironmentRecord = lastIterationEnvironment.Environment;
                var outer = lastIterationEnvironment.OuterEnvironment;
                Debug.Assert(outer != null);

                var thisIterationEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(context.Realm.Agent, outer);
                var thisIterationEnvironmentRecord = thisIterationEnvironment.Environment;

                foreach (var bindingName in perIterationBindings)
                {
                    thisIterationEnvironmentRecord.CreateMutableBinding(bindingName, false);
                    var lastValue = lastIterationEnvironmentRecord.GetBindingValue(bindingName, true);
                    thisIterationEnvironmentRecord.InitialiseBinding(bindingName, lastValue);
                }

                context.LexicalEnvironment = thisIterationEnvironment;
            }
        }

        private static (ScriptValue Key, ScriptFunctionObject Closure) DefineMethod([NotNull] ExecutionContext context, bool computed, [NotNull] ExpressionNode key, [NotNull] FunctionExpressionNode value, [NotNull] ScriptObject obj, [CanBeNull] ScriptObject functionPrototype = null)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-definemethod

            var propertyKey = EvaluatePropertyName(computed, key, context);
            var strict = context.Strict;
            var scope = context.LexicalEnvironment;

            FunctionKind kind;
            ScriptObject prototype;
            if (functionPrototype != null)
            {
                kind = FunctionKind.Normal;
                prototype = functionPrototype;
            }
            else
            {
                kind = FunctionKind.Method;
                prototype = context.Realm.FunctionPrototype;
            }

            var closure = context.Realm.Agent.FunctionCreate(kind, value.Parameters, value.Body, scope, strict, prototype);
            Agent.MakeMethod(closure, obj);
            return (Key: propertyKey, Closure: closure);
        }

        private static bool DeleteEvaluation(Agent agent, ValueReference reference)
        {
            //https://tc39.github.io/ecma262/#sec-delete-operator-runtime-semantics-evaluation

            if (!reference.IsReference)
            {
                return true;
            }

            if (reference.Reference.IsUnresolvableReference)
            {
                Debug.Assert(!reference.Reference.IsStrictReference);
                return true;
            }

            if (reference.Reference.IsPropertyReference)
            {
                if (reference.Reference.IsSuperReference)
                {
                    throw agent.CreateReferenceError();
                }

                var baseObject = agent.ToObject(reference.Reference.BaseValue);
                var deleteStatus = baseObject.Delete(reference.Reference.ReferencedName);

                if (!deleteStatus && reference.Reference.IsStrictReference)
                {
                    throw agent.CreateTypeError();
                }

                return deleteStatus;
            }

            var bindings = reference.Reference.BaseEnvironment;
            return bindings.DeleteBinding(reference.Reference.ReferencedName);
        }

        private static IEnumerable<ScriptValue> EnumerateObjectProperties([NotNull] ScriptObject obj)
        {
            var visited = new HashSet<ScriptValue>();
            foreach (var key in obj.OwnPropertyKeys())
            {
                if (key.IsSymbol)
                {
                    continue;
                }

                var descriptor = obj.GetOwnProperty(key);
                if (descriptor != null)
                {
                    visited.Add(key);
                    if (descriptor.Enumerable)
                    {
                        yield return key;
                    }
                }
            }

            var prototype = obj.GetPrototypeOf();
            if (prototype != null)
            {
                foreach (var prototypeKey in EnumerateObjectProperties(prototype))
                {
                    if (!visited.Contains(prototypeKey))
                    {
                        yield return prototypeKey;
                    }
                }
            }
        }

        private static ScriptValue EvaluateCall(ScriptValue function, ValueReference reference, [NotNull] IEnumerable<ExpressionNode> arguments, bool tailPosition, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-evaluatecall
            var agent = context.Realm.Agent;

            ScriptValue thisValue;
            if (reference.IsReference)
            {
                if (reference.Reference.IsPropertyReference)
                {
                    thisValue = reference.Reference.ThisValue;
                }
                else
                {
                    thisValue = reference.Reference.BaseEnvironment.WithBaseObject();
                }
            }
            else
            {
                thisValue = ScriptValue.Undefined;
            }
            var argumentList = ArgumentListEvaluation(arguments, context);

            if (!function.IsObject)
            {
                throw agent.CreateTypeError();
            }

            var functionObject = (ScriptObject)function;

            if (!functionObject.IsCallable)
            {
                throw agent.CreateTypeError();
            }

            if (tailPosition)
            {
                //If tailPosition is true, perform PrepareForTailCall().
                throw new NotImplementedException();
            }

            var result = agent.Call(functionObject, thisValue, argumentList);
            Debug.Assert(!tailPosition);
            return result;
        }

        private static Reference EvaluateSuperMember([NotNull] MemberExpressionNode memberExpression, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-super-keyword-runtime-semantics-evaluation
            var agent = context.Realm.Agent;

            ScriptValue propertyKey;
            if (memberExpression.Computed)
            {
                var propertyNameReference = Walk(memberExpression.Property, context);
                var propertyNameValue = agent.GetValue(propertyNameReference);
                propertyKey = agent.ToPropertyKey(propertyNameValue);
            }
            else
            {
                propertyKey = ((IdentifierNode)memberExpression.Property).Name;
            }

            return MakeSuperPropertyReference(agent, propertyKey, context.Strict);
        }

        private static ScriptValue EvaluatePropertyName(bool computed, [NotNull] ExpressionNode propertyName, ExecutionContext context)
        {
            if (!computed)
            {
                if (propertyName is IdentifierNode identifier)
                {
                    return identifier.Name;
                }
            }

            var expressionValue = Walk(propertyName, context);
            expressionValue = context.Realm.Agent.GetValue(expressionValue);
            return context.Realm.Agent.ToPropertyKey(expressionValue.Value);
        }

        private static ScriptValue ForBodyEvaluation([NotNull] ExecutionContext context, [CanBeNull] ExpressionNode test, [CanBeNull] ExpressionNode increment, [NotNull] BaseNode statement, [NotNull] IReadOnlyList<string> perIterationBindings, [CanBeNull] ICollection<string> labelSet)
        {
            //https://tc39.github.io/ecma262/#sec-forbodyevaluation
            var agent = context.Realm.Agent;
            var value = ScriptValue.Undefined;

            CreatePerIterationEnvironment(context, perIterationBindings);

            while (true)
            {
                if (test != null)
                {
                    var testReference = Walk(test, context);
                    var textValue = agent.GetValue(testReference);
                    if (!Agent.RealToBoolean(textValue))
                    {
                        return value;
                    }
                }

                try
                {
                    var result = Walk(statement, context);

                    if (result.IsValue)
                    {
                        value = result.Value;
                    }
                }
                catch (BreakException e)
                {
                    if (e.Target != null && (labelSet == null || !labelSet.Contains(e.Target)))
                    {
                        throw;
                    }

                    if (e.Value.HasValue)
                    {
                        value = e.Value.Value;
                    }

                    return value;
                }
                catch (ContinueException e)
                {
                    //https://tc39.github.io/ecma262/#sec-loopcontinues
                    if (e.Target != null && (labelSet == null || !labelSet.Contains(e.Target)))
                    {
                        throw;
                    }

                    if (e.Value.HasValue)
                    {
                        value = e.Value.Value;
                    }
                }

                CreatePerIterationEnvironment(context, perIterationBindings);

                if (increment != null)
                {
                    var incrementReference = Walk(increment, context);
                    agent.GetValue(incrementReference);
                }
            }
        }

        private static ScriptValue ForInBodyEvaluation([NotNull] ExecutionContext context, [NotNull] BaseNode lhs, [NotNull] BaseNode statement, [NotNull] ScriptObject iterator, [CanBeNull] ICollection<string> labelSet)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-forin-div-ofbodyevaluation-lhs-stmt-iterator-lhskind-labelset
            var agent = context.Realm.Agent;
            Debug.Assert(agent.RunningExecutionContext == context);

            var oldEnvironment = context.LexicalEnvironment;
            var value = ScriptValue.Undefined;
            var destructuring = IsDestructuring(lhs);
            if (destructuring && !(lhs is VariableDeclarationNode))
            {
                //Assert: lhs is a LeftHandSideExpression.
                //Let assignmentPattern be the result of reparsing lhs as an AssignmentPattern.
                throw new NotImplementedException();
            }

            var variableDeclaration = lhs as VariableDeclarationNode;

            foreach (var nextValue in EnumerateObjectProperties(iterator))
            {
                try
                {
                    Reference lhsReference = default;
                    if (variableDeclaration != null && variableDeclaration.Kind != VariableKind.Var)
                    {
                        var iterationEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(agent, oldEnvironment);
                        BindingInstantiation(variableDeclaration, iterationEnvironment);
                        context.LexicalEnvironment = iterationEnvironment;
                        if (!destructuring)
                        {
                            Debug.Assert(variableDeclaration.Declarations.Count == 1);
                            var lhsName = ((IdentifierNode)variableDeclaration.Declarations[0].Id).Name;
                            lhsReference = agent.ResolveBinding(lhsName);
                        }
                    }
                    else if (variableDeclaration != null)
                    {
                        if (!destructuring)
                        {
                            lhsReference = agent.ResolveBinding(((IdentifierNode)variableDeclaration.Declarations[0].Id).Name);
                        }
                    }
                    else
                    {
                        if (!destructuring)
                        {
                            lhsReference = Walk(lhs, context).Reference;
                        }
                    }

                    if (!destructuring)
                    {
                        if (variableDeclaration != null && variableDeclaration.Kind != VariableKind.Var)
                        {
                            Agent.InitialiseReferencedBinding(lhsReference, nextValue);
                        }
                        else
                        {
                            agent.PutValue(lhsReference, nextValue);
                        }
                    }
                    else
                    {
                        //If lhsKind is assignment, then
                        //    Let status be the result of performing DestructuringAssignmentEvaluation of assignmentPattern using nextValue as the argument.
                        //Else if lhsKind is varBinding, then
                        //    Assert: lhs is a ForBinding.
                        //    Let status be the result of performing BindingInitialization for lhs passing nextValue and undefined as the arguments.
                        //Else,
                        //    Assert: lhsKind is lexicalBinding.
                        //    Assert: lhs is a ForDeclaration.
                        //    Let status be the result of performing BindingInitialization for lhs passing nextValue and iterationEnv as arguments.
                        throw new NotImplementedException();
                    }

                    var result = Walk(statement, context);
                    if (result.IsValue)
                    {
                        value = result.Value;
                    }
                }
                catch (BreakException e)
                {
                    if (e.Target != null)
                    {
                        throw new NotImplementedException();
                    }

                    return value;
                }
                catch (ContinueException e)
                {
                    //https://tc39.github.io/ecma262/#sec-loopcontinues
                    throw new NotImplementedException();
                }
                finally
                {
                    context.LexicalEnvironment = oldEnvironment;
                }
            }

            return value;
        }

        private static ScriptValue ForOfBodyEvaluation([NotNull] ExecutionContext context, [NotNull] BaseNode lhs, [NotNull] BaseNode statement, (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, [CanBeNull] ICollection<string> labelSet)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-forin-div-ofbodyevaluation-lhs-stmt-iterator-lhskind-labelset
            var agent = context.Realm.Agent;
            Debug.Assert(agent.RunningExecutionContext == context);

            var oldEnvironment = context.LexicalEnvironment;
            var value = ScriptValue.Undefined;
            var destructuring = IsDestructuring(lhs);
            if (destructuring && !(lhs is VariableDeclarationNode))
            {
                //Assert: lhs is a LeftHandSideExpression.
                //Let assignmentPattern be the result of reparsing lhs as an AssignmentPattern.
                throw new NotImplementedException();
            }

            var variableDeclaration = lhs as VariableDeclarationNode;

            while (true)
            {
                try
                {
                    var nextResult = agent.IteratorStep(iteratorRecord);
                    if (nextResult.IsBoolean && (bool)nextResult == false)
                    {
                        return value;
                    }

                    var nextValue = Agent.IteratorValue((ScriptObject)nextResult);

                    Reference lhsReference = default;
                    if (variableDeclaration != null && variableDeclaration.Kind != VariableKind.Var)
                    {
                        var iterationEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(agent, oldEnvironment);
                        BindingInstantiation(variableDeclaration, iterationEnvironment);
                        context.LexicalEnvironment = iterationEnvironment;
                        if (!destructuring)
                        {
                            Debug.Assert(variableDeclaration.Declarations.Count == 1);
                            var lhsName = ((IdentifierNode)variableDeclaration.Declarations[0].Id).Name;
                            lhsReference = agent.ResolveBinding(lhsName);
                        }
                    }
                    else if (variableDeclaration != null)
                    {
                        if (!destructuring)
                        {
                            lhsReference = agent.ResolveBinding(((IdentifierNode)variableDeclaration.Declarations[0].Id).Name);
                        }
                    }
                    else
                    {
                        if (!destructuring)
                        {
                            lhsReference = Walk(lhs, context).Reference;
                        }
                    }

                    if (!destructuring)
                    {
                        if (variableDeclaration != null && variableDeclaration.Kind != VariableKind.Var)
                        {
                            Agent.InitialiseReferencedBinding(lhsReference, nextValue);
                        }
                        else
                        {
                            agent.PutValue(lhsReference, nextValue);
                        }
                    }
                    else
                    {
                        //If lhsKind is assignment, then
                        //    Let status be the result of performing DestructuringAssignmentEvaluation of assignmentPattern using nextValue as the argument.
                        //Else if lhsKind is varBinding, then
                        //    Assert: lhs is a ForBinding.
                        //    Let status be the result of performing BindingInitialization for lhs passing nextValue and undefined as the arguments.
                        //Else,
                        //    Assert: lhsKind is lexicalBinding.
                        //    Assert: lhs is a ForDeclaration.
                        //    Let status be the result of performing BindingInitialization for lhs passing nextValue and iterationEnv as arguments.
                        throw new NotImplementedException();
                    }

                    var result = Walk(statement, context);
                    if (result.IsValue)
                    {
                        value = result.Value;
                    }
                }
                catch (BreakException e)
                {
                    if (e.Target != null)
                    {
                        throw new NotImplementedException();
                    }

                    agent.IteratorClose(iteratorRecord);
                    return value;
                }
                catch (ContinueException e)
                {
                    //https://tc39.github.io/ecma262/#sec-loopcontinues
                    throw new NotImplementedException();
                }
                finally
                {
                    context.LexicalEnvironment = oldEnvironment;
                }
            }
        }

        [CanBeNull]
        private static ScriptObject ForInHeadEvaluation([NotNull] ExecutionContext context, [NotNull] IReadOnlyCollection<string> tdzNames, [NotNull] ExpressionNode expression)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-forin-div-ofheadevaluation-tdznames-expr-iterationkind
            var agent = context.Realm.Agent;
            Debug.Assert(agent.RunningExecutionContext == context);

            var oldEnvironment = context.LexicalEnvironment;
            if (tdzNames.Count > 0)
            {
                Debug.Assert(new HashSet<string>(tdzNames).Count == tdzNames.Count);
                var tdz = LexicalEnvironment.NewDeclarativeEnvironment(agent, oldEnvironment);
                var tdzEnvironmentRecord = tdz.Environment;
                foreach (var name in tdzNames)
                {
                    tdzEnvironmentRecord.CreateMutableBinding(name, false);
                }

                context.LexicalEnvironment = tdz;
            }

            ValueReference expressionResult;
            try
            {
                expressionResult = Walk(expression, context);
            }
            finally
            {
                context.LexicalEnvironment = oldEnvironment;
            }

            var expressionValue = agent.GetValue(expressionResult);
            if (expressionValue == ScriptValue.Undefined || expressionValue == ScriptValue.Null)
            {
                return null;
            }

            return agent.ToObject(expressionValue);
        }

        private static (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) ForOfHeadEvaluation([NotNull] ExecutionContext context, [NotNull] IReadOnlyCollection<string> tdzNames, [NotNull] ExpressionNode expression)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-forin-div-ofheadevaluation-tdznames-expr-iterationkind
            var agent = context.Realm.Agent;
            Debug.Assert(agent.RunningExecutionContext == context);

            var oldEnvironment = context.LexicalEnvironment;
            if (tdzNames.Count > 0)
            {
                Debug.Assert(new HashSet<string>(tdzNames).Count == tdzNames.Count);
                var tdz = LexicalEnvironment.NewDeclarativeEnvironment(agent, oldEnvironment);
                var tdzEnvironmentRecord = tdz.Environment;
                foreach (var name in tdzNames)
                {
                    tdzEnvironmentRecord.CreateMutableBinding(name, false);
                }

                context.LexicalEnvironment = tdz;
            }

            ValueReference expressionResult;
            try
            {
                expressionResult = Walk(expression, context);
            }
            finally
            {
                context.LexicalEnvironment = oldEnvironment;
            }

            var expressionValue = agent.GetValue(expressionResult);
            return agent.GetIterator(expressionValue);
        }

        private static void InitialiseBoundName([NotNull] Agent agent, [NotNull] string name, ScriptValue value, [CanBeNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-initializeboundname
            if (environment != null)
            {
                var environmentRecord = environment.Environment;
                environmentRecord.InitialiseBinding(name, value);
            }
            else
            {
                var lhs = agent.ResolveBinding(name);
                agent.PutValue(lhs, value);
            }
        }

        internal static bool IsAnonymousFunctionDefinition(ExpressionNode expression)
        {
            switch (expression)
            {
                case ArrowFunctionExpressionNode _:
                case ClassExpressionNode _:
                    return true;
                case FunctionExpressionNode functionExpression:
                    return functionExpression.Id == null;
            }

            return false;
        }

        private static bool IsDestructuring(BaseNode value)
        {
            return value is ObjectExpressionNode || value is ArrayExpressionNode ||
                   value is VariableDeclarationNode variableDeclaration &&
                   variableDeclaration.Kind != VariableKind.Var &&
                   !(variableDeclaration.Declarations[0].Id is IdentifierNode);
        }

        private static bool IsInTailPosition([NotNull] CallExpressionNode call, [NotNull] ExecutionContext context)
        {
            if (!context.Strict)
            {
                return false;
            }
            //TODO
            return false;
            //If call is not contained within a FunctionBody, ConciseBody, or AsyncConciseBody, return false.
            //Let body be the FunctionBody, ConciseBody, or AsyncConciseBody that most closely contains call.
            //If body is the FunctionBody of a GeneratorBody, return false.
            //If body is the FunctionBody of an AsyncFunctionBody, return false.
            //If body is an AsyncConciseBody, return false.
            //Return the result of HasCallInTailPosition of body with argument call.
            throw new NotImplementedException();
        }

        private static Reference MakeSuperPropertyReference([NotNull] Agent agent, ScriptValue propertyKey, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-makesuperpropertyreference
            var environment = agent.RunningExecutionContext.GetThisEnvironment();
            Debug.Assert(environment.HasSuperBinding());
            var actualThis = environment.GetThisBinding();
            var baseValue = environment.GetSuperBase();
            baseValue = agent.RequireObjectCoercible(baseValue);
            return new Reference(baseValue, propertyKey, actualThis, strict);
        }

        private static void PropertyDefinitionEvaluation([NotNull] ExecutionContext context, PropertyKind kind, bool computed, [NotNull] ExpressionNode key, [NotNull] ExpressionNode value, [NotNull] ScriptObject obj, bool enumerable)
        {
            var agent = context.Realm.Agent;

            switch (kind)
            {
                case PropertyKind.Initialise:
                {
                    //https://tc39.github.io/ecma262/#sec-object-initializer-runtime-semantics-propertydefinitionevaluation
                    var propertyKey = EvaluatePropertyName(computed, key, context);
                    var expressionValueReference = Walk(value, context);
                    var propertyValue = agent.GetValue(expressionValueReference);

                    if (IsAnonymousFunctionDefinition(value))
                    {
                        var hasNameProperty = propertyValue.HasOwnProperty("name");
                        if (!hasNameProperty)
                        {
                            agent.SetFunctionName((ScriptObject)propertyValue, propertyKey);
                        }
                    }

                    agent.CreateDataPropertyOrThrow(obj, propertyKey, propertyValue);
                    break;
                }

                case PropertyKind.Get:
                {
                    //https://tc39.github.io/ecma262/#sec-method-definitions-runtime-semantics-propertydefinitionevaluation
                    var function = (FunctionExpressionNode)value;
                    Debug.Assert(!function.Generator && !function.Async);

                    var propertyKey = EvaluatePropertyName(computed, key, context);
                    var closure = agent.FunctionCreate(FunctionKind.Method, function.Parameters, function.Body, context.LexicalEnvironment, context.Strict);
                    Agent.MakeMethod(closure, obj);
                    agent.SetFunctionName(closure, propertyKey, "get");
                    var descriptor = new PropertyDescriptor(closure, null, enumerable, true);
                    agent.DefinePropertyOrThrow(obj, propertyKey, descriptor);
                    break;
                }

                case PropertyKind.Set:
                {
                    //https://tc39.github.io/ecma262/#sec-method-definitions-runtime-semantics-propertydefinitionevaluation
                    var function = (FunctionExpressionNode)value;
                    Debug.Assert(!function.Generator && !function.Async);

                    var propertyKey = EvaluatePropertyName(computed, key, context);
                    var closure = agent.FunctionCreate(FunctionKind.Method, function.Parameters, function.Body, context.LexicalEnvironment, context.Strict);
                    Agent.MakeMethod(closure, obj);
                    agent.SetFunctionName(closure, propertyKey, "set");
                    var descriptor = new PropertyDescriptor(null, closure, enumerable, true);
                    agent.DefinePropertyOrThrow(obj, propertyKey, descriptor);
                    break;
                }

                case PropertyKind.Method:
                {
                    var function = (FunctionExpressionNode)value;

                    if (function.Generator)
                    {
                        //https://tc39.github.io/ecma262/#sec-generator-function-definitions-runtime-semantics-propertydefinitionevaluation
                        var propertyKey = EvaluatePropertyName(computed, key, context);
                        var closure = agent.GeneratorFunctionCreate(FunctionKind.Method, function.Parameters, function.Body, context.LexicalEnvironment, context.Strict);
                        Agent.MakeMethod(closure, obj);

                        var prototype = agent.ObjectCreate(context.Realm.GeneratorPrototype);
                        agent.DefinePropertyOrThrow(closure, "prototype", new PropertyDescriptor(prototype, true, false, false));
                        agent.SetFunctionName(closure, propertyKey);
                        var descriptor = new PropertyDescriptor(closure, true, enumerable, true);
                        agent.DefinePropertyOrThrow(obj, propertyKey, descriptor);
                    }
                    else if (function.Async)
                    {
                        //https://tc39.github.io/ecma262/#sec-async-function-definitions-PropertyDefinitionEvaluation
                        var propertyKey = EvaluatePropertyName(computed, key, context);
                        var closure = agent.AsyncFunctionCreate(FunctionKind.Method, function.Parameters, function.Body, context.LexicalEnvironment, context.Strict);
                        Agent.MakeMethod(closure, obj);
                        agent.SetFunctionName(closure, propertyKey);

                        var descriptor = new PropertyDescriptor(closure, true, enumerable, true);
                        agent.DefinePropertyOrThrow(obj, propertyKey, descriptor);
                    }
                    else
                    {
                        //https://tc39.github.io/ecma262/#sec-method-definitions-runtime-semantics-propertydefinitionevaluation
                        var methodDefinition = DefineMethod(context, computed, key, function, obj);
                        agent.SetFunctionName(methodDefinition.Closure, methodDefinition.Key);
                        var descriptor = new PropertyDescriptor(methodDefinition.Closure, true, enumerable, true);
                        agent.DefinePropertyOrThrow(obj, methodDefinition.Key, descriptor);
                    }
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static ScriptValue TypeofEvaluation(Agent agent, ValueReference argument)
        {
            //https://tc39.github.io/ecma262/#sec-typeof-operator-runtime-semantics-evaluation

            if (argument.IsReference && argument.Reference.IsUnresolvableReference)
            {
                return "undefined";
            }

            var value = agent.GetValue(argument);
            switch (value.ValueType)
            {
                case ScriptValue.Type.Undefined:
                    return "undefined";
                case ScriptValue.Type.Null:
                    return "object";
                case ScriptValue.Type.Boolean:
                    return "boolean";
                case ScriptValue.Type.Number:
                    return "number";
                case ScriptValue.Type.String:
                    return "string";
                case ScriptValue.Type.Symbol:
                    return "symbol";
                case ScriptValue.Type.Object:
                    return ((ScriptObject)value).TypeOf;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static void FunctionIteratorBindingInitialisation([NotNull] Agent agent, [NotNull] IEnumerable<ExpressionNode> formalParameters, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-runtime-semantics-iteratorbindinginitialization
            foreach (var formalParameter in formalParameters)
            {
                FunctionIteratorBindingInitialisation(agent, formalParameter, ref iteratorRecord, environment);
            }
        }

        private static void FunctionIteratorBindingInitialisation([NotNull] Agent agent, [NotNull] ExpressionNode formalParameter, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-runtime-semantics-iteratorbindinginitialization
            switch (formalParameter)
            {
                case RestElementNode restElement:
                    IteratorBindingInitialisationRest(agent, restElement.Argument, ref iteratorRecord, environment);
                    break;

                case AssignmentPatternNode assignmentPattern:
                {
                    var currentContext = agent.RunningExecutionContext;
                    var originalEnvironment = currentContext.VariableEnvironment;
                    Debug.Assert(currentContext.VariableEnvironment == currentContext.LexicalEnvironment);
                    Debug.Assert(environment == originalEnvironment);
                    var paramVariableEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(agent, originalEnvironment);
                    currentContext.VariableEnvironment = paramVariableEnvironment;
                    currentContext.LexicalEnvironment = paramVariableEnvironment;
                    try
                    {
                        switch (assignmentPattern.Left)
                        {
                            case ArrayPatternNode _:
                            case ObjectPatternNode _:
                                IteratorBindingInitialisationBindingPattern(agent, assignmentPattern.Left, assignmentPattern.Right, ref iteratorRecord, environment);
                                break;

                            case IdentifierNode identifier:
                                IteratorBindingInitialisationSingleName(agent, identifier.Name, assignmentPattern.Right, ref iteratorRecord, environment);
                                break;

                            default:
                                throw new NotImplementedException();
                        }
                    }
                    finally
                    {
                        currentContext.VariableEnvironment = originalEnvironment;
                        currentContext.LexicalEnvironment = originalEnvironment;
                    }

                    break;
                }

                case ArrayPatternNode _:
                case ObjectPatternNode _:
                    IteratorBindingInitialisationBindingPattern(agent, formalParameter, null, ref iteratorRecord, environment);
                    break;

                case IdentifierNode identifier:
                    IteratorBindingInitialisationSingleName(agent, identifier.Name, null, ref iteratorRecord, environment);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private static void IteratorBindingInitialisationBindingPattern([NotNull] Agent agent, [NotNull] ExpressionNode formalParameter, [CanBeNull] BaseNode initialiser, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, [NotNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-iteratorbindinginitialization

            var value = ScriptValue.Undefined;
            if (!iteratorRecord.Done)
            {
                ScriptValue next;
                try
                {
                    next = agent.IteratorStep(iteratorRecord);
                }
                catch (ScriptException)
                {
                    iteratorRecord.Done = true;
                    throw;
                }

                if (next.IsBoolean && !(bool)next)
                {
                    iteratorRecord.Done = true;
                }
                else
                {
                    try
                    {
                        value = Agent.IteratorValue((ScriptObject)next);
                    }
                    catch (ScriptException)
                    {
                        iteratorRecord.Done = true;
                        throw;
                    }
                }
            }

            if (initialiser != null && value == ScriptValue.Undefined)
            {
                var defaultValue = Walk(initialiser, agent.RunningExecutionContext);
                value = agent.GetValue(defaultValue);
            }

            BindingInitialisation(agent, formalParameter, value, environment);
        }

        private static void IteratorBindingInitialisationRest([NotNull] Agent agent, [NotNull] ExpressionNode restArgument, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, [CanBeNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-iteratorbindinginitialization

            var array = ArrayIntrinsics.ArrayCreate(agent, 0);

            var isPattern = !(restArgument is IdentifierNode);
            Reference lhs = default;
            if (!isPattern)
            {
                lhs = agent.ResolveBinding(((IdentifierNode)restArgument).Name, environment);
            }

            for (var i = 0;; i++)
            {
                ScriptValue next = default;
                if (!iteratorRecord.Done)
                {
                    try
                    {
                        next = agent.IteratorStep(iteratorRecord);
                    }
                    catch(ScriptException)
                    {
                        iteratorRecord.Done = true;
                        throw;
                    }

                    if (next.IsBoolean && !(bool)next)
                    {
                        iteratorRecord.Done = true;
                    }
                }

                if (iteratorRecord.Done)
                {
                    if (isPattern)
                    {
                        BindingInitialisation(agent, restArgument, array, environment);
                    }
                    else
                    {
                        if (environment == null)
                        {
                            agent.PutValue(lhs, array);
                            return;
                        }

                        Agent.InitialiseReferencedBinding(lhs, array);
                    }
                    return;
                }

                ScriptValue nextValue;
                try
                {
                    nextValue = Agent.IteratorValue((ScriptObject)next);
                }
                catch(ScriptException)
                {
                    iteratorRecord.Done = true;
                    throw;
                }

                var status = array.CreateDataProperty(i.ToString(), nextValue);
                Debug.Assert(status);
            }
        }

        private static void IteratorBindingInitialisationSingleName([NotNull] Agent agent, [NotNull] string bindingId, [CanBeNull] ExpressionNode initialiser, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, [CanBeNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-iteratorbindinginitialization
            var lhs = agent.ResolveBinding(bindingId, environment);
            var value = ScriptValue.Undefined;
            if (!iteratorRecord.Done)
            {
                ScriptValue next;
                try
                {
                    next = agent.IteratorStep(iteratorRecord);
                }
                catch (ScriptException)
                {
                    iteratorRecord.Done = true;
                    throw;
                }

                if (next.IsBoolean && !(bool)next)
                {
                    iteratorRecord.Done = true;
                }
                else
                {
                    try
                    {
                        value = Agent.IteratorValue((ScriptObject)next);
                    }
                    catch (ScriptException)
                    {
                        iteratorRecord.Done = true;
                        throw;
                    }
                }
            }

            if (iteratorRecord.Done)
            {
                value = ScriptValue.Undefined;
            }

            if (initialiser != null && value == ScriptValue.Undefined)
            {
                var defaultValue = Walk(initialiser, agent.RunningExecutionContext);
                value = agent.GetValue(defaultValue);
                if (IsAnonymousFunctionDefinition(initialiser))
                {
                    var hasNameProperty = value.HasOwnProperty("name");
                    if (!hasNameProperty)
                    {
                        agent.SetFunctionName((ScriptObject)value, bindingId);
                    }
                }
            }

            if (environment == null)
            {
                agent.PutValue(lhs, value);
            }
            else
            {
                Agent.InitialiseReferencedBinding(lhs, value);
            }
        }

        private static void KeyedBindingInitialisationBinding([NotNull] Agent agent, [NotNull] ExpressionNode bindingPattern, [CanBeNull] ExpressionNode initialiser, ScriptValue value, [NotNull] LexicalEnvironment environment, ScriptValue propertyName)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-keyedbindinginitialization
            value = agent.GetValue(value, propertyName);
            if (initialiser != null && value == ScriptValue.Undefined)
            {
                var defaultValue = Walk(initialiser, agent.RunningExecutionContext);
                value = agent.GetValue(defaultValue);
            }

            BindingInitialisation(agent, bindingPattern, value, environment);
        }

        private static void KeyedBindingInitialisationSingle([NotNull] Agent agent, [NotNull] IdentifierNode identifier, [CanBeNull] ExpressionNode initialiser, ScriptValue value, [CanBeNull] LexicalEnvironment environment, ScriptValue propertyName)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-keyedbindinginitialization
            var bindingIdentifier = identifier.Name;
            var lhs = agent.ResolveBinding(bindingIdentifier, environment);
            value = agent.GetValue(value, propertyName);
            if (initialiser != null && value == ScriptValue.Undefined)
            {
                var defaultValue = Walk(initialiser, agent.RunningExecutionContext);
                value = agent.GetValue(defaultValue);

                if (IsAnonymousFunctionDefinition(initialiser))
                {
                    var hasNameProperty = value.HasOwnProperty("name");
                    if (!hasNameProperty)
                    {
                        agent.SetFunctionName((ScriptObject)value, bindingIdentifier);
                    }
                }
            }

            if (environment == null)
            {
                agent.PutValue(lhs, value);
            }
            else
            {
                Agent.InitialiseReferencedBinding(lhs, value);
            }
        }

        private static void KeyedBindingInitialisation([NotNull] Agent agent, [NotNull] ExpressionNode bindingElement, ScriptValue value, [NotNull] LexicalEnvironment environment, ScriptValue propertyName)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-keyedbindinginitialization
            ExpressionNode left;
            ExpressionNode right;

            if (bindingElement is AssignmentPatternNode assignmentPattern)
            {
                left = assignmentPattern.Left;
                right = assignmentPattern.Right;
            }
            else
            {
                left = bindingElement;
                right = null;
            }

            if (left is IdentifierNode identifier)
            {
                KeyedBindingInitialisationSingle(agent, identifier, right, value, environment, propertyName);
            }
            else
            {
                KeyedBindingInitialisationBinding(agent, left, right, value, environment, propertyName);
            }
        }

        private static void SuperCall([NotNull] IEnumerable<ExpressionNode> arguments, [NotNull] ExecutionContext context)
        {
            //https://tc39.github.io/ecma262/#sec-super-keyword-runtime-semantics-evaluation
            var newTarget = context.GetNewTarget();
            Debug.Assert(newTarget.IsObject);

            //https://tc39.github.io/ecma262/#sec-getsuperconstructor
            var environmentRecord = context.GetThisEnvironment();
            Debug.Assert(environmentRecord is FunctionEnvironment);
            var functionRecord = (FunctionEnvironment)environmentRecord;
            var activeFunction = functionRecord.FunctionObject;
            var function = activeFunction.GetPrototypeOf();
            if (!Agent.IsConstructor(function))
            {
                throw context.Realm.Agent.CreateTypeError();
            }

            var argumentList = ArgumentListEvaluation(arguments, context);
            var result = Agent.Construct(function, argumentList, (ScriptObject)newTarget);
            functionRecord.BindThisValue(result);
        }


        private static ScriptValue Addition(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-addition-operator-plus-runtime-semantics-evaluation
            var leftPrimitive = agent.ToPrimitive(left);
            var rightPrimitive = agent.ToPrimitive(right);

            if (leftPrimitive.IsString || rightPrimitive.IsString)
            {
                var leftString = agent.ToString(leftPrimitive);
                var rightString = agent.ToString(rightPrimitive);
                return leftString + rightString;
            }

            var leftNumber = agent.ToNumber(leftPrimitive);
            var rightNumber = agent.ToNumber(rightPrimitive);
            return leftNumber + rightNumber;
        }

        private static ScriptValue Subtraction(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-subtraction-operator-minus-runtime-semantics-evaluation
            var leftNumber = agent.ToNumber(left);
            var rightNumber = agent.ToNumber(right);

            return leftNumber - rightNumber;
        }

        private static ScriptValue Multiplication(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-multiplicative-operators-runtime-semantics-evaluation
            var leftNumber = agent.ToNumber(left);
            var rightNumber = agent.ToNumber(right);

            return leftNumber * rightNumber;
        }

        private static ScriptValue Division(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-multiplicative-operators-runtime-semantics-evaluation
            var leftNumber = agent.ToNumber(left);
            var rightNumber = agent.ToNumber(right);

            return leftNumber / rightNumber;
        }

        private static ScriptValue Modulus(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-multiplicative-operators-runtime-semantics-evaluation
            var leftNumber = agent.ToNumber(left);
            var rightNumber = agent.ToNumber(right);

            return leftNumber % rightNumber;
        }

        internal static ScriptValue Exponentiation(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-exp-operator-runtime-semantics-evaluation
            var leftNumber = agent.ToNumber(left);
            var rightNumber = agent.ToNumber(right);

            if (double.IsNaN(leftNumber) && rightNumber == 0)
            {
                return 1;
            }

            if (leftNumber == 1 && double.IsInfinity(rightNumber))
            {
                return double.NaN;
            }

            return Math.Pow(leftNumber, rightNumber);
        }

        private static ScriptValue LeftShift(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-left-shift-operator-runtime-semantics-evaluation
            var leftNumber = agent.ToInt32(left);
            var rightNumber = agent.ToUint32(right);
            var shiftCount = (int)(rightNumber & 0x1F);
            return leftNumber << shiftCount;
        }

        private static ScriptValue RightShift(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-signed-right-shift-operator-runtime-semantics-evaluation
            var leftNumber = agent.ToInt32(left);
            var rightNumber = agent.ToUint32(right);
            var shiftCount = (int)(rightNumber & 0x1F);
            return leftNumber >> shiftCount;
        }

        private static ScriptValue RightShiftUnsigned(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-unsigned-right-shift-operator-runtime-semantics-evaluation
            var leftNumber = agent.ToUint32(left);
            var rightNumber = agent.ToUint32(right);
            var shiftCount = (int)(rightNumber & 0x1F);
            return leftNumber >> shiftCount;
        }

        private static ScriptValue BitwiseAnd(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-binary-bitwise-operators-runtime-semantics-evaluation
            var leftNumber = agent.ToInt32(left);
            var rightNumber = agent.ToInt32(right);

            return leftNumber & rightNumber;
        }

        private static ScriptValue BitwiseOr(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-binary-bitwise-operators-runtime-semantics-evaluation
            var leftNumber = agent.ToInt32(left);
            var rightNumber = agent.ToInt32(right);

            return leftNumber | rightNumber;
        }

        private static ScriptValue BitwiseXOr(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-binary-bitwise-operators-runtime-semantics-evaluation
            var leftNumber = agent.ToInt32(left);
            var rightNumber = agent.ToInt32(right);

            return leftNumber ^ rightNumber;
        }

        private static ScriptValue LessThan(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            var result = agent.AbstractRelationalComparison(left, right);
            return result == ScriptValue.Undefined ? false : result;
        }

        private static ScriptValue LessEquals(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            var result = agent.AbstractRelationalComparison(right, left, false);
            return result != ScriptValue.Undefined && result != true;
        }

        private static ScriptValue GreaterThan(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            var result = agent.AbstractRelationalComparison(right, left, false);
            return result == ScriptValue.Undefined ? false : result;
        }

        private static ScriptValue GreaterEquals(ScriptValue left, ScriptValue right, [NotNull] Agent agent)
        {
            var result = agent.AbstractRelationalComparison(left, right);
            return result != ScriptValue.Undefined && result != true;
        }

        private static ScriptValue InOperator(ScriptValue leftValue, ScriptValue rightValue, [NotNull] Agent agent)
        {
            if (!rightValue.IsObject)
            {
                throw agent.CreateTypeError();
            }

            return rightValue.HasProperty(agent.ToPropertyKey(leftValue));
        }

        private static ScriptValue InstanceOfOperator(ScriptValue value, ScriptValue target, [NotNull] Agent agent)
        {
            //https://tc39.github.io/ecma262/#sec-instanceofoperator
            if (!target.IsObject)
            {
                throw agent.CreateTypeError();
            }

            var instanceOfHandler = agent.GetMethod(target, Symbol.HasInstance);
            if (instanceOfHandler != ScriptValue.Undefined)
            {
                return Agent.RealToBoolean(agent.Call(instanceOfHandler, target, value));
            }

            if (Agent.IsCallable(target))
            {
                throw agent.CreateTypeError();
            }

            throw new NotImplementedException();
//            return agent.OrdinaryHasInstance(target, value);
        }
    }
}