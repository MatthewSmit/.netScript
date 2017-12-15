using Xunit;

namespace NetScriptTest.built﹏ins.ArrayBuffer.prototype
{
    public sealed class Test_byteLength : BaseTest
    {
        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/detached-buffer.js")]
        public void Test_detached﹏buffer_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/detached-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/invoked-as-accessor.js")]
        public void Test_invoked﹏as﹏accessor_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/invoked-as-accessor.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/invoked-as-func.js")]
        public void Test_invoked﹏as﹏func_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/invoked-as-func.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/length.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/name.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/return-bytelength.js")]
        public void Test_return﹏bytelength_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/return-bytelength.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/this-has-no-typedarrayname-internal.js")]
        public void Test_this﹏has﹏no﹏typedarrayname﹏internal_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/this-has-no-typedarrayname-internal.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/this-is-not-object.js")]
        public void Test_this﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/this-is-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/byteLength/this-is-sharedarraybuffer.js")]
        public void Test_this﹏is﹏sharedarraybuffer_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/byteLength/this-is-sharedarraybuffer.js");
        }
    }
}
