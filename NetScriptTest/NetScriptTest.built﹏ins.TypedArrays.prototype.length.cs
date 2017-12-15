using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays.prototype
{
    public sealed class Test_length : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/prototype/length/inherited.js")]
        public void Test_inherited_js()
        {
            RunTest("built-ins/TypedArrays/prototype/length/inherited.js");
        }
    }
}
