using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_add : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/add/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/add/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/add/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/add/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/add/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/add/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/add/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/add/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/add/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/add/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/add/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/add/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/add/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/add/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/add/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/add/shared-nonint-views.js");
        }
    }
}
