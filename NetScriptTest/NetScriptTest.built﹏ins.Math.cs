using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_Math : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Math/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Math/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Math/proto.js")]
        public void Test_proto_js()
        {
            RunTest("built-ins/Math/proto.js");
        }

        [Fact(DisplayName = "/built-ins/Math/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/Math/Symbol.toStringTag.js");
        }
    }
}
