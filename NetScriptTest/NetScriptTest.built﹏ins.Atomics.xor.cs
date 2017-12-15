using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_xor : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/xor/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/xor/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/xor/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/xor/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/xor/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/xor/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/xor/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/xor/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/xor/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/xor/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/xor/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/xor/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/xor/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/xor/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/xor/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/xor/shared-nonint-views.js");
        }
    }
}
