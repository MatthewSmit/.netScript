using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_asinh : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/asinh/asinh-specialVals.js")]
        public void Test_asinh﹏specialVals_js()
        {
            RunTest("built-ins/Math/asinh/asinh-specialVals.js");
        }

        [Fact(DisplayName = "/built-ins/Math/asinh/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/asinh/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/asinh/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/asinh/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/asinh/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/asinh/prop-desc.js");
        }
    }
}
