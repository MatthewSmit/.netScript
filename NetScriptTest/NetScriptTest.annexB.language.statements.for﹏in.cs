using Xunit;

namespace NetScriptTest.annexB.language.statements
{
    public sealed class Test_for﹏in : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/statements/for-in/bare-initializer.js")]
        public void Test_bare﹏initializer_js()
        {
            RunTest("annexB/language/statements/for-in/bare-initializer.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/for-in/const-initializer.js")]
        public void Test_const﹏initializer_js()
        {
            RunTest("annexB/language/statements/for-in/const-initializer.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/for-in/let-initializer.js")]
        public void Test_let﹏initializer_js()
        {
            RunTest("annexB/language/statements/for-in/let-initializer.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/for-in/nonstrict-initializer.js")]
        public void Test_nonstrict﹏initializer_js()
        {
            RunTest("annexB/language/statements/for-in/nonstrict-initializer.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/for-in/strict-initializer.js")]
        public void Test_strict﹏initializer_js()
        {
            RunTest("annexB/language/statements/for-in/strict-initializer.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/for-in/var-arraybindingpattern-initializer.js")]
        public void Test_var﹏arraybindingpattern﹏initializer_js()
        {
            RunTest("annexB/language/statements/for-in/var-arraybindingpattern-initializer.js");
        }

        [Fact(DisplayName = "/annexB/language/statements/for-in/var-objectbindingpattern-initializer.js")]
        public void Test_var﹏objectbindingpattern﹏initializer_js()
        {
            RunTest("annexB/language/statements/for-in/var-objectbindingpattern-initializer.js");
        }
    }
}
