using Xunit;

namespace NetScriptTest.language.statements.Class
{
    public sealed class Test_strict﹏mode : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/strict-mode/arguments-callee.js")]
        public void Test_arguments﹏callee_js()
        {
            RunTest("language/statements/class/strict-mode/arguments-callee.js");
        }

        [Fact(DisplayName = "/language/statements/class/strict-mode/with.js")]
        public void Test_with_js()
        {
            RunTest("language/statements/class/strict-mode/with.js");
        }
    }
}
