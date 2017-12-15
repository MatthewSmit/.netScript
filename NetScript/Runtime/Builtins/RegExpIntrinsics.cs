using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class RegExpIntrinsics
    {
        public static (ScriptObject RegExp, ScriptObject RegExpPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var regExp = Intrinsics.CreateBuiltinFunction(agent, realm, RegExp, realm.FunctionPrototype, 2, "RegExp", ConstructorKind.Base);

            var regExpPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineDataProperty(regExpPrototype, "constructor", regExp);
            Intrinsics.DefineFunction(regExpPrototype, "exec", 1, agent, realm, Exec);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "flags", Intrinsics.CreateBuiltinFunction(agent, realm, GetFlags, realm.FunctionPrototype, 0, "get flags"), null);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "global", Intrinsics.CreateBuiltinFunction(agent, realm, GetGlobal, realm.FunctionPrototype, 0, "get global"), null);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "ignoreCase", Intrinsics.CreateBuiltinFunction(agent, realm, GetIgnoreCase, realm.FunctionPrototype, 0, "get ignoreCase"), null);
            Intrinsics.DefineDataProperty(regExpPrototype, realm.SymbolMatch, Intrinsics.CreateBuiltinFunction(agent, realm, Match, realm.FunctionPrototype, 1, "[Symbol.match]"));
            Intrinsics.DefineAccessorProperty(regExpPrototype, "multiline", Intrinsics.CreateBuiltinFunction(agent, realm, GetMultiline, realm.FunctionPrototype, 0, "get multiline"), null);
            Intrinsics.DefineDataProperty(regExpPrototype, realm.SymbolReplace, Intrinsics.CreateBuiltinFunction(agent, realm, Replace, realm.FunctionPrototype, 2, "[Symbol.replace]"));
            Intrinsics.DefineDataProperty(regExpPrototype, realm.SymbolSearch, Intrinsics.CreateBuiltinFunction(agent, realm, Search, realm.FunctionPrototype, 1, "[Symbol.search]"));
            Intrinsics.DefineAccessorProperty(regExpPrototype, "source", Intrinsics.CreateBuiltinFunction(agent, realm, GetSource, realm.FunctionPrototype, 0, "get source"), null);
            Intrinsics.DefineDataProperty(regExpPrototype, realm.SymbolSplit, Intrinsics.CreateBuiltinFunction(agent, realm, Split, realm.FunctionPrototype, 2, "[Symbol.split]"));
            Intrinsics.DefineAccessorProperty(regExpPrototype, "sticky", Intrinsics.CreateBuiltinFunction(agent, realm, GetSticky, realm.FunctionPrototype, 0, "get sticky"), null);
            Intrinsics.DefineFunction(regExpPrototype, "test", 1, agent, realm, Test);
            Intrinsics.DefineFunction(regExpPrototype, "toString", 0, agent, realm, ToString);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "unicode", Intrinsics.CreateBuiltinFunction(agent, realm, GetUnicode, realm.FunctionPrototype, 0, "get unicode"), null);

            Intrinsics.DefineDataProperty(regExp, "prototype", regExpPrototype, false, false, false);
            Intrinsics.DefineAccessorProperty(regExp, realm.SymbolSpecies, Intrinsics.CreateBuiltinFunction(agent, realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            return (regExp, regExpPrototype);
        }

        private static ScriptValue RegExp(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Exec(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetFlags(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetGlobal(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetIgnoreCase(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Match(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetMultiline(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Replace(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Search(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSource(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Split(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSticky(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Test(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue ToString(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetUnicode(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}