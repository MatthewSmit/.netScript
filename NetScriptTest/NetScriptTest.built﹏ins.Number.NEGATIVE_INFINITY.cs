using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_NEGATIVE_INFINITY : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/NEGATIVE_INFINITY/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Number/NEGATIVE_INFINITY/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Number/NEGATIVE_INFINITY/S15.7.3.5_A1.js")]
        public void Test_S15_7_3_5_A1_js()
        {
            RunTest("built-ins/Number/NEGATIVE_INFINITY/S15.7.3.5_A1.js");
        }

        [Fact(DisplayName = "/built-ins/Number/NEGATIVE_INFINITY/S15.7.3.5_A2.js")]
        public void Test_S15_7_3_5_A2_js()
        {
            RunTest("built-ins/Number/NEGATIVE_INFINITY/S15.7.3.5_A2.js");
        }

        [Fact(DisplayName = "/built-ins/Number/NEGATIVE_INFINITY/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Number/NEGATIVE_INFINITY/value.js");
        }
    }
}
