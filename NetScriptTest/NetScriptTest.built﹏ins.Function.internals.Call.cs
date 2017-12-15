using Xunit;

namespace NetScriptTest.built﹏ins.Function.internals
{
    public sealed class Test_Call : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Function/internals/Call/class-ctor-realm.js")]
        public void Test_class﹏ctor﹏realm_js()
        {
            RunTest("built-ins/Function/internals/Call/class-ctor-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Function/internals/Call/class-ctor.js")]
        public void Test_class﹏ctor_js()
        {
            RunTest("built-ins/Function/internals/Call/class-ctor.js");
        }
    }
}
