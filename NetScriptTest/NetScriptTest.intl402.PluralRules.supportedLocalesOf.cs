using Xunit;

namespace NetScriptTest.intl402.PluralRules
{
    public sealed class Test_supportedLocalesOf : BaseTest
    {
        [Fact(DisplayName = "/intl402/PluralRules/supportedLocalesOf/arguments.js")]
        public void Test_arguments_js()
        {
            RunTest("intl402/PluralRules/supportedLocalesOf/arguments.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/supportedLocalesOf/main.js")]
        public void Test_main_js()
        {
            RunTest("intl402/PluralRules/supportedLocalesOf/main.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/supportedLocalesOf/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/PluralRules/supportedLocalesOf/name.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/supportedLocalesOf/supportedLocalesOf.js")]
        public void Test_supportedLocalesOf_js()
        {
            RunTest("intl402/PluralRules/supportedLocalesOf/supportedLocalesOf.js");
        }
    }
}
