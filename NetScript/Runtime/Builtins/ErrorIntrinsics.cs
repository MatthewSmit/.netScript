using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class ErrorIntrinsics
    {
        public static (ScriptObject error, ScriptObject errorPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            //https://tc39.github.io/ecma262/#sec-error-objects

            var error = Intrinsics.CreateBuiltinFunction(agent, realm, ErrorConstructor, functionPrototype, 1, "Error", ConstructorKind.Base);

            var errorPrototype = agent.ObjectCreate(objectPrototype);
            Intrinsics.DefineDataProperty(errorPrototype, "constructor", error);
            Intrinsics.DefineDataProperty(errorPrototype, "message", string.Empty);
            Intrinsics.DefineDataProperty(errorPrototype, "name", "Error");
            Intrinsics.DefineFunction(errorPrototype, "toString", 0, agent, realm, ToString);

            Intrinsics.DefineDataProperty(error, "prototype", errorPrototype, false, false, false);

            return (error, errorPrototype);
        }

        public static (ScriptObject error, ScriptObject errorPrototype) InitialiseNativeError([NotNull] Agent agent, string nativeErrorType, [NotNull] Realm realm, ScriptObject error, ScriptObject errorPrototype)
        {
            var nativeErrorPrototype = agent.ObjectCreate(errorPrototype);

            var nativeError = Intrinsics.CreateBuiltinFunction(agent, realm, arguments => NativeErrorConstructor(arguments, nativeErrorPrototype), error, 1, nativeErrorType, ConstructorKind.Base);

            Intrinsics.DefineDataProperty(nativeErrorPrototype, "constructor", nativeError);
            Intrinsics.DefineDataProperty(nativeErrorPrototype, "message", string.Empty);
            Intrinsics.DefineDataProperty(nativeErrorPrototype, "name", nativeErrorType);

            Intrinsics.DefineDataProperty(nativeError, "prototype", nativeErrorPrototype, false, false, false);

            return (nativeError, nativeErrorPrototype);
        }

        private static ScriptValue ErrorConstructor([NotNull] ScriptArguments arguments)
        {
            //https://tc39.github.io/ecma262/#sec-error-message

            var newTarget = arguments.NewTarget ?? arguments.Function;
            var obj = arguments.Agent.OrdinaryCreateFromConstructor(newTarget, arguments.Agent.Realm.ErrorPrototype, SpecialObjectType.Error);
            obj.ErrorData = new ErrorData();

            var message = arguments[0];
            if (message != ScriptValue.Undefined)
            {
                var msg = arguments.Agent.ToString(message);
                var msgDesc = new PropertyDescriptor(msg, true, false, true);
                arguments.Agent.DefinePropertyOrThrow(obj, "message", msgDesc);
            }

            return obj;
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arguments)
        {
            throw new NotImplementedException();
//            if (arguments.ThisValue.Type != ScriptObjectType.Object)
//                return arguments.ScriptHost.ThrowTypeError();
//            var name = arguments.ThisValue.Get("name", arguments.ThisValue);
//            if (!name)
//                return name;
//
//            Debug.Assert(name.Value != null, "name.Value != null");
//            var nameString = name.Value == ScriptObject.Undefined ? "Error" : name.Value.ToString();
//            var msg = arguments.ThisValue.Get("message", arguments.ThisValue);
//            if (!msg)
//                return msg;
//
//            Debug.Assert(msg.Value != null, "msg.Value != null");
//            var msgString = msg.Value == ScriptObject.Undefined ? "" : msg.Value.ToString();
//            if (nameString == string.Empty)
//                return new Completion(msgString);
//            if (msgString == string.Empty)
//                return new Completion(nameString);
//
//            return new Completion(nameString + ": " + msgString);
        }

        private static ScriptValue NativeErrorConstructor([NotNull] ScriptArguments arguments, [NotNull] ScriptObject errorPrototype)
        {
            //https://tc39.github.io/ecma262/#sec-nativeerror

            var newTarget = arguments.NewTarget ?? arguments.Function;
            var obj = arguments.Agent.OrdinaryCreateFromConstructor(newTarget, errorPrototype, SpecialObjectType.Error);
            obj.ErrorData = new ErrorData();

            var message = arguments[0];
            if (message != ScriptValue.Undefined)
            {
                var msg = arguments.Agent.ToString(message);
                var msgDesc = new PropertyDescriptor(msg, true, false, true);
                arguments.Agent.DefinePropertyOrThrow(obj, "message", msgDesc);
            }

            return obj;
        }
    }
}
