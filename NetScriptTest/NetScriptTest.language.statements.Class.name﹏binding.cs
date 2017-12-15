using Xunit;

namespace NetScriptTest.language.statements.Class
{
    public sealed class Test_name﹏binding : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/name-binding/basic.js")]
        public void Test_basic_js()
        {
            RunTest("language/statements/class/name-binding/basic.js");
        }

        [Fact(DisplayName = "/language/statements/class/name-binding/const.js")]
        public void Test_const_js()
        {
            RunTest("language/statements/class/name-binding/const.js");
        }

        [Fact(DisplayName = "/language/statements/class/name-binding/expression.js")]
        public void Test_expression_js()
        {
            RunTest("language/statements/class/name-binding/expression.js");
        }

        [Fact(DisplayName = "/language/statements/class/name-binding/in-extends-expression-assigned.js")]
        public void Test_in﹏extends﹏expression﹏assigned_js()
        {
            RunTest("language/statements/class/name-binding/in-extends-expression-assigned.js");
        }

        [Fact(DisplayName = "/language/statements/class/name-binding/in-extends-expression-grouped.js")]
        public void Test_in﹏extends﹏expression﹏grouped_js()
        {
            RunTest("language/statements/class/name-binding/in-extends-expression-grouped.js");
        }

        [Fact(DisplayName = "/language/statements/class/name-binding/in-extends-expression.js")]
        public void Test_in﹏extends﹏expression_js()
        {
            RunTest("language/statements/class/name-binding/in-extends-expression.js");
        }
    }
}
