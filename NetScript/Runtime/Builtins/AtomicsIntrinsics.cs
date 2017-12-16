using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class AtomicsIntrinsics
    {
        [NotNull]
        public static ScriptObject Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var atomics = agent.ObjectCreate(realm.ObjectPrototype);

            Intrinsics.DefineFunction(atomics, "add", 3, realm, Add);
            Intrinsics.DefineFunction(atomics, "and", 3, realm, And);
            Intrinsics.DefineFunction(atomics, "compareExchange", 4, realm, CompareExchange);
            Intrinsics.DefineFunction(atomics, "exchange", 3, realm, Exchange);
            Intrinsics.DefineFunction(atomics, "isLockFree", 1, realm, IsLockFree);
            Intrinsics.DefineFunction(atomics, "load", 2, realm, Load);
            Intrinsics.DefineFunction(atomics, "or", 3, realm, Or);
            Intrinsics.DefineFunction(atomics, "store", 3, realm, Store);
            Intrinsics.DefineFunction(atomics, "sub", 3, realm, Sub);
            Intrinsics.DefineFunction(atomics, "wait", 4, realm, Wait);
            Intrinsics.DefineFunction(atomics, "wake", 3, realm, Wake);
            Intrinsics.DefineFunction(atomics, "xor", 3, realm, Xor);
            Intrinsics.DefineDataProperty(atomics, Symbol.ToStringTag, "Atomics", false);

            return atomics;
        }

        private static ScriptValue Add(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue And(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue CompareExchange(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Exchange(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue IsLockFree(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Load(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Or(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Store(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Sub(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Wait(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Wake(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Xor(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}