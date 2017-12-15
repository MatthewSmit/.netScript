using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_trunc : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/trunc/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/trunc/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/Math.trunc_Infinity.js")]
        public void Test_Math_trunc_Infinity_js()
        {
            RunTest("built-ins/Math/trunc/Math.trunc_Infinity.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/Math.trunc_NaN.js")]
        public void Test_Math_trunc_NaN_js()
        {
            RunTest("built-ins/Math/trunc/Math.trunc_NaN.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/Math.trunc_NegDecimal.js")]
        public void Test_Math_trunc_NegDecimal_js()
        {
            RunTest("built-ins/Math/trunc/Math.trunc_NegDecimal.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/Math.trunc_PosDecimal.js")]
        public void Test_Math_trunc_PosDecimal_js()
        {
            RunTest("built-ins/Math/trunc/Math.trunc_PosDecimal.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/Math.trunc_Success.js")]
        public void Test_Math_trunc_Success_js()
        {
            RunTest("built-ins/Math/trunc/Math.trunc_Success.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/Math.trunc_Zero.js")]
        public void Test_Math_trunc_Zero_js()
        {
            RunTest("built-ins/Math/trunc/Math.trunc_Zero.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/trunc/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/trunc/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/trunc-sampleTests.js")]
        public void Test_trunc﹏sampleTests_js()
        {
            RunTest("built-ins/Math/trunc/trunc-sampleTests.js");
        }

        [Fact(DisplayName = "/built-ins/Math/trunc/trunc-specialVals.js")]
        public void Test_trunc﹏specialVals_js()
        {
            RunTest("built-ins/Math/trunc/trunc-specialVals.js");
        }
    }
}
