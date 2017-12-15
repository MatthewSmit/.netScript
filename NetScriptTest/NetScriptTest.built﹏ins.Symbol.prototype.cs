using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/Symbol/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/intrinsic.js")]
        public void Test_intrinsic_js()
        {
            RunTest("built-ins/Symbol/prototype/intrinsic.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toStringTag.js");
        }
    }
}
