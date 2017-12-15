using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays
{
    public sealed class Test_Float32Array : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/Float32Array/BYTES_PER_ELEMENT.js")]
        public void Test_BYTES_PER_ELEMENT_js()
        {
            RunTest("built-ins/TypedArrays/Float32Array/BYTES_PER_ELEMENT.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Float32Array/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/TypedArrays/Float32Array/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Float32Array/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/TypedArrays/Float32Array/length.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Float32Array/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/TypedArrays/Float32Array/name.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Float32Array/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/TypedArrays/Float32Array/proto.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Float32Array/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/TypedArrays/Float32Array/prototype.js");
        }
    }
}
