using Xunit;

namespace NetScriptTest.intl402.NumberFormat
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/NumberFormat/prototype/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/NumberFormat/prototype/builtin.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/NumberFormat/prototype/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/this-value-not-numberformat.js")]
        public void Test_this﹏value﹏not﹏numberformat_js()
        {
            RunTest("intl402/NumberFormat/prototype/this-value-not-numberformat.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prototype/this-value-numberformat-prototype.js")]
        public void Test_this﹏value﹏numberformat﹏prototype_js()
        {
            RunTest("intl402/NumberFormat/prototype/this-value-numberformat-prototype.js");
        }
    }
}
