using Xunit;

namespace NetScriptTest.built﹏ins.Set.prototype
{
    public sealed class Test_constructor : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Set/prototype/constructor/set-prototype-constructor-intrinsic.js")]
        public void Test_set﹏prototype﹏constructor﹏intrinsic_js()
        {
            RunTest("built-ins/Set/prototype/constructor/set-prototype-constructor-intrinsic.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/constructor/set-prototype-constructor.js")]
        public void Test_set﹏prototype﹏constructor_js()
        {
            RunTest("built-ins/Set/prototype/constructor/set-prototype-constructor.js");
        }
    }
}
