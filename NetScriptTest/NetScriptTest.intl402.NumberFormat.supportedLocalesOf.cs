using Xunit;

namespace NetScriptTest.intl402.NumberFormat
{
    public sealed class Test_supportedLocalesOf : BaseTest
    {
        [Fact(DisplayName = "/intl402/NumberFormat/supportedLocalesOf/11.2.2_a.js")]
        public void Test_11_2_2_a_js()
        {
            RunTest("intl402/NumberFormat/supportedLocalesOf/11.2.2_a.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/supportedLocalesOf/11.2.2_b.js")]
        public void Test_11_2_2_b_js()
        {
            RunTest("intl402/NumberFormat/supportedLocalesOf/11.2.2_b.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/supportedLocalesOf/11.2.2_L15.js")]
        public void Test_11_2_2_L15_js()
        {
            RunTest("intl402/NumberFormat/supportedLocalesOf/11.2.2_L15.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/supportedLocalesOf/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/NumberFormat/supportedLocalesOf/name.js");
        }
    }
}
