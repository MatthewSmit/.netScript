using Xunit;

namespace NetScriptTest.built﹏ins.SetIteratorPrototype
{
    public sealed class Test_next : BaseTest
    {
        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/does-not-have-mapiterator-internal-slots-set.js")]
        public void Test_does﹏not﹏have﹏mapiterator﹏internal﹏slots﹏set_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/does-not-have-mapiterator-internal-slots-set.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/does-not-have-mapiterator-internal-slots.js")]
        public void Test_does﹏not﹏have﹏mapiterator﹏internal﹏slots_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/does-not-have-mapiterator-internal-slots.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/iteration-mutable.js")]
        public void Test_iteration﹏mutable_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/iteration-mutable.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/iteration.js")]
        public void Test_iteration_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/iteration.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/length.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/name.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/this-not-object-throw-entries.js")]
        public void Test_this﹏not﹏object﹏throw﹏entries_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/this-not-object-throw-entries.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/this-not-object-throw-keys.js")]
        public void Test_this﹏not﹏object﹏throw﹏keys_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/this-not-object-throw-keys.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/this-not-object-throw-prototype-iterator.js")]
        public void Test_this﹏not﹏object﹏throw﹏prototype﹏iterator_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/this-not-object-throw-prototype-iterator.js");
        }

        [Fact(DisplayName = "/built-ins/SetIteratorPrototype/next/this-not-object-throw-values.js")]
        public void Test_this﹏not﹏object﹏throw﹏values_js()
        {
            RunTest("built-ins/SetIteratorPrototype/next/this-not-object-throw-values.js");
        }
    }
}
