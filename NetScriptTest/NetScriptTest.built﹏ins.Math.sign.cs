using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_sign : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/sign/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/sign/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sign/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/sign/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sign/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/sign/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/sign/sign-specialVals.js")]
        public void Test_sign﹏specialVals_js()
        {
            RunTest("built-ins/Math/sign/sign-specialVals.js");
        }
    }
}
