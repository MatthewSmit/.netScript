using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_toPrimitive : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/toPrimitive/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/toPrimitive/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/toPrimitive/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/toPrimitive/prop-desc.js");
        }
    }
}
