using Xunit;

namespace NetScriptTest.language.statements.let
{
    public sealed class Test_syntax : BaseTest
    {
        [Fact(DisplayName = "/language/statements/let/syntax/attempt-to-redeclare-let-binding-with-function-declaration.js")]
        public void Test_attempt﹏to﹏redeclare﹏let﹏binding﹏with﹏function﹏declaration_js()
        {
            RunTest("language/statements/let/syntax/attempt-to-redeclare-let-binding-with-function-declaration.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/attempt-to-redeclare-let-binding-with-var.js")]
        public void Test_attempt﹏to﹏redeclare﹏let﹏binding﹏with﹏var_js()
        {
            RunTest("language/statements/let/syntax/attempt-to-redeclare-let-binding-with-var.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/escaped-let.js")]
        public void Test_escaped﹏let_js()
        {
            RunTest("language/statements/let/syntax/escaped-let.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/identifier-let-allowed-as-lefthandside-expression-strict.js")]
        public void Test_identifier﹏let﹏allowed﹏as﹏lefthandside﹏expression﹏strict_js()
        {
            RunTest("language/statements/let/syntax/identifier-let-allowed-as-lefthandside-expression-strict.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/identifier-let-disallowed-as-boundname.js")]
        public void Test_identifier﹏let﹏disallowed﹏as﹏boundname_js()
        {
            RunTest("language/statements/let/syntax/identifier-let-disallowed-as-boundname.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-closure-inside-condition.js")]
        public void Test_let﹏closure﹏inside﹏condition_js()
        {
            RunTest("language/statements/let/syntax/let-closure-inside-condition.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-closure-inside-initialization.js")]
        public void Test_let﹏closure﹏inside﹏initialization_js()
        {
            RunTest("language/statements/let/syntax/let-closure-inside-initialization.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-closure-inside-next-expression.js")]
        public void Test_let﹏closure﹏inside﹏next﹏expression_js()
        {
            RunTest("language/statements/let/syntax/let-closure-inside-next-expression.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-iteration-variable-is-freshly-allocated-for-each-iteration-multi-let-binding.js")]
        public void Test_let﹏iteration﹏variable﹏is﹏freshly﹏allocated﹏for﹏each﹏iteration﹏multi﹏let﹏binding_js()
        {
            RunTest("language/statements/let/syntax/let-iteration-variable-is-freshly-allocated-for-each-iteration-multi-let-binding.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-iteration-variable-is-freshly-allocated-for-each-iteration-single-let-binding.js")]
        public void Test_let﹏iteration﹏variable﹏is﹏freshly﹏allocated﹏for﹏each﹏iteration﹏single﹏let﹏binding_js()
        {
            RunTest("language/statements/let/syntax/let-iteration-variable-is-freshly-allocated-for-each-iteration-single-let-binding.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-let-declaration-split-across-two-lines.js")]
        public void Test_let﹏let﹏declaration﹏split﹏across﹏two﹏lines_js()
        {
            RunTest("language/statements/let/syntax/let-let-declaration-split-across-two-lines.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-let-declaration-with-initializer-split-across-two-lines.js")]
        public void Test_let﹏let﹏declaration﹏with﹏initializer﹏split﹏across﹏two﹏lines_js()
        {
            RunTest("language/statements/let/syntax/let-let-declaration-with-initializer-split-across-two-lines.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-newline-await-in-normal-function.js")]
        public void Test_let﹏newline﹏await﹏in﹏normal﹏function_js()
        {
            RunTest("language/statements/let/syntax/let-newline-await-in-normal-function.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-newline-yield-in-generator-function.js")]
        public void Test_let﹏newline﹏yield﹏in﹏generator﹏function_js()
        {
            RunTest("language/statements/let/syntax/let-newline-yield-in-generator-function.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-newline-yield-in-normal-function.js")]
        public void Test_let﹏newline﹏yield﹏in﹏normal﹏function_js()
        {
            RunTest("language/statements/let/syntax/let-newline-yield-in-normal-function.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let-outer-inner-let-bindings.js")]
        public void Test_let﹏outer﹏inner﹏let﹏bindings_js()
        {
            RunTest("language/statements/let/syntax/let-outer-inner-let-bindings.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/let.js")]
        public void Test_let_js()
        {
            RunTest("language/statements/let/syntax/let.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-case-expression-statement-list.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏case﹏expression﹏statement﹏list_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-case-expression-statement-list.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-default-statement-list.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏default﹏statement﹏list_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-default-statement-list.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-do-statement-while-expression.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏do﹏statement﹏while﹏expression_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-do-statement-while-expression.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-for-statement.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏for﹏statement_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-for-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-if-expression-statement-else-statement.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏if﹏expression﹏statement﹏else﹏statement_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-if-expression-statement-else-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-if-expression-statement.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏if﹏expression﹏statement_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-if-expression-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-label-statement.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏label﹏statement_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-label-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/with-initialisers-in-statement-positions-while-expression-statement.js")]
        public void Test_with﹏initialisers﹏in﹏statement﹏positions﹏while﹏expression﹏statement_js()
        {
            RunTest("language/statements/let/syntax/with-initialisers-in-statement-positions-while-expression-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-case-expression-statement-list.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏case﹏expression﹏statement﹏list_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-case-expression-statement-list.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-default-statement-list.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏default﹏statement﹏list_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-default-statement-list.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-do-statement-while-expression.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏do﹏statement﹏while﹏expression_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-do-statement-while-expression.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-for-statement.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏for﹏statement_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-for-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-if-expression-statement-else-statement.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏if﹏expression﹏statement﹏else﹏statement_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-if-expression-statement-else-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-if-expression-statement.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏if﹏expression﹏statement_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-if-expression-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-label-statement.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏label﹏statement_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-label-statement.js");
        }

        [Fact(DisplayName = "/language/statements/let/syntax/without-initialisers-in-statement-positions-while-expression-statement.js")]
        public void Test_without﹏initialisers﹏in﹏statement﹏positions﹏while﹏expression﹏statement_js()
        {
            RunTest("language/statements/let/syntax/without-initialisers-in-statement-positions-while-expression-statement.js");
        }
    }
}
