﻿using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class ProxyIntrinsics
    {
        [NotNull]
        public static ScriptObject Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var proxy = Intrinsics.CreateBuiltinFunction(agent, realm, Proxy, realm.FunctionPrototype, 2, "Proxy", ConstructorKind.Base);
            Intrinsics.DefineFunction(proxy, "revocable", 2, agent, realm, Revocable);
            return proxy;
        }

        private static ScriptValue Proxy([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-target-handler
            if (arg.NewTarget == null)
            {
                throw arg.Agent.CreateTypeError();
            }

            return ProxyCreate(arg.Agent, arg[0], arg[1]);
        }

        private static ScriptValue Revocable(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        [NotNull]
        private static ScriptProxyObject ProxyCreate([NotNull] Agent agent, ScriptValue target, ScriptValue handler)
        {
            //https://tc39.github.io/ecma262/#sec-proxycreate
            if (!target.IsObject)
            {
                throw agent.CreateTypeError();
            }
            var targetObject = (ScriptObject)target;
            if (targetObject is ScriptProxyObject targetProxy && targetProxy.ProxyHandler == null)
            {
                throw agent.CreateTypeError();
            }

            if (!handler.IsObject)
            {
                throw agent.CreateTypeError();
            }
            var handlerObject = (ScriptObject)handler;
            if (handlerObject is ScriptProxyObject handlerProxy && handlerProxy.ProxyHandler == null)
            {
                throw agent.CreateTypeError();
            }

            return new ScriptProxyObject(agent, targetObject, handlerObject);
        }
    }
}