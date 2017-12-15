using Xunit;

namespace NetScriptTest.built﹏ins.BigInt
{
    public sealed class Test_asUintN : BaseTest
    {
        [Fact(DisplayName = "/built-ins/BigInt/asUintN/arithmetic.js")]
        public void Test_arithmetic_js()
        {
            RunTest("built-ins/BigInt/asUintN/arithmetic.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asUintN/asUintN.js")]
        public void Test_asUintN_js()
        {
            RunTest("built-ins/BigInt/asUintN/asUintN.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asUintN/bigint-tobigint.js")]
        public void Test_bigint﹏tobigint_js()
        {
            RunTest("built-ins/BigInt/asUintN/bigint-tobigint.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asUintN/bits-toindex.js")]
        public void Test_bits﹏toindex_js()
        {
            RunTest("built-ins/BigInt/asUintN/bits-toindex.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asUintN/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/BigInt/asUintN/length.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asUintN/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/BigInt/asUintN/name.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asUintN/order-of-steps.js")]
        public void Test_order﹏of﹏steps_js()
        {
            RunTest("built-ins/BigInt/asUintN/order-of-steps.js");
        }
    }
}
