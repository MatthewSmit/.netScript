using Xunit;

namespace NetScriptTest.language.types
{
    public sealed class Test_list : BaseTest
    {
        [Fact(DisplayName = "/language/types/list/S8.8_A2_T1.js")]
        public void Test_S8_8_A2_T1_js()
        {
            RunTest("language/types/list/S8.8_A2_T1.js");
        }

        [Fact(DisplayName = "/language/types/list/S8.8_A2_T2.js")]
        public void Test_S8_8_A2_T2_js()
        {
            RunTest("language/types/list/S8.8_A2_T2.js");
        }

        [Fact(DisplayName = "/language/types/list/S8.8_A2_T3.js")]
        public void Test_S8_8_A2_T3_js()
        {
            RunTest("language/types/list/S8.8_A2_T3.js");
        }
    }
}
