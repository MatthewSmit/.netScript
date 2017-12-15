using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_toStringTag : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/toStringTag/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/toStringTag/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/toStringTag/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/toStringTag/prop-desc.js");
        }
    }
}
