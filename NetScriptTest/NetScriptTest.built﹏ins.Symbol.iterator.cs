using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_iterator : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/iterator/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/iterator/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/iterator/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/iterator/prop-desc.js");
        }
    }
}
