using Xunit;

namespace NetScriptTest.intl402.Number.prototype
{
    public sealed class Test_toLocaleString : BaseTest
    {
        [Fact(DisplayName = "/intl402/Number/prototype/toLocaleString/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Number/prototype/toLocaleString/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Number/prototype/toLocaleString/default-options-object-prototype.js")]
        public void Test_default﹏options﹏object﹏prototype_js()
        {
            RunTest("intl402/Number/prototype/toLocaleString/default-options-object-prototype.js");
        }

        [Fact(DisplayName = "/intl402/Number/prototype/toLocaleString/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/Number/prototype/toLocaleString/length.js");
        }

        [Fact(DisplayName = "/intl402/Number/prototype/toLocaleString/returns-same-results-as-NumberFormat.js")]
        public void Test_returns﹏same﹏results﹏as﹏NumberFormat_js()
        {
            RunTest("intl402/Number/prototype/toLocaleString/returns-same-results-as-NumberFormat.js");
        }

        [Fact(DisplayName = "/intl402/Number/prototype/toLocaleString/taint-Intl-NumberFormat.js")]
        public void Test_taint﹏Intl﹏NumberFormat_js()
        {
            RunTest("intl402/Number/prototype/toLocaleString/taint-Intl-NumberFormat.js");
        }

        [Fact(DisplayName = "/intl402/Number/prototype/toLocaleString/this-number-value.js")]
        public void Test_this﹏number﹏value_js()
        {
            RunTest("intl402/Number/prototype/toLocaleString/this-number-value.js");
        }

        [Fact(DisplayName = "/intl402/Number/prototype/toLocaleString/throws-same-exceptions-as-NumberFormat.js")]
        public void Test_throws﹏same﹏exceptions﹏as﹏NumberFormat_js()
        {
            RunTest("intl402/Number/prototype/toLocaleString/throws-same-exceptions-as-NumberFormat.js");
        }
    }
}
