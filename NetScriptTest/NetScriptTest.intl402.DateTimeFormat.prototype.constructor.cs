using Xunit;

namespace NetScriptTest.intl402.DateTimeFormat.prototype
{
    public sealed class Test_constructor : BaseTest
    {
        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/constructor/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/constructor/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/DateTimeFormat/prototype/constructor/value.js")]
        public void Test_value_js()
        {
            RunTest("intl402/DateTimeFormat/prototype/constructor/value.js");
        }
    }
}
