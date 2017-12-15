using Xunit;

namespace NetScriptTest.built﹏ins.SharedArrayBuffer
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/SharedArrayBuffer/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/SharedArrayBuffer/prototype/Symbol.toStringTag.js");
        }
    }
}
