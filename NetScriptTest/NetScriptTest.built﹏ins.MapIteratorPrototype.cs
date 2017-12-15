using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_MapIteratorPrototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/MapIteratorPrototype/Symbol.toStringTag.js");
        }
    }
}
