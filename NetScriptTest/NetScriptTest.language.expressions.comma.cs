using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_comma : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/comma/S11.14_A1.js")]
        public void Test_S11_14_A1_js()
        {
            RunTest("language/expressions/comma/S11.14_A1.js");
        }

        [Fact(DisplayName = "/language/expressions/comma/S11.14_A2.1_T1.js")]
        public void Test_S11_14_A2_1_T1_js()
        {
            RunTest("language/expressions/comma/S11.14_A2.1_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/comma/S11.14_A2.1_T2.js")]
        public void Test_S11_14_A2_1_T2_js()
        {
            RunTest("language/expressions/comma/S11.14_A2.1_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/comma/S11.14_A2.1_T3.js")]
        public void Test_S11_14_A2_1_T3_js()
        {
            RunTest("language/expressions/comma/S11.14_A2.1_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/comma/S11.14_A3.js")]
        public void Test_S11_14_A3_js()
        {
            RunTest("language/expressions/comma/S11.14_A3.js");
        }

        [Fact(DisplayName = "/language/expressions/comma/tco-final.js")]
        public void Test_tco﹏final_js()
        {
            RunTest("language/expressions/comma/tco-final.js");
        }
    }
}
