using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_and : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/and/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/and/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/and/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/and/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/and/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/and/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/and/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/and/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/and/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/and/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/and/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/and/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/and/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/and/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/and/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/and/shared-nonint-views.js");
        }
    }
}
