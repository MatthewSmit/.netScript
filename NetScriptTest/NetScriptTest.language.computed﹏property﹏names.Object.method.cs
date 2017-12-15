using Xunit;

namespace NetScriptTest.language.computed﹏property﹏names.Object
{
    public sealed class Test_method : BaseTest
    {
        [Fact(DisplayName = "/language/computed-property-names/object/method/generator.js")]
        public void Test_generator_js()
        {
            RunTest("language/computed-property-names/object/method/generator.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/method/number.js")]
        public void Test_number_js()
        {
            RunTest("language/computed-property-names/object/method/number.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/method/string.js")]
        public void Test_string_js()
        {
            RunTest("language/computed-property-names/object/method/string.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/method/super.js")]
        public void Test_super_js()
        {
            RunTest("language/computed-property-names/object/method/super.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/object/method/symbol.js")]
        public void Test_symbol_js()
        {
            RunTest("language/computed-property-names/object/method/symbol.js");
        }
    }
}
