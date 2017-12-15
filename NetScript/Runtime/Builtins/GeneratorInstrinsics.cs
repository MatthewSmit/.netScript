using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class GeneratorInstrinsics
    {
        public static (ScriptObject Generator, ScriptObject GeneratorPrototype, ScriptObject GeneratorFunction) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject functionPrototype)
        {
            var generator = agent.ObjectCreate(functionPrototype);

            var generatorPrototype = agent.ObjectCreate(realm.IteratorPrototype);
            Intrinsics.DefineDataProperty(generatorPrototype, "constructor", generator, false);
            Intrinsics.DefineFunction(generatorPrototype, "next", 1, agent, realm, Next);
            Intrinsics.DefineFunction(generatorPrototype, "return", 1, agent, realm, Return);
            Intrinsics.DefineFunction(generatorPrototype, "throw", 1, agent, realm, Throw);
            Intrinsics.DefineDataProperty(generatorPrototype, realm.SymbolToStringTag, "Generator", false);

            var generatorFunction = Intrinsics.CreateBuiltinFunction(agent, realm, GeneratorFunction, realm.Function, 1, "GeneratorFunction", ConstructorKind.Base);
            Intrinsics.DefineDataProperty(generatorFunction, "prototype", generator, false, false, false);

            Intrinsics.DefineDataProperty(generator, "constructor", generatorFunction, false);
            Intrinsics.DefineDataProperty(generator, "prototype", generatorPrototype, false);
            Intrinsics.DefineDataProperty(generator, realm.SymbolToStringTag, "GeneratorFunction", false);

            return (generator, generatorPrototype, generatorFunction);
        }

        private static ScriptValue Next(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Return(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Throw(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GeneratorFunction(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }
    }
}