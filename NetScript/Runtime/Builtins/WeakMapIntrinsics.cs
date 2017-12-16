using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class WeakMapIntrinsics
    {
        public static (ScriptFunctionObject WeakMap, ScriptObject WeakMapPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var weakMap = Intrinsics.CreateBuiltinFunction(realm, WeakMap, realm.FunctionPrototype, 0, "WeakMap", ConstructorKind.Base);

            var weakMapPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineDataProperty(weakMapPrototype, "constructor", weakMap);
            Intrinsics.DefineFunction(weakMapPrototype, "delete", 1, realm, Delete);
            Intrinsics.DefineFunction(weakMapPrototype, "get", 1, realm, Get);
            Intrinsics.DefineFunction(weakMapPrototype, "has", 1, realm, Has);
            Intrinsics.DefineFunction(weakMapPrototype, "set", 2, realm, Set);
            Intrinsics.DefineDataProperty(weakMapPrototype, Symbol.ToStringTag, "WeakMap", false);

            Intrinsics.DefineDataProperty(weakMap, "prototype", weakMapPrototype, false, false, false);

            return (weakMap, weakMapPrototype);
        }

        private static ScriptValue WeakMap(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Delete(ScriptArguments arg)
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

        private static ScriptValue Set(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}