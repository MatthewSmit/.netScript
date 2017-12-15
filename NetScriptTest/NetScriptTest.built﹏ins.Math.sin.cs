using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_sin : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/sin/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/sin/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sin/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/sin/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sin/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/sin/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sin/S15.8.2.16_A1.js")]
        public void Test_S15_8_2_16_A1_js()
        {
            RunTest("built-ins/Math/sin/S15.8.2.16_A1.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sin/S15.8.2.16_A4.js")]
        public void Test_S15_8_2_16_A4_js()
        {
            RunTest("built-ins/Math/sin/S15.8.2.16_A4.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sin/S15.8.2.16_A5.js")]
        public void Test_S15_8_2_16_A5_js()
        {
            RunTest("built-ins/Math/sin/S15.8.2.16_A5.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sin/zero.js")]
        public void Test_zero_js()
        {
            RunTest("built-ins/Math/sin/zero.js");
        }
    }
}
