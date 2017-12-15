using Xunit;

namespace NetScriptTest.language.computed﹏property﹏names.Class
{
    public sealed class Test_accessor : BaseTest
    {
        [Fact(DisplayName = "/language/computed-property-names/class/accessor/getter-duplicates.js")]
        public void Test_getter﹏duplicates_js()
        {
            RunTest("language/computed-property-names/class/accessor/getter-duplicates.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/class/accessor/getter.js")]
        public void Test_getter_js()
        {
            RunTest("language/computed-property-names/class/accessor/getter.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/class/accessor/setter-duplicates.js")]
        public void Test_setter﹏duplicates_js()
        {
            RunTest("language/computed-property-names/class/accessor/setter-duplicates.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/class/accessor/setter.js")]
        public void Test_setter_js()
        {
            RunTest("language/computed-property-names/class/accessor/setter.js");
        }
    }
}
