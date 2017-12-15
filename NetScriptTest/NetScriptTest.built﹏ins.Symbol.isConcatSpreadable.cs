using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_isConcatSpreadable : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/isConcatSpreadable/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/isConcatSpreadable/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/isConcatSpreadable/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/isConcatSpreadable/prop-desc.js");
        }
    }
}
