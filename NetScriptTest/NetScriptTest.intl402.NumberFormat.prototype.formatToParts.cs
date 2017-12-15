using Xunit;

namespace NetScriptTest.intl402.NumberFormat.prototype
{
    public sealed class Test_formatToParts : BaseTest
    {
        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/default-parameter.js")]
        public void Test_default﹏parameter_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/default-parameter.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/formatToParts.js")]
        public void Test_formatToParts_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/formatToParts.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/length.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/main.js")]
        public void Test_main_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/main.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/name.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/return-abrupt-tonumber.js")]
        public void Test_return﹏abrupt﹏tonumber_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/return-abrupt-tonumber.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/this-has-not-internal-throws.js")]
        public void Test_this﹏has﹏not﹏internal﹏throws_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/this-has-not-internal-throws.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/formatToParts/this-is-not-object-throws.js")]
        public void Test_this﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("intl402/NumberFormat/prototype/formatToParts/this-is-not-object-throws.js");
        }
    }
}
