using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_MIN_VALUE : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/MIN_VALUE/S15.7.3.3_A2.js")]
        public void Test_S15_7_3_3_A2_js()
        {
            RunTest("built-ins/Number/MIN_VALUE/S15.7.3.3_A2.js");
        }

        [Fact(DisplayName = "/built-ins/Number/MIN_VALUE/S15.7.3.3_A3.js")]
        public void Test_S15_7_3_3_A3_js()
        {
            RunTest("built-ins/Number/MIN_VALUE/S15.7.3.3_A3.js");
        }

        [Fact(DisplayName = "/built-ins/Number/MIN_VALUE/S15.7.3.3_A4.js")]
        public void Test_S15_7_3_3_A4_js()
        {
            RunTest("built-ins/Number/MIN_VALUE/S15.7.3.3_A4.js");
        }
    }
}
