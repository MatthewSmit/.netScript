using Xunit;

namespace NetScriptTest.built﹏ins.Map.prototype
{
    public sealed class Test_has : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Map/prototype/has/does-not-have-mapdata-internal-slot-set.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏set_js()
        {
            RunTest("built-ins/Map/prototype/has/does-not-have-mapdata-internal-slot-set.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/does-not-have-mapdata-internal-slot-weakmap.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot﹏weakmap_js()
        {
            RunTest("built-ins/Map/prototype/has/does-not-have-mapdata-internal-slot-weakmap.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/does-not-have-mapdata-internal-slot.js")]
        public void Test_does﹏not﹏have﹏mapdata﹏internal﹏slot_js()
        {
            RunTest("built-ins/Map/prototype/has/does-not-have-mapdata-internal-slot.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/has.js")]
        public void Test_has_js()
        {
            RunTest("built-ins/Map/prototype/has/has.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Map/prototype/has/length.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Map/prototype/has/name.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/normalizes-zero-key.js")]
        public void Test_normalizes﹏zero﹏key_js()
        {
            RunTest("built-ins/Map/prototype/has/normalizes-zero-key.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/return-false-different-key-types.js")]
        public void Test_return﹏false﹏different﹏key﹏types_js()
        {
            RunTest("built-ins/Map/prototype/has/return-false-different-key-types.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/return-true-different-key-types.js")]
        public void Test_return﹏true﹏different﹏key﹏types_js()
        {
            RunTest("built-ins/Map/prototype/has/return-true-different-key-types.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/has/this-not-object-throw.js")]
        public void Test_this﹏not﹏object﹏throw_js()
        {
            RunTest("built-ins/Map/prototype/has/this-not-object-throw.js");
        }
    }
}
