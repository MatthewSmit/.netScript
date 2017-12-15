using Xunit;

namespace NetScriptTest.built﹏ins.Object.internals
{
    public sealed class Test_DefineOwnProperty : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Object/internals/DefineOwnProperty/consistent-value-function-arguments.js")]
        public void Test_consistent﹏value﹏function﹏arguments_js()
        {
            RunTest("built-ins/Object/internals/DefineOwnProperty/consistent-value-function-arguments.js");
        }

        [Fact(DisplayName = "/built-ins/Object/internals/DefineOwnProperty/consistent-value-function-caller.js")]
        public void Test_consistent﹏value﹏function﹏caller_js()
        {
            RunTest("built-ins/Object/internals/DefineOwnProperty/consistent-value-function-caller.js");
        }

        [Fact(DisplayName = "/built-ins/Object/internals/DefineOwnProperty/consistent-value-regexp-$1.js")]
        public void Test_consistent﹏value﹏regexp﹏1_js()
        {
            RunTest("built-ins/Object/internals/DefineOwnProperty/consistent-value-regexp-$1.js");
        }

        [Fact(DisplayName = "/built-ins/Object/internals/DefineOwnProperty/consistent-writable-regexp-$1.js")]
        public void Test_consistent﹏writable﹏regexp﹏1_js()
        {
            RunTest("built-ins/Object/internals/DefineOwnProperty/consistent-writable-regexp-$1.js");
        }

        [Fact(DisplayName = "/built-ins/Object/internals/DefineOwnProperty/nan-equivalence.js")]
        public void Test_nan﹏equivalence_js()
        {
            RunTest("built-ins/Object/internals/DefineOwnProperty/nan-equivalence.js");
        }
    }
}
