using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_POSITIVE_INFINITY : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/POSITIVE_INFINITY/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Number/POSITIVE_INFINITY/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Number/POSITIVE_INFINITY/S15.7.3.6_A1.js")]
        public void Test_S15_7_3_6_A1_js()
        {
            RunTest("built-ins/Number/POSITIVE_INFINITY/S15.7.3.6_A1.js");
        }

        [Fact(DisplayName = "/built-ins/Number/POSITIVE_INFINITY/S15.7.3.6_A2.js")]
        public void Test_S15_7_3_6_A2_js()
        {
            RunTest("built-ins/Number/POSITIVE_INFINITY/S15.7.3.6_A2.js");
        }

        [Fact(DisplayName = "/built-ins/Number/POSITIVE_INFINITY/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Number/POSITIVE_INFINITY/value.js");
        }
    }
}
