using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_isFinite : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/isFinite/arg-is-not-number.js")]
        public void Test_arg﹏is﹏not﹏number_js()
        {
            RunTest("built-ins/Number/isFinite/arg-is-not-number.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isFinite/finite-numbers.js")]
        public void Test_finite﹏numbers_js()
        {
            RunTest("built-ins/Number/isFinite/finite-numbers.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isFinite/infinity.js")]
        public void Test_infinity_js()
        {
            RunTest("built-ins/Number/isFinite/infinity.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isFinite/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Number/isFinite/length.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isFinite/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Number/isFinite/name.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isFinite/nan.js")]
        public void Test_nan_js()
        {
            RunTest("built-ins/Number/isFinite/nan.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isFinite/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Number/isFinite/prop-desc.js");
        }
    }
}
