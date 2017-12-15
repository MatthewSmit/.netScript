using Xunit;

namespace NetScriptTest.annexB.language.expressions
{
    public sealed class Test_yield : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/expressions/yield/star-iterable-return-emulates-undefined-throws-when-called.js")]
        public void Test_star﹏iterable﹏return﹏emulates﹏undefined﹏throws﹏when﹏called_js()
        {
            RunTest("annexB/language/expressions/yield/star-iterable-return-emulates-undefined-throws-when-called.js");
        }
    }
}
