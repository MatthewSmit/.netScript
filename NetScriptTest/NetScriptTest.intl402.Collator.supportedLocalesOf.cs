using Xunit;

namespace NetScriptTest.intl402.Collator
{
    public sealed class Test_supportedLocalesOf : BaseTest
    {
        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/10.2.2_a.js")]
        public void Test_10_2_2_a_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/10.2.2_a.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/10.2.2_b.js")]
        public void Test_10_2_2_b_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/10.2.2_b.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/10.2.2_L15.js")]
        public void Test_10_2_2_L15_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/10.2.2_L15.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/name.js");
        }
    }
}
