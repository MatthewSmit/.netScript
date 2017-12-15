using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_unscopables : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/unscopables/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/unscopables/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/unscopables/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/unscopables/prop-desc.js");
        }
    }
}
