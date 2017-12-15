using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_acos : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/acos/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/acos/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acos/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/acos/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acos/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/acos/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acos/S15.8.2.2_A1.js")]
        public void Test_S15_8_2_2_A1_js()
        {
            RunTest("built-ins/Math/acos/S15.8.2.2_A1.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acos/S15.8.2.2_A2.js")]
        public void Test_S15_8_2_2_A2_js()
        {
            RunTest("built-ins/Math/acos/S15.8.2.2_A2.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acos/S15.8.2.2_A3.js")]
        public void Test_S15_8_2_2_A3_js()
        {
            RunTest("built-ins/Math/acos/S15.8.2.2_A3.js");
        }

        [Fact(DisplayName = "/built-ins/Math/acos/S15.8.2.2_A4.js")]
        public void Test_S15_8_2_2_A4_js()
        {
            RunTest("built-ins/Math/acos/S15.8.2.2_A4.js");
        }
    }
}
