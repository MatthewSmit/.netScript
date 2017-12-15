using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class PromiseIntrinsics
    {
        public static (ScriptObject Promise,
            ScriptObject PromisePrototype,
            ScriptObject PromiseProtoThen,
            ScriptObject PromiseAll,
            ScriptObject PromiseReject,
            ScriptObject PromiseResolve) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var promise = Intrinsics.CreateBuiltinFunction(agent, realm, Promise, realm.FunctionPrototype, 1, "Promise", ConstructorKind.Base);
            var promiseAll = Intrinsics.DefineFunction(promise, "all", 1, agent, realm, All);
            Intrinsics.DefineFunction(promise, "race", 1, agent, realm, Race);
            var promiseReject = Intrinsics.DefineFunction(promise, "reject", 1, agent, realm, Reject);
            var promiseResolve = Intrinsics.DefineFunction(promise, "resolve", 1, agent, realm, Resolve);
            Intrinsics.DefineAccessorProperty(promise, realm.SymbolSpecies, Intrinsics.CreateBuiltinFunction(agent, realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            var promisePrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineFunction(promisePrototype, "catch", 1, agent, realm, Catch);
            var promiseProtoThen = Intrinsics.DefineFunction(promisePrototype, "then", 2, agent, realm, Then);

            Intrinsics.DefineDataProperty(promisePrototype, "constructor", promise);
            Intrinsics.DefineDataProperty(promisePrototype, realm.SymbolToStringTag, "Promise", false);

            Intrinsics.DefineDataProperty(promise, "prototype", promisePrototype, false, false, false);

            return (promise, promisePrototype, promiseProtoThen, promiseAll, promiseReject, promiseResolve);
        }

        private static ScriptValue Promise(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue All(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Race(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Reject(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Resolve(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Catch(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Then(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}