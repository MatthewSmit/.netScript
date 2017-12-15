using Xunit;

namespace NetScriptTest.annexB.language.literals
{
    public sealed class Test_string : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/literals/string/legacy-octal-escape-sequence.js")]
        public void Test_legacy﹏octal﹏escape﹏sequence_js()
        {
            RunTest("annexB/language/literals/string/legacy-octal-escape-sequence.js");
        }
    }
}
