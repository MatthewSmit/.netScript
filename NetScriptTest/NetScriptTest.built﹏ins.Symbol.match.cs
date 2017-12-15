using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_match : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/match/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/match/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/match/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/match/prop-desc.js");
        }
    }
}
