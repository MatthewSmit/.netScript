using Xunit;

namespace NetScriptTest.built﹏ins.Number
{
    public sealed class Test_isSafeInteger : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/arg-is-not-number.js")]
        public void Test_arg﹏is﹏not﹏number_js()
        {
            RunTest("built-ins/Number/isSafeInteger/arg-is-not-number.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/infinity.js")]
        public void Test_infinity_js()
        {
            RunTest("built-ins/Number/isSafeInteger/infinity.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Number/isSafeInteger/length.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Number/isSafeInteger/name.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/nan.js")]
        public void Test_nan_js()
        {
            RunTest("built-ins/Number/isSafeInteger/nan.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/not-integer.js")]
        public void Test_not﹏integer_js()
        {
            RunTest("built-ins/Number/isSafeInteger/not-integer.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/not-safe-integer.js")]
        public void Test_not﹏safe﹏integer_js()
        {
            RunTest("built-ins/Number/isSafeInteger/not-safe-integer.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Number/isSafeInteger/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Number/isSafeInteger/safe-integers.js")]
        public void Test_safe﹏integers_js()
        {
            RunTest("built-ins/Number/isSafeInteger/safe-integers.js");
        }
    }
}
