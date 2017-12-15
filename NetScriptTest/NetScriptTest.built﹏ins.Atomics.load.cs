using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_load : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/load/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/load/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/load/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/load/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/load/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/load/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/load/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/load/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/load/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/load/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/load/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/load/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/load/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/load/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/load/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/load/shared-nonint-views.js");
        }
    }
}
