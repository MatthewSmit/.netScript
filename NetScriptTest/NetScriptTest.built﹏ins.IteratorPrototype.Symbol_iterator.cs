using Xunit;

namespace NetScriptTest.built﹏ins.IteratorPrototype
{
    public sealed class Test_Symbol_iterator : BaseTest
    {
        [Fact(DisplayName = "/built-ins/IteratorPrototype/Symbol.iterator/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/IteratorPrototype/Symbol.iterator/length.js");
        }

        [Fact(DisplayName = "/built-ins/IteratorPrototype/Symbol.iterator/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/IteratorPrototype/Symbol.iterator/name.js");
        }

        [Fact(DisplayName = "/built-ins/IteratorPrototype/Symbol.iterator/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/IteratorPrototype/Symbol.iterator/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/IteratorPrototype/Symbol.iterator/return-val.js")]
        public void Test_return﹏val_js()
        {
            RunTest("built-ins/IteratorPrototype/Symbol.iterator/return-val.js");
        }
    }
}
