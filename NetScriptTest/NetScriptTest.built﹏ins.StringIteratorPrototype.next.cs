using Xunit;

namespace NetScriptTest.built﹏ins.StringIteratorPrototype
{
    public sealed class Test_next : BaseTest
    {
        [Fact(DisplayName = "/built-ins/StringIteratorPrototype/next/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/StringIteratorPrototype/next/length.js");
        }

        [Fact(DisplayName = "/built-ins/StringIteratorPrototype/next/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/StringIteratorPrototype/next/name.js");
        }

        [Fact(DisplayName = "/built-ins/StringIteratorPrototype/next/next-iteration-surrogate-pairs.js")]
        public void Test_next﹏iteration﹏surrogate﹏pairs_js()
        {
            RunTest("built-ins/StringIteratorPrototype/next/next-iteration-surrogate-pairs.js");
        }

        [Fact(DisplayName = "/built-ins/StringIteratorPrototype/next/next-iteration.js")]
        public void Test_next﹏iteration_js()
        {
            RunTest("built-ins/StringIteratorPrototype/next/next-iteration.js");
        }

        [Fact(DisplayName = "/built-ins/StringIteratorPrototype/next/next-missing-internal-slots.js")]
        public void Test_next﹏missing﹏internal﹏slots_js()
        {
            RunTest("built-ins/StringIteratorPrototype/next/next-missing-internal-slots.js");
        }
    }
}
