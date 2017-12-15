using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal sealed class LexicalEnvironment
    {
        private LexicalEnvironment([NotNull] BaseEnvironment environment)
        {
            Environment = environment;
        }

        private LexicalEnvironment([NotNull] BaseEnvironment environment, LexicalEnvironment outerEnvironment)
        {
            Environment = environment;
            OuterEnvironment = outerEnvironment;
        }

        [NotNull]
        public static LexicalEnvironment NewDeclarativeEnvironment([NotNull] Agent agent, [NotNull] LexicalEnvironment environment)
        {
            //https://tc39.github.io/ecma262/#sec-newdeclarativeenvironment
            return new LexicalEnvironment(new DeclarativeEnvironment(agent), environment);
        }

        [NotNull]
        public static LexicalEnvironment NewFunctionEnvironment([NotNull] ScriptFunctionObject function, ScriptObject newTarget)
        {
            //https://tc39.github.io/ecma262/#sec-newfunctionenvironment
            var environmentRecord = new FunctionEnvironment(function,
                function.ThisMode == ThisMode.Lexical ? ThisBindingStatus.Lexical : ThisBindingStatus.Uninitialised,
                function.HomeObject,
                newTarget);
            return new LexicalEnvironment(environmentRecord, function.Environment);
        }

        [NotNull]
        public static LexicalEnvironment NewGlobalEnvironment([NotNull] Agent agent, [NotNull] ScriptObject global, [NotNull] ScriptObject thisValue)
        {
            //https://tc39.github.io/ecma262/#sec-newglobalenvironment
            var globalRecord = new GlobalEnvironment(agent, global, thisValue);
            return new LexicalEnvironment(globalRecord);
        }

        [NotNull]
        public static LexicalEnvironment NewObjectEnvironment([NotNull] ScriptObject obj, [NotNull] LexicalEnvironment environment, bool withEnvironment)
        {
            //https://tc39.github.io/ecma262/#sec-newobjectenvironment
            var environmentRecord = new ObjectEnvironment(obj, withEnvironment);
            return new LexicalEnvironment(environmentRecord, environment);
        }

        [NotNull]
        public BaseEnvironment Environment { get; }

        [CanBeNull]
        public LexicalEnvironment OuterEnvironment { get; }
    }
}