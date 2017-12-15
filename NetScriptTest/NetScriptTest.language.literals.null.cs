using Xunit;

namespace NetScriptTest.language.literals
{
    public sealed class Test_null : BaseTest
    {
        [Fact(DisplayName = "/language/literals/null/S7.8.1_A1_T1.js")]
        public void Test_S7_8_1_A1_T1_js()
        {
            RunTest("language/literals/null/S7.8.1_A1_T1.js");
        }

        [Fact(DisplayName = "/language/literals/null/S7.8.1_A1_T2.js")]
        public void Test_S7_8_1_A1_T2_js()
        {
            RunTest("language/literals/null/S7.8.1_A1_T2.js");
        }
    }
}
