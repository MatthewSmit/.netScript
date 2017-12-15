using Xunit;

namespace NetScriptTest.built﹏ins.NativeErrors.SyntaxError
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/prototype/message.js")]
        public void Test_message_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/prototype/message.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/prototype/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/prototype/name.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/prototype/not-error-object.js")]
        public void Test_not﹏error﹏object_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/prototype/not-error-object.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/SyntaxError/prototype/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/NativeErrors/SyntaxError/prototype/proto.js");
        }
    }
}
