using Xunit;

namespace NetScriptTest.built﹏ins.MapIteratorPrototype
{
    public sealed class Test_next : BaseTest
    {
        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/does-not-have-mapiterator-internal-slots-map.js")]
        public void Test_does﹏not﹏have﹏mapiterator﹏internal﹏slots﹏map_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/does-not-have-mapiterator-internal-slots-map.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/does-not-have-mapiterator-internal-slots.js")]
        public void Test_does﹏not﹏have﹏mapiterator﹏internal﹏slots_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/does-not-have-mapiterator-internal-slots.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/iteration-mutable.js")]
        public void Test_iteration﹏mutable_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/iteration-mutable.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/iteration.js")]
        public void Test_iteration_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/iteration.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/length.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/name.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/this-not-object-throw-entries.js")]
        public void Test_this﹏not﹏object﹏throw﹏entries_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/this-not-object-throw-entries.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/this-not-object-throw-keys.js")]
        public void Test_this﹏not﹏object﹏throw﹏keys_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/this-not-object-throw-keys.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/this-not-object-throw-prototype-iterator.js")]
        public void Test_this﹏not﹏object﹏throw﹏prototype﹏iterator_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/this-not-object-throw-prototype-iterator.js");
        }

        [Fact(DisplayName = "/built-ins/MapIteratorPrototype/next/this-not-object-throw-values.js")]
        public void Test_this﹏not﹏object﹏throw﹏values_js()
        {
            RunTest("built-ins/MapIteratorPrototype/next/this-not-object-throw-values.js");
        }
    }
}
