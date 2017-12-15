using Xunit;

namespace NetScriptTest.language.computed﹏property﹏names.Object
{
    public sealed class Test_accessor : BaseTest
    {
        [Fact(DisplayName = "/language/computed-property-names/object/accessor/getter-duplicates.js")]
        public void Test_getter﹏duplicates_js()
        {
            RunTest("language/computed-property-names/object/accessor/getter-duplicates.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/accessor/getter-super.js")]
        public void Test_getter﹏super_js()
        {
            RunTest("language/computed-property-names/object/accessor/getter-super.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/accessor/getter.js")]
        public void Test_getter_js()
        {
            RunTest("language/computed-property-names/object/accessor/getter.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/accessor/setter-duplicates.js")]
        public void Test_setter﹏duplicates_js()
        {
            RunTest("language/computed-property-names/object/accessor/setter-duplicates.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/accessor/setter-super.js")]
        public void Test_setter﹏super_js()
        {
            RunTest("language/computed-property-names/object/accessor/setter-super.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/accessor/setter.js")]
        public void Test_setter_js()
        {
            RunTest("language/computed-property-names/object/accessor/setter.js");
        }
    }
}
