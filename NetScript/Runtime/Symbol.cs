using JetBrains.Annotations;

namespace NetScript.Runtime
{
    public sealed class Symbol
    {
        public Symbol([CanBeNull] string description)
        {
            Description = description;
        }

        [CanBeNull]
        public string Description { get; }
    }
}
