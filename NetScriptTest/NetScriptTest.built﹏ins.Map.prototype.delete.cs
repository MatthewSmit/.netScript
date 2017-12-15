using Xunit;

namespace NetScriptTest.built﹏ins.Map.prototype
{
    public sealed class Test_delete : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Map/prototype/delete/context-is-not-map-object.js")]
        public void Test_context﹏is﹏not﹏map﹏object_js()
        {
            RunTest("built-ins/Map/prototype/delete/context-is-not-map-object.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/context-is-not-object.js")]
        public void Test_context﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/Map/prototype/delete/context-is-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/context-is-set-object-throws.js")]
        public void Test_context﹏is﹏set﹏object﹏throws_js()
        {
            RunTest("built-ins/Map/prototype/delete/context-is-set-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/context-is-weakmap-object-throws.js")]
        public void Test_context﹏is﹏weakmap﹏object﹏throws_js()
        {
            RunTest("built-ins/Map/prototype/delete/context-is-weakmap-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/delete.js")]
        public void Test_delete_js()
        {
            RunTest("built-ins/Map/prototype/delete/delete.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/does-not-break-iterators.js")]
        public void Test_does﹏not﹏break﹏iterators_js()
        {
            RunTest("built-ins/Map/prototype/delete/does-not-break-iterators.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Map/prototype/delete/length.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Map/prototype/delete/name.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/returns-false.js")]
        public void Test_returns﹏false_js()
        {
            RunTest("built-ins/Map/prototype/delete/returns-false.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype/delete/returns-true-for-deleted-entry.js")]
        public void Test_returns﹏true﹏for﹏deleted﹏entry_js()
        {
            RunTest("built-ins/Map/prototype/delete/returns-true-for-deleted-entry.js");
        }
    }
}
