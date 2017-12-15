using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_sub : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/sub/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/sub/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/sub/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/sub/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/sub/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/sub/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/sub/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/sub/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/sub/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/sub/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/sub/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/sub/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/sub/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/sub/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/sub/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/sub/shared-nonint-views.js");
        }
    }
}
