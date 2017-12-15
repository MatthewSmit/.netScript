using Xunit;

namespace NetScriptTest.annexB.language.statements
{
    public sealed class Test_try : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/statements/try/catch-redeclared-for-in-var.js")]
        public void Test_catch﹏redeclared﹏for﹏in﹏var_js()
        {
            RunTest("annexB/language/statements/try/catch-redeclared-for-in-var.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/try/catch-redeclared-for-var.js")]
        public void Test_catch﹏redeclared﹏for﹏var_js()
        {
            RunTest("annexB/language/statements/try/catch-redeclared-for-var.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/try/catch-redeclared-var-statement-captured.js")]
        public void Test_catch﹏redeclared﹏var﹏statement﹏captured_js()
        {
            RunTest("annexB/language/statements/try/catch-redeclared-var-statement-captured.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/try/catch-redeclared-var-statement.js")]
        public void Test_catch﹏redeclared﹏var﹏statement_js()
        {
            RunTest("annexB/language/statements/try/catch-redeclared-var-statement.js");
        }
    }
}
