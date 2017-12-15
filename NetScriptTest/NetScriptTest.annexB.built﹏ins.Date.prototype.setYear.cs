using Xunit;

namespace NetScriptTest.annexB.built﹏ins.Date.prototype
{
    public sealed class Test_setYear : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/B.2.5.js")]
        public void Test_B_2_5_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/B.2.5.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/this-not-date.js")]
        public void Test_this﹏not﹏date_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/this-not-date.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/this-time-nan.js")]
        public void Test_this﹏time﹏nan_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/this-time-nan.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/this-time-valid.js")]
        public void Test_this﹏time﹏valid_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/this-time-valid.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/time-clip.js")]
        public void Test_time﹏clip_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/time-clip.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/year-nan.js")]
        public void Test_year﹏nan_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/year-nan.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/year-number-absolute.js")]
        public void Test_year﹏number﹏absolute_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/year-number-absolute.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/year-number-relative.js")]
        public void Test_year﹏number﹏relative_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/year-number-relative.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/Date/prototype/setYear/year-to-number-err.js")]
        public void Test_year﹏to﹏number﹏err_js()
        {
            RunTest("annexB/built-ins/Date/prototype/setYear/year-to-number-err.js");
        }
    }
}
