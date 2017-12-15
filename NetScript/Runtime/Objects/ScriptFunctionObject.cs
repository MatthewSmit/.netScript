using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Walkers;

namespace NetScript.Runtime.Objects
{
    public sealed class ScriptFunctionObject : ScriptObject
    {
        [CanBeNull] private readonly Func<ScriptArguments, ScriptValue> callback;

        internal ScriptFunctionObject([NotNull] Agent agent, [CanBeNull] ScriptObject prototype, bool extensible, [NotNull] Realm realm, [NotNull] Func<ScriptArguments, ScriptValue> callback, ConstructorKind constructorKind = ConstructorKind.None) :
            base(agent, prototype, extensible, SpecialObjectType.None)
        {
            Realm = realm;
            this.callback = callback;
            FunctionKind = FunctionKind.Normal;
            ConstructorKind = constructorKind;
        }

        internal ScriptFunctionObject([NotNull] Agent agent, [NotNull] ScriptObject prototype, bool extensible, [NotNull] Realm realm, FunctionKind functionKind, ConstructorKind constructorKind, bool strict) :
            base(agent, prototype, extensible, SpecialObjectType.None)
        {
            Realm = realm;
            FunctionKind = functionKind;
            ConstructorKind = constructorKind;
            Strict = strict;
        }

        internal override ScriptValue Call(ScriptValue thisArgument, IReadOnlyList<ScriptValue> arguments)
        {
            //https://tc39.github.io/ecma262/#sec-ecmascript-function-objects-call-thisargument-argumentslist
            if (FunctionKind == FunctionKind.ClassConstructor)
            {
                throw Agent.CreateTypeError();
            }

            if (callback != null)
            {
                return callback(new ScriptArguments(this, thisArgument, default, arguments));
            }

            var callerContext = Agent.RunningExecutionContext;
            var calleeContext = PrepareForOrdinaryCall(null);
            Debug.Assert(calleeContext == Agent.RunningExecutionContext);
            OrdinaryCallBindThis(calleeContext, thisArgument);

            ScriptValue result;
            try
            {
                result = OrdinaryCallEvaluateBody(arguments);
            }
            catch (ReturnException e)
            {
                result = e.Value;
            }
            finally
            {
                Agent.PopCalleeContext();
            }
            Debug.Assert(Agent.RunningExecutionContext == callerContext);
            return result;
        }

        internal override ScriptValue Construct(IReadOnlyList<ScriptValue> arguments, ScriptObject newTarget)
        {
            //https://tc39.github.io/ecma262/#sec-ecmascript-function-objects-construct-argumentslist-newtarget
            Debug.Assert(ConstructorKind != ConstructorKind.None);

            if (callback != null)
            {
                return callback(new ScriptArguments(this, default, newTarget, arguments));
            }

            var callerContext = Agent.RunningExecutionContext;
            ScriptObject thisArgument = null;
            if (ConstructorKind == ConstructorKind.Base)
            {
                thisArgument = Agent.OrdinaryCreateFromConstructor(newTarget, Agent.Realm.ObjectPrototype);
            }

            var calleeContext = PrepareForOrdinaryCall(newTarget);
            Debug.Assert(calleeContext == Agent.RunningExecutionContext);

            if (ConstructorKind == ConstructorKind.Base)
            {
                OrdinaryCallBindThis(calleeContext, thisArgument);
            }

            var constructorEnvironment = calleeContext.LexicalEnvironment;
            var environmentRecord = (FunctionEnvironment)constructorEnvironment.Environment;

            ScriptValue result;
            try
            {
                result = OrdinaryCallEvaluateBody(arguments);
            }
            catch (ReturnException e)
            {
                result = e.Value;
                if (result.IsObject)
                {
                    return result;
                }

                if (ConstructorKind == ConstructorKind.Base)
                {
                    return thisArgument;
                }

                if (result != ScriptValue.Undefined)
                {
                    throw Agent.CreateTypeError();
                }
            }
            finally
            {
                Agent.PopCalleeContext();
            }
            Debug.Assert(Agent.RunningExecutionContext == callerContext);
            return environmentRecord.GetThisBinding();
        }

