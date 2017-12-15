using Xunit;

namespace NetScriptTest.language.statements
{
    public sealed class Test_empty : BaseTest
    {
        [Fact(DisplayName = "/language/statements/empty/cptn-value.js")]
        public void Test_cptn﹏value_js()
        {
            RunTest("language/statements/empty/cptn-value.js");
        }

        [Fact(DisplayName = "/language/statements/empty/S12.3_A1.js")]
        public void Test_S12_3_A1_js()
        {
            RunTest("language/statements/empty/S12.3_A1.js");
        }
    }
}
