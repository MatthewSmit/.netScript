using Xunit;

namespace NetScriptTest.built﹏ins.Array.prototype
{
    public sealed class Test_entries : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Array/prototype/entries/iteration-mutable.js")]
        public void Test_iteration﹏mutable_js()
        {
            RunTest("built-ins/Array/prototype/entries/iteration-mutable.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/entries/iteration.js")]
        public void Test_iteration_js()
        {
            RunTest("built-ins/Array/prototype/entries/iteration.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/entries/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Array/prototype/entries/length.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/entries/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Array/prototype/entries/name.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/entries/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Array/prototype/entries/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/entries/return-abrupt-from-this.js")]
        public void Test_return﹏abrupt﹏from﹏this_js()
        {
            RunTest("built-ins/Array/prototype/entries/return-abrupt-from-this.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/entries/returns-iterator-from-object.js")]
        public void Test_returns﹏iterator﹏from﹏object_js()
        {
            RunTest("built-ins/Array/prototype/entries/returns-iterator-from-object.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/entries/returns-iterator.js")]
        public void Test_returns﹏iterator_js()
        {
            RunTest("built-ins/Array/prototype/entries/returns-iterator.js");
        }
    }
}
