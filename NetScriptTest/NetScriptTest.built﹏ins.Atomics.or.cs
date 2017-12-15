using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_or : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/or/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/or/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/or/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/or/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/or/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/or/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/or/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/or/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/or/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/or/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/or/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/or/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/or/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/or/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/or/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/or/shared-nonint-views.js");
        }
    }
}
