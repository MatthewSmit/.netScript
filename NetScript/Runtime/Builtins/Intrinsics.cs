using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class Intrinsics
    {
        [NotNull]
        public static ScriptFunctionObject CreateBuiltinFunction([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] Func<ScriptArguments, ScriptValue> callback, ScriptObject prototype, int length, string name, ConstructorKind constructorKind = ConstructorKind.None)
        {
            var function = new ScriptFunctionObject(agent, prototype, true, realm, callback, constructorKind);
            function.DefineOwnProperty("length", new PropertyDescriptor(length, false, false, true));
            function.DefineOwnProperty("name", new PropertyDescriptor(name, false, false, true));
            return function;
        }

        public static void DefineDataProperty([NotNull] ScriptObject scriptObject, ScriptValue property, ScriptValue value, bool writable = true, bool enumerable = false, bool configurable = true)
        {
            scriptObject.DefineOwnProperty(property, new PropertyDescriptor(value, writable, enumerable, configurable));
        }

        public static void DefineAccessorProperty([NotNull] ScriptObject scriptObject, ScriptValue property, [CanBeNull] ScriptFunctionObject get, [CanBeNull] ScriptFunctionObject set, bool enumerable = false, bool configurable = true)
        {
            scriptObject.DefineOwnProperty(property, new PropertyDescriptor(get, set, enumerable, configurable));
        }

        [NotNull]
        public static ScriptFunctionObject DefineFunction([NotNull] ScriptObject scriptObject, string name, int length, [NotNull] Agent agent, [NotNull] Realm realm, [NotNull] Func<ScriptArguments, ScriptValue> callback)
        {
            var function = CreateBuiltinFunction(agent, realm, callback, realm.FunctionPrototype, length, name);
            DefineDataProperty(scriptObject, name, function);
            return function;
        }
    }
}
