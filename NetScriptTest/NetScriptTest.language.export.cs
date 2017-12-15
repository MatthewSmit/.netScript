using Xunit;

namespace NetScriptTest.language
{
    public sealed class Test_export : BaseTest
    {
        [Fact(DisplayName = "/language/export/escaped-as-export-specifier.js")]
        public void Test_escaped﹏as﹏export﹏specifier_js()
        {
            RunTest("language/export/escaped-as-export-specifier.js");
        }

        [Fact(DisplayName = "/language/export/escaped-default.js")]
        public void Test_escaped﹏default_js()
        {
            RunTest("language/export/escaped-default.js");
        }

        [Fact(DisplayName = "/language/export/escaped-from.js")]
        public void Test_escaped﹏from_js()
        {
            RunTest("language/export/escaped-from.js");
        }
    }
}
