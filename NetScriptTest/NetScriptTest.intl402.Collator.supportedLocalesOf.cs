using Xunit;

namespace NetScriptTest.intl402.Collator
{
    public sealed class Test_supportedLocalesOf : BaseTest
    {
        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/basic.js")]
        public void Test_basic_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/basic.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/length.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/name.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/Collator/supportedLocalesOf/taint-Object-prototype.js")]
        public void Test_taint﹏Object﹏prototype_js()
        {
            RunTest("intl402/Collator/supportedLocalesOf/taint-Object-prototype.js");
        }
    }
}
