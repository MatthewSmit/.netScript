using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_SetIteratorPrototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/SetIteratorPrototype/Symbol.toStringTag.js");
        }
    }
}
