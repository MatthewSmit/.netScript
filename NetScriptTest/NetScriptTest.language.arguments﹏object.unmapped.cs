using Xunit;

namespace NetScriptTest.language.arguments﹏object
{
    public sealed class Test_unmapped : BaseTest
    {
        [Fact(DisplayName = "/language/arguments-object/unmapped/Symbol.iterator.js")]
        public void Test_Symbol_iterator_js()
        {
            RunTest("language/arguments-object/unmapped/Symbol.iterator.js");
        }

        [Fact(DisplayName = "/language/arguments-object/unmapped/via-params-dflt.js")]
        public void Test_via﹏params﹏dflt_js()
        {
            RunTest("language/arguments-object/unmapped/via-params-dflt.js");
        }

        [Fact(DisplayName = "/language/arguments-object/unmapped/via-params-dstr.js")]
        public void Test_via﹏params﹏dstr_js()
        {
            RunTest("language/arguments-object/unmapped/via-params-dstr.js");
        }

        [Fact(DisplayName = "/language/arguments-object/unmapped/via-params-rest.js")]
        public void Test_via﹏params﹏rest_js()
        {
            RunTest("language/arguments-object/unmapped/via-params-rest.js");
        }

        [Fact(DisplayName = "/language/arguments-object/unmapped/via-strict.js")]
        public void Test_via﹏strict_js()
        {
            RunTest("language/arguments-object/unmapped/via-strict.js");
        }
    }
}
