using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_hasInstance : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/hasInstance/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/hasInstance/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/hasInstance/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/hasInstance/prop-desc.js");
        }
    }
}
