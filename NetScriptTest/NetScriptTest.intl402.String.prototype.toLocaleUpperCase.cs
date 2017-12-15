using Xunit;

namespace NetScriptTest.intl402.String.prototype
{
    public sealed class Test_toLocaleUpperCase : BaseTest
    {
        [Fact(DisplayName = "/intl402/String/prototype/toLocaleUpperCase/special_casing_Azeri.js")]
        public void Test_special_casing_Azeri_js()
        {
            RunTest("intl402/String/prototype/toLocaleUpperCase/special_casing_Azeri.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/toLocaleUpperCase/special_casing_Lithuanian.js")]
        public void Test_special_casing_Lithuanian_js()
        {
            RunTest("intl402/String/prototype/toLocaleUpperCase/special_casing_Lithuanian.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/toLocaleUpperCase/special_casing_Turkish.js")]
        public void Test_special_casing_Turkish_js()
        {
            RunTest("intl402/String/prototype/toLocaleUpperCase/special_casing_Turkish.js");
        }
    }
}
