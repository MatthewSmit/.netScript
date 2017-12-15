using Xunit;

namespace NetScriptTest.intl402.DateTimeFormat
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/12.2.1.js")]
        public void Test_12_2_1_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/12.2.1.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/12.3_a.js")]
        public void Test_12_3_a_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/12.3_a.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/12.3_b.js")]
        public void Test_12_3_b_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/12.3_b.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/12.3_L15.js")]
        public void Test_12_3_L15_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/12.3_L15.js");
        }
    }
}
