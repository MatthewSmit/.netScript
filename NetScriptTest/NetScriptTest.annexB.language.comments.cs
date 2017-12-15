using Xunit;

namespace NetScriptTest.annexB.language
{
    public sealed class Test_comments : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/comments/multi-line-html-close.js")]
        public void Test_multi﹏line﹏html﹏close_js()
        {
            RunTest("annexB/language/comments/multi-line-html-close.js");
        }

        [Fact(DisplayName = "/annexB/language/comments/single-line-html-close-asi.js")]
        public void Test_single﹏line﹏html﹏close﹏asi_js()
        {
            RunTest("annexB/language/comments/single-line-html-close-asi.js");
        }

        [Fact(DisplayName = "/annexB/language/comments/single-line-html-close.js")]
        public void Test_single﹏line﹏html﹏close_js()
        {
            RunTest("annexB/language/comments/single-line-html-close.js");
        }

        [Fact(DisplayName = "/annexB/language/comments/single-line-html-open.js")]
        public void Test_single﹏line﹏html﹏open_js()
        {
            RunTest("annexB/language/comments/single-line-html-open.js");
        }
    }
}
