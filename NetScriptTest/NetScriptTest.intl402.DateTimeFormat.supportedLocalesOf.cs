using Xunit;

namespace NetScriptTest.intl402.DateTimeFormat
{
    public sealed class Test_supportedLocalesOf : BaseTest
    {
        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/basic.js")]
        public void Test_basic_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/basic.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/builtin.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/length.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/name.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/supportedLocalesOf/taint-Object-prototype.js")]
        public void Test_taint﹏Object﹏prototype_js()
        {
            RunTest("intl402/DateTimeFormat/supportedLocalesOf/taint-Object-prototype.js");
        }
    }
}
