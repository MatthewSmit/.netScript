using Xunit;

namespace NetScriptTest.language.block﹏scope.syntax
{
    public sealed class Test_redeclaration﹏global : BaseTest
    {
        [Fact(DisplayName = "/language/block-scope/syntax/redeclaration-global/allowed-to-declare-function-with-function-declaration.js")]
        public void Test_allowed﹏to﹏declare﹏function﹏with﹏function﹏declaration_js()
        {
            RunTest("language/block-scope/syntax/redeclaration-global/allowed-to-declare-function-with-function-declaration.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/redeclaration-global/allowed-to-redeclare-function-declaration-with-var.js")]
        public void Test_allowed﹏to﹏redeclare﹏function﹏declaration﹏with﹏var_js()
        {
            RunTest("language/block-scope/syntax/redeclaration-global/allowed-to-redeclare-function-declaration-with-var.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/redeclaration-global/allowed-to-redeclare-var-with-function-declaration.js")]
        public void Test_allowed﹏to﹏redeclare﹏var﹏with﹏function﹏declaration_js()
        {
            RunTest("language/block-scope/syntax/redeclaration-global/allowed-to-redeclare-var-with-function-declaration.js");
        }
    }
}
