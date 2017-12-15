using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_tanh : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/tanh/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/tanh/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/tanh/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/tanh/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/tanh/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/tanh/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/tanh/tanh-specialVals.js")]
        public void Test_tanh﹏specialVals_js()
        {
            RunTest("built-ins/Math/tanh/tanh-specialVals.js");
        }
    }
}
