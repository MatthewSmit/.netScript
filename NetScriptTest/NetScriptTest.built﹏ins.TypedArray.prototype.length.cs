using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray.prototype
{
    public sealed class Test_length : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/detached-buffer.js")]
        public void Test_detached﹏buffer_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/detached-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/invoked-as-accessor.js")]
        public void Test_invoked﹏as﹏accessor_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/invoked-as-accessor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/invoked-as-func.js")]
        public void Test_invoked﹏as﹏func_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/invoked-as-func.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/return-length.js")]
        public void Test_return﹏length_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/return-length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/this-has-no-typedarrayname-internal.js")]
        public void Test_this﹏has﹏no﹏typedarrayname﹏internal_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/this-has-no-typedarrayname-internal.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/length/this-is-not-object.js")]
        public void Test_this﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/TypedArray/prototype/length/this-is-not-object.js");
        }
    }
}
