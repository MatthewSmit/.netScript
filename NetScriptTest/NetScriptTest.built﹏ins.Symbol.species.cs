using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_species : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/species/basic.js")]
        public void Test_basic_js()
        {
            RunTest("built-ins/Symbol/species/basic.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/species/builtin-getter-name.js")]
        public void Test_builtin﹏getter﹏name_js()
        {
            RunTest("built-ins/Symbol/species/builtin-getter-name.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/species/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/species/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/species/subclassing.js")]
        public void Test_subclassing_js()
        {
            RunTest("built-ins/Symbol/species/subclassing.js");
        }
    }
}
