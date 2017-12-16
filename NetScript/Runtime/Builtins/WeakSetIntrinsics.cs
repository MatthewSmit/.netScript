using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class WeakSetIntrinsics
    {
        public static (ScriptFunctionObject WeakSet, ScriptObject WeakSetPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var weakSet = Intrinsics.CreateBuiltinFunction(realm, Set, realm.FunctionPrototype, 0, "Set", ConstructorKind.Base);

            var weakSetPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineFunction(weakSetPrototype, "add", 1, realm, Add);
            Intrinsics.DefineDataProperty(weakSetPrototype, "constructor", weakSet);
            Intrinsics.DefineFunction(weakSetPrototype, "delete", 1, realm, Delete);
            Intrinsics.DefineFunction(weakSetPrototype, "has", 1, realm, Has);
            Intrinsics.DefineDataProperty(weakSetPrototype, Symbol.ToStringTag, "WeakSet", false);

            Intrinsics.DefineDataProperty(weakSet, "prototype", weakSetPrototype, false, false, false);

            return (weakSet, weakSetPrototype);
        }

        private static ScriptValue Set(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Add(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Delete(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Has(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}