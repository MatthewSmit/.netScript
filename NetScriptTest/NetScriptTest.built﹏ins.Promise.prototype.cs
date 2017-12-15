using Xunit;

namespace NetScriptTest.built﹏ins.Promise
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Promise/prototype/no-promise-state.js")]
        public void Test_no﹏promise﹏state_js()
        {
            RunTest("built-ins/Promise/prototype/no-promise-state.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Promise/prototype/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/Promise/prototype/proto.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/S25.4.4.2_A1.1_T1.js")]
        public void Test_S25_4_4_2_A1_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/S25.4.4.2_A1.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/S25.4.5_A3.1_T1.js")]
        public void Test_S25_4_5_A3_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/S25.4.5_A3.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/Promise/prototype/Symbol.toStringTag.js");
        }
    }
}
