using Xunit;

namespace NetScriptTest.built﹏ins.Set
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Set/prototype/set-prototype.js")]
        public void Test_set﹏prototype_js()
        {
            RunTest("built-ins/Set/prototype/set-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/Symbol.iterator.js")]
        public void Test_Symbol_iterator_js()
        {
            RunTest("built-ins/Set/prototype/Symbol.iterator.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/Set/prototype/Symbol.toStringTag.js");
        }
    }
}
