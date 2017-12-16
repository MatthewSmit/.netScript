using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
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

        /// <summary>
        /// Creates an Agent.
        /// </summary>
        public Agent()
        {
            //https://tc39.github.io/ecma262/#sec-initializehostdefinedrealm

            var realm = new Realm(this, "Default");
            var newContext = new ExecutionContext(realm, null, true);
            ExecutionContexts.Add(newContext);
            RunningExecutionContext = newContext;
            SetRealmGlobalObject(realm, null, null);
            SetDefaultGlobalBindings(realm);
        }

        /// <summary>
        /// Queues ECMAScript code to be run when RunNextJob/RunAllJobs is next called.
        /// </summary>
        /// <param name="source">The source code for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        public void QueueCode([NotNull] string source, ScriptOptions options = default)
        {
            EnqueueJob(scriptJobs, () => RunCode(source, options));
        }

        /// <summary>
        /// Queues ECMAScript code to be run when RunNextJob/RunAllJobs is next called.
        /// </summary>
        /// <param name="fileName">The file name for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        public void QueueFile([NotNull] string fileName, ScriptOptions options = default)
        {
            if (options.ScriptName == null)
            {
                options.ScriptName = fileName;
            }

            QueueCode(File.ReadAllText(fileName), options);
        }

        /// <summary>
        /// Immediately runs the ECMAScript code.
        /// </summary>
        /// <param name="source">The source code for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        /// <returns>The value of the last expression run.</returns>
        public ScriptValue RunCode([NotNull] string source,ScriptOptions options = default)
        {
            if (options.ForceStrict)
            {
                source = "'use strict';" + source;
            }

            switch (options.Type)
            {
                case ScriptType.Script:
                    var script = ParseScript(source, options.ScriptName, false, false);
                    return ScriptEvaluation((RunningExecutionContext.Realm, script));
                case ScriptType.Module:
                    var module = ParseModule(source, options.ScriptName);
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Immediately runs the ECMAScript code.
        /// </summary>
        /// <param name="fileName">The file name for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        /// <returns>The value of the last expression run.</returns>
        public ScriptValue RunFile([NotNull] string fileName, ScriptOptions options = default)
        {
            if (options.ScriptName == null)
            {
                options.ScriptName = fileName;
            }

            return RunCode(File.ReadAllText(fileName), options);
        }

        /// <summary>
        /// Runs jobs until the queue is empty.
        /// </summary>
        public void RunAllJobs()
        {
            while (scriptJobs.Count > 0 || promiseJobs.Count > 0)
            {
                RunNextJob();
            }
        }

        /// <summary>
        /// Runs the next job.
        /// </summary>
        public void RunNextJob()
        {
            Debug.Assert(ExecutionContexts.Count == 1 && RunningExecutionContext == ExecutionContexts[0]);
            ExecutionContexts.Clear();

            var nextQueue = promiseJobs.Count > 0 ? promiseJobs : scriptJobs;
            var nextPending = nextQueue.Dequeue();
            var newContext = new ExecutionContext(nextPending.Realm, nextPending.ScriptOrModule, true);
            ExecutionContexts.Add(newContext);
            RunningExecutionContext = newContext;
            nextPending.Callback();
        }

        /// <summary>
        /// Creates a new realm.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public Realm CreateRealm(string name = "")
        {
            var newRealm = new Realm(this, name);
            SetRealmGlobalObject(newRealm, null, null);
            SetDefaultGlobalBindings(newRealm);
            return newRealm;
        }

        /// <summary>
        /// Creates a new ECMAScript object.
        /// </summary>
        /// <param name="prototype">The prototype of the new object. Will use the object prototype if null.</param>
        /// <returns>The new ECMAScript object.</returns>
        [NotNull]
        public ScriptObject CreateObject(ScriptObject prototype = null)
        {
            if (prototype == null)
            {
                prototype = Realm.ObjectPrototype;
            }

            return ObjectCreate(prototype);
        }

        /// <summary>
        /// Creates an ECMAScript function that calls managed code.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        [NotNull]
        public ScriptFunctionObject CreateUserFunction([NotNull] Func<ScriptArguments, ScriptValue> callback)
        {
            return new ScriptFunctionObject(Realm, Realm.FunctionPrototype, true, callback);
        }

        [NotNull]
        internal ScriptObject ObjectCreate([CanBeNull] ScriptObject prototype, SpecialObjectType specialObjectType = SpecialObjectType.None)
        {
            //https://tc39.github.io/ecma262/#sec-objectcreate

            return new ScriptObject(prototype?.Realm ?? Realm, prototype, true, specialObjectType);
        }

        [NotNull]
        internal ScriptObject ObjectCreate([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, SpecialObjectType specialObjectType = SpecialObjectType.None)
        {
            //https://tc39.github.io/ecma262/#sec-objectcreate

            return new ScriptObject(realm, prototype, true, specialObjectType);
        }

        [NotNull]
        internal ScriptObject OrdinaryCreateFromConstructor([NotNull] ScriptObject constructor, [NotNull] ScriptObject defaultPrototype, SpecialObjectType specialObjectType = SpecialObjectType.None)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarycreatefromconstructor
            var prototype = GetPrototypeFromConstructor(constructor, defaultPrototype);
            return ObjectCreate(prototype, specialObjectType);
        }

        [NotNull]
        internal static ScriptObject GetPrototypeFromConstructor([NotNull] ScriptObject constructor, [NotNull] ScriptObject defaultPrototype)
        {
            Debug.Assert(IsCallable(constructor));
            var prototype = constructor.Get("prototype");
            if (!prototype.IsObject)
            {
                Debug.Assert(defaultPrototype.Realm == constructor.Realm);
                prototype = defaultPrototype;
            }

            return (ScriptObject)prototype;
        }

        [NotNull]
        internal ScriptFunctionObject CreateBuiltinFunction([NotNull] Realm realm, [NotNull] Func<ScriptArguments, ScriptValue> callback, [CanBeNull] ScriptObject prototype)
        {
            return new ScriptFunctionObject(realm, prototype, true, callback);
        }

        /// <summary>
        /// Returns the prototype of a script value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [CanBeNull]
        public ScriptObject GetPrototypeOf(ScriptValue value)
        {
            var obj = ToObject(value);
            return obj.GetPrototypeOf();
        }

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

        private void SetDefaultGlobalBindings([NotNull] Realm realm)
        {
            var global = realm.GlobalObject;
            DefinePropertyOrThrow(global, "Infinity", new PropertyDescriptor(double.PositiveInfinity, false, false, false));
            DefinePropertyOrThrow(global, "NaN", new PropertyDescriptor(double.NaN, false, false, false));
            DefinePropertyOrThrow(global, "undefined", new PropertyDescriptor(ScriptValue.Undefined, false, false, false));

            DefinePropertyOrThrow(global, "eval", new PropertyDescriptor(realm.Eval, true, false, true));
            DefinePropertyOrThrow(global, "isFinite", new PropertyDescriptor(realm.IsFinite, true, false, true));
            DefinePropertyOrThrow(global, "isNaN", new PropertyDescriptor(realm.IsNaN, true, false, true));
            DefinePropertyOrThrow(global, "parseFloat", new PropertyDescriptor(realm.ParseFloat, true, false, true));
            DefinePropertyOrThrow(global, "parseInt", new PropertyDescriptor(realm.ParseInt, true, false, true));
            DefinePropertyOrThrow(global, "decodeURI", new PropertyDescriptor(realm.DecodeURI, true, false, true));
            DefinePropertyOrThrow(global, "decodeURIComponent", new PropertyDescriptor(realm.DecodeURIComponent, true, false, true));
            DefinePropertyOrThrow(global, "encodeURI", new PropertyDescriptor(realm.EncodeURI, true, false, true));
            DefinePropertyOrThrow(global, "encodeURIComponent", new PropertyDescriptor(realm.EncodeURIComponent, true, false, true));

            DefinePropertyOrThrow(global, "Array", new PropertyDescriptor(realm.Array, true, false, true));
            DefinePropertyOrThrow(global, "ArrayBuffer", new PropertyDescriptor(realm.ArrayBuffer, true, false, true));
            DefinePropertyOrThrow(global, "Boolean", new PropertyDescriptor(realm.Boolean, true, false, true));
            DefinePropertyOrThrow(global, "DataView", new PropertyDescriptor(realm.DataView, true, false, true));
            DefinePropertyOrThrow(global, "Date", new PropertyDescriptor(realm.Date, true, false, true));
            DefinePropertyOrThrow(global, "Error", new PropertyDescriptor(realm.Error, true, false, true));
            DefinePropertyOrThrow(global, "EvalError", new PropertyDescriptor(realm.EvalError, true, false, true));
            DefinePropertyOrThrow(global, "Float32Array", new PropertyDescriptor(realm.Float32Array, true, false, true));
            DefinePropertyOrThrow(global, "Float64Array", new PropertyDescriptor(realm.Float64Array, true, false, true));
            DefinePropertyOrThrow(global, "Function", new PropertyDescriptor(realm.Function, true, false, true));
            DefinePropertyOrThrow(global, "Int8Array", new PropertyDescriptor(realm.Int8Array, true, false, true));
            DefinePropertyOrThrow(global, "Int16Array", new PropertyDescriptor(realm.Int16Array, true, false, true));
            DefinePropertyOrThrow(global, "Int32Array", new PropertyDescriptor(realm.Int32Array, true, false, true));
            DefinePropertyOrThrow(global, "Map", new PropertyDescriptor(realm.Map, true, false, true));
            DefinePropertyOrThrow(global, "Number", new PropertyDescriptor(realm.Number, true, false, true));
            DefinePropertyOrThrow(global, "Object", new PropertyDescriptor(realm.ObjectConstructor, true, false, true));
            DefinePropertyOrThrow(global, "Proxy", new PropertyDescriptor(realm.Proxy, true, false, true));
            DefinePropertyOrThrow(global, "Promise", new PropertyDescriptor(realm.Promise, true, false, true));
            DefinePropertyOrThrow(global, "RangeError", new PropertyDescriptor(realm.RangeError, true, false, true));
            DefinePropertyOrThrow(global, "ReferenceError", new PropertyDescriptor(realm.ReferenceError, true, false, true));
            DefinePropertyOrThrow(global, "RegExp", new PropertyDescriptor(realm.RegExp, true, false, true));
            DefinePropertyOrThrow(global, "Set", new PropertyDescriptor(realm.Set, true, false, true));
            DefinePropertyOrThrow(global, "SharedArrayBuffer", new PropertyDescriptor(realm.SharedArrayBuffer, true, false, true));
            DefinePropertyOrThrow(global, "String", new PropertyDescriptor(realm.StringConstructor, true, false, true));
            DefinePropertyOrThrow(global, "Symbol", new PropertyDescriptor(realm.Symbol, true, false, true));
            DefinePropertyOrThrow(global, "SyntaxError", new PropertyDescriptor(realm.SyntaxError, true, false, true));
            DefinePropertyOrThrow(global, "TypeError", new PropertyDescriptor(realm.TypeError, true, false, true));
            DefinePropertyOrThrow(global, "Uint8Array", new PropertyDescriptor(realm.Uint8Array, true, false, true));
            DefinePropertyOrThrow(global, "Uint8ClampedArray", new PropertyDescriptor(realm.Uint8ClampedArray, true, false, true));
            DefinePropertyOrThrow(global, "Uint16Array", new PropertyDescriptor(realm.Uint16Array, true, false, true));
            DefinePropertyOrThrow(global, "Uint32Array", new PropertyDescriptor(realm.Uint32Array, true, false, true));
            DefinePropertyOrThrow(global, "URIError", new PropertyDescriptor(realm.UriError, true, false, true));
            DefinePropertyOrThrow(global, "WeakMap", new PropertyDescriptor(realm.WeakMap, true, false, true));
            DefinePropertyOrThrow(global, "WeakSet", new PropertyDescriptor(realm.WeakSet, true, false, true));

            DefinePropertyOrThrow(global, "Atomics", new PropertyDescriptor(realm.Atomics, true, false, true));
            DefinePropertyOrThrow(global, "JSON", new PropertyDescriptor(realm.Json, true, false, true));
            DefinePropertyOrThrow(global, "Math", new PropertyDescriptor(realm.Math, true, false, true));
            DefinePropertyOrThrow(global, "Reflect", new PropertyDescriptor(realm.Reflect, true, false, true));
        }

        private void SetRealmGlobalObject([NotNull] Realm realm, [CanBeNull] ScriptObject globalObject, [CanBeNull] ScriptObject thisValue)
        {
            //https://tc39.github.io/ecma262/#sec-setrealmglobalobject
            if (globalObject == null)
            {
                globalObject = ObjectCreate(realm.ObjectPrototype);
            }

            Debug.Assert(globalObject != null);
            if (thisValue == null)
            {
                thisValue = globalObject;
            }
            realm.GlobalObject = globalObject;
            realm.GlobalEnvironment = LexicalEnvironment.NewGlobalEnvironment(this, globalObject, thisValue);
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

        internal void SetFunctionName([NotNull] ScriptObject function, ScriptValue name, [CanBeNull] string prefix = null)
        {
            //https://tc39.github.io/ecma262/#sec-setfunctionname
            Debug.Assert(function.IsExtensible && !function.HasOwnProperty("name"));
            Debug.Assert(name.IsSymbol || name.IsString);

            string realName;
            if (name.IsSymbol)
            {
                var nameSymbol = (Symbol)name;
                var description = nameSymbol.Description;
                if (description == null)
                {
                    realName = "";
                }
                else
                {
                    realName = "[" + description + "]";
                }
            }
            else
            {
                realName = (string)name;
            }

            if (prefix != null)
            {
                realName = prefix + " " + realName;
            }

            DefinePropertyOrThrow(function, "name", new PropertyDescriptor(realName, false, false, true));
        }

        internal static void InitialiseReferencedBinding(Reference v, ScriptValue w)
        {
            //https://tc39.github.io/ecma262/#sec-initializereferencedbinding
            Debug.Assert(!v.IsUnresolvableReference);
            var baseValue = v.BaseEnvironment;
            baseValue.InitialiseBinding(v.ReferencedName, w);
        }

        internal void MakeConstructor([NotNull] ScriptFunctionObject function, bool writablePrototype = true, [CanBeNull] ScriptObject prototype = null)
        {
            //https://tc39.github.io/ecma262/#sec-makeconstructor

            Debug.Assert(function.ConstructorKind != ConstructorKind.None);
            Debug.Assert(function.IsExtensible);
            Debug.Assert(!function.HasOwnProperty("prototype"));

            if (prototype == null)
            {
                prototype = ObjectCreate(RunningExecutionContext.Realm.ObjectPrototype);
                DefinePropertyOrThrow(prototype, "constructor", new PropertyDescriptor(function, writablePrototype, false, true));
            }

            DefinePropertyOrThrow(function, "prototype", new PropertyDescriptor(prototype, writablePrototype, false, false));
        }

        internal static void MakeClassConstructor([NotNull] ScriptFunctionObject function)
        {
            //https://tc39.github.io/ecma262/#sec-makeclassconstructor
            Debug.Assert(function.FunctionKind == FunctionKind.Normal);
            function.FunctionKind = FunctionKind.ClassConstructor;
        }

        internal static bool CreateMethodProperty([NotNull] ScriptObject obj, ScriptValue property, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-createmethodproperty
            Debug.Assert(IsPropertyKey(property));
            var newDescriptor = new PropertyDescriptor(value, true, false, true);
            return obj.DefineOwnProperty(property, newDescriptor);
        }

        [NotNull]
        internal ScriptFunctionObject FunctionCreate(FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope, bool strict, ScriptObject prototype = null)
        {
            if (prototype == null)
            {
                prototype = RunningExecutionContext.Realm.FunctionPrototype;
            }

            var function = FunctionAllocate(prototype, strict, kind == FunctionKind.Normal ? FunctionKind.Normal : FunctionKind.NonConstructor);
            return FunctionInitialise(function, kind, parameters, body, scope);
        }

        [NotNull]
        internal ScriptFunctionObject GeneratorFunctionCreate(FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-generatorfunctioncreate

            var function = FunctionAllocate(Realm.Generator, strict, FunctionKind.Generator);
            return FunctionInitialise(function, kind, parameters, body, scope);
        }

        [NotNull]
        internal ScriptFunctionObject AsyncFunctionCreate(FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-async-functions-abstract-operations-async-function-create
            var function = FunctionAllocate(Realm.AsyncFunctionPrototype, strict, FunctionKind.Async);
            return FunctionInitialise(function, kind, parameters, body, scope);
        }

        [NotNull]
        internal ScriptFunctionObject FunctionInitialise([NotNull] ScriptFunctionObject function, FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope)
        {
            //https://tc39.github.io/ecma262/#sec-functioninitialize
            Debug.Assert(function.IsExtensible && function.GetOwnProperty("length") == null);
            var length = ExpectedArgumentCount(parameters);
            DefinePropertyOrThrow(function, "length", new PropertyDescriptor(length, false, false, true));

            var strict = function.Strict;
            function.Environment = scope;
            function.FormalParameters = parameters;
            function.ECMAScriptCode = new FunctionNode(body);
            function.ScriptOrModule = GetActiveScriptOrModule();
            if (kind == FunctionKind.Arrow)
            {
                function.ThisMode = ThisMode.Lexical;
            }
            else if (strict)
            {
                function.ThisMode = ThisMode.Strict;
            }
            else
            {
                function.ThisMode = ThisMode.Global;
            }
            return function;
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

        [NotNull]
        internal static ScriptFunctionObject FunctionAllocate([NotNull] ScriptObject functionPrototype, bool strict, FunctionKind functionKind)
        {
            //https://tc39.github.io/ecma262/#sec-functionallocate
            Debug.Assert(functionPrototype != null);
            var needsConstruct = functionKind == FunctionKind.Normal;
            if (functionKind == FunctionKind.NonConstructor)
            {
                functionKind = FunctionKind.Normal;
            }

            return new ScriptFunctionObject(functionPrototype.Realm, functionPrototype, true, functionKind, needsConstruct ? ConstructorKind.Base : ConstructorKind.None, strict);
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

        internal ScriptValue CreateIterResultObject(ScriptValue value, bool done)
        {
            //https://tc39.github.io/ecma262/#sec-createiterresultobject
            var obj = ObjectCreate(RunningExecutionContext.Realm.ObjectPrototype);
            obj.CreateDataProperty("value", value);
            obj.CreateDataProperty("done", done);
            return obj;
        }

        internal bool OrdinaryHasInstance(ScriptValue constructor, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-ordinaryhasinstance
            if (!IsCallable(constructor))
            {
                return false;
            }

            var constructorObject = (ScriptObject)constructor;

            if (constructorObject is ScriptBoundFunctionObject)
            {
                //Let BC be C.[[BoundTargetFunction]].
                //Return ? InstanceofOperator(O, BC).
                throw new NotImplementedException();
            }

            if (!value.IsObject)
            {
                return false;
            }

            var prototype = constructorObject.Get("prototype", constructor);
            if (!prototype.IsObject)
            {
                throw CreateTypeError();
            }

            var obj = (ScriptObject)value;

            while (true)
            {
                obj = obj.GetPrototypeOf();
                if (obj == null)
                {
                    return false;
                }

                if (prototype.SameValue(obj))
                {
                    return true;
                }
            }
        }

        internal static void MakeMethod([NotNull] ScriptFunctionObject function, ScriptObject homeObject)
        {
            //https://tc39.github.io/ecma262/#sec-makemethod
            function.HomeObject = homeObject;
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

        internal object NewPromiseCapability([NotNull] ScriptObject constructor)
        {
            //https://tc39.github.io/ecma262/#sec-newpromisecapability
            if (!IsConstructor(constructor))
            {
                throw CreateTypeError();
            }

            //NOTE: C is assumed to be a constructor function that supports the parameter conventions of the Promise constructor (see 25.4.3.1).
//            var promiseCapability = new PromiseCapability();
            //Let executor be a new built-in function object as defined in GetCapabilitiesExecutor Functions.
            //Set executor.[[Capability]] to promiseCapability.
            //Let promise be ? Construct(C, « executor »).
            //If IsCallable(promiseCapability.[[Resolve]]) is false, throw a TypeError exception.
            //If IsCallable(promiseCapability.[[Reject]]) is false, throw a TypeError exception.
            //Set promiseCapability.[[Promise]] to promise.
            //Return promiseCapability.
            throw new NotImplementedException();
        }

        [NotNull]
        internal IReadOnlyList<ScriptValue> CreateListFromArrayLike(ScriptValue obj, ScriptValue.Type[] elementTypes = null)
        {
            //https://tc39.github.io/ecma262/#sec-createlistfromarraylike
            if (elementTypes == null)
            {
                elementTypes = new[]
                {
                    ScriptValue.Type.Undefined,
                    ScriptValue.Type.Null,
                    ScriptValue.Type.Boolean,
                    ScriptValue.Type.String,
                    ScriptValue.Type.Symbol,
                    ScriptValue.Type.Number,
                    ScriptValue.Type.Object
                };
            }

            if (!obj.IsObject)
            {
                throw CreateTypeError();
            }

            var length = ToLength(((ScriptObject)obj).Get("length"));

            var list = new List<ScriptValue>();
            var index = 0UL;
            while (index < length)
            {
                var indexName = index.ToString(CultureInfo.InvariantCulture);
                var next = ((ScriptObject)obj).Get(indexName);
                if (!elementTypes.Contains(next.ValueType))
                {
                    throw CreateTypeError();
                }

                list.Add(next);
                index++;
            }

            return list;
        }

        [NotNull]
        internal Realm GetFunctionRealm([NotNull] ScriptObject obj)
        {
            //https://tc39.github.io/ecma262/#sec-getfunctionrealm
            Debug.Assert(obj.IsCallable);
            if (obj is ScriptFunctionObject functionObject)
            {
                return functionObject.Realm;
            }

            if (obj is ScriptBoundFunctionObject boundFunctionObject)
            {
                //Let target be obj.[[BoundTargetFunction]].
                //Return ? GetFunctionRealm(target).
                throw new NotImplementedException();
            }

            if (obj is ScriptProxyObject proxyObject)
            {
                //    If obj.[[ProxyHandler]] is null, throw a TypeError exception.
                //    Let proxyTarget be obj.[[ProxyTarget]].
                //    Return ? GetFunctionRealm(proxyTarget).
                throw new NotImplementedException();
            }

            return Realm;
        }

        internal ScriptValue Invoke(ScriptValue value, ScriptValue property, [NotNull] params ScriptValue[] arguments)
        {
            return Invoke(value, property, (IReadOnlyList<ScriptValue>)arguments);
        }

        private ScriptValue Invoke(ScriptValue value, ScriptValue property, [NotNull] IReadOnlyList<ScriptValue> arguments)
        {
            Debug.Assert(IsPropertyKey(property));
            var function = GetValue(value, property);
            return Call(function, value, arguments);
        }

        /// <summary>
        /// Returns the global object for the current Realm.
        /// </summary>
        public ScriptObject Global => Realm.GlobalObject;

        /// <summary>
        /// Returns the current execution contexts Realm.
        /// </summary>
        [NotNull]
        public Realm Realm => RunningExecutionContext.Realm;

        public bool LittleEndian => BitConverter.IsLittleEndian;

        [NotNull]
        internal ExecutionContext RunningExecutionContext { get; private set; }

        [NotNull]
        internal IList<ExecutionContext> ExecutionContexts => executionContexts;
    }
}