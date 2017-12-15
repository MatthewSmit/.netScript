using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_replace : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/replace/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/replace/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/replace/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/replace/prop-desc.js");
        }
    }
}
