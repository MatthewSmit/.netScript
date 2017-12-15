using Xunit;

namespace NetScriptTest.language.types
{
    public sealed class Test_undefined : BaseTest
    {
        [Fact(DisplayName = "/language/types/undefined/S8.1_A1_T1.js")]
        public void Test_S8_1_A1_T1_js()
        {
            RunTest("language/types/undefined/S8.1_A1_T1.js");
        }

        [Fact(DisplayName = "/language/types/undefined/S8.1_A1_T2.js")]
        public void Test_S8_1_A1_T2_js()
        {
            RunTest("language/types/undefined/S8.1_A1_T2.js");
        }

        [Fact(DisplayName = "/language/types/undefined/S8.1_A2_T1.js")]
        public void Test_S8_1_A2_T1_js()
        {
            RunTest("language/types/undefined/S8.1_A2_T1.js");
        }

        [Fact(DisplayName = "/language/types/undefined/S8.1_A2_T2.js")]
        public void Test_S8_1_A2_T2_js()
        {
            RunTest("language/types/undefined/S8.1_A2_T2.js");
        }

        [Fact(DisplayName = "/language/types/undefined/S8.1_A3_T1.js")]
        public void Test_S8_1_A3_T1_js()
        {
            RunTest("language/types/undefined/S8.1_A3_T1.js");
        }

        [Fact(DisplayName = "/language/types/undefined/S8.1_A3_T2.js")]
        public void Test_S8_1_A3_T2_js()
        {
            RunTest("language/types/undefined/S8.1_A3_T2.js");
        }

        [Fact(DisplayName = "/language/types/undefined/S8.1_A4.js")]
        public void Test_S8_1_A4_js()
        {
            RunTest("language/types/undefined/S8.1_A4.js");
        }

        [Fact(DisplayName = "/language/types/undefined/S8.1_A5.js")]
        public void Test_S8_1_A5_js()
        {
            RunTest("language/types/undefined/S8.1_A5.js");
        }
    }
}
