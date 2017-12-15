using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_SQRT2 : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/SQRT2/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/SQRT2/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/SQRT2/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Math/SQRT2/value.js");
        }
    }
}
