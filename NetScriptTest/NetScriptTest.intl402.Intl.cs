using Xunit;

namespace NetScriptTest.intl402
{
    public sealed class Test_Intl : BaseTest
    {
        [Fact(DisplayName = "/intl402/Intl/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Intl/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Intl/proto.js")]
        public void Test_proto_js()
        {
            RunTest("intl402/Intl/proto.js");
        }
    }
}
