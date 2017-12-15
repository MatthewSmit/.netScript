using Xunit;

namespace NetScriptTest.built﹏ins.Array
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Array/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/Array/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/exotic-array.js")]
        public void Test_exotic﹏array_js()
        {
            RunTest("built-ins/Array/prototype/exotic-array.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Array/prototype/length.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Array/prototype/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/Array/prototype/proto.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/Symbol.iterator.js")]
        public void Test_Symbol_iterator_js()
        {
            RunTest("built-ins/Array/prototype/Symbol.iterator.js");
        }
    }
}
