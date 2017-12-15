using Xunit;

namespace NetScriptTest.intl402.String.prototype
{
    public sealed class Test_toLocaleLowerCase : BaseTest
    {
        [Fact(DisplayName = "/intl402/String/prototype/toLocaleLowerCase/capital_I_with_dot.js")]
        public void Test_capital_I_with_dot_js()
        {
            RunTest("intl402/String/prototype/toLocaleLowerCase/capital_I_with_dot.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/toLocaleLowerCase/special_casing_Azeri.js")]
        public void Test_special_casing_Azeri_js()
        {
            RunTest("intl402/String/prototype/toLocaleLowerCase/special_casing_Azeri.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/toLocaleLowerCase/special_casing_Lithuanian.js")]
        public void Test_special_casing_Lithuanian_js()
        {
            RunTest("intl402/String/prototype/toLocaleLowerCase/special_casing_Lithuanian.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/toLocaleLowerCase/special_casing_Turkish.js")]
        public void Test_special_casing_Turkish_js()
        {
            RunTest("intl402/String/prototype/toLocaleLowerCase/special_casing_Turkish.js");
        }
    }
}
