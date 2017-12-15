using Xunit;

namespace NetScriptTest.language.literals
{
    public sealed class Test_boolean : BaseTest
    {
        [Fact(DisplayName = "/language/literals/boolean/S7.8.2_A1_T1.js")]
        public void Test_S7_8_2_A1_T1_js()
        {
            RunTest("language/literals/boolean/S7.8.2_A1_T1.js");
        }

        [Fact(DisplayName = "/language/literals/boolean/S7.8.2_A1_T2.js")]
        public void Test_S7_8_2_A1_T2_js()
        {
            RunTest("language/literals/boolean/S7.8.2_A1_T2.js");
        }
    }
}
