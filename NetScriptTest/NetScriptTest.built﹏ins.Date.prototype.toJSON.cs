using Xunit;

namespace NetScriptTest.built﹏ins.Date.prototype
{
    public sealed class Test_toJSON : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Date/prototype/toJSON/15.9.5.44-0-1.js")]
        public void Test_15_9_5_44﹏0﹏1_js()
        {
            RunTest("built-ins/Date/prototype/toJSON/15.9.5.44-0-1.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/toJSON/15.9.5.44-0-2.js")]
        public void Test_15_9_5_44﹏0﹏2_js()
        {
            RunTest("built-ins/Date/prototype/toJSON/15.9.5.44-0-2.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/toJSON/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Date/prototype/toJSON/name.js");
        }
    }
}
