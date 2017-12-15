using Xunit;

namespace NetScriptTest.language.types
{
    public sealed class Test_null : BaseTest
    {
        [Fact(DisplayName = "/language/types/null/S8.2_A1_T1.js")]
        public void Test_S8_2_A1_T1_js()
        {
            RunTest("language/types/null/S8.2_A1_T1.js");
        }

        [Fact(DisplayName = "/language/types/null/S8.2_A1_T2.js")]
        public void Test_S8_2_A1_T2_js()
        {
            RunTest("language/types/null/S8.2_A1_T2.js");
        }

        [Fact(DisplayName = "/language/types/null/S8.2_A2.js")]
        public void Test_S8_2_A2_js()
        {
            RunTest("language/types/null/S8.2_A2.js");
        }

        [Fact(DisplayName = "/language/types/null/S8.2_A3.js")]
        public void Test_S8_2_A3_js()
        {
            RunTest("language/types/null/S8.2_A3.js");
        }
    }
}
