using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_relational : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/relational/S9.1_A1_T4.js")]
        public void Test_S9_1_A1_T4_js()
        {
            RunTest("language/expressions/relational/S9.1_A1_T4.js");
        }
    }
}
