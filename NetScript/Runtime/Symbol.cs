using System.Collections.Generic;
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

        public static IDictionary<string, Symbol> GlobalRegistry { get; } = new Dictionary<string, Symbol>();

        [NotNull]
        public static Symbol HasInstance { get; } = new Symbol("Symbol.hasInstance");
        [NotNull]
        public static Symbol IsConcatSpreadable { get; } = new Symbol("Symbol.isConcatSpreadable");
        [NotNull]
        public static Symbol Iterator { get; } = new Symbol("Symbol.iterator");
        [NotNull]
        public static Symbol Match { get; } = new Symbol("Symbol.match");
        [NotNull]
        public static Symbol Replace { get; } = new Symbol("Symbol.replace");
        [NotNull]
        public static Symbol Search { get; } = new Symbol("Symbol.search");
        [NotNull]
        public static Symbol Species { get; } = new Symbol("Symbol.species");
        [NotNull]
        public static Symbol Split { get; } = new Symbol("Symbol.split");
        [NotNull]
        public static Symbol ToPrimitive { get; } = new Symbol("Symbol.toPrimitive");
        [NotNull]
        public static Symbol ToStringTag { get; } = new Symbol("Symbol.toStringTag");
        [NotNull]
        public static Symbol Unscopables { get; } = new Symbol("Symbol.unscopables");
    }
}
