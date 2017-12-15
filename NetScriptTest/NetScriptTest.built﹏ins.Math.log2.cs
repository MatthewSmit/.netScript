using Xunit;

namespace NetScriptTest.built﹏ins.Math
{
    public sealed class Test_log2 : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/log2/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Math/log2/length.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log2/log2-basicTests.js")]
        public void Test_log2﹏basicTests_js()
        {
            RunTest("built-ins/Math/log2/log2-basicTests.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log2/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Math/log2/name.js");
        }

        [Fact(DisplayName = "/built-ins/Math/log2/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/log2/prop-desc.js");
        }
    }
}
