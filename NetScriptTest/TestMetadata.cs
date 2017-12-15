using System.Collections.Generic;

namespace NetScriptTest
{
    internal sealed class TestMetadata
    {
        public IList<string> Includes { get; } = new List<string>();
        public IList<string> Features { get; } = new List<string>();
        public string Es5Id { get; set; }
        public string Es6Id { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string EsId { get; set; }
        public string NegativePhase { get; set; }
        public string NegativeType { get; set; }
        public bool OnlyStrict { get; set; }
        public bool NoStrict { get; set; }
        public bool Module { get; set; }
        public bool Raw { get; set; }
        public bool Async { get; set; }
        public bool Generated { get; set; }
        public string Author { get; set; }
    }
}