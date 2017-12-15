using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_typeof : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/typeof/bigint.js")]
        public void Test_bigint_js()
        {
            RunTest("language/expressions/typeof/bigint.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/boolean.js")]
        public void Test_boolean_js()
        {
            RunTest("language/expressions/typeof/boolean.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/built-in-exotic-objects-no-call.js")]
        public void Test_built﹏in﹏exotic﹏objects﹏no﹏call_js()
        {
            RunTest("language/expressions/typeof/built-in-exotic-objects-no-call.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/built-in-functions.js")]
        public void Test_built﹏in﹏functions_js()
        {
            RunTest("language/expressions/typeof/built-in-functions.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/built-in-ordinary-objects-no-call.js")]
        public void Test_built﹏in﹏ordinary﹏objects﹏no﹏call_js()
        {
            RunTest("language/expressions/typeof/built-in-ordinary-objects-no-call.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/get-value-ref-err.js")]
        public void Test_get﹏value﹏ref﹏err_js()
        {
            RunTest("language/expressions/typeof/get-value-ref-err.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/get-value.js")]
        public void Test_get﹏value_js()
        {
            RunTest("language/expressions/typeof/get-value.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/native-call.js")]
        public void Test_native﹏call_js()
        {
            RunTest("language/expressions/typeof/native-call.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/null.js")]
        public void Test_null_js()
        {
            RunTest("language/expressions/typeof/null.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/number.js")]
        public void Test_number_js()
        {
            RunTest("language/expressions/typeof/number.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/string.js")]
        public void Test_string_js()
        {
            RunTest("language/expressions/typeof/string.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/symbol.js")]
        public void Test_symbol_js()
        {
            RunTest("language/expressions/typeof/symbol.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/syntax.js")]
        public void Test_syntax_js()
        {
            RunTest("language/expressions/typeof/syntax.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/undefined.js")]
        public void Test_undefined_js()
        {
            RunTest("language/expressions/typeof/undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/typeof/unresolvable-reference.js")]
        public void Test_unresolvable﹏reference_js()
        {
            RunTest("language/expressions/typeof/unresolvable-reference.js");
        }
    }
}
