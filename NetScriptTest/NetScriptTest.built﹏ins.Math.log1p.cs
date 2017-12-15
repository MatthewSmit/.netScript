using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_log1p : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/log1p/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/log1p/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log1p/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/log1p/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log1p/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/log1p/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log1p/specific-results.js")]
        public void Test_specific﹏results_js()
        {
            RunTest("built-ins/Math/log1p/specific-results.js");
        }
    }
}
