using Xunit;

namespace NetScriptTest.built﹏ins.Map.prototype
{
    public sealed class Test_entries : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Map/prototype/entries/does-not-have-mapdata-internal-slot-set.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏set_js()
        {
            RunTest("built-ins/Map/prototype/entries/does-not-have-mapdata-internal-slot-set.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/does-not-have-mapdata-internal-slot-weakmap.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏weakmap_js()
        {
            RunTest("built-ins/Map/prototype/entries/does-not-have-mapdata-internal-slot-weakmap.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/does-not-have-mapdata-internal-slot.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot_js()
        {
            RunTest("built-ins/Map/prototype/entries/does-not-have-mapdata-internal-slot.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/entries.js")]
        public void Test_entries_js()
        {
            RunTest("built-ins/Map/prototype/entries/entries.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Map/prototype/entries/length.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Map/prototype/entries/name.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/returns-iterator-empty.js")]
        public void Test_returns﹏iterator﹏empty_js()
        {
            RunTest("built-ins/Map/prototype/entries/returns-iterator-empty.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/returns-iterator.js")]
        public void Test_returns﹏iterator_js()
        {
            RunTest("built-ins/Map/prototype/entries/returns-iterator.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/entries/this-not-object-throw.js")]
        public void Test_this﹏not﹏object﹏throw_js()
        {
            RunTest("built-ins/Map/prototype/entries/this-not-object-throw.js");
        }
    }
}
