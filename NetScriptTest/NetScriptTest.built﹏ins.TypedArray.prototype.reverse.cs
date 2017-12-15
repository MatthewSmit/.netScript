using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray.prototype
{
    public sealed class Test_reverse : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/detached-buffer.js")]
        public void Test_detached﹏buffer_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/detached-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/get-length-uses-internal-arraylength.js")]
        public void Test_get﹏length﹏uses﹏internal﹏arraylength_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/get-length-uses-internal-arraylength.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/invoked-as-func.js")]
        public void Test_invoked﹏as﹏func_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/invoked-as-func.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/invoked-as-method.js")]
        public void Test_invoked﹏as﹏method_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/invoked-as-method.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/preserves-non-numeric-properties.js")]
        public void Test_preserves﹏non﹏numeric﹏properties_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/preserves-non-numeric-properties.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/returns-original-object.js")]
        public void Test_returns﹏original﹏object_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/returns-original-object.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/reverts.js")]
        public void Test_reverts_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/reverts.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/this-is-not-object.js")]
        public void Test_this﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/this-is-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/reverse/this-is-not-typedarray-instance.js")]
        public void Test_this﹏is﹏not﹏typedarray﹏instance_js()
        {
            RunTest("built-ins/TypedArray/prototype/reverse/this-is-not-typedarray-instance.js");
        }
    }
}
