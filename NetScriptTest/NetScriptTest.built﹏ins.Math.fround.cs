using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_fround : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/fround/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/fround/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/fround/Math.fround_Infinity.js")]
        public void Test_Math_fround_Infinity_js()
        {
            RunTest("built-ins/Math/fround/Math.fround_Infinity.js");
        }

        [Fact(DisplayName = "/built-ins/Math/fround/Math.fround_NaN.js")]
        public void Test_Math_fround_NaN_js()
        {
            RunTest("built-ins/Math/fround/Math.fround_NaN.js");
        }

        [Fact(DisplayName = "/built-ins/Math/fround/Math.fround_Zero.js")]
        public void Test_Math_fround_Zero_js()
        {
            RunTest("built-ins/Math/fround/Math.fround_Zero.js");
        }

        [Fact(DisplayName = "/built-ins/Math/fround/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/fround/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/fround/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/fround/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/fround/value-convertion.js")]
        public void Test_value﹏convertion_js()
        {
            RunTest("built-ins/Math/fround/value-convertion.js");
        }
    }
}
