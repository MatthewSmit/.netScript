using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_acosh : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/acosh/arg-is-infinity.js")]
        public void Test_arg﹏is﹏infinity_js()
        {
            RunTest("built-ins/Math/acosh/arg-is-infinity.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acosh/arg-is-one.js")]
        public void Test_arg﹏is﹏one_js()
        {
            RunTest("built-ins/Math/acosh/arg-is-one.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acosh/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/acosh/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acosh/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/acosh/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acosh/nan-returns.js")]
        public void Test_nan﹏returns_js()
        {
            RunTest("built-ins/Math/acosh/nan-returns.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acosh/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/acosh/prop-desc.js");
        }
    }
}
