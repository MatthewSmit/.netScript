using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_TypedArray : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/invoked.js")]
        public void Test_invoked_js()
        {
            RunTest("built-ins/TypedArray/invoked.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/TypedArray/prototype.js");
        }
    }
}
