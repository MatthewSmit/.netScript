using Xunit;

namespace NetScriptTest.intl402.Collator.prototype
{
    public sealed class Test_resolvedOptions : BaseTest
    {
        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/10.3.3.js")]
        public void Test_10_3_3_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/10.3.3.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/10.3.3_L15.js")]
        public void Test_10_3_3_L15_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/10.3.3_L15.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/name.js");
        }
    }
}
