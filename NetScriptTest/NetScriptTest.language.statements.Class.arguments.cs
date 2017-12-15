using Xunit;

namespace NetScriptTest.language.statements.Class
{
    public sealed class Test_arguments : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/arguments/access.js")]
        public void Test_access_js()
        {
            RunTest("language/statements/class/arguments/access.js");
        }

        [Fact(DisplayName = "/language/statements/class/arguments/default-constructor.js")]
        public void Test_default﹏constructor_js()
        {
            RunTest("language/statements/class/arguments/default-constructor.js");
        }
    }
}
