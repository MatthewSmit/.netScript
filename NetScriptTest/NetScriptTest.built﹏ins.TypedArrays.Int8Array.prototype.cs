using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays.Int8Array
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/Int8Array/prototype/BYTES_PER_ELEMENT.js")]
        public void Test_BYTES_PER_ELEMENT_js()
        {
            RunTest("built-ins/TypedArrays/Int8Array/prototype/BYTES_PER_ELEMENT.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int8Array/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/TypedArrays/Int8Array/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int8Array/prototype/not-typedarray-object.js")]
        public void Test_not﹏typedarray﹏object_js()
        {
            RunTest("built-ins/TypedArrays/Int8Array/prototype/not-typedarray-object.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Int8Array/prototype/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/TypedArrays/Int8Array/prototype/proto.js");
        }
    }
}
