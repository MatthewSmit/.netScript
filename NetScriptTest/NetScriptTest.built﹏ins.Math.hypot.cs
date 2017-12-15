using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_hypot : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/hypot/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/hypot/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/Math.hypot_Infinity.js")]
        public void Test_Math_hypot_Infinity_js()
        {
            RunTest("built-ins/Math/hypot/Math.hypot_Infinity.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/Math.hypot_InfinityNaN.js")]
        public void Test_Math_hypot_InfinityNaN_js()
        {
            RunTest("built-ins/Math/hypot/Math.hypot_InfinityNaN.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/Math.hypot_NaN.js")]
        public void Test_Math_hypot_NaN_js()
        {
            RunTest("built-ins/Math/hypot/Math.hypot_NaN.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/Math.hypot_NegInfinity.js")]
        public void Test_Math_hypot_NegInfinity_js()
        {
            RunTest("built-ins/Math/hypot/Math.hypot_NegInfinity.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/Math.hypot_NoArgs.js")]
        public void Test_Math_hypot_NoArgs_js()
        {
            RunTest("built-ins/Math/hypot/Math.hypot_NoArgs.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/Math.hypot_Success_2.js")]
        public void Test_Math_hypot_Success_2_js()
        {
            RunTest("built-ins/Math/hypot/Math.hypot_Success_2.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/Math.hypot_Zero_2.js")]
        public void Test_Math_hypot_Zero_2_js()
        {
            RunTest("built-ins/Math/hypot/Math.hypot_Zero_2.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/hypot/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/hypot/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/hypot/prop-desc.js");
        }
    }
}
