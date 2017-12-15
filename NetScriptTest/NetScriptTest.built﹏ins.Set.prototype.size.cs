using Xunit;

namespace NetScriptTest.built﹏ins.Set.prototype
{
    public sealed class Test_size : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Set/prototype/size/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Set/prototype/size/length.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/size/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Set/prototype/size/name.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/size/returns-count-of-present-values-before-after-add-delete.js")]
        public void Test_returns﹏count﹏of﹏present﹏values﹏before﹏after﹏add﹏delete_js()
        {
            RunTest("built-ins/Set/prototype/size/returns-count-of-present-values-before-after-add-delete.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/size/returns-count-of-present-values-by-insertion.js")]
        public void Test_returns﹏count﹏of﹏present﹏values﹏by﹏insertion_js()
        {
            RunTest("built-ins/Set/prototype/size/returns-count-of-present-values-by-insertion.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/size/returns-count-of-present-values-by-iterable.js")]
        public void Test_returns﹏count﹏of﹏present﹏values﹏by﹏iterable_js()
        {
            RunTest("built-ins/Set/prototype/size/returns-count-of-present-values-by-iterable.js");
        }

        [Fact(DisplayName = "/built-ins/Set/prototype/size/size.js")]
        public void Test_size_js()
        {
            RunTest("built-ins/Set/prototype/size/size.js");
        }
    }
}
