using Xunit;

namespace NetScriptTest.language.destructuring
{
    public sealed class Test_binding : BaseTest
    {
        [Fact(DisplayName = "/language/destructuring/binding/initialization-requires-object-coercible-null.js")]
        public void Test_initialization﹏requires﹏object﹏coercible﹏null_js()
        {
            RunTest("language/destructuring/binding/initialization-requires-object-coercible-null.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/initialization-requires-object-coercible-undefined.js")]
        public void Test_initialization﹏requires﹏object﹏coercible﹏undefined_js()
        {
            RunTest("language/destructuring/binding/initialization-requires-object-coercible-undefined.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/initialization-returns-normal-completion-for-empty-objects.js")]
        public void Test_initialization﹏returns﹏normal﹏completion﹏for﹏empty﹏objects_js()
        {
            RunTest("language/destructuring/binding/initialization-returns-normal-completion-for-empty-objects.js");
        }
    }
}
