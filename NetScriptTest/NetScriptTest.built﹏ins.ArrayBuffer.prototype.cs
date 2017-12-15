using Xunit;

namespace NetScriptTest.built﹏ins.ArrayBuffer
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype/Symbol.toStringTag.js");
        }
    }
}
