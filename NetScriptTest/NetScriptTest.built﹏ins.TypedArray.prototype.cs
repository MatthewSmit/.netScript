using Xunit;

namespace NetScriptTest.built﹏ins.TypedArray
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArray/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/TypedArray/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/Symbol.iterator.js")]
        public void Test_Symbol_iterator_js()
        {
            RunTest("built-ins/TypedArray/prototype/Symbol.iterator.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArray/prototype/toString.js")]
        public void Test_toString_js()
        {
            RunTest("built-ins/TypedArray/prototype/toString.js");
        }
    }
}
