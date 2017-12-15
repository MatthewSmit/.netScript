using Xunit;

namespace NetScriptTest.built﹏ins.NativeErrors
{
    public sealed class Test_TypeError : BaseTest
    {
        [Fact(DisplayName = "/built-ins/NativeErrors/TypeError/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/NativeErrors/TypeError/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/TypeError/instance-proto.js")]
        public void Test_instance﹏proto_js()
        {
            RunTest("built-ins/NativeErrors/TypeError/instance-proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/TypeError/is-error-object.js")]
        public void Test_is﹏error﹏object_js()
        {
            RunTest("built-ins/NativeErrors/TypeError/is-error-object.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/TypeError/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/NativeErrors/TypeError/length.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/TypeError/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/NativeErrors/TypeError/name.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/TypeError/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/NativeErrors/TypeError/proto.js");
        }

        [Fact(DisplayName = "/built-ins/NativeErrors/TypeError/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/NativeErrors/TypeError/prototype.js");
        }
    }
}
