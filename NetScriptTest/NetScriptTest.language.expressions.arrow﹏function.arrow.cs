using Xunit;

namespace NetScriptTest.language.expressions.arrow﹏function
{
    public sealed class Test_arrow : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/arrow-function/arrow/binding-tests-1.js")]
        public void Test_binding﹏tests﹏1_js()
        {
            RunTest("language/expressions/arrow-function/arrow/binding-tests-1.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/arrow/binding-tests-2.js")]
        public void Test_binding﹏tests﹏2_js()
        {
            RunTest("language/expressions/arrow-function/arrow/binding-tests-2.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/arrow/binding-tests-3.js")]
        public void Test_binding﹏tests﹏3_js()
        {
            RunTest("language/expressions/arrow-function/arrow/binding-tests-3.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/arrow/capturing-closure-variables-1.js")]
        public void Test_capturing﹏closure﹏variables﹏1_js()
        {
            RunTest("language/expressions/arrow-function/arrow/capturing-closure-variables-1.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/arrow/capturing-closure-variables-2.js")]
        public void Test_capturing﹏closure﹏variables﹏2_js()
        {
            RunTest("language/expressions/arrow-function/arrow/capturing-closure-variables-2.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/arrow/concisebody-lookahead-assignmentexpression-1.js")]
        public void Test_concisebody﹏lookahead﹏assignmentexpression﹏1_js()
        {
            RunTest("language/expressions/arrow-function/arrow/concisebody-lookahead-assignmentexpression-1.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/arrow/concisebody-lookahead-assignmentexpression-2.js")]
        public void Test_concisebody﹏lookahead﹏assignmentexpression﹏2_js()
        {
            RunTest("language/expressions/arrow-function/arrow/concisebody-lookahead-assignmentexpression-2.js");
        }
    }
}
