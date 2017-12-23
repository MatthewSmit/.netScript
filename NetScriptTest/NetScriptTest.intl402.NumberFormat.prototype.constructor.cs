using Xunit;

namespace NetScriptTest.intl402.NumberFormat.prototype
{
    public sealed class Test_constructor : BaseTest
    {
        [Fact(DisplayName = "/intl402/NumberFormat/prototype/constructor/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/NumberFormat/prototype/constructor/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/constructor/value.js")]
        public void Test_value_js()
        {
            RunTest("intl402/NumberFormat/prototype/constructor/value.js");
        }
    }
}
