using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_wait : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/wait/bad-range.js")]
        public void Test_bad﹏range_js()
        {
            RunTest("built-ins/Atomics/wait/bad-range.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/wait/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/did-timeout.js")]
        public void Test_did﹏timeout_js()
        {
            RunTest("built-ins/Atomics/wait/did-timeout.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/good-views.js")]
        public void Test_good﹏views_js()
        {
            RunTest("built-ins/Atomics/wait/good-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/wait/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/wait/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/nan-timeout.js")]
        public void Test_nan﹏timeout_js()
        {
            RunTest("built-ins/Atomics/wait/nan-timeout.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/negative-timeout.js")]
        public void Test_negative﹏timeout_js()
        {
            RunTest("built-ins/Atomics/wait/negative-timeout.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/no-spurious-wakeup.js")]
        public void Test_no﹏spurious﹏wakeup_js()
        {
            RunTest("built-ins/Atomics/wait/no-spurious-wakeup.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/non-views.js")]
        public void Test_non﹏views_js()
        {
            RunTest("built-ins/Atomics/wait/non-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/nonshared-int-views.js")]
        public void Test_nonshared﹏int﹏views_js()
        {
            RunTest("built-ins/Atomics/wait/nonshared-int-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/shared-nonint-views.js")]
        public void Test_shared﹏nonint﹏views_js()
        {
            RunTest("built-ins/Atomics/wait/shared-nonint-views.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/wait/was-woken.js")]
        public void Test_was﹏woken_js()
        {
            RunTest("built-ins/Atomics/wait/was-woken.js");
        }
    }
}
