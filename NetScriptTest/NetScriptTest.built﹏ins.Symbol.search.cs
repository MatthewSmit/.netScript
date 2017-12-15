using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_search : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/search/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/search/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/search/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/search/prop-desc.js");
        }
    }
}
