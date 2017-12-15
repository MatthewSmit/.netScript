using Xunit;

namespace NetScriptTest.language.block﹏scope
{
    public sealed class Test_return﹏from : BaseTest
    {
        [Fact(DisplayName = "/language/block-scope/return-from/block-const.js")]
        public void Test_block﹏const_js()
        {
            RunTest("language/block-scope/return-from/block-const.js");
        }

        [Fact(DisplayName = "/language/block-scope/return-from/block-let.js")]
        public void Test_block﹏let_js()
        {
            RunTest("language/block-scope/return-from/block-let.js");
        }
    }
}
