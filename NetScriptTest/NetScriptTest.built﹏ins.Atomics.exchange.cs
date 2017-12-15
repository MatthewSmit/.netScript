using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_exchange : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/exchange/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/exchange/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/exchange/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/exchange/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/exchange/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/exchange/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/exchange/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/exchange/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/exchange/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/exchange/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/exchange/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/exchange/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/exchange/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/exchange/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/exchange/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/exchange/shared-nonint-views.js");
        }
    }
}
