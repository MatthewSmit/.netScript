using Xunit;

namespace NetScriptTest.built﹏ins.WeakSet.prototype
{
    public sealed class Test_constructor : BaseTest
    {
        [Fact(DisplayName = "/built-ins/WeakSet/prototype/constructor/weakset-prototype-constructor-intrinsic.js")]
        public void Test_weakset﹏prototype﹏constructor﹏intrinsic_js()
        {
            RunTest("built-ins/WeakSet/prototype/constructor/weakset-prototype-constructor-intrinsic.js");
        }

        [Fact(DisplayName = "/built-ins/WeakSet/prototype/constructor/weakset-prototype-constructor.js")]
        public void Test_weakset﹏prototype﹏constructor_js()
        {
            RunTest("built-ins/WeakSet/prototype/constructor/weakset-prototype-constructor.js");
        }
    }
}
