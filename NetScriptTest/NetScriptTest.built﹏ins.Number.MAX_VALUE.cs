using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_MAX_VALUE : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/MAX_VALUE/S15.7.3.2_A2.js")]
        public void Test_S15_7_3_2_A2_js()
        {
            RunTest("built-ins/Number/MAX_VALUE/S15.7.3.2_A2.js");
        }

        [Fact(DisplayName = "/built-ins/Number/MAX_VALUE/S15.7.3.2_A3.js")]
        public void Test_S15_7_3_2_A3_js()
        {
            RunTest("built-ins/Number/MAX_VALUE/S15.7.3.2_A3.js");
        }

        [Fact(DisplayName = "/built-ins/Number/MAX_VALUE/S15.7.3.2_A4.js")]
        public void Test_S15_7_3_2_A4_js()
        {
            RunTest("built-ins/Number/MAX_VALUE/S15.7.3.2_A4.js");
        }
    }
}
