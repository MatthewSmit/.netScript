using Xunit;

namespace NetScriptTest.built﹏ins.WeakSet
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/WeakSet/prototype/prototype-attributes.js")]
        public void Test_prototype﹏attributes_js()
        {
            RunTest("built-ins/WeakSet/prototype/prototype-attributes.js");
        }

        [Fact(DisplayName = "/built-ins/WeakSet/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/WeakSet/prototype/Symbol.toStringTag.js");
        }
    }
}
