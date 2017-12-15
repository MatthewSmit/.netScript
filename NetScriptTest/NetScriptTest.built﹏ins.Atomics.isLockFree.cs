using Xunit;

namespace NetScriptTest.built﹏ins.Atomics
{
    public sealed class Test_isLockFree : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Atomics/isLockFree/corner-cases.js")]
        public void Test_corner﹏cases_js()
        {
            RunTest("built-ins/Atomics/isLockFree/corner-cases.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/isLockFree/descriptor.js")]
        public void Test_descriptor_js()
        {
            RunTest("built-ins/Atomics/isLockFree/descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/isLockFree/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Atomics/isLockFree/length.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/isLockFree/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Atomics/isLockFree/name.js");
        }

        [Fact(DisplayName = "/built-ins/Atomics/isLockFree/value.js")]
        public void Test_value_js()
        {
            RunTest("built-ins/Atomics/isLockFree/value.js");
        }
    }
}
