using Xunit;

namespace NetScriptTest.intl402.Collator
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/Collator/prototype/10.2.1.js")]
        public void Test_10_2_1_js()
        {
            RunTest("intl402/Collator/prototype/10.2.1.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/10.3_a.js")]
        public void Test_10_3_a_js()
        {
            RunTest("intl402/Collator/prototype/10.3_a.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/10.3_b.js")]
        public void Test_10_3_b_js()
        {
            RunTest("intl402/Collator/prototype/10.3_b.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/10.3_L15.js")]
        public void Test_10_3_L15_js()
        {
            RunTest("intl402/Collator/prototype/10.3_L15.js");
        }
    }
}
