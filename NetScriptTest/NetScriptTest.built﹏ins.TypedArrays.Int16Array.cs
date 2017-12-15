using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays
{
    public sealed class Test_Int16Array : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/Int16Array/BYTES_PER_ELEMENT.js")]
        public void Test_BYTES_PER_ELEMENT_js()
        {
            RunTest("built-ins/TypedArrays/Int16Array/BYTES_PER_ELEMENT.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int16Array/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/TypedArrays/Int16Array/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int16Array/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArrays/Int16Array/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int16Array/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArrays/Int16Array/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int16Array/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/TypedArrays/Int16Array/proto.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int16Array/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/TypedArrays/Int16Array/prototype.js");
        }
    }
}
