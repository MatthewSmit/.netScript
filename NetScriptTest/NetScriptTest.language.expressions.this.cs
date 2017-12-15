using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_this : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/this/11.1.1-1gs.js")]
        public void Test_11_1_1﹏1gs_js()
        {
            RunTest("language/expressions/this/11.1.1-1gs.js");
        }

        [Fact(DisplayName = "/language/expressions/this/S11.1.1_A1.js")]
        public void Test_S11_1_1_A1_js()
        {
            RunTest("language/expressions/this/S11.1.1_A1.js");
        }

        [Fact(DisplayName = "/language/expressions/this/S11.1.1_A3.1.js")]
        public void Test_S11_1_1_A3_1_js()
        {
            RunTest("language/expressions/this/S11.1.1_A3.1.js");
        }

        [Fact(DisplayName = "/language/expressions/this/S11.1.1_A3.2.js")]
        public void Test_S11_1_1_A3_2_js()
        {
            RunTest("language/expressions/this/S11.1.1_A3.2.js");
        }

        [Fact(DisplayName = "/language/expressions/this/S11.1.1_A4.1.js")]
        public void Test_S11_1_1_A4_1_js()
        {
            RunTest("language/expressions/this/S11.1.1_A4.1.js");
        }

        [Fact(DisplayName = "/language/expressions/this/S11.1.1_A4.2.js")]
        public void Test_S11_1_1_A4_2_js()
        {
            RunTest("language/expressions/this/S11.1.1_A4.2.js");
        }
    }
}
