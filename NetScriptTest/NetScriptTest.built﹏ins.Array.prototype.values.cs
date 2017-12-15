using Xunit;

namespace NetScriptTest.built﹏ins.Array.prototype
{
    public sealed class Test_values : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Array/prototype/values/iteration-mutable.js")]
        public void Test_iteration﹏mutable_js()
        {
            RunTest("built-ins/Array/prototype/values/iteration-mutable.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/values/iteration.js")]
        public void Test_iteration_js()
        {
            RunTest("built-ins/Array/prototype/values/iteration.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/values/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Array/prototype/values/length.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/values/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Array/prototype/values/name.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/values/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Array/prototype/values/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/values/returns-iterator-from-object.js")]
        public void Test_returns﹏iterator﹏from﹏object_js()
        {
            RunTest("built-ins/Array/prototype/values/returns-iterator-from-object.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/values/returns-iterator.js")]
        public void Test_returns﹏iterator_js()
        {
            RunTest("built-ins/Array/prototype/values/returns-iterator.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/values/this-val-non-obj-coercible.js")]
        public void Test_this﹏val﹏non﹏obj﹏coercible_js()
        {
            RunTest("built-ins/Array/prototype/values/this-val-non-obj-coercible.js");
        }
    }
}
