using Xunit;

namespace NetScriptTest.language.statements
{
    public sealed class Test_expression : BaseTest
    {
        [Fact(DisplayName = "/language/statements/expression/S12.4_A1.js")]
        public void Test_S12_4_A1_js()
        {
            RunTest("language/statements/expression/S12.4_A1.js");
        }

        [Fact(DisplayName = "/language/statements/expression/S12.4_A2_T1.js")]
        public void Test_S12_4_A2_T1_js()
        {
            RunTest("language/statements/expression/S12.4_A2_T1.js");
        }

        [Fact(DisplayName = "/language/statements/expression/S12.4_A2_T2.js")]
        public void Test_S12_4_A2_T2_js()
        {
            RunTest("language/statements/expression/S12.4_A2_T2.js");
        }
    }
}
