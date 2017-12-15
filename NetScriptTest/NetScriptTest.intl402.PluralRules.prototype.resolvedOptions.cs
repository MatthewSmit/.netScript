using Xunit;

namespace NetScriptTest.intl402.PluralRules.prototype
{
    public sealed class Test_resolvedOptions : BaseTest
    {
        [Fact(DisplayName = "/intl402/PluralRules/prototype/resolvedOptions/builtins.js")]
        public void Test_builtins_js()
        {
            RunTest("intl402/PluralRules/prototype/resolvedOptions/builtins.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/resolvedOptions/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/PluralRules/prototype/resolvedOptions/name.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/resolvedOptions/properties.js")]
        public void Test_properties_js()
        {
            RunTest("intl402/PluralRules/prototype/resolvedOptions/properties.js");
        }
    }
}
