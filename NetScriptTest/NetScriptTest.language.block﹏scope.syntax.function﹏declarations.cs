using Xunit;

namespace NetScriptTest.language.block﹏scope.syntax
{
    public sealed class Test_function﹏declarations : BaseTest
    {
        [Fact(DisplayName = "/language/block-scope/syntax/function-declarations/in-statement-position-case-expression-statement-list.js")]
        public void Test_in﹏statement﹏position﹏case﹏expression﹏statement﹏list_js()
        {
            RunTest("language/block-scope/syntax/function-declarations/in-statement-position-case-expression-statement-list.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/function-declarations/in-statement-position-default-statement-list.js")]
        public void Test_in﹏statement﹏position﹏default﹏statement﹏list_js()
        {
            RunTest("language/block-scope/syntax/function-declarations/in-statement-position-default-statement-list.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/function-declarations/in-statement-position-do-statement-while-expression.js")]
        public void Test_in﹏statement﹏position﹏do﹏statement﹏while﹏expression_js()
        {
            RunTest("language/block-scope/syntax/function-declarations/in-statement-position-do-statement-while-expression.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/function-declarations/in-statement-position-for-statement.js")]
        public void Test_in﹏statement﹏position﹏for﹏statement_js()
        {
            RunTest("language/block-scope/syntax/function-declarations/in-statement-position-for-statement.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/function-declarations/in-statement-position-if-expression-statement-else-statement.js")]
        public void Test_in﹏statement﹏position﹏if﹏expression﹏statement﹏else﹏statement_js()
        {
            RunTest("language/block-scope/syntax/function-declarations/in-statement-position-if-expression-statement-else-statement.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/function-declarations/in-statement-position-if-expression-statement.js")]
        public void Test_in﹏statement﹏position﹏if﹏expression﹏statement_js()
        {
            RunTest("language/block-scope/syntax/function-declarations/in-statement-position-if-expression-statement.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/function-declarations/in-statement-position-while-expression-statement.js")]
        public void Test_in﹏statement﹏position﹏while﹏expression﹏statement_js()
        {
            RunTest("language/block-scope/syntax/function-declarations/in-statement-position-while-expression-statement.js");
        }
    }
}
