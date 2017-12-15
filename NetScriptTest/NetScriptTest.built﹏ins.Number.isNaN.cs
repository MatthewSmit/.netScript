using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_isNaN : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/isNaN/arg-is-not-number.js")]
        public void Test_arg﹏is﹏not﹏number_js()
        {
            RunTest("built-ins/Number/isNaN/arg-is-not-number.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isNaN/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Number/isNaN/length.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isNaN/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Number/isNaN/name.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isNaN/nan.js")]
        public void Test_nan_js()
        {
            RunTest("built-ins/Number/isNaN/nan.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isNaN/not-nan.js")]
        public void Test_not﹏nan_js()
        {
            RunTest("built-ins/Number/isNaN/not-nan.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isNaN/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Number/isNaN/prop-desc.js");
        }
    }
}
