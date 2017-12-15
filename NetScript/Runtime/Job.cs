using System;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal sealed class Job
    {
        public Job([NotNull] Func<ScriptValue> callback, [NotNull] Realm realm, [CanBeNull] object scriptOrModule)
        {
            Callback = callback;
            Realm = realm;
            ScriptOrModule = scriptOrModule;
        }

        [NotNull]
        public Func<ScriptValue> Callback { get; }
        [NotNull]
        public Realm Realm { get; }
        [CanBeNull]
        public object ScriptOrModule { get; }
    }
}