using System;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Builtins;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    /// <summary>
    /// Contains the global objects and prototypes.
    /// </summary>
    public sealed class Realm
    {
        private readonly string name;

        internal Realm([NotNull] Agent agent, string name)
        {
            this.name = name;
            Agent = agent;
            //https://tc39.github.io/ecma262/#sec-createrealm
            //https://tc39.github.io/ecma262/#sec-createintrinsics
            ObjectPrototype = Agent.ObjectCreate(this, null);
            ThrowTypeError = Agent.CreateBuiltinFunction(this, arguments => throw arguments.Agent.CreateTypeError(), null);
            FunctionPrototype = Agent.CreateBuiltinFunction(this, arguments => ScriptValue.Undefined, ObjectPrototype);
            ThrowTypeError.SetPrototypeOf(FunctionPrototype);
            AddRestrictedFunctionProperties(FunctionPrototype);

            IteratorPrototype = IteratorIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);

            (Array, ArrayPrototype, ArrayIteratorPrototype, ArrayProtoEntries, ArrayProtoForEach, ArrayProtoKeys, ArrayProtoValues) = ArrayIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            (ArrayBuffer, ArrayBufferPrototype) = ArrayBufferIntrinsics.Initialise(agent, this);
            (AsyncFunction, AsyncFunctionPrototype) = AsyncFunctionIntrinsics.Initialise(agent, this);
            Atomics = AtomicsIntrinsics.Initialise(agent, this);
            (Boolean, BooleanPrototype) = BooleanIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            (DataView, DataViewPrototype) = DataViewIntrinsics.Initialise(agent, this);
            (Date, DatePrototype) = DateIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            DecodeURI = Intrinsics.CreateBuiltinFunction(this, DecodeURIImplementation, FunctionPrototype, 1, "decodeURI");
            DecodeURIComponent = Intrinsics.CreateBuiltinFunction(this, DecodeURIComponentImplementation, FunctionPrototype, 1, "decodeURIComponent");
            EncodeURI = Intrinsics.CreateBuiltinFunction(this, EncodeURIImplementation, FunctionPrototype, 1, "encodeURI");
            EncodeURIComponent = Intrinsics.CreateBuiltinFunction(this, EncodeURIComponentImplementation, FunctionPrototype, 1, "encodeURIComponent");
            (Error, ErrorPrototype) = ErrorIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            Eval = Intrinsics.CreateBuiltinFunction(this, EvalImplementation, FunctionPrototype, 1, "eval");
            (EvalError, EvalErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "EvalError", this, Error, ErrorPrototype);
            Function = FunctionIntrinsics.Initialise(this, FunctionPrototype);
            (Generator, GeneratorPrototype, GeneratorFunction) = GeneratorInstrinsics.Initialise(agent, this, FunctionPrototype);
            IsFinite = Intrinsics.CreateBuiltinFunction(this, IsFiniteImplementation, FunctionPrototype, 1, "isFinite");
            IsNaN = Intrinsics.CreateBuiltinFunction(this, IsNaNImplementation, FunctionPrototype, 1, "isNaN");
            (Json, JsonParse) = JsonIntrinsics.Initialise(agent, this);
            (Map, MapPrototype, MapIteratorPrototype) = MapIntrinsics.Initialise(agent, this);
            Math = MathsIntrinsics.Initialise(agent, this);
            (Number, NumberPrototype) = NumberIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            (ObjectConstructor, ObjProtoToString, ObjProtoValueOf) = ObjectIntrinsics.Initialise(this, ObjectPrototype, FunctionPrototype);
            ParseFloat = Intrinsics.CreateBuiltinFunction(this, ParseFloatImplementation, FunctionPrototype, 1, "parseFloat");
            ParseInt = Intrinsics.CreateBuiltinFunction(this, ParseIntImplementation, FunctionPrototype, 2, "parseInt");
            (Promise, PromisePrototype, PromiseProtoThen, PromiseAll, PromiseReject, PromiseResolve) = PromiseIntrinsics.Initialise(agent, this);
            Proxy = ProxyIntrinsics.Initialise(this);
            (RangeError, RangeErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "RangeError", this, Error, ErrorPrototype);
            (ReferenceError, ReferenceErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "ReferenceError", this, Error, ErrorPrototype);
            Reflect = ReflectIntrinsics.Initialise(agent, this);
            (RegExp, RegExpPrototype) = RegExpIntrinsics.Initialise(agent, this);
            (Set, SetPrototype, SetIteratorPrototype) = SetIntrinsics.Initialise(agent, this);
            (SharedArrayBuffer, SharedArrayBufferPrototype) = SharedArrayBufferIntrinsics.Initialise(agent, this);
            (StringConstructor, StringIteratorPrototype, StringPrototype) = StringIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            (Symbol, SymbolPrototype) = SymbolIntrinsics.Initialise(agent, this, ObjectPrototype, FunctionPrototype);
            (SyntaxError, SyntaxErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "SyntaxError", this, Error, ErrorPrototype);
            (TypeError, TypeErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "TypeError", this, Error, ErrorPrototype);
            (TypedArray, TypedArrayPrototype) = TypedArrayIntrinsics.Initialise(agent, this);
            (UriError, UriErrorPrototype) = ErrorIntrinsics.InitialiseNativeError(agent, "UriError", this, Error, ErrorPrototype);
            (WeakMap, WeakMapPrototype) = WeakMapIntrinsics.Initialise(agent, this);
            (WeakSet, WeakSetPrototype) = WeakSetIntrinsics.Initialise(agent, this);

            (Float32Array, Float32ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<float>(agent, this);
            (Float64Array, Float64ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<double>(agent, this);
            (Int8Array, Int8ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<sbyte>(agent, this);
            (Int16Array, Int16ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<short>(agent, this);
            (Int32Array, Int32ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<int>(agent, this);
            (Uint8Array, Uint8ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<byte>(agent, this);
            (Uint8ClampedArray, Uint8ClampedArrayPrototype) = TypedArrayIntrinsics.InitialiseType<byte>(agent, this, true);
            (Uint16Array, Uint16ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<ushort>(agent, this);
            (Uint32Array, Uint32ArrayPrototype) = TypedArrayIntrinsics.InitialiseType<uint>(agent, this);
        }

        internal void SetRealmGlobalObject([CanBeNull] ScriptObject globalObject, [CanBeNull] ScriptObject thisValue)
        {
            //https://tc39.github.io/ecma262/#sec-setrealmglobalobject
            if (globalObject == null)
            {
                globalObject = Agent.ObjectCreate(ObjectPrototype);
            }

            Debug.Assert(globalObject != null);
            if (thisValue == null)
            {
                thisValue = globalObject;
            }
            GlobalObject = globalObject;
            GlobalEnvironment = LexicalEnvironment.NewGlobalEnvironment(Agent, globalObject, thisValue);
        }

        internal void SetDefaultGlobalBindings()
        {
            var global = GlobalObject;
            var agent = Agent;
            agent.DefinePropertyOrThrow(global, "Infinity", new PropertyDescriptor(double.PositiveInfinity, false, false, false));
            agent.DefinePropertyOrThrow(global, "NaN", new PropertyDescriptor(double.NaN, false, false, false));
            agent.DefinePropertyOrThrow(global, "undefined", new PropertyDescriptor(ScriptValue.Undefined, false, false, false));

            agent.DefinePropertyOrThrow(global, "eval", new PropertyDescriptor(Eval, true, false, true));
            agent.DefinePropertyOrThrow(global, "isFinite", new PropertyDescriptor(IsFinite, true, false, true));
            agent.DefinePropertyOrThrow(global, "isNaN", new PropertyDescriptor(IsNaN, true, false, true));
            agent.DefinePropertyOrThrow(global, "parseFloat", new PropertyDescriptor(ParseFloat, true, false, true));
            agent.DefinePropertyOrThrow(global, "parseInt", new PropertyDescriptor(ParseInt, true, false, true));
            agent.DefinePropertyOrThrow(global, "decodeURI", new PropertyDescriptor(DecodeURI, true, false, true));
            agent.DefinePropertyOrThrow(global, "decodeURIComponent", new PropertyDescriptor(DecodeURIComponent, true, false, true));
            agent.DefinePropertyOrThrow(global, "encodeURI", new PropertyDescriptor(EncodeURI, true, false, true));
            agent.DefinePropertyOrThrow(global, "encodeURIComponent", new PropertyDescriptor(EncodeURIComponent, true, false, true));

            agent.DefinePropertyOrThrow(global, "Array", new PropertyDescriptor(Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "ArrayBuffer", new PropertyDescriptor(ArrayBuffer, true, false, true));
            agent.DefinePropertyOrThrow(global, "Boolean", new PropertyDescriptor(Boolean, true, false, true));
            agent.DefinePropertyOrThrow(global, "DataView", new PropertyDescriptor(DataView, true, false, true));
            agent.DefinePropertyOrThrow(global, "Date", new PropertyDescriptor(Date, true, false, true));
            agent.DefinePropertyOrThrow(global, "Error", new PropertyDescriptor(Error, true, false, true));
            agent.DefinePropertyOrThrow(global, "EvalError", new PropertyDescriptor(EvalError, true, false, true));
            agent.DefinePropertyOrThrow(global, "Float32Array", new PropertyDescriptor(Float32Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "Float64Array", new PropertyDescriptor(Float64Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "Function", new PropertyDescriptor(Function, true, false, true));
            agent.DefinePropertyOrThrow(global, "Int8Array", new PropertyDescriptor(Int8Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "Int16Array", new PropertyDescriptor(Int16Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "Int32Array", new PropertyDescriptor(Int32Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "Map", new PropertyDescriptor(Map, true, false, true));
            agent.DefinePropertyOrThrow(global, "Number", new PropertyDescriptor(Number, true, false, true));
            agent.DefinePropertyOrThrow(global, "Object", new PropertyDescriptor(ObjectConstructor, true, false, true));
            agent.DefinePropertyOrThrow(global, "Proxy", new PropertyDescriptor(Proxy, true, false, true));
            agent.DefinePropertyOrThrow(global, "Promise", new PropertyDescriptor(Promise, true, false, true));
            agent.DefinePropertyOrThrow(global, "RangeError", new PropertyDescriptor(RangeError, true, false, true));
            agent.DefinePropertyOrThrow(global, "ReferenceError", new PropertyDescriptor(ReferenceError, true, false, true));
            agent.DefinePropertyOrThrow(global, "RegExp", new PropertyDescriptor(RegExp, true, false, true));
            agent.DefinePropertyOrThrow(global, "Set", new PropertyDescriptor(Set, true, false, true));
            agent.DefinePropertyOrThrow(global, "SharedArrayBuffer", new PropertyDescriptor(SharedArrayBuffer, true, false, true));
            agent.DefinePropertyOrThrow(global, "String", new PropertyDescriptor(StringConstructor, true, false, true));
            agent.DefinePropertyOrThrow(global, "Symbol", new PropertyDescriptor(Symbol, true, false, true));
            agent.DefinePropertyOrThrow(global, "SyntaxError", new PropertyDescriptor(SyntaxError, true, false, true));
            agent.DefinePropertyOrThrow(global, "TypeError", new PropertyDescriptor(TypeError, true, false, true));
            agent.DefinePropertyOrThrow(global, "Uint8Array", new PropertyDescriptor(Uint8Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "Uint8ClampedArray", new PropertyDescriptor(Uint8ClampedArray, true, false, true));
            agent.DefinePropertyOrThrow(global, "Uint16Array", new PropertyDescriptor(Uint16Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "Uint32Array", new PropertyDescriptor(Uint32Array, true, false, true));
            agent.DefinePropertyOrThrow(global, "URIError", new PropertyDescriptor(UriError, true, false, true));
            agent.DefinePropertyOrThrow(global, "WeakMap", new PropertyDescriptor(WeakMap, true, false, true));
            agent.DefinePropertyOrThrow(global, "WeakSet", new PropertyDescriptor(WeakSet, true, false, true));

            agent.DefinePropertyOrThrow(global, "Atomics", new PropertyDescriptor(Atomics, true, false, true));
            agent.DefinePropertyOrThrow(global, "JSON", new PropertyDescriptor(Json, true, false, true));
            agent.DefinePropertyOrThrow(global, "Math", new PropertyDescriptor(Math, true, false, true));
            agent.DefinePropertyOrThrow(global, "Reflect", new PropertyDescriptor(Reflect, true, false, true));
        }

        private void AddRestrictedFunctionProperties([NotNull] ScriptObject function)
        {
            //https://tc39.github.io/ecma262/#sec-addrestrictedfunctionproperties
            Debug.Assert(ThrowTypeError != null);
            Agent.DefinePropertyOrThrow(function, "caller", new PropertyDescriptor(ThrowTypeError, ThrowTypeError, false, true));
            Agent.DefinePropertyOrThrow(function, "arguments", new PropertyDescriptor(ThrowTypeError, ThrowTypeError, false, true));
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "Realm (" + name + ")";
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

        private static ScriptValue IsFiniteImplementation([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-isfinite-number
            var number = arg.Agent.ToNumber(arg[0]);
            return !double.IsNaN(number) && !double.IsInfinity(number);
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

        private static readonly char[] validChars =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        private static ScriptValue ParseIntImplementation([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-parseint-string-radix
            var inputString = arg.Agent.ToString(arg[0]).TrimStart();
            var sign = inputString.Length > 0 && inputString[0] == '-' ? -1 : 1;
            if (inputString.Length > 0 && (inputString[0] == '-' || inputString[0] == '+'))
            {
                inputString = inputString.Substring(1);
            }

            var radix = arg.Agent.ToInt32(arg[1]);
            var stripPrefix = true;
            if (radix != 0)
            {
                if (radix < 2 || radix > 36)
                {
                    return double.NaN;
                }

                if (radix != 16)
                {
                    stripPrefix = false;
                }
            }
            else
            {
                radix = 10;
            }

            if (stripPrefix)
            {
                if (inputString.Length > 1 && inputString[0] == '0' && (inputString[1] == 'x' || inputString[1] == 'X'))
                {
                    inputString = inputString.Substring(2);
                    radix = 16;
                }
            }

            if (inputString.Length == 0 || !IsValidDigitChar(inputString[0], radix))
            {
                return double.NaN;
            }

            var value = 0L;
            foreach (var c in inputString)
            {
                if (!IsValidDigitChar(c, radix))
                {
                    break;
                }

                value *= radix;
                if (c >= '0' && c <= '9')
                {
                    value += c - '0';
                }
                else
                {
                    value += c - 'a' + 10;
                }
            }

            if (value == 0)
            {
                return sign * 0.0;
            }

            return sign * value;
        }

        private static bool IsValidDigitChar(char c, int radix)
        {
            for (var i = 0; i < radix; i++)
            {
                if (validChars[i] == char.ToLowerInvariant(c))
                {
                    return true;
                }
            }

            return false;
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

        [NotNull] public ScriptFunctionObject Array { get; }

        [NotNull] public ScriptFunctionObject ArrayBuffer { get; }

        [NotNull] public ScriptObject ArrayBufferPrototype { get; }

        [NotNull] public ScriptObject ArrayIteratorPrototype { get; }

        [NotNull] public ScriptObject ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject ArrayProtoEntries { get; }

        [NotNull] public ScriptFunctionObject ArrayProtoForEach { get; }

        [NotNull] public ScriptFunctionObject ArrayProtoKeys { get; }

        [NotNull] public ScriptFunctionObject ArrayProtoValues { get; }

        [NotNull] public ScriptFunctionObject AsyncFunction { get; }

        [NotNull] public ScriptObject AsyncFunctionPrototype { get; }

        [NotNull] public ScriptObject Atomics { get; }

        [NotNull] public ScriptFunctionObject Boolean { get; }

        [NotNull] public ScriptObject BooleanPrototype { get; }

        [NotNull] public ScriptFunctionObject DataView { get; }

        [NotNull] public ScriptObject DataViewPrototype { get; }

        [NotNull] public ScriptFunctionObject Date { get; }

        [NotNull] public ScriptObject DatePrototype { get; }

        [NotNull] public ScriptFunctionObject DecodeURI { get; }

        [NotNull] public ScriptFunctionObject DecodeURIComponent { get; }

        [NotNull] public ScriptFunctionObject EncodeURI { get; }

        [NotNull] public ScriptFunctionObject EncodeURIComponent { get; }

        [NotNull] public ScriptFunctionObject Error { get; }

        [NotNull] public ScriptObject ErrorPrototype { get; }

        [NotNull] public ScriptFunctionObject Eval { get; }

        [NotNull] public ScriptFunctionObject EvalError { get; }

        [NotNull] public ScriptObject EvalErrorPrototype { get; }

        [NotNull] public ScriptFunctionObject Float32Array { get; }

        [NotNull] public ScriptObject Float32ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject Float64Array { get; }

        [NotNull] public ScriptObject Float64ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject Function { get; }

        [NotNull] public ScriptObject FunctionPrototype { get; }

        [NotNull] public ScriptObject Generator { get; }

        [NotNull] public ScriptFunctionObject GeneratorFunction { get; }

        [NotNull] public ScriptObject GeneratorPrototype { get; }

        [NotNull] public ScriptFunctionObject Int8Array { get; }

        [NotNull] public ScriptObject Int8ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject Int16Array { get; }

        [NotNull] public ScriptObject Int16ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject Int32Array { get; }

        [NotNull] public ScriptObject Int32ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject IsFinite { get; }

        [NotNull] public ScriptFunctionObject IsNaN { get; }

        [NotNull] public ScriptObject IteratorPrototype { get; }

        [NotNull] public ScriptObject Json { get; }

        [NotNull] public ScriptFunctionObject JsonParse { get; }

        [NotNull] public ScriptFunctionObject Map { get; }

        [NotNull] public ScriptObject MapIteratorPrototype { get; }

        [NotNull] public ScriptObject MapPrototype { get; }

        [NotNull] public ScriptObject Math { get; }

        [NotNull] public ScriptFunctionObject Number { get; }

        [NotNull] public ScriptObject NumberPrototype { get; }

        [NotNull] public ScriptFunctionObject ObjectConstructor { get; }

        [NotNull] public ScriptObject ObjectPrototype { get; }

        [NotNull] public ScriptFunctionObject ObjProtoToString { get; }

        [NotNull] public ScriptFunctionObject ObjProtoValueOf { get; }

        [NotNull] public ScriptFunctionObject ParseFloat { get; }

        [NotNull] public ScriptFunctionObject ParseInt { get; }

        [NotNull] public ScriptFunctionObject Promise { get; }

        [NotNull] public ScriptObject PromisePrototype { get; }

        [NotNull] public ScriptFunctionObject PromiseProtoThen { get; }

        [NotNull] public ScriptFunctionObject PromiseAll { get; }

        [NotNull] public ScriptFunctionObject PromiseReject { get; }

        [NotNull] public ScriptFunctionObject PromiseResolve { get; }

        [NotNull] public ScriptFunctionObject Proxy { get; }

        [NotNull] public ScriptFunctionObject RangeError { get; }

        [NotNull] public ScriptObject RangeErrorPrototype { get; }

        [NotNull] public ScriptFunctionObject ReferenceError { get; }

        [NotNull] public ScriptObject ReferenceErrorPrototype { get; }

        [NotNull] public ScriptObject Reflect { get; }

        [NotNull] public ScriptFunctionObject RegExp { get; }

        [NotNull] public ScriptObject RegExpPrototype { get; }

        [NotNull] public ScriptFunctionObject Set { get; }

        [NotNull] public ScriptObject SetIteratorPrototype { get; }

        [NotNull] public ScriptObject SetPrototype { get; }

        [NotNull] public ScriptFunctionObject SharedArrayBuffer { get; }

        [NotNull] public ScriptObject SharedArrayBufferPrototype { get; }

        [NotNull] public ScriptFunctionObject StringConstructor { get; }

        [NotNull] public ScriptObject StringIteratorPrototype { get; }

        [NotNull] public ScriptObject StringPrototype { get; }

        [NotNull] public ScriptFunctionObject Symbol { get; }

        [NotNull] public ScriptObject SymbolPrototype { get; }

        [NotNull] public ScriptFunctionObject SyntaxError { get; }

        [NotNull] public ScriptObject SyntaxErrorPrototype { get; }

        [NotNull] public ScriptFunctionObject ThrowTypeError { get; }

        [NotNull] public ScriptFunctionObject TypedArray { get; }

        [NotNull] public ScriptObject TypedArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject TypeError { get; }

        [NotNull] public ScriptObject TypeErrorPrototype { get; }

        [NotNull] public ScriptFunctionObject Uint8Array { get; }

        [NotNull] public ScriptObject Uint8ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject Uint8ClampedArray { get; }

        [NotNull] public ScriptObject Uint8ClampedArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject Uint16Array { get; }

        [NotNull] public ScriptObject Uint16ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject Uint32Array { get; }

        [NotNull] public ScriptObject Uint32ArrayPrototype { get; }

        [NotNull] public ScriptFunctionObject UriError { get; }

        [NotNull] public ScriptObject UriErrorPrototype { get; }

        [NotNull] public ScriptFunctionObject WeakMap { get; }

        [NotNull] public ScriptObject WeakMapPrototype { get; }

        [NotNull] public ScriptFunctionObject WeakSet { get; }

        [NotNull] public ScriptObject WeakSetPrototype { get; }

        internal Random Random { get; } = new Random();
    }
}
