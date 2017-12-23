using Xunit;

namespace NetScriptTest.intl402.Date.prototype
{
    public sealed class Test_toLocaleTimeString : BaseTest
    {
        [Fact(DisplayName = "/intl402/Date/prototype/toLocaleTimeString/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Date/prototype/toLocaleTimeString/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/toLocaleTimeString/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/Date/prototype/toLocaleTimeString/length.js");
        }
    }
}
