using Xunit;

namespace NetScriptTest.built﹏ins.Array.prototype
{
    public sealed class Test_keys : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Array/prototype/keys/iteration-mutable.js")]
        public void Test_iteration﹏mutable_js()
        {
            RunTest("built-ins/Array/prototype/keys/iteration-mutable.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/keys/iteration.js")]
        public void Test_iteration_js()
        {
            RunTest("built-ins/Array/prototype/keys/iteration.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/keys/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Array/prototype/keys/length.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/keys/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Array/prototype/keys/name.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/keys/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Array/prototype/keys/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/keys/return-abrupt-from-this.js")]
        public void Test_return﹏abrupt﹏from﹏this_js()
        {
            RunTest("built-ins/Array/prototype/keys/return-abrupt-from-this.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/keys/returns-iterator-from-object.js")]
        public void Test_returns﹏iterator﹏from﹏object_js()
        {
            RunTest("built-ins/Array/prototype/keys/returns-iterator-from-object.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/keys/returns-iterator.js")]
        public void Test_returns﹏iterator_js()
        {
            RunTest("built-ins/Array/prototype/keys/returns-iterator.js");
        }
    }
}
