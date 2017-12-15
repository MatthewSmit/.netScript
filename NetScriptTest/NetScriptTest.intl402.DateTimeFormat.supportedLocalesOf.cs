using Xunit;

namespace NetScriptTest.intl402.DateTimeFormat
{
    public sealed class Test_supportedLocalesOf : BaseTest
    {
        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/12.2.2_a.js")]
        public void Test_12_2_2_a_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/12.2.2_a.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/12.2.2_b.js")]
        public void Test_12_2_2_b_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/12.2.2_b.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/12.2.2_L15.js")]
        public void Test_12_2_2_L15_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/12.2.2_L15.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/name.js");
        }
    }
}
