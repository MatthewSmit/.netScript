using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class MapIntrinsics
    {
        public static (ScriptFunctionObject Map, ScriptObject MapPrototype, ScriptObject MapIteratorPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var map = Intrinsics.CreateBuiltinFunction(realm, Map, realm.FunctionPrototype, 0, "Map", ConstructorKind.Base);
            Intrinsics.DefineAccessorProperty(map, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            var mapPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineFunction(mapPrototype, "clear", 0, realm, Clear);
            Intrinsics.DefineDataProperty(mapPrototype, "constructor", map);
            Intrinsics.DefineFunction(mapPrototype, "delete", 1, realm, Delete);
            var mapEntries = Intrinsics.DefineFunction(mapPrototype, "entries", 0, realm, Entries);
            Intrinsics.DefineFunction(mapPrototype, "forEach", 1, realm, ForEach);
            Intrinsics.DefineFunction(mapPrototype, "get", 1, realm, Get);
            Intrinsics.DefineFunction(mapPrototype, "has", 1, realm, Has);
            Intrinsics.DefineFunction(mapPrototype, "keys", 0, realm, Keys);
            Intrinsics.DefineFunction(mapPrototype, "set", 2, realm, Set);
            Intrinsics.DefineAccessorProperty(mapPrototype, "size", Intrinsics.CreateBuiltinFunction(realm, GetSize, realm.FunctionPrototype, 0, "get size"), null);
            Intrinsics.DefineFunction(mapPrototype, "values", 0, realm, Values);
            Intrinsics.DefineDataProperty(mapPrototype, Symbol.Iterator, mapEntries);
            Intrinsics.DefineDataProperty(mapPrototype, Symbol.ToStringTag, "Map", false);

            Intrinsics.DefineDataProperty(map, "prototype", mapPrototype, false, false, false);

            var mapIteratorPrototype = agent.ObjectCreate(realm.IteratorPrototype);
            Intrinsics.DefineFunction(mapIteratorPrototype, "next", 0, realm, Next);
            Intrinsics.DefineDataProperty(mapIteratorPrototype, Symbol.ToStringTag, "Map Iterator", false);

            return (map, mapPrototype, mapIteratorPrototype);
        }

        private static ScriptValue Map(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
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

        private static ScriptValue Get(ScriptArguments arg)
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

        private static ScriptValue Set(ScriptArguments arg)
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