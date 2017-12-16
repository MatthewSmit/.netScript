using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class JsonIntrinsics
    {
        public static (ScriptObject Json, ScriptFunctionObject JsonParse) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var json = agent.ObjectCreate(realm.ObjectPrototype);

            var jsonParse = Intrinsics.DefineFunction(json, "parse", 2, realm, Parse);
            Intrinsics.DefineFunction(json, "stringify", 3, realm, Stringify);
            Intrinsics.DefineDataProperty(json, Symbol.ToStringTag, "JSON", false);

            return (json, jsonParse);
        }

        private static ScriptValue Parse(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Stringify(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}