using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal sealed class ExecutionContext
    {
        public ExecutionContext([NotNull] Realm realm, [CanBeNull] object scriptOrModule, bool strict)
        {
            Realm = realm;
            ScriptOrModule = scriptOrModule;
            Strict = strict;
        }

        [NotNull]
        public BaseEnvironment GetThisEnvironment()
        {
            var lexicalEnvironment = LexicalEnvironment;

            while (true)
            {
                var environmentRecord = lexicalEnvironment.Environment;
                var exists = environmentRecord.HasThisBinding();
                if (exists)
                {
                    return environmentRecord;
                }

                lexicalEnvironment = lexicalEnvironment.OuterEnvironment;
                Debug.Assert(lexicalEnvironment != null);
            }
        }

        public ScriptValue GetNewTarget()
        {
            var environment = GetThisEnvironment();
            Debug.Assert(environment is FunctionEnvironment);
            return ((FunctionEnvironment)environment).NewTarget ?? ScriptValue.Undefined;
        }

        [NotNull]
        public Realm Realm { get; set; }

        [CanBeNull]
        public object ScriptOrModule { get; set; }

        public bool Strict { get; }

        public LexicalEnvironment LexicalEnvironment { get; set; }

        public LexicalEnvironment VariableEnvironment { get; set; }

        public ScriptFunctionObject Function { get; set; }
    }
}