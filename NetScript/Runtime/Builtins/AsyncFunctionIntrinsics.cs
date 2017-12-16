using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class AsyncFunctionIntrinsics
    {
        public static (ScriptFunctionObject AsyncFunction, ScriptObject AsyncFunctionPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var asyncFunction = Intrinsics.CreateBuiltinFunction(realm, AsyncFunction, realm.FunctionPrototype, 1, "AsyncFunction", ConstructorKind.Base);

            var asyncFunctionPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineDataProperty(asyncFunctionPrototype, "constructor", asyncFunction, false);
            Intrinsics.DefineDataProperty(asyncFunctionPrototype, Symbol.ToStringTag, "AsyncFunction", false);

            Intrinsics.DefineDataProperty(asyncFunction, "prototype", asyncFunctionPrototype, false, false, false);

            return (asyncFunction, asyncFunctionPrototype);
        }

        private static ScriptValue AsyncFunction(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}