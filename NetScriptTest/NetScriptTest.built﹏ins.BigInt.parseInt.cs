using Xunit;

namespace NetScriptTest.built﹏ins.BigInt
{
    public sealed class Test_parseInt : BaseTest
    {
        [Fact(DisplayName = "/built-ins/BigInt/parseInt/nonexistent.js")]
        public void Test_nonexistent_js()
        {
            RunTest("built-ins/BigInt/parseInt/nonexistent.js");
        }
    }
}
