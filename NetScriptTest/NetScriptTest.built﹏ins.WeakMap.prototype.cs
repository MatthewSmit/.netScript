using Xunit;

namespace NetScriptTest.built﹏ins.WeakMap
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/WeakMap/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/WeakMap/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/WeakMap/prototype/prototype-attributes.js")]
        public void Test_prototype﹏attributes_js()
        {
            RunTest("built-ins/WeakMap/prototype/prototype-attributes.js");
        }

        [Fact(DisplayName = "/built-ins/WeakMap/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/WeakMap/prototype/Symbol.toStringTag.js");
        }
    }
}
