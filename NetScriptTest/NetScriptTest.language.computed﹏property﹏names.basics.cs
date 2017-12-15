using Xunit;

namespace NetScriptTest.language.computed﹏property﹏names
{
    public sealed class Test_basics : BaseTest
    {
        [Fact(DisplayName = "/language/computed-property-names/basics/number.js")]
        public void Test_number_js()
        {
            RunTest("language/computed-property-names/basics/number.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/basics/string.js")]
        public void Test_string_js()
        {
            RunTest("language/computed-property-names/basics/string.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/basics/symbol.js")]
        public void Test_symbol_js()
        {
            RunTest("language/computed-property-names/basics/symbol.js");
        }
    }
}
