using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_LOG10E : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/LOG10E/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/LOG10E/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/LOG10E/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Math/LOG10E/value.js");
        }
    }
}
