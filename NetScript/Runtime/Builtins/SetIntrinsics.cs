using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class SetIntrinsics
    {
        public static (ScriptFunctionObject Set, ScriptObject SetPrototype, ScriptObject SetIteratorPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var set = Intrinsics.CreateBuiltinFunction(realm, Set, realm.FunctionPrototype, 0, "Set", ConstructorKind.Base);
            Intrinsics.DefineAccessorProperty(set, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            var setPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineFunction(setPrototype, "add", 1, realm, Add);
            Intrinsics.DefineFunction(setPrototype, "clear", 0, realm, Clear);
            Intrinsics.DefineDataProperty(setPrototype, "constructor", set);
            Intrinsics.DefineFunction(setPrototype, "delete", 1, realm, Delete);
            var setEntries = Intrinsics.DefineFunction(setPrototype, "entries", 0, realm, Entries);
            Intrinsics.DefineFunction(setPrototype, "forEach", 1, realm, ForEach);
            Intrinsics.DefineFunction(setPrototype, "has", 1, realm, Has);
            Intrinsics.DefineFunction(setPrototype, "keys", 0, realm, Keys);
            Intrinsics.DefineAccessorProperty(setPrototype, "size", Intrinsics.CreateBuiltinFunction(realm, GetSize, realm.FunctionPrototype, 0, "get size"), null);
            Intrinsics.DefineFunction(setPrototype, "values", 0, realm, Values);
            Intrinsics.DefineDataProperty(setPrototype, Symbol.Iterator, setEntries);
            Intrinsics.DefineDataProperty(setPrototype, Symbol.ToStringTag, "Set", false);

            Intrinsics.DefineDataProperty(set, "prototype", setPrototype, false, false, false);

            var setIteratorPrototype = agent.ObjectCreate(realm.IteratorPrototype);
            Intrinsics.DefineFunction(setIteratorPrototype, "next", 0, realm, Next);
            Intrinsics.DefineDataProperty(setIteratorPrototype, Symbol.ToStringTag, "Set Iterator", false);

            return (set, setPrototype, setIteratorPrototype);
        }

        private static ScriptValue Set(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Add(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Clear(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Delete(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Entries(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue ForEach(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Has(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Keys(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSize(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Values(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Next(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}