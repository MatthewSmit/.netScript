using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray.prototype
{
    public sealed class Test_keys : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/detached-buffer.js")]
        public void Test_detached﹏buffer_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/detached-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/invoked-as-func.js")]
        public void Test_invoked﹏as﹏func_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/invoked-as-func.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/invoked-as-method.js")]
        public void Test_invoked﹏as﹏method_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/invoked-as-method.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/iter-prototype.js")]
        public void Test_iter﹏prototype_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/iter-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/return-itor.js")]
        public void Test_return﹏itor_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/return-itor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/this-is-not-object.js")]
        public void Test_this﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/this-is-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/keys/this-is-not-typedarray-instance.js")]
        public void Test_this﹏is﹏not﹏typedarray﹏instance_js()
        {
            RunTest("built-ins/TypedArray/prototype/keys/this-is-not-typedarray-instance.js");
        }
    }
}
