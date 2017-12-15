using Xunit;

namespace NetScriptTest.built﹏ins.Number.prototype
{
    public sealed class Test_toLocaleString : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/prototype/toLocaleString/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Number/prototype/toLocaleString/length.js");
        }

        [Fact(DisplayName = "/built-ins/Number/prototype/toLocaleString/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Number/prototype/toLocaleString/name.js");
        }

        [Fact(DisplayName = "/built-ins/Number/prototype/toLocaleString/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Number/prototype/toLocaleString/prop-desc.js");
        }
    }
}
