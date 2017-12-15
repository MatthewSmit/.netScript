using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_Atomics : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Atomics/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/Atomics/proto.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/Atomics/Symbol.toStringTag.js");
        }
    }
}
