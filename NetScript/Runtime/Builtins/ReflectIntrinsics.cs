using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class ReflectIntrinsics
    {
        [NotNull]
        public static ScriptObject Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var reflect = agent.ObjectCreate(realm.ObjectPrototype);

            Intrinsics.DefineFunction(reflect, "apply", 3, realm, Apply);
            Intrinsics.DefineFunction(reflect, "construct", 2, realm, Construct);
            Intrinsics.DefineFunction(reflect, "defineProperty", 3, realm, DefineProperty);
            Intrinsics.DefineFunction(reflect, "deleteProperty", 2, realm, DeleteProperty);
            Intrinsics.DefineFunction(reflect, "get", 2, realm, Get);
            Intrinsics.DefineFunction(reflect, "getOwnPropertyDescriptor", 2, realm, GetOwnPropertyDescriptor);
            Intrinsics.DefineFunction(reflect, "getPrototypeOf", 1, realm, GetPrototypeOf);
            Intrinsics.DefineFunction(reflect, "has", 2, realm, Has);
            Intrinsics.DefineFunction(reflect, "isExtensible", 1, realm, IsExtensible);
            Intrinsics.DefineFunction(reflect, "ownKeys", 1, realm, OwnKeys);
            Intrinsics.DefineFunction(reflect, "preventExtensions", 1, realm, PreventExtensions);
            Intrinsics.DefineFunction(reflect, "set", 3, realm, Set);
            Intrinsics.DefineFunction(reflect, "setPrototypeOf", 2, realm, SetPrototypeOf);

            return reflect;
        }

        private static ScriptValue Apply(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Construct([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-reflect.construct
            if (!Agent.IsConstructor(arg[0]))
            {
                throw arg.Agent.CreateTypeError();
            }

            var target = (ScriptObject)arg[0];
            var argumentsList = arg[1];
            var newTarget = arg[2];

            if (arg.Count < 3)
            {
                newTarget = target;
            }
            else if (!Agent.IsConstructor(newTarget))
            {
                throw arg.Agent.CreateTypeError();
            }

            var args = arg.Agent.CreateListFromArrayLike(argumentsList);
            return Agent.Construct(target, args, (ScriptObject)newTarget);
        }

        private static ScriptValue DefineProperty([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-reflect.defineproperty
            if (!arg[0].IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            var key = arg.Agent.ToPropertyKey(arg[1]);
            var descriptor = ObjectIntrinsics.ToPropertyDescriptor(arg.Agent, arg[2]);
            return ((ScriptObject)arg[0]).DefineOwnProperty(key, descriptor);
        }

        private static ScriptValue DeleteProperty(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Get(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetOwnPropertyDescriptor([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-reflect.getownpropertydescriptor
            if (!arg[0].IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            var key = arg.Agent.ToPropertyKey(arg[1]);
            var descriptor = ((ScriptObject)arg[0]).GetOwnProperty(key);
            return ObjectIntrinsics.FromPropertyDescriptor(arg.Agent, descriptor);
        }

        private static ScriptValue GetPrototypeOf(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Has(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue IsExtensible(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue OwnKeys([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-reflect.ownkeys
            if (!arg[0].IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            var keys = ((ScriptObject)arg[0]).OwnPropertyKeys();
            return ArrayIntrinsics.CreateArrayFromList(arg.Agent, keys);
        }

        private static ScriptValue PreventExtensions(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Set(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue SetPrototypeOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-reflect.setprototypeof
            if (!arg[0].IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            if (!arg[1].IsObject && arg[1] != ScriptValue.Null)
            {
                throw arg.Agent.CreateTypeError();
            }

            return ((ScriptObject)arg[0]).SetPrototypeOf(arg[1] == ScriptValue.Null ? null : (ScriptObject)arg[1]);
        }
    }
}