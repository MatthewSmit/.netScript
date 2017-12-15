using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_cosh : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/cosh/cosh-specialVals.js")]
        public void Test_cosh﹏specialVals_js()
        {
            RunTest("built-ins/Math/cosh/cosh-specialVals.js");
        }

        [Fact(DisplayName = "/built-ins/Math/cosh/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/cosh/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/cosh/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/cosh/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/cosh/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/cosh/prop-desc.js");
        }
    }
}
