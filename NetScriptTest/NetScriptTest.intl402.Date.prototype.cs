using Xunit;

namespace NetScriptTest.intl402.Date
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/Date/prototype/returns-same-results-as-DateTimeFormat.js")]
        public void Test_returns﹏same﹏results﹏as﹏DateTimeFormat_js()
        {
            RunTest("intl402/Date/prototype/returns-same-results-as-DateTimeFormat.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/taint-Intl-DateTimeFormat.js")]
        public void Test_taint﹏Intl﹏DateTimeFormat_js()
        {
            RunTest("intl402/Date/prototype/taint-Intl-DateTimeFormat.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/this-value-invalid-date.js")]
        public void Test_this﹏value﹏invalid﹏date_js()
        {
            RunTest("intl402/Date/prototype/this-value-invalid-date.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/this-value-non-date.js")]
        public void Test_this﹏value﹏non﹏date_js()
        {
            RunTest("intl402/Date/prototype/this-value-non-date.js");
        }

        [Fact(DisplayName = "/intl402/Date/prototype/throws-same-exceptions-as-DateTimeFormat.js")]
        public void Test_throws﹏same﹏exceptions﹏as﹏DateTimeFormat_js()
        {
            RunTest("intl402/Date/prototype/throws-same-exceptions-as-DateTimeFormat.js");
        }
    }
}
