using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_LN10 : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/LN10/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/LN10/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/LN10/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Math/LN10/value.js");
        }
    }
}
