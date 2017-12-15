using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray
{
    public sealed class Test_of : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/of/invoked-as-func.js")]
        public void Test_invoked﹏as﹏func_js()
        {
            RunTest("built-ins/TypedArray/of/invoked-as-func.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/of/invoked-as-method.js")]
        public void Test_invoked﹏as﹏method_js()
        {
            RunTest("built-ins/TypedArray/of/invoked-as-method.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/of/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/of/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/of/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/of/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/of/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/TypedArray/of/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/of/this-is-not-constructor.js")]
        public void Test_this﹏is﹏not﹏constructor_js()
        {
            RunTest("built-ins/TypedArray/of/this-is-not-constructor.js");
        }
    }
}
