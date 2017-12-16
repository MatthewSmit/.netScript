using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class ProxyIntrinsics
    {
        [NotNull]
        public static ScriptFunctionObject Initialise([NotNull] Realm realm)
        {
            var proxy = Intrinsics.CreateBuiltinFunction(realm, Proxy, realm.FunctionPrototype, 2, "Proxy", ConstructorKind.Base);
            Intrinsics.DefineFunction(proxy, "revocable", 2, realm, Revocable);
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

        private static ScriptValue Revocable([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-proxy.revocable
            var proxy = ProxyCreate(arg.Agent, arg[0], arg[1]);

            var revoker = new ScriptFunctionObject(arg.Function.Realm, arg.Function.Realm.FunctionPrototype, true, ProxyRevocation, SpecialObjectType.RevocableProxy);
            revoker.DefineOwnProperty("length", new PropertyDescriptor(0, false, false, true));
            revoker.RevocableProxy = proxy;

            var result = arg.Agent.ObjectCreate(arg.Function.Realm.ObjectPrototype);
            result.CreateDataProperty("proxy", proxy);
            result.CreateDataProperty("revoke", revoker);
            return result;
        }

        private static ScriptValue ProxyRevocation([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-revocation-functions
            var proxy = arg.Function.RevocableProxy;
            if (proxy == null)
            {
                return ScriptValue.Undefined;
            }

            arg.Function.RevocableProxy = null;
            Debug.Assert(proxy is ScriptProxyObject);
            var proxyObject = (ScriptProxyObject)proxy;
            proxyObject.ProxyTarget = null;
            proxyObject.ProxyHandler = null;
            return ScriptValue.Undefined;
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

            return new ScriptProxyObject(targetObject.Realm, targetObject, handlerObject);
        }
    }
}