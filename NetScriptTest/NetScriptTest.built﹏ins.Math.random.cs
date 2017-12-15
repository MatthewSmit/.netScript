using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_random : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/random/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/random/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/random/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/random/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/random/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/random/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/random/S15.8.2.14_A1.js")]
        public void Test_S15_8_2_14_A1_js()
        {
            RunTest("built-ins/Math/random/S15.8.2.14_A1.js");
        }
    }
}
