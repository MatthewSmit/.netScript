using Xunit;

namespace NetScriptTest.built﹏ins.NativeErrors
{
    public sealed class Test_SyntaxError : BaseTest
    {
        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/instance-proto.js")]
        public void Test_instance﹏proto_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/instance-proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/is-error-object.js")]
        public void Test_is﹏error﹏object_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/is-error-object.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/length.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/name.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/prototype.js");
        }
    }
}