        private ScriptValue OrdinaryCallEvaluateBody(IReadOnlyList<ScriptValue> arguments)
        {
            if (FunctionKind == FunctionKind.Generator)
            {
                //https://tc39.github.io/ecma262/#sec-generator-function-definitions-runtime-semantics-evaluatebody
                throw new NotImplementedException();
            }
            else if (FunctionKind == FunctionKind.Async)
            {
                //https://tc39.github.io/ecma262/#sec-async-function-definitions-EvaluateBody
                var promiseCapability = Agent.NewPromiseCapability(Realm.Promise);
                //Let declResult be FunctionDeclarationInstantiation(functionObject, argumentsList).
                //If declResult is not an abrupt completion, then
                //    Perform ! AsyncFunctionStart(promiseCapability, FunctionBody).
                //Else declResult is an abrupt completion,
                //    Perform ! Call(promiseCapability.[[Reject]], undefined, «declResult.[[Value]]»).
                //Return Completion{[[Type]]: return, [[Value]]: promiseCapability.[[Promise]], [[Target]]: empty}.
                throw new NotImplementedException();
            }
            else
            {
                //https://tc39.github.io/ecma262/#sec-function-definitions-runtime-semantics-evaluatebody
                FunctionDeclarationInstantiation(arguments);
                return ECMAScriptCode.Run(Agent.RunningExecutionContext);
            }
        }

