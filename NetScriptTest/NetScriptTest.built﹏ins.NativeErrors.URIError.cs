using Xunit;

namespace NetScriptTest.built﹏ins.NativeErrors
{
    public sealed class Test_URIError : BaseTest
    {
        [Fact(DisplayName = "/built-ins/NativeErrors/URIError/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/NativeErrors/URIError/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/URIError/instance-proto.js")]
        public void Test_instance﹏proto_js()
        {
            RunTest("built-ins/NativeErrors/URIError/instance-proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/URIError/is-error-object.js")]
        public void Test_is﹏error﹏object_js()
        {
            RunTest("built-ins/NativeErrors/URIError/is-error-object.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/URIError/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/NativeErrors/URIError/length.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/URIError/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/NativeErrors/URIError/name.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/URIError/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/NativeErrors/URIError/proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/URIError/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/NativeErrors/URIError/prototype.js");
        }
    }
}
