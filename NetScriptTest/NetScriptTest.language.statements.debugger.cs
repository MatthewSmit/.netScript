using Xunit;

namespace NetScriptTest.language.statements
{
    public sealed class Test_debugger : BaseTest
    {
        [Fact(DisplayName = "/language/statements/debugger/expression.js")]
        public void Test_expression_js()
        {
            RunTest("language/statements/debugger/expression.js");
        }

        [Fact(DisplayName = "/language/statements/debugger/statement.js")]
        public void Test_statement_js()
        {
            RunTest("language/statements/debugger/statement.js");
        }
    }
}
