using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_PI : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/PI/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/PI/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/PI/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Math/PI/value.js");
        }
    }
}
