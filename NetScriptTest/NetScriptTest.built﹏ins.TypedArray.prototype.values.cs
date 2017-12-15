using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray.prototype
{
    public sealed class Test_values : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/detached-buffer.js")]
        public void Test_detached﹏buffer_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/detached-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/invoked-as-func.js")]
        public void Test_invoked﹏as﹏func_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/invoked-as-func.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/invoked-as-method.js")]
        public void Test_invoked﹏as﹏method_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/invoked-as-method.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/iter-prototype.js")]
        public void Test_iter﹏prototype_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/iter-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/return-itor.js")]
        public void Test_return﹏itor_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/return-itor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/this-is-not-object.js")]
        public void Test_this﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/this-is-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/values/this-is-not-typedarray-instance.js")]
        public void Test_this﹏is﹏not﹏typedarray﹏instance_js()
        {
            RunTest("built-ins/TypedArray/prototype/values/this-is-not-typedarray-instance.js");
        }
    }
}
