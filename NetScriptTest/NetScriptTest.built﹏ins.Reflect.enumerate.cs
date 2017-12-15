using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_enumerate : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/enumerate/undefined.js")]
        public void Test_undefined_js()
        {
            RunTest("built-ins/Reflect/enumerate/undefined.js");
        }
    }
}
