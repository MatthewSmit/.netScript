using Xunit;

namespace NetScriptTest.intl402.Date.prototype
{
    public sealed class Test_toLocaleString : BaseTest
    {
        [Fact(DisplayName = "/intl402/Date/prototype/toLocaleString/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Date/prototype/toLocaleString/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/toLocaleString/default-options-object-prototype.js")]
        public void Test_default﹏options﹏object﹏prototype_js()
        {
            RunTest("intl402/Date/prototype/toLocaleString/default-options-object-prototype.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/toLocaleString/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/Date/prototype/toLocaleString/length.js");
        }
    }
}
