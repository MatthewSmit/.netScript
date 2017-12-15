using Xunit;

namespace NetScriptTest.intl402.PluralRules
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/PluralRules/prototype/bind.js")]
        public void Test_bind_js()
        {
            RunTest("intl402/PluralRules/prototype/bind.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/builtins.js")]
        public void Test_builtins_js()
        {
            RunTest("intl402/PluralRules/prototype/builtins.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/properties.js")]
        public void Test_properties_js()
        {
            RunTest("intl402/PluralRules/prototype/properties.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("intl402/PluralRules/prototype/prototype.js");
        }
    }
}
