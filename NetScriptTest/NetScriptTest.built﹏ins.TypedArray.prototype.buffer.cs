using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray.prototype
{
    public sealed class Test_buffer : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/detached-buffer.js")]
        public void Test_detached﹏buffer_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/detached-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/invoked-as-accessor.js")]
        public void Test_invoked﹏as﹏accessor_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/invoked-as-accessor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/invoked-as-func.js")]
        public void Test_invoked﹏as﹏func_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/invoked-as-func.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/return-buffer.js")]
        public void Test_return﹏buffer_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/return-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/this-has-no-typedarrayname-internal.js")]
        public void Test_this﹏has﹏no﹏typedarrayname﹏internal_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/this-has-no-typedarrayname-internal.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/buffer/this-is-not-object.js")]
        public void Test_this﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/TypedArray/prototype/buffer/this-is-not-object.js");
        }
    }
}
