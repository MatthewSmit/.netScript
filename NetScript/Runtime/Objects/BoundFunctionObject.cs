using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class BoundFunctionObject : ScriptObject
    {
        internal BoundFunctionObject([NotNull] Agent agent, [CanBeNull] ScriptObject prototype, bool extensible, SpecialObjectType specialObjectType) :
            base(agent, prototype, extensible, specialObjectType)
        {
        }

        public override bool IsCallable => true;
    }
}
