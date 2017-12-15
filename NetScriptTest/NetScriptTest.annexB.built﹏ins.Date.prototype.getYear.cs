using Xunit;

namespace NetScriptTest.annexB.built﹏ins.Date.prototype
{
    public sealed class Test_getYear : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/getYear/B.2.4.js")]
        public void Test_B_2_4_js()
        {
            RunTest("annexB/built-ins/Date/prototype/getYear/B.2.4.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/getYear/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/Date/prototype/getYear/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/getYear/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/Date/prototype/getYear/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/getYear/nan.js")]
        public void Test_nan_js()
        {
            RunTest("annexB/built-ins/Date/prototype/getYear/nan.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/getYear/return-value.js")]
        public void Test_return﹏value_js()
        {
            RunTest("annexB/built-ins/Date/prototype/getYear/return-value.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/getYear/this-not-date.js")]
        public void Test_this﹏not﹏date_js()
        {
            RunTest("annexB/built-ins/Date/prototype/getYear/this-not-date.js");
        }
    }
}
