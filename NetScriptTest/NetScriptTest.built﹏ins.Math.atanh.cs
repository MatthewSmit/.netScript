using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_atanh : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/atanh/atanh-specialVals.js")]
        public void Test_atanh﹏specialVals_js()
        {
            RunTest("built-ins/Math/atanh/atanh-specialVals.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atanh/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/atanh/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atanh/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/atanh/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/atanh/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/atanh/prop-desc.js");
        }
    }
}