        private void BindingInitialisation([NotNull] ExpressionNode formalParameter, ScriptValue value, [NotNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-bindinginitialization

            if (formalParameter is ArrayPatternNode arrayPattern)
            {
                var iteratorRecord = Agent.GetIterator(value);
                try
                {
                    IteratorBindingInitialisation(arrayPattern.Elements, ref iteratorRecord, environment);
                }
                catch (ScriptException)
                {
                    if (!iteratorRecord.Done)
                    {
                        Agent.IteratorClose(iteratorRecord);
                    }
                    throw;
                }
                if (!iteratorRecord.Done)
                {
                    Agent.IteratorClose(iteratorRecord);
                }
            }
            else if (formalParameter is ObjectPatternNode objectPattern)
            {
                Agent.RequireObjectCoercible(value);
                foreach (var property in objectPattern.Properties)
                {
                    var name = property.Computed ? Agent.GetValue(EvaluateWalker.Walk(property.Key, Agent.RunningExecutionContext)) : ((IdentifierNode)property.Key).Name;
                    if (((AssignmentPatternNode)property.Value).Left is IdentifierNode)
                    {
                        KeyedBindingInitialisationSingle((AssignmentPatternNode)property.Value, value, environment, name);
                    }
                    else
                    {
                        KeyedBindingInitialisationBinding((AssignmentPatternNode)property.Value, value, environment, name);
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void FunctionDeclarationInstantiation(IReadOnlyList<ScriptValue> arguments)
        {
            //https://tc39.github.io/ecma262/#sec-functiondeclarationinstantiation
            var calleeContext = Agent.RunningExecutionContext;
            var environment = calleeContext.LexicalEnvironment;
            var environmentRecord = environment.Environment;
            var parameterNames = BoundNamesWalker.Walk(FormalParameters);
            var hasDuplicates = new HashSet<string>(parameterNames).Count != parameterNames.Count;
            var simpleParameterList = IsSimpleParameterList(FormalParameters);
            var hasParameterExpressions = ContainsExpression(FormalParameters);
            var variableNames = ECMAScriptCode.VariableNames;
            var variableDeclarations = ECMAScriptCode.VariableDeclarations;
            var lexicalNames = ECMAScriptCode.LexicalNames;
            var functionNames = new HashSet<string>();
            var functionsToInitialise = new List<IDeclaration>();
            foreach (var declaration in variableDeclarations.Reverse())
            {
                if (!declaration.IsVariable)
                {
                    Debug.Assert(declaration.IsFunction);
                    var functionName = declaration.BoundNames.Single();
                    if (!functionNames.Contains(functionName))
                    {
                        functionNames.Add(functionName);
                        //NOTE: If there are multiple function declarations for the same name, the last declaration is used.
                        functionsToInitialise.Add(declaration);
                    }
                }
            }

            var argumentsObjectNeeded = true;
            if (ThisMode == ThisMode.Lexical)
            {
                //NOTE: Arrow functions never have an arguments objects.
                argumentsObjectNeeded = false;
            }
            else if (parameterNames.Contains("arguments"))
            {
                argumentsObjectNeeded = false;
            }
            else if (!hasParameterExpressions)
            {
                if (functionNames.Contains("arguments") || lexicalNames.Contains("arguments"))
                {
                    argumentsObjectNeeded = false;
                }
            }

            foreach (var parameterName in parameterNames)
            {
                var alreadyDeclared = environmentRecord.HasBinding(parameterName);
                //NOTE: Early errors ensure that duplicate parameter names can only occur in non-strict functions that do not have parameter default values or rest parameters.
                if (!alreadyDeclared)
                {
                    environmentRecord.CreateMutableBinding(parameterName, false);
                    if (hasDuplicates)
                    {
                        environmentRecord.InitialiseBinding(parameterName, ScriptValue.Undefined);
                    }
                }
            }

            var parameterBindings = parameterNames;

            if (argumentsObjectNeeded)
            {
                ScriptObject argumentObject;
                if (Strict || !simpleParameterList)
                {
                    argumentObject = CreateUnmappedArgumentsObject(arguments);
                }
                else
                {
                    //NOTE: mapped argument object is only provided for non-strict functions that don't have a rest parameter, any parameter default value initializers, or any destructured parameters.
                    argumentObject = CreateMappedArgumentsObject(FormalParameters, arguments, environmentRecord);
                }

                if (Strict)
                {
                    environmentRecord.CreateImmutableBinding("arguments", false);
                }
                else
                {
                    environmentRecord.CreateMutableBinding("arguments", false);
                }
                environmentRecord.InitialiseBinding("arguments", argumentObject);

                var list = new List<string>();
                list.AddRange(parameterBindings);
                list.Add("arguments");
                parameterBindings = list;
            }

            var iteratorRecord = Agent.CreateListIteratorRecord(arguments);
            if (hasDuplicates)
            {
                IteratorBindingInitialisation(FormalParameters, ref iteratorRecord, null);
            }
            else
            {
                IteratorBindingInitialisation(FormalParameters, ref iteratorRecord, environment);
            }

            LexicalEnvironment variableEnvironment;
            BaseEnvironment variableEnvironmentRecord;

            if (!hasParameterExpressions)
            {
                //NOTE: Only a single lexical environment is needed for the parameters and top-level vars.
                var instantiatedVarNames = new HashSet<string>(parameterBindings);
                foreach (var name in variableNames)
                {
                    if (!instantiatedVarNames.Contains(name))
                    {
                        instantiatedVarNames.Add(name);
                        environmentRecord.CreateMutableBinding(name, false);
                        environmentRecord.InitialiseBinding(name, ScriptValue.Undefined);
                    }
                }

                variableEnvironment = environment;
                variableEnvironmentRecord = environmentRecord;
            }
            else
            {
                //NOTE: A separate Environment Record is needed to ensure that closures created by expressions in the formal parameter list do not have visibility of declarations in the function body.
                variableEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(Agent, environment);
                variableEnvironmentRecord = variableEnvironment.Environment;
                calleeContext.VariableEnvironment = variableEnvironment;
                var instantiatedVarNames = new HashSet<string>();
                foreach (var name in variableNames)
                {
                    if (!instantiatedVarNames.Contains(name))
                    {
                        //Append n to instantiatedVarNames.
                        //Perform ! varEnvRec.CreateMutableBinding(n, false).
                        //If n is not an element of parameterBindings or if n is an element of functionNames, let initialValue be undefined.
                        //Else,
                        //    Let initialValue be ! envRec.GetBindingValue(n, false).
                        //Call varEnvRec.InitializeBinding(n, initialValue).
                        //NOTE: vars whose names are the same as a formal parameter, initially have the same value as the corresponding initialized parameter.
                        throw new NotImplementedException();
                    }
                }
            }

            //NOTE: Annex B.3.3.1 adds additional steps at this point.

            LexicalEnvironment lexicalEnvironment;
            if (!Strict)
            {
                lexicalEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(Agent, variableEnvironment);
                //NOTE: Non-strict functions use a separate lexical Environment Record for top-level lexical declarations so that a direct eval can determine whether any var scoped declarations introduced by the eval code conflict with pre-existing top-level lexically scoped declarations. This is not needed for strict functions because a strict direct eval always places all declarations into a new Environment Record.
            }
            else lexicalEnvironment = variableEnvironment;

            var lexicalEnvironmentRecord = lexicalEnvironment.Environment;
            calleeContext.LexicalEnvironment = lexicalEnvironment;

            var lexicalDeclarations = ECMAScriptCode.LexicalDeclarations;
            foreach (var declaration in lexicalDeclarations)
            {
                //NOTE: A lexically declared name cannot be the same as a function/generator declaration, formal parameter, or a var name. Lexically declared names are only instantiated here but not initialized.
                foreach (var declaredName in declaration.BoundNames)
                {
                    if (declaration.IsConstant)
                    {
                        lexicalEnvironmentRecord.CreateImmutableBinding(declaredName, true);
                    }
                    else
                    {
                        lexicalEnvironmentRecord.CreateMutableBinding(declaredName, false);
                    }
                }
            }

            foreach (var function in functionsToInitialise)
            {
                var functionName = function.BoundNames.Single();
                var functionObject = function.InstantiateFunctionObject(Agent, lexicalEnvironment);
                variableEnvironmentRecord.SetMutableBinding(functionName, functionObject, false);
            }
        }

        private void IteratorBindingInitialisation([NotNull] IEnumerable<ExpressionNode> formalParameters, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-runtime-semantics-iteratorbindinginitialization
            foreach (var formalParameter in formalParameters)
            {
                IteratorBindingInitialisation(formalParameter, ref iteratorRecord, environment);
            }
        }

        private void IteratorBindingInitialisation([NotNull] ExpressionNode formalParameter, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-runtime-semantics-iteratorbindinginitialization
            switch (formalParameter)
            {
                case RestElementNode restElement:
                    IteratorBindingInitialisationRest(restElement.Argument, ref iteratorRecord, environment);
                    break;

                case AssignmentPatternNode assignmentPattern:
                {
                    var currentContext = Agent.RunningExecutionContext;
                    var originalEnvironment = currentContext.VariableEnvironment;
                    Debug.Assert(currentContext.VariableEnvironment == currentContext.LexicalEnvironment);
                    Debug.Assert(environment == originalEnvironment);
                    var paramVariableEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(Agent, originalEnvironment);
                    currentContext.VariableEnvironment = paramVariableEnvironment;
                    currentContext.LexicalEnvironment = paramVariableEnvironment;
                    try
                    {
                        switch (assignmentPattern.Left)
                        {
                            case ArrayPatternNode _:
                            case ObjectPatternNode _:
                                IteratorBindingInitialisationBindingPattern(assignmentPattern.Left, assignmentPattern.Right, ref iteratorRecord, environment);
                                break;

                            case IdentifierNode identifier:
                                IteratorBindingInitialisationSingleName(identifier.Name, assignmentPattern.Right, ref iteratorRecord, environment);
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
                    IteratorBindingInitialisationBindingPattern(formalParameter, null, ref iteratorRecord, environment);
                    break;

                case IdentifierNode identifier:
                    IteratorBindingInitialisationSingleName(identifier.Name, null, ref iteratorRecord, environment);
                    break;

                default:
                    throw new NotImplementedException();
            }

//            switch (formalParameter)
//            {
//                case ArrayPatternNode arrayPattern:
//                    foreach (var element in arrayPattern.Elements)
//                    {
//                        IteratorBindingInitialisation(element, ref iteratorRecord, environment);
//                    }
//                    break;
//
//                case AssignmentPatternNode assignmentPattern:
//                {
//                    //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-iteratorbindinginitialization
//                    if (assignmentPattern.Left is IdentifierNode identifier)
//                    {
//                        IteratorBindingInitialisationSingleName(identifier.Name, assignmentPattern.Right, ref iteratorRecord, environment);
//                    }
//                    else
//                    {
//                        throw new NotImplementedException();
//                    }
//                    break;
//                }
//
//                case RestElementNode restElement:
//                    IteratorBindingInitialisationRest(restElement.Argument, ref iteratorRecord, environment);
//                    break;
//
//                case ObjectPatternNode objectPattern:
//                    foreach (var property in objectPattern.Properties)
//                    {
//                        throw new NotImplementedException();
//                    }
//
//                    break;
//
//                default:
//                    throw new NotImplementedException();
//            }
        }

        private void IteratorBindingInitialisationBindingPattern([NotNull] ExpressionNode formalParameter, [CanBeNull] BaseNode initialiser, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, [NotNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-iteratorbindinginitialization

            var value = ScriptValue.Undefined;
            if (!iteratorRecord.Done)
            {
                ScriptValue next;
                try
                {
                    next = Agent.IteratorStep(iteratorRecord);
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
                var defaultValue = EvaluateWalker.Walk(initialiser, Agent.RunningExecutionContext);
                value = Agent.GetValue(defaultValue);
            }

            BindingInitialisation(formalParameter, value, environment);
        }

        private void IteratorBindingInitialisationRest([NotNull] ExpressionNode restArgument, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, [CanBeNull] LexicalEnvironment environment)
        {
            if (restArgument is IdentifierNode identifier)
            {
                var lhs = Agent.ResolveBinding(identifier.Name, environment);
                var array = Agent.ArrayCreate(0);

                for (var i = 0;; i++)
                {
                    ScriptValue next = default;
                    if (!iteratorRecord.Done)
                    {
                        try
                        {
                            next = Agent.IteratorStep(iteratorRecord);
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
                        if (environment == null)
                        {
                            Agent.PutValue(lhs, array);
                            return;
                        }

                        Agent.InitialiseReferencedBinding(lhs, array);
                        return;
                    }

                    ScriptValue nextValue;
                    try
                    {
                        nextValue = Agent.IteratorValue((ScriptObject)next);
                    }
                    catch (ScriptException)
                    {
                        iteratorRecord.Done = true;
                        throw;
                    }

                    var status = array.CreateDataProperty(i.ToString(), nextValue);
                    Debug.Assert(status);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void IteratorBindingInitialisationSingleName([NotNull] string bindingId, [CanBeNull] ExpressionNode initialiser, ref (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, [CanBeNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-destructuring-binding-patterns-runtime-semantics-iteratorbindinginitialization
            var lhs = Agent.ResolveBinding(bindingId, environment);
            var value = ScriptValue.Undefined;
            if (!iteratorRecord.Done)
            {
                ScriptValue next;
                try
                {
                    next = Agent.IteratorStep(iteratorRecord);
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
                var defaultValue = EvaluateWalker.Walk(initialiser, Agent.RunningExecutionContext);
                value = Agent.GetValue(defaultValue);
                if (EvaluateWalker.IsAnonymousFunctionDefinition(initialiser))
                {
                    var hasNameProperty = value.HasOwnProperty("name");
                    if (!hasNameProperty) Agent.SetFunctionName((ScriptObject)value, bindingId);
                }
            }

            if (environment == null)
            {
                Agent.PutValue(lhs, value);
            }
            else
            {
                Agent.InitialiseReferencedBinding(lhs, value);
            }
        }

        private void KeyedBindingInitialisationBinding([NotNull] AssignmentPatternNode property, ScriptValue value, [NotNull] LexicalEnvironment environment, ScriptValue propertyName)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-keyedbindinginitialization
            value = Agent.GetValue(value, propertyName);
            if (property.Right != null && value == ScriptValue.Undefined)
            {
                var defaultValue = EvaluateWalker.Walk(property.Right, Agent.RunningExecutionContext);
                value = Agent.GetValue(defaultValue);
            }

            BindingInitialisation(property.Left, value, environment);
        }

        private void KeyedBindingInitialisationSingle([NotNull] AssignmentPatternNode property, ScriptValue value, [CanBeNull] LexicalEnvironment environment, ScriptValue propertyName)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-keyedbindinginitialization
            var bindingIdentifier = ((IdentifierNode)property.Left).Name;
            var lhs = Agent.ResolveBinding(bindingIdentifier, environment);
            value = Agent.GetValue(value, propertyName);
            if (property.Right != null && value == ScriptValue.Undefined)
            {
                var defaultValue = EvaluateWalker.Walk(property.Right, Agent.RunningExecutionContext);
                value = Agent.GetValue(defaultValue);

                if (EvaluateWalker.IsAnonymousFunctionDefinition(property.Right))
                {
                    var hasNameProperty = value.HasOwnProperty("name");
                    if (!hasNameProperty)
                    {
                        Agent.SetFunctionName((ScriptObject)value, bindingIdentifier);
                    }
                }
            }

            if (environment == null)
            {
                Agent.PutValue(lhs, value);
            }
            else
            {
                Agent.InitialiseReferencedBinding(lhs, value);
            }
        }

        [NotNull]
        private ScriptObject CreateUnmappedArgumentsObject([NotNull] IReadOnlyList<ScriptValue> arguments)
        {
            //https://tc39.github.io/ecma262/#sec-createunmappedargumentsobject
            var length = arguments.Count;
            var obj = Agent.ObjectCreate(Realm.ObjectPrototype, SpecialObjectType.Parameter);
            Agent.DefinePropertyOrThrow(obj, "length", new PropertyDescriptor(length, true, false, true));
            for (var i = 0; i < length; i++)
            {
                obj.CreateDataProperty(i.ToString(), arguments[i]);
            }
            Agent.DefinePropertyOrThrow(obj, Realm.SymbolIterator, new PropertyDescriptor(Realm.ArrayProtoValues, true, false, true));
            Agent.DefinePropertyOrThrow(obj, "callee", new PropertyDescriptor(Realm.ThrowTypeError, Realm.ThrowTypeError, false, false));
            return obj;
        }

        [NotNull]
        private ScriptObject CreateMappedArgumentsObject([NotNull] IEnumerable<ExpressionNode> formalParameters, [NotNull] IReadOnlyList<ScriptValue> argumentsList, BaseEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-createmappedargumentsobject
            var length = argumentsList.Count;
            var obj = new ScriptArgumentsObject(Agent, Agent.RunningExecutionContext.Realm.ObjectPrototype, true);
            var map = Agent.ObjectCreate(null);
            obj.ParameterMap = map;

            var parameterNames = BoundNamesWalker.Walk(formalParameters);
            var numberOfParameters = parameterNames.Count;
            for (var i = 0; i < length; i++)
            {
                var value = argumentsList[i];
                obj.CreateDataProperty(i.ToString(), value);
            }

            Agent.DefinePropertyOrThrow(obj, "length", new PropertyDescriptor(length, true, false, true));
            var mappedNames = new HashSet<string>();
            for (var i = numberOfParameters - 1; i >= 0; i--)
            {
                var name = parameterNames[i];
                if (!mappedNames.Contains(name))
                {
                    mappedNames.Add(name);
                    if (i < length)
                    {
                        var getter = MakeArgGetter(name, environment);
                        var setter = MakeArgSetter(name, environment);
                        map.DefineOwnProperty(i.ToString(), new PropertyDescriptor(getter, setter, false, true));
                    }
                }
            }

            Agent.DefinePropertyOrThrow(obj, Agent.RunningExecutionContext.Realm.SymbolIterator, new PropertyDescriptor(Agent.RunningExecutionContext.Realm.ArrayProtoValues, true, false, true));
            Agent.DefinePropertyOrThrow(obj, "callee", new PropertyDescriptor(this, true, false, true));
            return obj;
        }

        [NotNull]
        private ScriptFunctionObject MakeArgGetter(string name, BaseEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-makearggetter
            return Agent.CreateBuiltinFunction(Realm, arguments => environment.GetBindingValue(name, false), Realm.FunctionPrototype);
        }

        [NotNull]
        private ScriptFunctionObject MakeArgSetter(string name, BaseEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-makeargsetter
            return Agent.CreateBuiltinFunction(Realm, arguments =>
            {
                environment.SetMutableBinding(name, arguments[0], false);
                return ScriptValue.Undefined;
            }, Realm.FunctionPrototype);
        }

        private static bool ContainsExpression([NotNull] IEnumerable<ExpressionNode> formalParameters)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-static-semantics-containsexpression
            foreach (var formalParameter in formalParameters)
            {
                switch (formalParameter)
                {
                    case AssignmentPatternNode _:
                        return true;

                    case ArrayPatternNode _:
                    case IdentifierNode _:
                        break;

                    case ObjectPatternNode objectPattern:
                        foreach (var property in objectPattern.Properties)
                        {
                            if (property.Computed)
                            {
                                return true;
                            }

                            return true;
                        }

                        break;

                    case RestElementNode restElement:
                        if (restElement.Argument is AssignmentPatternNode)
                        {
                            return true;
                        }
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return false;
        }

        private static bool IsSimpleParameterList([NotNull] IEnumerable<ExpressionNode> formalParameters)
        {
            //https://tc39.github.io/ecma262/#sec-function-definitions-static-semantics-issimpleparameterlist
            foreach (var formalParameter in formalParameters)
            {
                switch (formalParameter)
                {
                    case ArrayPatternNode _:
                    case AssignmentPatternNode _:
                    case ObjectPatternNode _:
                    case RestElementNode _:
                        return false;
                    case IdentifierNode _:
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return true;
        }

        [NotNull]
        private ExecutionContext PrepareForOrdinaryCall(ScriptObject newTarget)
        {
            //https://tc39.github.io/ecma262/#sec-prepareforordinarycall
            var localEnvironment = LexicalEnvironment.NewFunctionEnvironment(this, newTarget);
            var callerContext = Agent.RunningExecutionContext;
            var calleeContext = new ExecutionContext(callerContext.Realm, ScriptOrModule, callerContext.Strict || IsBodyStrict)
            {
                Function = this,
                Realm = Realm,
                ScriptOrModule = ScriptOrModule,
                LexicalEnvironment = localEnvironment,
                VariableEnvironment = localEnvironment
            };

            Agent.PushExecutionContext(calleeContext);
            return calleeContext;
        }

        private void OrdinaryCallBindThis(ExecutionContext calleeContext, ScriptValue thisArgument)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarycallbindthis
            var thisMode = ThisMode;
            if (thisMode == ThisMode.Lexical)
            {
                return;
            }

            var calleeRealm = Realm;
            var localEnvironment = calleeContext.LexicalEnvironment;

            ScriptValue thisValue;
            if (thisMode == ThisMode.Strict)
            {
                thisValue = thisArgument;
            }
            else
            {
                if (thisArgument == ScriptValue.Undefined || thisArgument == ScriptValue.Null)
                {
                    var globalEnvironment = calleeRealm.GlobalEnvironment;
                    var globalEnvironmentRecord = globalEnvironment.Environment;
                    thisValue = ((GlobalEnvironment)globalEnvironmentRecord).GetThisBinding();
                }
                else
                {
                    thisValue = Agent.ToObject(thisArgument);
                }
            }

            var environmentRecord = (FunctionEnvironment)localEnvironment.Environment;
            environmentRecord.BindThisValue(thisValue);
        }

        private bool IsBodyStrict => ECMAScriptCode.IsStrict;

        public override bool IsCallable => true;
        public override bool IsConstructable => ConstructorKind != ConstructorKind.None;

        internal FunctionKind FunctionKind { get; set; }
        internal ConstructorKind ConstructorKind { get; set; }
        internal bool Strict { get; }
        internal LexicalEnvironment Environment { get; set; }
        internal IReadOnlyList<ExpressionNode> FormalParameters { get; set; }
        internal IFunction ECMAScriptCode { get; set; }
        internal ThisMode ThisMode { get; set; }
        internal object ScriptOrModule { get; set; }
        internal ScriptObject HomeObject { get; set; }
        [NotNull]
        public Realm Realm { get; }
    }
}