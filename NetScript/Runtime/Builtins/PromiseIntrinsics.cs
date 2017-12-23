using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static ScriptValue Promise([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-promise-executor
            if (arg.NewTarget == null)
            {
                throw arg.Agent.CreateTypeError();
            }

            if (!Agent.IsCallable(arg[0]))
            {
                throw arg.Agent.CreateTypeError();
            }

            var promise = arg.Agent.OrdinaryCreateFromConstructor(arg.NewTarget, arg.Function.Realm.PromisePrototype, SpecialObjectType.PromiseState);
            promise.PromiseState.State = ScriptObject.PromiseStateInternals.PromiseState.Pending;
            promise.PromiseState.FulfillReactions = new List<object>();
            promise.PromiseState.RejectReactions = new List<object>();
            promise.PromiseState.IsHandled = false;

            var resolvingFunctions = CreateResolvingFunctions(arg.Function.Realm, promise);
            try
            {
                arg.Agent.Call((ScriptObject)arg[0], ScriptValue.Undefined, resolvingFunctions.Resolve, resolvingFunctions.Reject);
            }
            catch (ScriptException e)
            {
                arg.Agent.Call(resolvingFunctions.Reject, ScriptValue.Undefined, e.Value);
            }

            return promise;
        }

        private static ScriptValue All(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Race(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Reject(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Resolve(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Catch(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Then(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }


        private static (ScriptFunctionObject Resolve, ScriptFunctionObject Reject) CreateResolvingFunctions([NotNull] Realm realm, ScriptObject promise)
        {
            //https://tc39.github.io/ecma262/#sec-createresolvingfunctions
            var resolve = new ScriptFunctionObject(realm, realm.FunctionPrototype, true, arguments =>
            {
                //https://tc39.github.io/ecma262/#sec-promise-resolve-functions
                throw new NotImplementedException();
            }, SpecialObjectType.Promise);
            resolve.Promise.Promise = promise;
            resolve.Promise.Value = false;
            var reject = new ScriptFunctionObject(realm, realm.FunctionPrototype, true, arguments =>
            {
                //https://tc39.github.io/ecma262/#sec-promise-reject-functions
                throw new NotImplementedException();
            }, SpecialObjectType.Promise);
            reject.Promise.Promise = promise;
            reject.Promise.Value = false;
            return (Resolve: resolve, Reject: reject);
        }

        public static ScriptValue GetCapabilitiesExecutor([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-getcapabilitiesexecutor-functions
            var function = arg.Function;
            Debug.Assert(function.SpecialObjectType == SpecialObjectType.PromiseCapability);

            var promiseCapability = function.Capability;
            if (promiseCapability.Resolve != null)
            {
                throw arg.Agent.CreateTypeError();
            }
            if (promiseCapability.Reject != null)
            {
                throw arg.Agent.CreateTypeError();
            }

            promiseCapability.Resolve = (ScriptObject)arg[0];
            promiseCapability.Reject = (ScriptObject)arg[1];
            return ScriptValue.Undefined;
        }
    }
}