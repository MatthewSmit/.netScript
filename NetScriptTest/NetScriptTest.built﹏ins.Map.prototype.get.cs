using Xunit;

namespace NetScriptTest.built﹏ins.Map.prototype
{
    public sealed class Test_get : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Map/prototype/get/does-not-have-mapdata-internal-slot-set.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏set_js()
        {
            RunTest("built-ins/Map/prototype/get/does-not-have-mapdata-internal-slot-set.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/does-not-have-mapdata-internal-slot-weakmap.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏weakmap_js()
        {
            RunTest("built-ins/Map/prototype/get/does-not-have-mapdata-internal-slot-weakmap.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/does-not-have-mapdata-internal-slot.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot_js()
        {
            RunTest("built-ins/Map/prototype/get/does-not-have-mapdata-internal-slot.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/get.js")]
        public void Test_get_js()
        {
            RunTest("built-ins/Map/prototype/get/get.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Map/prototype/get/length.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Map/prototype/get/name.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/returns-undefined.js")]
        public void Test_returns﹏undefined_js()
        {
            RunTest("built-ins/Map/prototype/get/returns-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/returns-value-different-key-types.js")]
        public void Test_returns﹏value﹏different﹏key﹏types_js()
        {
            RunTest("built-ins/Map/prototype/get/returns-value-different-key-types.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/returns-value-normalized-zero-key.js")]
        public void Test_returns﹏value﹏normalized﹏zero﹏key_js()
        {
            RunTest("built-ins/Map/prototype/get/returns-value-normalized-zero-key.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/get/this-not-object-throw.js")]
        public void Test_this﹏not﹏object﹏throw_js()
        {
            RunTest("built-ins/Map/prototype/get/this-not-object-throw.js");
        }
    }
}
