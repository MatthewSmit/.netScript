using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal sealed class ModuleEnvironment : DeclarativeEnvironment
    {
        public ModuleEnvironment([NotNull] Agent agent) :
            base(agent)
        {
        }
    }
}