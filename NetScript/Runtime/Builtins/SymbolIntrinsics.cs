using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class SymbolIntrinsics
    {
        public static (ScriptFunctionObject symbol, ScriptObject symbolPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var symbol = Intrinsics.CreateBuiltinFunction(realm, SymbolConstructor, functionPrototype, 0, "Symbol", ConstructorKind.Base);
            Intrinsics.DefineFunction(symbol, "for", 1, realm, For);
            Intrinsics.DefineDataProperty(symbol, "hasInstance", Symbol.HasInstance, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "isConcatSpreadable", Symbol.IsConcatSpreadable, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "iterator", Symbol.Iterator, false, false, false);
            Intrinsics.DefineFunction(symbol, "keyFor", 1, realm, KeyFor);
            Intrinsics.DefineDataProperty(symbol, "match", Symbol.Match, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "replace", Symbol.Replace, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "search", Symbol.Search, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "species", Symbol.Species, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "split", Symbol.Split, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "toPrimitive", Symbol.ToPrimitive, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "toStringTag", Symbol.ToStringTag, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "unscopables", Symbol.Unscopables, false, false, false);

            var symbolPrototype = agent.ObjectCreate(objectPrototype);
            Intrinsics.DefineDataProperty(symbolPrototype, "constructor", symbol);
            Intrinsics.DefineFunction(symbolPrototype, "toString", 0, realm, ToString);
            Intrinsics.DefineFunction(symbolPrototype, "valueOf", 0, realm, ValueOf);
            Intrinsics.DefineDataProperty(symbolPrototype, Symbol.ToPrimitive, Intrinsics.CreateBuiltinFunction(realm, ToPrimitive, functionPrototype, 1, "[Symbol.toPrimitive]"), false);
            Intrinsics.DefineDataProperty(symbolPrototype, Symbol.ToStringTag, "Symbol", false);

            Intrinsics.DefineDataProperty(symbol, "prototype", symbolPrototype, false, false, false);

            return (symbol, symbolPrototype);
        }

        private static ScriptValue SymbolConstructor([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol-description

            if (arg.NewTarget != null)
            {
                throw arg.Agent.CreateTypeError();
            }

            var descriptionString = arg[0] == ScriptValue.Undefined ? ScriptValue.Undefined : arg.Agent.ToString(arg[0]);
            return new Symbol(descriptionString == ScriptValue.Undefined ? null : (string)descriptionString);
        }

        private static ScriptValue For([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol.for
            var stringKey = arg.Agent.ToString(arg[0]);
            lock (Symbol.GlobalRegistry)
            {
                if (Symbol.GlobalRegistry.TryGetValue(stringKey, out var symbol))
                {
                    return symbol;
                }

                var newSymbol = new Symbol(stringKey);
                Symbol.GlobalRegistry[stringKey] = newSymbol;
                return newSymbol;
            }
        }

        private static ScriptValue KeyFor([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol.keyfor
            if (!arg[0].IsSymbol)
            {
                throw arg.Agent.CreateTypeError();
            }

            var symbol = (Symbol)arg[0];

            lock (Symbol.GlobalRegistry)
            {
                foreach (var pair in Symbol.GlobalRegistry)
                {
                    if (pair.Value == symbol)
                    {
                        return pair.Key;
                    }
                }
            }

            return ScriptValue.Undefined;
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol.prototype.tostring
            var symbol = ThisSymbolValue(arg.Agent, arg.ThisValue);
            return SymbolDescriptiveString(symbol);
        }

        private static ScriptValue ValueOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol.prototype.valueof
            return ThisSymbolValue(arg.Agent, arg.ThisValue);
        }

        private static ScriptValue ToPrimitive([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol.prototype-@@toprimitive
            return ThisSymbolValue(arg.Agent, arg.ThisValue);
        }

        public static ScriptValue SymbolDescriptiveString([NotNull] Symbol symbol)
        {
            //https://tc39.github.io/ecma262/#sec-symboldescriptivestring
            var description = symbol.Description ?? "";
            return "Symbol(" + description + ")";
        }

        private static Symbol ThisSymbolValue([NotNull] Agent agent, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-thissymbolvalue
            if (value.IsSymbol)
            {
                return (Symbol)value;
            }

            if (value.IsObject && ((ScriptObject)value).SpecialObjectType == SpecialObjectType.Symbol)
            {
                return ((ScriptObject)value).SymbolValue;
            }

            throw agent.CreateTypeError();
        }
    }
}