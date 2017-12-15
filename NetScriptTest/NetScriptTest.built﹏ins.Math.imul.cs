using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_imul : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/imul/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/imul/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/imul/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/imul/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/imul/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/imul/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/imul/results.js")]
        public void Test_results_js()
        {
            RunTest("built-ins/Math/imul/results.js");
        }
    }
}
