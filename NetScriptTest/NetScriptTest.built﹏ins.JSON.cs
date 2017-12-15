using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_JSON : BaseTest
    {
        [Fact(DisplayName = "/built-ins/JSON/15.12-0-1.js")]
        public void Test_15_12﹏0﹏1_js()
        {
            RunTest("built-ins/JSON/15.12-0-1.js");
        }

        [Fact(DisplayName = "/built-ins/JSON/15.12-0-2.js")]
        public void Test_15_12﹏0﹏2_js()
        {
            RunTest("built-ins/JSON/15.12-0-2.js");
        }

        [Fact(DisplayName = "/built-ins/JSON/15.12-0-3.js")]
        public void Test_15_12﹏0﹏3_js()
        {
            RunTest("built-ins/JSON/15.12-0-3.js");
        }

        [Fact(DisplayName = "/built-ins/JSON/15.12-0-4.js")]
        public void Test_15_12﹏0﹏4_js()
        {
            RunTest("built-ins/JSON/15.12-0-4.js");
        }

        [Fact(DisplayName = "/built-ins/JSON/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/JSON/Symbol.toStringTag.js");
        }
    }
}
