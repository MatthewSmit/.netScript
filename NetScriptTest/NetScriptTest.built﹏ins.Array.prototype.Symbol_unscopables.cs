using Xunit;

namespace NetScriptTest.built﹏ins.Array.prototype
{
    public sealed class Test_Symbol_unscopables : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Array/prototype/Symbol.unscopables/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Array/prototype/Symbol.unscopables/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/Symbol.unscopables/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Array/prototype/Symbol.unscopables/value.js");
        }
    }
}
