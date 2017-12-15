using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_isInteger : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/isInteger/arg-is-not-number.js")]
        public void Test_arg﹏is﹏not﹏number_js()
        {
            RunTest("built-ins/Number/isInteger/arg-is-not-number.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isInteger/infinity.js")]
        public void Test_infinity_js()
        {
            RunTest("built-ins/Number/isInteger/infinity.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isInteger/integers.js")]
        public void Test_integers_js()
        {
            RunTest("built-ins/Number/isInteger/integers.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isInteger/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Number/isInteger/length.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isInteger/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Number/isInteger/name.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isInteger/nan.js")]
        public void Test_nan_js()
        {
            RunTest("built-ins/Number/isInteger/nan.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isInteger/non-integers.js")]
        public void Test_non﹏integers_js()
        {
            RunTest("built-ins/Number/isInteger/non-integers.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isInteger/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Number/isInteger/prop-desc.js");
        }
    }
}
