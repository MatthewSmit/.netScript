using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class BooleanIntrinsics
    {
        public static (ScriptObject boolean, ScriptObject booleanPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var boolean = Intrinsics.CreateBuiltinFunction(agent, realm, Boolean, functionPrototype, 1, "Boolean", ConstructorKind.Base);

            var booleanPrototype = agent.ObjectCreate(objectPrototype, SpecialObjectType.Boolean);
            Intrinsics.DefineDataProperty(booleanPrototype, "constructor", boolean);
            Intrinsics.DefineFunction(booleanPrototype, "toString", 0, agent, realm, ToString);
            Intrinsics.DefineFunction(booleanPrototype, "valueOf", 0, agent, realm, ValueOf);

            Intrinsics.DefineDataProperty(boolean, "prototype", booleanPrototype, false, false, false);

            return (boolean, booleanPrototype);
        }

        private static ScriptValue Boolean([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-boolean-constructor-boolean-value
            var boolean = Agent.ToBoolean(arg[0]);
            if (arg.NewTarget == null)
            {
                return boolean;
            }

            var obj = arg.Agent.OrdinaryCreateFromConstructor(arg.NewTarget, arg.Agent.Realm.BooleanPrototype, SpecialObjectType.Boolean);
            obj.BooleanValue = boolean;
            return obj;
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-boolean.prototype.tostring
            return ThisBooleanValue(arg.Agent, arg.ThisValue) ? "true" : "false";
        }

        private static ScriptValue ValueOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-boolean.prototype.valueof
            return ThisBooleanValue(arg.Agent, arg.ThisValue);
        }

        private static bool ThisBooleanValue([NotNull] Agent agent, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-thisbooleanvalue
            if (value.IsBoolean)
            {
                return (bool)value;
            }

            if (value.IsObject && ((ScriptObject)value).SpecialObjectType == SpecialObjectType.Boolean)
            {
                return ((ScriptObject)value).BooleanValue;
            }

            throw agent.CreateTypeError();
        }
    }
}