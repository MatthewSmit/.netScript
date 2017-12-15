using Xunit;

namespace NetScriptTest.intl402.PluralRules.prototype
{
    public sealed class Test_select : BaseTest
    {
        [Fact(DisplayName = "/intl402/PluralRules/prototype/select/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/PluralRules/prototype/select/name.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/select/non-finite.js")]
        public void Test_non﹏finite_js()
        {
            RunTest("intl402/PluralRules/prototype/select/non-finite.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/select/tainting.js")]
        public void Test_tainting_js()
        {
            RunTest("intl402/PluralRules/prototype/select/tainting.js");
        }
    }
}
