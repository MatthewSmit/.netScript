using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_cbrt : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/cbrt/cbrt-specialValues.js")]
        public void Test_cbrt﹏specialValues_js()
        {
            RunTest("built-ins/Math/cbrt/cbrt-specialValues.js");
        }

        [Fact(DisplayName = "/built-ins/Math/cbrt/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/cbrt/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/cbrt/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/cbrt/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/cbrt/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/cbrt/prop-desc.js");
        }
    }
}
