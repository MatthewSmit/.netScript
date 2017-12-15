using System;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Builtins;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed class Realm
    {
        internal Realm([NotNull] Agent agent)
        {
            Agent = agent;
            //https://tc39.github.io/ecma262/#sec-createrealm
            //https://tc39.github.io/ecma262/#sec-createintrinsics
            ObjectPrototype = agent.ObjectCreate(null);
            ThrowTypeError = agent.CreateBuiltinFunction(this, arguments => throw arguments.Agent.CreateTypeError(), null);
            FunctionPrototype = agent.CreateBuiltinFunction(this, arguments => ScriptValue.Undefined, ObjectPrototype);
            ThrowTypeError.SetPrototypeOf(FunctionPrototype);
            AddRestrictedFunctionProperties(FunctionPrototype);

            IteratorPrototype = IteratorIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);

            (Array, ArrayPrototype, ArrayIteratorPrototype, ArrayProtoEntries, ArrayProtoForEach, ArrayProtoKeys, ArrayProtoValues) = ArrayIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            //arrayBuffer;
            //arrayBufferPrototype;
            (AsyncFunction, AsyncFunctionPrototype) = AsyncFunctionIntrinsics.Initialise(agent, this);
            //atomics;
            (Boolean, BooleanPrototype) = BooleanIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            //dataView;
            //dataViewPrototype;
            (Date, DatePrototype) = DateIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            DecodeURI = Intrinsics.CreateBuiltinFunction(agent, this, DecodeURIImplementation, FunctionPrototype, 1, "decodeURI");
            DecodeURIComponent = Intrinsics.CreateBuiltinFunction(agent, this, DecodeURIComponentImplementation, FunctionPrototype, 1, "decodeURIComponent");
            EncodeURI = Intrinsics.CreateBuiltinFunction(agent, this, EncodeURIImplementation, FunctionPrototype, 1, "encodeURI");
            EncodeURIComponent = Intrinsics.CreateBuiltinFunction(agent, this, EncodeURIComponentImplementation, FunctionPrototype, 1, "encodeURIComponent");
            (Error, ErrorPrototype) = ErrorIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            Eval = Intrinsics.CreateBuiltinFunction(agent, this, EvalImplementation, FunctionPrototype, 1, "eval");
            (EvalError, EvalErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "EvalError", this, Error, ErrorPrototype);
            //float32Array;
            //float32ArrayPrototype;
            //float64Array;
            //float64ArrayPrototype;
            Function = FunctionIntrinsics.Initialise(agent, this, FunctionPrototype);
            (Generator, GeneratorPrototype, GeneratorFunction) = GeneratorInstrinsics.Initialise(agent, this, FunctionPrototype);
            //int8Array;
            //int8ArrayPrototype;
            //int16Array;
            //int16ArrayPrototype;
            //int32Array;
            //int32ArrayPrototype;
            IsFinite = Intrinsics.CreateBuiltinFunction(agent, this, IsFiniteImplementation, FunctionPrototype, 1, "isFinite");
            IsNaN = Intrinsics.CreateBuiltinFunction(agent, this, IsNaNImplementation, FunctionPrototype, 1, "isNaN");
            //json;
            //jsonParse;
            //map;
            //mapIteratorPrototype;
            //mapPrototype;
            Math = MathsIntrinsics.Initialise(agent, this);
            (Number, NumberPrototype) = NumberIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            (ObjectConstructor, ObjProtoToString, ObjProtoValueOf) = ObjectIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            ParseFloat = Intrinsics.CreateBuiltinFunction(agent, this, ParseFloatImplementation, FunctionPrototype, 1, "parseFloat");
            ParseInt = Intrinsics.CreateBuiltinFunction(agent, this, ParseIntImplementation, FunctionPrototype, 2, "parseInt");
            (Promise, PromisePrototype, PromiseProtoThen, PromiseAll, PromiseReject, PromiseResolve) = PromiseIntrinsics.Initialise(agent, this);
            Proxy = ProxyIntrinsics.Initialise(agent, this);
            (RangeError, RangeErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "RangeError", this, Error, ErrorPrototype);
            (ReferenceError, ReferenceErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "ReferenceError", this, Error, ErrorPrototype);
            //reflect;
            (RegExp, RegExpPrototype) = RegExpIntrinsics.Initialise(agent, this);
            //set;
            //setIteratorPrototype;
            //setPrototype;
            //sharedArrayBuffer;
            //sharedArrayBufferPrototype;
            (StringConstructor, StringIteratorPrototype, StringPrototype) = StringIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            //stringConstructor;
            //stringIteratorPrototype;
            //stringPrototype;
            (Symbol, SymbolPrototype) = SymbolIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            (SyntaxError, SyntaxErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "SyntaxError", this, Error, ErrorPrototype);
            //typedArray;
            //typedArrayPrototype;
            (TypeError, TypeErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "TypeError", this, Error, ErrorPrototype);
            //uint8Array;
            //uint8ArrayPrototype;
            //uint8ClampedArray;
            //uint8ClampedArrayPrototype;
            //uint16Array;
            //uint16ArrayPrototype;
            //uint32Array;
            //uint32ArrayPrototype;
            (UriError, UriErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "UriError", this, Error, ErrorPrototype);
            //weakMap;
            //weakMapPrototype;
            //weakSet;
            //weakSetPrototype;
        }

        private void AddRestrictedFunctionProperties([NotNull] ScriptObject function)
        {
            //https://tc39.github.io/ecma262/#sec-addrestrictedfunctionproperties
            Debug.Assert(ThrowTypeError != null);
            Agent.DefinePropertyOrThrow(function, "caller", new PropertyDescriptor(ThrowTypeError, ThrowTypeError, false, true));
            Agent.DefinePropertyOrThrow(function, "arguments", new PropertyDescriptor(ThrowTypeError, ThrowTypeError, false, true));
        }

        private static ScriptValue EvalImplementation([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-eval-x
            var agent = arg.Agent;
            var callerRealm = agent.RunningExecutionContext.Realm;
            var calleeRealm = arg.Function.Realm;
            agent.HostEnsureCanCompileStrings(callerRealm, calleeRealm);
            return agent.PerformEval(arg[0], calleeRealm, false, false);
        }

        private static ScriptValue IsFiniteImplementation(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IsNaNImplementation([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-isnan-number
            var number = arg.Agent.ToNumber(arg[0]);
            return double.IsNaN(number);
        }

        private static ScriptValue ParseFloatImplementation(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ParseIntImplementation(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue DecodeURIImplementation(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue DecodeURIComponentImplementation(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue EncodeURIImplementation(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue EncodeURIComponentImplementation(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        [NotNull]
        public Agent Agent { get; }
        public ScriptObject GlobalObject { get; set; }
        internal LexicalEnvironment GlobalEnvironment { get; set; }

        [NotNull] public ScriptObject Array { get; }

        [NotNull] public ScriptObject ArrayBuffer { get; }

        [NotNull] public ScriptObject ArrayBufferPrototype { get; }

        [NotNull] public ScriptObject ArrayIteratorPrototype { get; }

        [NotNull] public ScriptObject ArrayPrototype { get; }

        [NotNull] public ScriptObject ArrayProtoEntries { get; }

        [NotNull] public ScriptObject ArrayProtoForEach { get; }

        [NotNull] public ScriptObject ArrayProtoKeys { get; }

        [NotNull] public ScriptObject ArrayProtoValues { get; }

        [NotNull] public ScriptObject AsyncFunction { get; }

        [NotNull] public ScriptObject AsyncFunctionPrototype { get; }

        [NotNull] public ScriptObject Atomics { get; }

        [NotNull] public ScriptObject Boolean { get; }

        [NotNull] public ScriptObject BooleanPrototype { get; }

        [NotNull] public ScriptObject DataView { get; }

        [NotNull] public ScriptObject DataViewPrototype { get; }

        [NotNull] public ScriptObject Date { get; }

        [NotNull] public ScriptObject DatePrototype { get; }

        [NotNull] public ScriptObject DecodeURI { get; }

        [NotNull] public ScriptObject DecodeURIComponent { get; }

        [NotNull] public ScriptObject EncodeURI { get; }

        [NotNull] public ScriptObject EncodeURIComponent { get; }

        [NotNull] public ScriptObject Error { get; }

        [NotNull] public ScriptObject ErrorPrototype { get; }

        [NotNull] public ScriptObject Eval { get; }

        [NotNull] public ScriptObject EvalError { get; }

        [NotNull] public ScriptObject EvalErrorPrototype { get; }

        [NotNull] public ScriptObject Float32Array { get; }

        [NotNull] public ScriptObject Float32ArrayPrototype { get; }

        [NotNull] public ScriptObject Float64Array { get; }

        [NotNull] public ScriptObject Float64ArrayPrototype { get; }

        [NotNull] public ScriptObject Function { get; }

        [NotNull] public ScriptObject FunctionPrototype { get; }

        [NotNull] public ScriptObject Generator { get; }

        [NotNull] public ScriptObject GeneratorFunction { get; }

        [NotNull] public ScriptObject GeneratorPrototype { get; }

        [NotNull] public ScriptObject Int8Array { get; }

        [NotNull] public ScriptObject Int8ArrayPrototype { get; }

        [NotNull] public ScriptObject Int16Array { get; }

        [NotNull] public ScriptObject Int16ArrayPrototype { get; }

        [NotNull] public ScriptObject Int32Array { get; }

        [NotNull] public ScriptObject Int32ArrayPrototype { get; }

        [NotNull] public ScriptObject IsFinite { get; }

        [NotNull] public ScriptObject IsNaN { get; }

        [NotNull] public ScriptObject IteratorPrototype { get; }

        [NotNull] public ScriptObject Json { get; }

        [NotNull] public ScriptObject JsonParse { get; }

        [NotNull] public ScriptObject Map { get; }

        [NotNull] public ScriptObject MapIteratorPrototype { get; }

        [NotNull] public ScriptObject MapPrototype { get; }

        [NotNull] public ScriptObject Math { get; }

        [NotNull] public ScriptObject Number { get; }

        [NotNull] public ScriptObject NumberPrototype { get; }

        [NotNull] public ScriptObject ObjectConstructor { get; }

        [NotNull] public ScriptObject ObjectPrototype { get; }

        [NotNull] public ScriptObject ObjProtoToString { get; }

        [NotNull] public ScriptObject ObjProtoValueOf { get; }

        [NotNull] public ScriptObject ParseFloat { get; }

        [NotNull] public ScriptObject ParseInt { get; }

        [NotNull] public ScriptObject Promise { get; }

        [NotNull] public ScriptObject PromisePrototype { get; }

        [NotNull] public ScriptObject PromiseProtoThen { get; }

        [NotNull] public ScriptObject PromiseAll { get; }

        [NotNull] public ScriptObject PromiseReject { get; }

        [NotNull] public ScriptObject PromiseResolve { get; }

        [NotNull] public ScriptObject Proxy { get; }

        [NotNull] public ScriptObject RangeError { get; }

        [NotNull] public ScriptObject RangeErrorPrototype { get; }

        [NotNull] public ScriptObject ReferenceError { get; }

        [NotNull] public ScriptObject ReferenceErrorPrototype { get; }

        [NotNull] public ScriptObject Reflect { get; }

        [NotNull] public ScriptObject RegExp { get; }

        [NotNull] public ScriptObject RegExpPrototype { get; }

        [NotNull] public ScriptObject Set { get; }

        [NotNull] public ScriptObject SetIteratorPrototype { get; }

        [NotNull] public ScriptObject SetPrototype { get; }

        [NotNull] public ScriptObject SharedArrayBuffer { get; }

        [NotNull] public ScriptObject SharedArrayBufferPrototype { get; }

        [NotNull] public ScriptObject StringConstructor { get; }

        [NotNull] public ScriptObject StringIteratorPrototype { get; }

        [NotNull] public ScriptObject StringPrototype { get; }

        [NotNull] public ScriptObject Symbol { get; }

        [NotNull] public ScriptObject SymbolPrototype { get; }

        [NotNull] public ScriptObject SyntaxError { get; }

        [NotNull] public ScriptObject SyntaxErrorPrototype { get; }

        [NotNull] public ScriptObject ThrowTypeError { get; }

        [NotNull] public ScriptObject TypedArray { get; }

        [NotNull] public ScriptObject TypedArrayPrototype { get; }

        [NotNull] public ScriptObject TypeError { get; }

        [NotNull] public ScriptObject TypeErrorPrototype { get; }

        [NotNull] public ScriptObject Uint8Array { get; }

        [NotNull] public ScriptObject Uint8ArrayPrototype { get; }

        [NotNull] public ScriptObject Uint8ClampedArray { get; }

        [NotNull] public ScriptObject Uint8ClampedArrayPrototype { get; }

        [NotNull] public ScriptObject Uint16Array { get; }

        [NotNull] public ScriptObject Uint16ArrayPrototype { get; }

        [NotNull] public ScriptObject Uint32Array { get; }

        [NotNull] public ScriptObject Uint32ArrayPrototype { get; }

        [NotNull] public ScriptObject UriError { get; }

        [NotNull] public ScriptObject UriErrorPrototype { get; }

        [NotNull] public ScriptObject WeakMap { get; }

        [NotNull] public ScriptObject WeakMapPrototype { get; }

        [NotNull] public ScriptObject WeakSet { get; }

        [NotNull] public ScriptObject WeakSetPrototype { get; }

        [NotNull]
        public Symbol SymbolHasInstance { get; } = new Symbol("Symbol.hasInstance");
        [NotNull]
        public Symbol SymbolIsConcatSpreadable { get; } = new Symbol("Symbol.isConcatSpreadable");
        [NotNull]
        public Symbol SymbolIterator { get; } = new Symbol("Symbol.iterator");
        [NotNull]
        public Symbol SymbolMatch { get; } = new Symbol("Symbol.match");
        [NotNull]
        public Symbol SymbolReplace { get; } = new Symbol("Symbol.replace");
        [NotNull]
        public Symbol SymbolSearch { get; } = new Symbol("Symbol.search");
        [NotNull]
        public Symbol SymbolSpecies { get; } = new Symbol("Symbol.species");
        [NotNull]
        public Symbol SymbolSplit { get; } = new Symbol("Symbol.split");
        [NotNull]
        public Symbol SymbolToPrimitive { get; } = new Symbol("Symbol.toPrimitive");
        [NotNull]
        public Symbol SymbolToStringTag { get; } = new Symbol("Symbol.toStringTag");
        [NotNull]
        public Symbol SymbolUnscopables { get; } = new Symbol("Symbol.unscopables");
    }
}
