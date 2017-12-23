using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    internal sealed class PromiseCapability
    {
        [CanBeNull] public ScriptObject Promise;
        [CanBeNull] public ScriptObject Resolve;
        [CanBeNull] public ScriptObject Reject;
    }
}
