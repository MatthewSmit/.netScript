using Xunit;

namespace NetScriptTest.annexB.language.statements
{
    public sealed class Test_for﹏await﹏of : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/statements/for-await-of/iterator-close-return-emulates-undefined-throws-when-called.js")]
        public void Test_iterator﹏close﹏return﹏emulates﹏undefined﹏throws﹏when﹏called_js()
        {
            RunTest("annexB/language/statements/for-await-of/iterator-close-return-emulates-undefined-throws-when-called.js");
        }
    }
}
