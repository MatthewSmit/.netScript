using Xunit;

namespace NetScriptTest.built﹏ins.BigInt
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/BigInt/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/BigInt/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/BigInt/prototype/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/BigInt/prototype/proto.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/BigInt/prototype/Symbol.toStringTag.js");
        }
    }
}
