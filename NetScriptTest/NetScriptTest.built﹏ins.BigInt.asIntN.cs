using Xunit;

namespace NetScriptTest.built﹏ins.BigInt
{
    public sealed class Test_asIntN : BaseTest
    {
        [Fact(DisplayName = "/built-ins/BigInt/asIntN/arithmetic.js")]
        public void Test_arithmetic_js()
        {
            RunTest("built-ins/BigInt/asIntN/arithmetic.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asIntN/asIntN.js")]
        public void Test_asIntN_js()
        {
            RunTest("built-ins/BigInt/asIntN/asIntN.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asIntN/bigint-tobigint.js")]
        public void Test_bigint﹏tobigint_js()
        {
            RunTest("built-ins/BigInt/asIntN/bigint-tobigint.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asIntN/bits-toindex.js")]
        public void Test_bits﹏toindex_js()
        {
            RunTest("built-ins/BigInt/asIntN/bits-toindex.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asIntN/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/BigInt/asIntN/length.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asIntN/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/BigInt/asIntN/name.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/asIntN/order-of-steps.js")]
        public void Test_order﹏of﹏steps_js()
        {
            RunTest("built-ins/BigInt/asIntN/order-of-steps.js");
        }
    }
}
