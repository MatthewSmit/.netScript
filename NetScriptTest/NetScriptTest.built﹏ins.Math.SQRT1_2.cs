using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_SQRT1_2 : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/SQRT1_2/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/SQRT1_2/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/SQRT1_2/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Math/SQRT1_2/value.js");
        }
    }
}
