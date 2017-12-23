using Xunit;

namespace NetScriptTest.intl402.PluralRules.prototype
{
    public sealed class Test_constructor : BaseTest
    {
        [Fact(DisplayName = "/intl402/PluralRules/prototype/constructor/main.js")]
        public void Test_main_js()
        {
            RunTest("intl402/PluralRules/prototype/constructor/main.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/prototype/constructor/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/PluralRules/prototype/constructor/prop-desc.js");
        }
    }
}
