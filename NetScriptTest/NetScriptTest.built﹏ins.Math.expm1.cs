using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_expm1 : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/expm1/expm1-specialVals.js")]
        public void Test_expm1﹏specialVals_js()
        {
            RunTest("built-ins/Math/expm1/expm1-specialVals.js");
        }

        [Fact(DisplayName = "/built-ins/Math/expm1/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/expm1/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/expm1/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/expm1/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/expm1/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/expm1/prop-desc.js");
        }
    }
}
