using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_E : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/E/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/E/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/E/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Math/E/value.js");
        }
    }
}
