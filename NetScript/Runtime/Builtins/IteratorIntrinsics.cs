using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class IteratorIntrinsics
    {
        [NotNull]
        public static ScriptObject Initialise([NotNull] Agent agent, [NotNull] Realm realm, ScriptObject objectPrototype, ScriptObject functionPrototype)
        {
            var iteratorPrototype = agent.ObjectCreate(objectPrototype);
            Intrinsics.DefineDataProperty(iteratorPrototype, realm.SymbolIterator, Intrinsics.CreateBuiltinFunction(agent, realm, Iterator, functionPrototype, 0, "[Symbol.iterator]"));
            return iteratorPrototype;
        }

        private static ScriptValue Iterator([NotNull] ScriptArguments arg)
        {
            return arg.ThisValue;
        }
    }
}