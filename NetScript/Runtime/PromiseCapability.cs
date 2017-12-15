using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal struct PromiseCapability
    {
        [CanBeNull] public ScriptObject Promise;
        [CanBeNull] public ScriptFunctionObject Resolve;
        [CanBeNull] public ScriptFunctionObject Reject;
    }
}
