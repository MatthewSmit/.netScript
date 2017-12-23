using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime.Builtins;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    /// <summary>
    /// Root class for an ECMAScript agent, containing the execution context and job queues.
    /// </summary>
    public sealed partial class Agent
    {
        [NotNull] [ItemNotNull] private readonly List<ExecutionContext> executionContexts = new List<ExecutionContext>();

        [NotNull] [ItemNotNull] private readonly Queue<Job> scriptJobs = new Queue<Job>();
        [NotNull] [ItemNotNull] private readonly Queue<Job> promiseJobs = new Queue<Job>();

        private void EnqueueJob([NotNull] Queue<Job> queue, [NotNull] Func<ScriptValue> callback)
        {
            queue.Enqueue(new Job(callback, RunningExecutionContext.Realm, RunningExecutionContext.ScriptOrModule));
        }

        [NotNull]
        internal IScript ParseScript([NotNull] string source, [CanBeNull] string scriptName, bool strictEval, bool inFunction)
        {
            //https://tc39.github.io/ecma262/#sec-parse-script
            IScript script;
            try
            {
                var result = Acorn.Parse(source, new Options
                {
                    ecmaVersion = 8,
                    SourceFile = scriptName,
                    StartInFunction = inFunction
                });
                script = new NodeScript(result);
            }
            catch (SyntaxError e)
            {
                throw new ScriptException(CreateError(Realm.SyntaxErrorPrototype, e.Message), e);
            }
            script.HandleEarlyErrors(this, strictEval);
            return script;
        }

        [NotNull]
        private IModule ParseModule([NotNull] string source, [CanBeNull] string scriptName)
        {
            //https://tc39.github.io/ecma262/#sec-parsemodule
            IModule module;
            try
            {
                var result = Acorn.Parse(source, new Options
                {
                    ecmaVersion = 8,
                    SourceFile = scriptName,
                    sourceType = SourceType.Module
                });
                module = new NodeModule(result);
            }
            catch (SyntaxError e)
            {
                throw new ScriptException(CreateError(Realm.SyntaxErrorPrototype, e.Message), e);
            }
            module.HandleEarlyErrors(this, false);
            module.Initialise();
            return module;
        }

        private ScriptValue ScriptEvaluation((Realm realm, IScript script) script)
        {
            //https://tc39.github.io/ecma262/#sec-runtime-semantics-scriptevaluation

            var globalEnvironment = script.realm.GlobalEnvironment;
            var scriptContext = new ExecutionContext(script.realm, script, script.script.Strict)
            {
                VariableEnvironment = globalEnvironment,
                LexicalEnvironment = globalEnvironment
            };
            ExecutionContexts.Add(scriptContext);
            RunningExecutionContext = scriptContext;
            var scriptBody = script.script;
            GlobalDeclarationInstantiation(scriptBody, globalEnvironment);
            var result = scriptBody.Evaluate(RunningExecutionContext);
            ExecutionContexts.RemoveAt(ExecutionContexts.Count - 1);
            Debug.Assert(ExecutionContexts.Count > 0);
            RunningExecutionContext = ExecutionContexts[ExecutionContexts.Count - 1];
            return result;
        }

        private void GlobalDeclarationInstantiation([NotNull] IScript script, [NotNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-globaldeclarationinstantiation
            var environmentRecord = environment.Environment;
            Debug.Assert(environmentRecord is GlobalEnvironment);
            var globalEnvironment = (GlobalEnvironment)environmentRecord;
            var lexNames = script.LexicallyDeclaredNames;
            var varNames = script.VarDeclaredNames;
            foreach (var name in lexNames)
            {
                if (globalEnvironment.HasVarDeclaration(name))
                {
                    throw CreateSyntaxError();
                }

                if (globalEnvironment.HasLexicalDeclaration(name))
                {
                    throw CreateSyntaxError();
                }

                if (globalEnvironment.HasRestrictedGlobalProperty(name))
                {
                    throw CreateSyntaxError();
                }
            }

            foreach (var name in varNames)
            {
                if (globalEnvironment.HasLexicalDeclaration(name))
                {
                    throw CreateSyntaxError();
                }
            }

            var varDeclarations = script.VarScopedDeclarations;
            var functionsToInitialise = new List<IDeclaration>();
            var declaredFunctionNames = new HashSet<string>();
            foreach (var declaration in varDeclarations.Reverse())
            {
                if (declaration.IsFunction)
                {
                    //NOTE: If there are multiple function declarations for the same name, the last declaration is used.
                    var functionName = declaration.BoundNames.Single();
                    if (!declaredFunctionNames.Contains(functionName))
                    {
                        var functionDefinable = globalEnvironment.CanDeclareGlobalFunction(functionName);
                        if (!functionDefinable)
                        {
                            throw CreateTypeError();
                        }

                        declaredFunctionNames.Add(functionName);
                        functionsToInitialise.Add(declaration);
                    }
                }
            }

            var declaredVarNames = new HashSet<string>();
            foreach (var declaration in varDeclarations)
            {
                if (declaration.IsVariable)
                {
                    foreach (var variableName in declaration.BoundNames)
                    {
                        if (!declaredFunctionNames.Contains(variableName))
                        {
                            var variableNameDefinable = globalEnvironment.CanDeclareGlobalVar(variableName);
                            if (!variableNameDefinable)
                            {
                                throw CreateTypeError();
                            }

                            declaredVarNames.Add(variableName);
                        }
                    }
                }
            }

            //NOTE: No abnormal terminations occur after this algorithm step if the global object is an ordinary object. However, if the global object is a Proxy exotic object it may exhibit behaviours that cause abnormal terminations in some of the following steps.
            //NOTE: Annex B.3.3.2 adds additional steps at this point.
            var lexDeclarations = script.LexicallyScopedDeclarations;
            foreach (var declaration in lexDeclarations)
            {
                //NOTE: Lexically declared names are only instantiated here but not initialized.
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
            }

            foreach (var function in functionsToInitialise)
            {
                var functionName = function.BoundNames.Single();
                var functionObject = function.InstantiateFunctionObject(this, environment);
                globalEnvironment.CreateGlobalFunctionBinding(functionName, functionObject, false);
            }

            foreach (var variableName in declaredVarNames)
            {
                globalEnvironment.CreateGlobalVarBinding(variableName, false);
            }
        }

        [NotNull]
        internal ScriptObject CreateError([NotNull] ScriptObject prototype, ScriptValue message = default)
        {
            //TODO: Use proper constructor
            var obj = ObjectCreate(prototype, SpecialObjectType.Error);
            if (message != ScriptValue.Undefined)
            {
                var messageString = ToString(message);
                DefinePropertyOrThrow(obj, "message", new PropertyDescriptor(messageString, true, false, true));
            }
            return obj;
        }

        [NotNull]
        internal ScriptException CreateSyntaxError(ScriptValue message = default)
        {
            var error = CreateError(Realm.SyntaxErrorPrototype, message);
            return new ScriptException(error);
        }

        [NotNull]
        internal ScriptException CreateTypeError(ScriptValue message = default)
        {
            var error = CreateError(Realm.TypeErrorPrototype, message);
            return new ScriptException(error);
        }

        [NotNull]
        internal ScriptException CreateRangeError(ScriptValue message = default)
        {
            var error = CreateError(Realm.RangeErrorPrototype, message);
            return new ScriptException(error);
        }

        [NotNull]
        internal ScriptException CreateReferenceError(ScriptValue message = default)
        {
            var error = CreateError(Realm.ReferenceErrorPrototype, message);
            return new ScriptException(error);
        }

        internal Reference ResolveBinding([NotNull] string name, [CanBeNull] LexicalEnvironment environment = null)
        {
            if (environment == null)
            {
                environment = RunningExecutionContext.LexicalEnvironment;
            }
            return GetIdentifierReference(environment, name, RunningExecutionContext.Strict);
        }

        private static Reference GetIdentifierReference([CanBeNull] LexicalEnvironment environment, [NotNull] string name, bool strict)
        {
            if (environment == null)
            {
                return new Reference(null, name, strict);
            }

            var environmentRecord = environment.Environment;
            if (environmentRecord.HasBinding(name))
            {
                return new Reference(environmentRecord, name, strict);
            }
            return GetIdentifierReference(environment.OuterEnvironment, name, strict);
        }

        internal ScriptValue GetValue(ValueReference value)
        {
            if (!value.IsReference)
            {
                return value.Value;
            }

            if (value.Reference.IsUnresolvableReference)
            {
                throw CreateReferenceError();
            }

            if (value.Reference.IsPropertyReference)
            {
                var baseValue = value.Reference.BaseValue;
                if (value.Reference.HasPrimitiveBase)
                {
                    baseValue = ToObject(baseValue);
                }
                return ((ScriptObject)baseValue).Get(value.Reference.ReferencedName, value.Reference.ThisValue);
            }

            return value.Reference.BaseEnvironment.GetBindingValue(value.Reference.ReferencedName, value.Reference.IsStrictReference);
        }

        [CanBeNull]
        private object GetActiveScriptOrModule()
        {
            //https://tc39.github.io/ecma262/#sec-getactivescriptormodule

            for (var i = ExecutionContexts.Count - 1; i >= 0; i--)
            {
                if (ExecutionContexts[i].ScriptOrModule != null)
                {
                    return ExecutionContexts[i].ScriptOrModule;
                }
            }

            return null;
        }

        private static int ExpectedArgumentCount([NotNull] IEnumerable<ExpressionNode> parameters)
        {
            var count = 0;
            foreach (var expression in parameters)
            {
                if (expression is RestElementNode || expression is AssignmentPatternNode)
                {
                    break;
                }

                if (expression is IdentifierNode || expression is ArrayPatternNode || expression is ObjectPatternNode)
                {
                    count++;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return count;
        }

        internal bool PutValue(ValueReference reference, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-putvalue

            if (!reference.IsReference)
            {
                throw CreateReferenceError();
            }

            var realReference = reference.Reference;

            if (realReference.IsUnresolvableReference)
            {
                if (realReference.IsStrictReference)
                {
                    throw CreateReferenceError();
                }

                var globalObject = RunningExecutionContext.Realm.GlobalObject;
                return Set(globalObject, realReference.ReferencedName, value, false);
            }

            if (realReference.IsPropertyReference)
            {
                var baseValue = realReference.BaseValue;
                if (realReference.HasPrimitiveBase)
                {
                    baseValue = ToObject(baseValue);
                }

                var succeeded = ((ScriptObject)baseValue).Set(realReference.ReferencedName, value, realReference.ThisValue);

                if (!succeeded && realReference.IsStrictReference)
                {
                    throw CreateTypeError();
                }

                return succeeded;
            }

            realReference.BaseEnvironment.SetMutableBinding(realReference.ReferencedName, value, realReference.IsStrictReference);
            return true;
        }

        internal void PushExecutionContext([NotNull] ExecutionContext context)
        {
            ExecutionContexts.Add(context);
            RunningExecutionContext = context;
        }

        internal void PopCalleeContext()
        {
            ExecutionContexts.RemoveAt(ExecutionContexts.Count - 1);
            RunningExecutionContext = ExecutionContexts[ExecutionContexts.Count - 1];
        }

        internal void HostEnsureCanCompileStrings(Realm callerRealm, Realm calleeRealm)
        {
            //https://tc39.github.io/ecma262/#sec-hostensurecancompilestrings
        }

        internal ScriptValue PerformEval(ScriptValue x, Realm evalRealm, bool strictCaller, bool direct)
        {
            //https://tc39.github.io/ecma262/#sec-performeval
            Debug.Assert(direct || !strictCaller);

            if (!x.IsString)
            {
                return x;
            }

            var inFunction = false;
            var inMethod = false;
            var inDerivedConstructor = false;
            var thisEnvironmentRecord = RunningExecutionContext.GetThisEnvironment();
            if (thisEnvironmentRecord is FunctionEnvironment functionEnvironment)
            {
                var function = functionEnvironment.FunctionObject;
                inFunction = true;
                inMethod = functionEnvironment.HasSuperBinding();
                inDerivedConstructor = function.ConstructorKind == ConstructorKind.Derived;
            }

            var script = ParseScript((string)x, null, strictCaller, inFunction);
            script.HandleEvalEarlyErrors(this, inFunction && direct, inMethod && direct, inDerivedConstructor && direct);

            //If script Contains ScriptBody is false, return undefined.
            //Let body be the ScriptBody of script.
            var strictEval = strictCaller || script.Strict;
            var context = RunningExecutionContext;

            //NOTE: If direct is true, ctx will be the execution context that performed the direct eval.
            //If direct is false, ctx will be the execution context for the invocation of the eval function.
            LexicalEnvironment lexicalEnvironment;
            LexicalEnvironment variableEnvironment;
            if (direct)
            {
                lexicalEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(this, context.LexicalEnvironment);
                variableEnvironment = context.VariableEnvironment;
            }
            else
            {
                lexicalEnvironment = LexicalEnvironment.NewDeclarativeEnvironment(this, evalRealm.GlobalEnvironment);
                variableEnvironment = evalRealm.GlobalEnvironment;
            }

            if (strictEval)
            {
                variableEnvironment = lexicalEnvironment;
            }

            var evalContext = new ExecutionContext(evalRealm, context.ScriptOrModule, strictEval)
            {
                VariableEnvironment = variableEnvironment,
                LexicalEnvironment = lexicalEnvironment
            };
            PushExecutionContext(evalContext);

            try
            {
                EvalDeclarationInstantiation(script, variableEnvironment, lexicalEnvironment, strictEval);
                return script.Evaluate(evalContext);
            }
            finally
            {
                PopCalleeContext();
                Debug.Assert(RunningExecutionContext == context);
            }
        }

        private void EvalDeclarationInstantiation([NotNull] IScript script, [NotNull] LexicalEnvironment variableEnvironment, [NotNull] LexicalEnvironment lexicalEnvironment, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-evaldeclarationinstantiation
            var variableDeclarations = script.VarScopedDeclarations;
            var lexicalEnvironmentRecord = lexicalEnvironment.Environment;
            var variableEnvironmentRecord = variableEnvironment.Environment;

            if (!strict)
            {
                var variableNames = script.VarDeclaredNames;
                if (variableEnvironmentRecord is GlobalEnvironment globalEnvironment)
                {
                    foreach (var name in variableNames)
                    {
                        if (globalEnvironment.HasLexicalDeclaration(name))
                        {
                            throw CreateSyntaxError();
                        }
                        //NOTE: eval will not create a global var declaration that would be shadowed by a global lexical declaration.
                    }
                }

                var thisLexical = lexicalEnvironment;
                while (thisLexical != variableEnvironment)
                {
                    Debug.Assert(thisLexical != null, nameof(thisLexical) + " != null");
                    var thisEnvironmentRecord = thisLexical.Environment;
                    if (!(thisEnvironmentRecord is ObjectEnvironment))
                    {
                        //NOTE: The environment of with statements cannot contain any lexical declaration so it doesn't need to be checked for var/let hoisting conflicts.
                        foreach (var name in variableNames)
                        {
                            if (thisEnvironmentRecord.HasBinding(name))
                            {
                                throw CreateSyntaxError();
                                //NOTE: Annex B.3.5 defines alternate semantics for the above step.
                            }
                            //NOTE: A direct eval will not hoist var declaration over a like-named lexical declaration.
                        }
                    }

                    thisLexical = thisLexical.OuterEnvironment;
                }
            }

            var functionsToInitialise = new List<IDeclaration>();
            var declaredFunctionNames = new HashSet<string>();
            foreach (var declaration in variableDeclarations.Reverse())
            {
                if (declaration.IsFunction)
                {
                    //NOTE: If there are multiple function declarations for the same name, the last declaration is used.
                    var functionName = declaration.BoundNames.Single();
                    if (!declaredFunctionNames.Contains(functionName))
                    {
                        if (variableEnvironmentRecord is GlobalEnvironment globalEnvironment)
                        {
                            var functionDefinable = globalEnvironment.CanDeclareGlobalFunction(functionName);
                            if (!functionDefinable)
                            {
                                throw CreateTypeError();
                            }
                        }

                        declaredFunctionNames.Add(functionName);
                        functionsToInitialise.Add(declaration);
                    }
                }
            }

            //NOTE: Annex B.3.3.3 adds additional steps at this point.
            var declaredVariableNames = new HashSet<string>();
            foreach (var declaration in variableDeclarations)
            {
                if (declaration.IsVariable)
                {
                    foreach (var variableName in declaration.BoundNames)
                    {
                        if (!declaredFunctionNames.Contains(variableName))
                        {
                            if (variableEnvironmentRecord is GlobalEnvironment globalEnvironment)
                            {
                                var variableDefinable = globalEnvironment.CanDeclareGlobalVar(variableName);
                                if (!variableDefinable)
                                {
                                    throw CreateTypeError();
                                }
                            }

                            declaredVariableNames.Add(variableName);
                        }
                    }
                }
            }

            //NOTE: No abnormal terminations occur after this algorithm step unless varEnvRec is a global Environment Record and the global object is a Proxy exotic object.
            var lexicalDeclarations = script.LexicallyScopedDeclarations;
            foreach (var declaration in lexicalDeclarations)
            {
                //NOTE: Lexically declared names are only instantiated here but not initialized.
                foreach (var declarationName in declaration.BoundNames)
                {
                    if (declaration.IsConstant)
                    {
                        lexicalEnvironmentRecord.CreateImmutableBinding(declarationName, true);
                    }
                    else
                    {
                        lexicalEnvironmentRecord.CreateMutableBinding(declarationName, false);
                    }
                }
            }

            foreach (var function in functionsToInitialise)
            {
                var functionName = function.BoundNames.Single();
                var functionObject = function.InstantiateFunctionObject(this, lexicalEnvironment);
                if (variableEnvironmentRecord is GlobalEnvironment globalEnvironment)
                {
                    globalEnvironment.CreateGlobalFunctionBinding(functionName, functionObject, true);
                }
                else
                {
                    var bindingExists = variableEnvironmentRecord.HasBinding(functionName);
                    if (!bindingExists)
                    {
                        variableEnvironmentRecord.CreateMutableBinding(functionName, true);
                        variableEnvironmentRecord.InitialiseBinding(functionName, functionObject);
                    }
                    else
                    {
                        variableEnvironmentRecord.SetMutableBinding(functionName, functionObject, false);
                    }
                }
            }

            foreach (var variableName in declaredVariableNames)
            {
                if (variableEnvironmentRecord is GlobalEnvironment globalEnvironment)
                {
                    globalEnvironment.CreateGlobalVarBinding(variableName, true);
                }
                else
                {
                    var bindingExists = variableEnvironmentRecord.HasBinding(variableName);
                    if (!bindingExists)
                    {
                        variableEnvironmentRecord.CreateMutableBinding(variableName, true);
                        variableEnvironmentRecord.InitialiseBinding(variableName, ScriptValue.Undefined);
                    }
                }
            }
        }

        [NotNull]
        internal PromiseCapability NewPromiseCapability([NotNull] ScriptObject constructor)
        {
            //https://tc39.github.io/ecma262/#sec-newpromisecapability
            if (!IsConstructor(constructor))
            {
                throw CreateTypeError();
            }

            //NOTE: C is assumed to be a constructor function that supports the parameter conventions of the Promise constructor (see 25.4.3.1).
            var executor = new ScriptFunctionObject(constructor.Realm, constructor.Realm.FunctionPrototype, true, PromiseIntrinsics.GetCapabilitiesExecutor, SpecialObjectType.PromiseCapability);
            var promiseCapability = executor.Capability;

            var promise = Construct(constructor, new ScriptValue[]
            {
                executor
            });

            if (!IsCallable(promiseCapability.Resolve))
            {
                throw CreateTypeError();
            }
            if (!IsCallable(promiseCapability.Reject))
            {
                throw CreateTypeError();
            }

            promiseCapability.Promise = (ScriptObject)promise;
            return promiseCapability;
        }

        [NotNull]
        internal ExecutionContext RunningExecutionContext { get; private set; }

        [NotNull]
        internal IList<ExecutionContext> ExecutionContexts => executionContexts;
    }
}