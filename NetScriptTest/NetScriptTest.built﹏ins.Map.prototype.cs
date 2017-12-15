using Xunit;

namespace NetScriptTest.built﹏ins.Map
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Map/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/Map/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Map/prototype/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/Symbol.iterator.js")]
        public void Test_Symbol_iterator_js()
        {
            RunTest("built-ins/Map/prototype/Symbol.iterator.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/Map/prototype/Symbol.toStringTag.js");
        }
    }
}
