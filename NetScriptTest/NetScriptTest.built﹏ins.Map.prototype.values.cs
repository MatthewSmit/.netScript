using Xunit;

namespace NetScriptTest.built﹏ins.Map.prototype
{
    public sealed class Test_values : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Map/prototype/values/does-not-have-mapdata-internal-slot-set.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏set_js()
        {
            RunTest("built-ins/Map/prototype/values/does-not-have-mapdata-internal-slot-set.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/does-not-have-mapdata-internal-slot-weakmap.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏weakmap_js()
        {
            RunTest("built-ins/Map/prototype/values/does-not-have-mapdata-internal-slot-weakmap.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/does-not-have-mapdata-internal-slot.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot_js()
        {
            RunTest("built-ins/Map/prototype/values/does-not-have-mapdata-internal-slot.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Map/prototype/values/length.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Map/prototype/values/name.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/returns-iterator-empty.js")]
        public void Test_returns﹏iterator﹏empty_js()
        {
            RunTest("built-ins/Map/prototype/values/returns-iterator-empty.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/returns-iterator.js")]
        public void Test_returns﹏iterator_js()
        {
            RunTest("built-ins/Map/prototype/values/returns-iterator.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/this-not-object-throw.js")]
        public void Test_this﹏not﹏object﹏throw_js()
        {
            RunTest("built-ins/Map/prototype/values/this-not-object-throw.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/values/values.js")]
        public void Test_values_js()
        {
            RunTest("built-ins/Map/prototype/values/values.js");
        }
    }
}
