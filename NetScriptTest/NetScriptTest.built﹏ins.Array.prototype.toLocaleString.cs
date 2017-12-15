using Xunit;

namespace NetScriptTest.built﹏ins.Array.prototype
{
    public sealed class Test_toLocaleString : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/length.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/name.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/primitive_this_value.js")]
        public void Test_primitive_this_value_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/primitive_this_value.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/primitive_this_value_getter.js")]
        public void Test_primitive_this_value_getter_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/primitive_this_value_getter.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/S15.4.4.3_A1_T1.js")]
        public void Test_S15_4_4_3_A1_T1_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/S15.4.4.3_A1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/S15.4.4.3_A3_T1.js")]
        public void Test_S15_4_4_3_A3_T1_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/S15.4.4.3_A3_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Array/prototype/toLocaleString/S15.4.4.3_A4.7.js")]
        public void Test_S15_4_4_3_A4_7_js()
        {
            RunTest("built-ins/Array/prototype/toLocaleString/S15.4.4.3_A4.7.js");
        }
    }
}
