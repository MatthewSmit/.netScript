using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_abs : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/abs/absolute-value.js")]
        public void Test_absolute﹏value_js()
        {
            RunTest("built-ins/Math/abs/absolute-value.js");
        }

        [Fact(DisplayName = "/built-ins/Math/abs/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/abs/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/abs/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/abs/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/abs/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/abs/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/abs/S15.8.2.1_A1.js")]
        public void Test_S15_8_2_1_A1_js()
        {
            RunTest("built-ins/Math/abs/S15.8.2.1_A1.js");
        }

        [Fact(DisplayName = "/built-ins/Math/abs/S15.8.2.1_A2.js")]
        public void Test_S15_8_2_1_A2_js()
        {
            RunTest("built-ins/Math/abs/S15.8.2.1_A2.js");
        }

        [Fact(DisplayName = "/built-ins/Math/abs/S15.8.2.1_A3.js")]
        public void Test_S15_8_2_1_A3_js()
        {
            RunTest("built-ins/Math/abs/S15.8.2.1_A3.js");
        }
    }
}
