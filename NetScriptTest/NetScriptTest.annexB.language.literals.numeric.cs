using Xunit;

namespace NetScriptTest.annexB.language.literals
{
    public sealed class Test_numeric : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/literals/numeric/legacy-octal-integer.js")]
        public void Test_legacy﹏octal﹏integer_js()
        {
            RunTest("annexB/language/literals/numeric/legacy-octal-integer.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/numeric/non-octal-decimal-integer.js")]
        public void Test_non﹏octal﹏decimal﹏integer_js()
        {
            RunTest("annexB/language/literals/numeric/non-octal-decimal-integer.js");
        }
    }
}
