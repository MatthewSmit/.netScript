using Xunit;

namespace NetScriptTest.intl402.Date.prototype
{
    public sealed class Test_toLocaleDateString : BaseTest
    {
        [Fact(DisplayName = "/intl402/Date/prototype/toLocaleDateString/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Date/prototype/toLocaleDateString/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/toLocaleDateString/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/Date/prototype/toLocaleDateString/length.js");
        }
    }
}
