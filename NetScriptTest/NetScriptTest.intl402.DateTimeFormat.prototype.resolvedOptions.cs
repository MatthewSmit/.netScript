using Xunit;

namespace NetScriptTest.intl402.DateTimeFormat.prototype
{
    public sealed class Test_resolvedOptions : BaseTest
    {
        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/resolvedOptions/12.3.3.js")]
        public void Test_12_3_3_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/resolvedOptions/12.3.3.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/resolvedOptions/12.3.3_L15.js")]
        public void Test_12_3_3_L15_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/resolvedOptions/12.3.3_L15.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/resolvedOptions/hourCycle.js")]
        public void Test_hourCycle_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/resolvedOptions/hourCycle.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/resolvedOptions/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/resolvedOptions/name.js");
        }
    }
}
