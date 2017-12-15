using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray
{
    public sealed class Test_Symbol_species : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/Symbol.species/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/Symbol.species/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/Symbol.species/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/Symbol.species/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/Symbol.species/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/TypedArray/Symbol.species/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/Symbol.species/result.js")]
        public void Test_result_js()
        {
            RunTest("built-ins/TypedArray/Symbol.species/result.js");
        }
    }
}
