using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_compareExchange : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/compareExchange/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/compareExchange/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/compareExchange/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/compareExchange/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/compareExchange/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/compareExchange/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/compareExchange/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/compareExchange/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/compareExchange/shared-nonint-views.js");
        }
    }
}
