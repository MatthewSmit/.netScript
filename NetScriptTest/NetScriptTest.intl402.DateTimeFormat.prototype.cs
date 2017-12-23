using Xunit;

namespace NetScriptTest.intl402.DateTimeFormat
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/builtin.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/this-value-datetimeformat-prototype.js")]
        public void Test_this﹏value﹏datetimeformat﹏prototype_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/this-value-datetimeformat-prototype.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/this-value-not-datetimeformat.js")]
        public void Test_this﹏value﹏not﹏datetimeformat_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/this-value-not-datetimeformat.js");
        }
    }
}
