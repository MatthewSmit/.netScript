using Xunit;

namespace NetScriptTest.intl402
{
    public sealed class Test_Intl : BaseTest
    {
        [Fact(DisplayName = "/intl402/Intl/8.0.js")]
        public void Test_8_0_js()
        {
            RunTest("intl402/Intl/8.0.js");
        }

        [Fact(DisplayName = "/intl402/Intl/8.0_L15.js")]
        public void Test_8_0_L15_js()
        {
            RunTest("intl402/Intl/8.0_L15.js");
        }
    }
}
