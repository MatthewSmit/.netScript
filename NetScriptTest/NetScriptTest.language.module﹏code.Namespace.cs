using Xunit;

namespace NetScriptTest.language.module﹏code
{
    public sealed class Test_Namespace : BaseTest
    {
        [Fact(DisplayName = "/language/module-code/namespace/Symbol.iterator.js")]
        public void Test_Symbol_iterator_js()
        {
            RunTest("language/module-code/namespace/Symbol.iterator.js");
        }

        [Fact(DisplayName = "/language/module-code/namespace/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("language/module-code/namespace/Symbol.toStringTag.js");
        }
    }
}
