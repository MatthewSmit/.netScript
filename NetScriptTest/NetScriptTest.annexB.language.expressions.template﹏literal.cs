using Xunit;

namespace NetScriptTest.annexB.language.expressions
{
    public sealed class Test_template﹏literal : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/expressions/template-literal/legacy-octal-escape-sequence-non-strict.js")]
        public void Test_legacy﹏octal﹏escape﹏sequence﹏non﹏strict_js()
        {
            RunTest("annexB/language/expressions/template-literal/legacy-octal-escape-sequence-non-strict.js");
        }

        [Fact(DisplayName = "/annexB/language/expressions/template-literal/legacy-octal-escape-sequence-strict.js")]
        public void Test_legacy﹏octal﹏escape﹏sequence﹏strict_js()
        {
            RunTest("annexB/language/expressions/template-literal/legacy-octal-escape-sequence-strict.js");
        }
    }
}
