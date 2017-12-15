using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_store : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/store/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/store/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/store/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/store/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/store/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/store/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/store/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/store/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/store/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/store/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/store/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/store/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/store/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/store/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/store/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/store/shared-nonint-views.js");
        }
    }
}
