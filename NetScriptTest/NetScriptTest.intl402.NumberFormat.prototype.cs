using Xunit;

namespace NetScriptTest.intl402.NumberFormat
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/NumberFormat/prototype/11.2.1.js")]
        public void Test_11_2_1_js()
        {
            RunTest("intl402/NumberFormat/prototype/11.2.1.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/11.3_a.js")]
        public void Test_11_3_a_js()
        {
            RunTest("intl402/NumberFormat/prototype/11.3_a.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/11.3_b.js")]
        public void Test_11_3_b_js()
        {
            RunTest("intl402/NumberFormat/prototype/11.3_b.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/11.3_L15.js")]
        public void Test_11_3_L15_js()
        {
            RunTest("intl402/NumberFormat/prototype/11.3_L15.js");
        }
    }
}
