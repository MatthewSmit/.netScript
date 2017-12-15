using Xunit;

namespace NetScriptTest.intl402.DateTimeFormat.prototype
{
    public sealed class Test_formatToParts : BaseTest
    {
        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/date-is-infinity-throws.js")]
        public void Test_date﹏is﹏infinity﹏throws_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/date-is-infinity-throws.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/date-is-nan-throws.js")]
        public void Test_date﹏is﹏nan﹏throws_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/date-is-nan-throws.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/formatToParts.js")]
        public void Test_formatToParts_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/formatToParts.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/length.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/main.js")]
        public void Test_main_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/main.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/name.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/return-abrupt-tonumber-date.js")]
        public void Test_return﹏abrupt﹏tonumber﹏date_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/return-abrupt-tonumber-date.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/this-has-not-internal-throws.js")]
        public void Test_this﹏has﹏not﹏internal﹏throws_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/this-has-not-internal-throws.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/formatToParts/this-is-not-object-throws.js")]
        public void Test_this﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/formatToParts/this-is-not-object-throws.js");
        }
    }
}
