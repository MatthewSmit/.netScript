using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/prototype/Symbol.iterator.js")]
        public void Test_Symbol_iterator_js()
        {
            RunTest("built-ins/TypedArrays/prototype/Symbol.iterator.js");
        }
    }
}
