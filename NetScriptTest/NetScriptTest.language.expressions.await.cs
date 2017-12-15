using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_await : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/await/await-awaits-thenable-not-callable.js")]
        public void Test_await﹏awaits﹏thenable﹏not﹏callable_js()
        {
            RunTest("language/expressions/await/await-awaits-thenable-not-callable.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-awaits-thenables-that-throw.js")]
        public void Test_await﹏awaits﹏thenables﹏that﹏throw_js()
        {
            RunTest("language/expressions/await/await-awaits-thenables-that-throw.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-awaits-thenables.js")]
        public void Test_await﹏awaits﹏thenables_js()
        {
            RunTest("language/expressions/await/await-awaits-thenables.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-BindingIdentifier-in-global.js")]
        public void Test_await﹏BindingIdentifier﹏in﹏global_js()
        {
            RunTest("language/expressions/await/await-BindingIdentifier-in-global.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-BindingIdentifier-nested.js")]
        public void Test_await﹏BindingIdentifier﹏nested_js()
        {
            RunTest("language/expressions/await/await-BindingIdentifier-nested.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-in-function.js")]
        public void Test_await﹏in﹏function_js()
        {
            RunTest("language/expressions/await/await-in-function.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-in-generator.js")]
        public void Test_await﹏in﹏generator_js()
        {
            RunTest("language/expressions/await/await-in-generator.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-in-global.js")]
        public void Test_await﹏in﹏global_js()
        {
            RunTest("language/expressions/await/await-in-global.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-in-nested-function.js")]
        public void Test_await﹏in﹏nested﹏function_js()
        {
            RunTest("language/expressions/await/await-in-nested-function.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-in-nested-generator.js")]
        public void Test_await﹏in﹏nested﹏generator_js()
        {
            RunTest("language/expressions/await/await-in-nested-generator.js");
        }

        [Fact(DisplayName = "/language/expressions/await/await-throws-rejections.js")]
        public void Test_await﹏throws﹏rejections_js()
        {
            RunTest("language/expressions/await/await-throws-rejections.js");
        }

        [Fact(DisplayName = "/language/expressions/await/early-errors-await-not-simple-assignment-target.js")]
        public void Test_early﹏errors﹏await﹏not﹏simple﹏assignment﹏target_js()
        {
            RunTest("language/expressions/await/early-errors-await-not-simple-assignment-target.js");
        }

        [Fact(DisplayName = "/language/expressions/await/no-operand.js")]
        public void Test_no﹏operand_js()
        {
            RunTest("language/expressions/await/no-operand.js");
        }

        [Fact(DisplayName = "/language/expressions/await/syntax-await-has-UnaryExpression-with-MultiplicativeExpression.js")]
        public void Test_syntax﹏await﹏has﹏UnaryExpression﹏with﹏MultiplicativeExpression_js()
        {
            RunTest("language/expressions/await/syntax-await-has-UnaryExpression-with-MultiplicativeExpression.js");
        }

        [Fact(DisplayName = "/language/expressions/await/syntax-await-has-UnaryExpression.js")]
        public void Test_syntax﹏await﹏has﹏UnaryExpression_js()
        {
            RunTest("language/expressions/await/syntax-await-has-UnaryExpression.js");
        }
    }
}
