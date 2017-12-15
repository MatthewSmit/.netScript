using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_split : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/split/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/split/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/split/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/split/prop-desc.js");
        }
    }
}
