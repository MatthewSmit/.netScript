using Xunit;

namespace NetScriptTest.language.block﹏scope
{
    public sealed class Test_shadowing : BaseTest
    {
        [Fact(DisplayName = "/language/block-scope/shadowing/catch-parameter-shadowing-catch-parameter.js")]
        public void Test_catch﹏parameter﹏shadowing﹏catch﹏parameter_js()
        {
            RunTest("language/block-scope/shadowing/catch-parameter-shadowing-catch-parameter.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/catch-parameter-shadowing-function-parameter-name.js")]
        public void Test_catch﹏parameter﹏shadowing﹏function﹏parameter﹏name_js()
        {
            RunTest("language/block-scope/shadowing/catch-parameter-shadowing-function-parameter-name.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/catch-parameter-shadowing-let-declaration.js")]
        public void Test_catch﹏parameter﹏shadowing﹏let﹏declaration_js()
        {
            RunTest("language/block-scope/shadowing/catch-parameter-shadowing-let-declaration.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/catch-parameter-shadowing-var-variable.js")]
        public void Test_catch﹏parameter﹏shadowing﹏var﹏variable_js()
        {
            RunTest("language/block-scope/shadowing/catch-parameter-shadowing-var-variable.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/const-declaration-shadowing-catch-parameter.js")]
        public void Test_const﹏declaration﹏shadowing﹏catch﹏parameter_js()
        {
            RunTest("language/block-scope/shadowing/const-declaration-shadowing-catch-parameter.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/const-declarations-shadowing-parameter-name-let-const-and-var-variables.js")]
        public void Test_const﹏declarations﹏shadowing﹏parameter﹏name﹏let﹏const﹏and﹏var﹏variables_js()
        {
            RunTest("language/block-scope/shadowing/const-declarations-shadowing-parameter-name-let-const-and-var-variables.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/dynamic-lookup-from-closure.js")]
        public void Test_dynamic﹏lookup﹏from﹏closure_js()
        {
            RunTest("language/block-scope/shadowing/dynamic-lookup-from-closure.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/dynamic-lookup-in-and-through-block-contexts.js")]
        public void Test_dynamic﹏lookup﹏in﹏and﹏through﹏block﹏contexts_js()
        {
            RunTest("language/block-scope/shadowing/dynamic-lookup-in-and-through-block-contexts.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/hoisting-var-declarations-out-of-blocks.js")]
        public void Test_hoisting﹏var﹏declarations﹏out﹏of﹏blocks_js()
        {
            RunTest("language/block-scope/shadowing/hoisting-var-declarations-out-of-blocks.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/let-declaration-shadowing-catch-parameter.js")]
        public void Test_let﹏declaration﹏shadowing﹏catch﹏parameter_js()
        {
            RunTest("language/block-scope/shadowing/let-declaration-shadowing-catch-parameter.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/let-declarations-shadowing-parameter-name-let-const-and-var.js")]
        public void Test_let﹏declarations﹏shadowing﹏parameter﹏name﹏let﹏const﹏and﹏var_js()
        {
            RunTest("language/block-scope/shadowing/let-declarations-shadowing-parameter-name-let-const-and-var.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/lookup-from-closure.js")]
        public void Test_lookup﹏from﹏closure_js()
        {
            RunTest("language/block-scope/shadowing/lookup-from-closure.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/lookup-in-and-through-block-contexts.js")]
        public void Test_lookup﹏in﹏and﹏through﹏block﹏contexts_js()
        {
            RunTest("language/block-scope/shadowing/lookup-in-and-through-block-contexts.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/parameter-name-shadowing-catch-parameter.js")]
        public void Test_parameter﹏name﹏shadowing﹏catch﹏parameter_js()
        {
            RunTest("language/block-scope/shadowing/parameter-name-shadowing-catch-parameter.js");
        }

        [Fact(DisplayName = "/language/block-scope/shadowing/parameter-name-shadowing-parameter-name-let-const-and-var.js")]
        public void Test_parameter﹏name﹏shadowing﹏parameter﹏name﹏let﹏const﹏and﹏var_js()
        {
            RunTest("language/block-scope/shadowing/parameter-name-shadowing-parameter-name-let-const-and-var.js");
        }
    }
}
