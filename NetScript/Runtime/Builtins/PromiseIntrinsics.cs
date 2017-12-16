using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class PromiseIntrinsics
    {
        public static (ScriptFunctionObject Promise,
            ScriptObject PromisePrototype,
            ScriptFunctionObject PromiseProtoThen,
            ScriptFunctionObject PromiseAll,
            ScriptFunctionObject PromiseReject,
            ScriptFunctionObject PromiseResolve) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var promise = Intrinsics.CreateBuiltinFunction(realm, Promise, realm.FunctionPrototype, 1, "Promise", ConstructorKind.Base);
            var promiseAll = Intrinsics.DefineFunction(promise, "all", 1, realm, All);
            Intrinsics.DefineFunction(promise, "race", 1, realm, Race);
            var promiseReject = Intrinsics.DefineFunction(promise, "reject", 1, realm, Reject);
            var promiseResolve = Intrinsics.DefineFunction(promise, "resolve", 1, realm, Resolve);
            Intrinsics.DefineAccessorProperty(promise, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            var promisePrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineFunction(promisePrototype, "catch", 1, realm, Catch);
            var promiseProtoThen = Intrinsics.DefineFunction(promisePrototype, "then", 2, realm, Then);

            Intrinsics.DefineDataProperty(promisePrototype, "constructor", promise);
            Intrinsics.DefineDataProperty(promisePrototype, Symbol.ToStringTag, "Promise", false);

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