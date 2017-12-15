using Xunit;

namespace NetScriptTest.built﹏ins.NativeErrors
{
    public sealed class Test_EvalError : BaseTest
    {
        [Fact(DisplayName = "/built-ins/NativeErrors/EvalError/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/NativeErrors/EvalError/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/EvalError/instance-proto.js")]
        public void Test_instance﹏proto_js()
        {
            RunTest("built-ins/NativeErrors/EvalError/instance-proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/EvalError/is-error-object.js")]
        public void Test_is﹏error﹏object_js()
        {
            RunTest("built-ins/NativeErrors/EvalError/is-error-object.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/EvalError/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/NativeErrors/EvalError/length.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/EvalError/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/NativeErrors/EvalError/name.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/EvalError/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/NativeErrors/EvalError/proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/EvalError/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/NativeErrors/EvalError/prototype.js");
        }
    }
}
