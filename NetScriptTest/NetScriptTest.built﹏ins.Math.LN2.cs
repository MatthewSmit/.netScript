using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_LN2 : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/LN2/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/LN2/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/LN2/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Math/LN2/value.js");
        }
    }
}
