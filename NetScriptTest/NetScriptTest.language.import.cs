using Xunit;

namespace NetScriptTest.language
{
    public sealed class Test_import : BaseTest
    {
        [Fact(DisplayName = "/language/import/dup-bound-names.js")]
        public void Test_dup﹏bound﹏names_js()
        {
            RunTest("language/import/dup-bound-names.js");
        }

        [Fact(DisplayName = "/language/import/escaped-as-import-specifier.js")]
        public void Test_escaped﹏as﹏import﹏specifier_js()
        {
            RunTest("language/import/escaped-as-import-specifier.js");
        }

        [Fact(DisplayName = "/language/import/escaped-as-namespace-import.js")]
        public void Test_escaped﹏as﹏namespace﹏import_js()
        {
            RunTest("language/import/escaped-as-namespace-import.js");
        }

        [Fact(DisplayName = "/language/import/escaped-from.js")]
        public void Test_escaped﹏from_js()
        {
            RunTest("language/import/escaped-from.js");
        }
    }
}
