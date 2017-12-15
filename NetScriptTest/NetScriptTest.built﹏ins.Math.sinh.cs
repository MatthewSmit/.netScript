using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_sinh : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/sinh/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/sinh/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sinh/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/sinh/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sinh/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/sinh/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sinh/sinh-specialVals.js")]
        public void Test_sinh﹏specialVals_js()
        {
            RunTest("built-ins/Math/sinh/sinh-specialVals.js");
        }
    }
}
