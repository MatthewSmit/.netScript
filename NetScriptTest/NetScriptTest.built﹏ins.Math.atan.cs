using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_atan : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/atan/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/atan/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atan/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/atan/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atan/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/atan/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atan/S15.8.2.4_A1.js")]
        public void Test_S15_8_2_4_A1_js()
        {
            RunTest("built-ins/Math/atan/S15.8.2.4_A1.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atan/S15.8.2.4_A2.js")]
        public void Test_S15_8_2_4_A2_js()
        {
            RunTest("built-ins/Math/atan/S15.8.2.4_A2.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atan/S15.8.2.4_A3.js")]
        public void Test_S15_8_2_4_A3_js()
        {
            RunTest("built-ins/Math/atan/S15.8.2.4_A3.js");
        }
    }
}
