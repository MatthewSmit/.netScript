using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays.Uint8ClampedArray
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/Uint8ClampedArray/prototype/BYTES_PER_ELEMENT.js")]
        public void Test_BYTES_PER_ELEMENT_js()
        {
            RunTest("built-ins/TypedArrays/Uint8ClampedArray/prototype/BYTES_PER_ELEMENT.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Uint8ClampedArray/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/TypedArrays/Uint8ClampedArray/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Uint8ClampedArray/prototype/not-typedarray-object.js")]
        public void Test_not﹏typedarray﹏object_js()
        {
            RunTest("built-ins/TypedArrays/Uint8ClampedArray/prototype/not-typedarray-object.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/Uint8ClampedArray/prototype/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/TypedArrays/Uint8ClampedArray/prototype/proto.js");
        }
    }
}
