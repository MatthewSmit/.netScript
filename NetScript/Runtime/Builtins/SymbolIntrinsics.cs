using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class SymbolIntrinsics
    {
        public static (ScriptObject symbol, ScriptObject symbolPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var symbol = Intrinsics.CreateBuiltinFunction(agent, realm, Symbol, functionPrototype, 0, "Symbol", ConstructorKind.Base);
            Intrinsics.DefineFunction(symbol, "for", 1, agent, realm, For);
            Intrinsics.DefineDataProperty(symbol, "hasInstance", realm.SymbolHasInstance, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "isConcatSpreadable", realm.SymbolIsConcatSpreadable, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "iterator", realm.SymbolIterator, false, false, false);
            Intrinsics.DefineFunction(symbol, "keyFor", 1, agent, realm, KeyFor);
            Intrinsics.DefineDataProperty(symbol, "match", realm.SymbolMatch, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "replace", realm.SymbolReplace, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "search", realm.SymbolSearch, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "species", realm.SymbolSpecies, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "split", realm.SymbolSplit, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "toPrimitive", realm.SymbolToPrimitive, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "toStringTag", realm.SymbolToStringTag, false, false, false);
            Intrinsics.DefineDataProperty(symbol, "unscopables", realm.SymbolUnscopables, false, false, false);

            var symbolPrototype = agent.ObjectCreate(objectPrototype);
            Intrinsics.DefineDataProperty(symbolPrototype, "constructor", symbol);
            Intrinsics.DefineFunction(symbolPrototype, "toString", 0, agent, realm, ToString);
            Intrinsics.DefineFunction(symbolPrototype, "valueOf", 0, agent, realm, ValueOf);
            Intrinsics.DefineDataProperty(symbolPrototype, realm.SymbolToPrimitive, Intrinsics.CreateBuiltinFunction(agent, realm, ToPrimitive, functionPrototype, 1, "[Symbol.toPrimitive]"), false);
            Intrinsics.DefineDataProperty(symbolPrototype, realm.SymbolToStringTag, "Symbol", false);

            Intrinsics.DefineDataProperty(symbol, "prototype", symbolPrototype, false, false, false);

            return (symbol, symbolPrototype);
        }

        private static ScriptValue Symbol([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol-description

            if (arg.NewTarget != null)
            {
                throw arg.Agent.CreateTypeError();
            }

            var descriptionString = arg[0] == ScriptValue.Undefined ? ScriptValue.Undefined : arg.Agent.ToString(arg[0]);
            return new Symbol(descriptionString == ScriptValue.Undefined ? null : (string)descriptionString);
        }

        private static ScriptValue For(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue KeyFor(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue ToString(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue ValueOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-symbol.prototype.valueof
            return ThisSymbolValue(arg.Agent, arg.ThisValue);
        }

        private static ScriptValue ToPrimitive(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        public static ScriptValue SymbolDescriptiveString(ScriptValue symbol)
        {
            //https://tc39.github.io/ecma262/#sec-symboldescriptivestring
            Debug.Assert(symbol.IsSymbol);
            var description = ((Symbol)symbol).Description ?? "";
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