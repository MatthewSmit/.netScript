using Xunit;

namespace NetScriptTest.language.types
{
    public sealed class Test_boolean : BaseTest
    {
        [Fact(DisplayName = "/language/types/boolean/S8.3_A1_T1.js")]
        public void Test_S8_3_A1_T1_js()
        {
            RunTest("language/types/boolean/S8.3_A1_T1.js");
        }

        [Fact(DisplayName = "/language/types/boolean/S8.3_A1_T2.js")]
        public void Test_S8_3_A1_T2_js()
        {
            RunTest("language/types/boolean/S8.3_A1_T2.js");
        }

        [Fact(DisplayName = "/language/types/boolean/S8.3_A2.1.js")]
        public void Test_S8_3_A2_1_js()
        {
            RunTest("language/types/boolean/S8.3_A2.1.js");
        }

        [Fact(DisplayName = "/language/types/boolean/S8.3_A2.2.js")]
        public void Test_S8_3_A2_2_js()
        {
            RunTest("language/types/boolean/S8.3_A2.2.js");
        }

        [Fact(DisplayName = "/language/types/boolean/S8.3_A3.js")]
        public void Test_S8_3_A3_js()
        {
            RunTest("language/types/boolean/S8.3_A3.js");
        }
    }
}
