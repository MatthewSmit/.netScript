using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_log10 : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/log10/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/log10/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log10/Log10-specialVals.js")]
        public void Test_Log10﹏specialVals_js()
        {
            RunTest("built-ins/Math/log10/Log10-specialVals.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log10/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/log10/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log10/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/log10/prop-desc.js");
        }
    }
}
