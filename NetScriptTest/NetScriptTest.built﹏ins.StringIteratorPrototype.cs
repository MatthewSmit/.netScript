using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_StringIteratorPrototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/StringIteratorPrototype/ancestry.js")]
        public void Test_ancestry_js()
        {
            RunTest("built-ins/StringIteratorPrototype/ancestry.js");
        }

        [Fact(DisplayName = "/built-ins/StringIteratorPrototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/StringIteratorPrototype/Symbol.toStringTag.js");
        }
    }
}
