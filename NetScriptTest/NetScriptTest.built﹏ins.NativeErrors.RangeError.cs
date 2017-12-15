using Xunit;

namespace NetScriptTest.built﹏ins.NativeErrors
{
    public sealed class Test_RangeError : BaseTest
    {
        [Fact(DisplayName = "/built-ins/NativeErrors/RangeError/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/NativeErrors/RangeError/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/RangeError/instance-proto.js")]
        public void Test_instance﹏proto_js()
        {
            RunTest("built-ins/NativeErrors/RangeError/instance-proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/RangeError/is-error-object.js")]
        public void Test_is﹏error﹏object_js()
        {
            RunTest("built-ins/NativeErrors/RangeError/is-error-object.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/RangeError/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/NativeErrors/RangeError/length.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/RangeError/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/NativeErrors/RangeError/name.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/RangeError/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/NativeErrors/RangeError/proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/RangeError/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/NativeErrors/RangeError/prototype.js");
        }
    }
}
