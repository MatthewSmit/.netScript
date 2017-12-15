using Xunit;

namespace NetScriptTest.built﹏ins.Promise
{
    public sealed class Test_Symbol_species : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Promise/Symbol.species/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Promise/Symbol.species/length.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/Symbol.species/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Promise/Symbol.species/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/Symbol.species/return-value.js")]
        public void Test_return﹏value_js()
        {
            RunTest("built-ins/Promise/Symbol.species/return-value.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/Symbol.species/symbol-species-name.js")]
        public void Test_symbol﹏species﹏name_js()
        {
            RunTest("built-ins/Promise/Symbol.species/symbol-species-name.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/Symbol.species/symbol-species.js")]
        public void Test_symbol﹏species_js()
        {
            RunTest("built-ins/Promise/Symbol.species/symbol-species.js");
        }
    }
}
