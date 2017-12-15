using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_isNaN : BaseTest
    {
        [Fact(DisplayName = "/built-ins/isNaN/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/isNaN/length.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/isNaN/name.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/isNaN/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/return-abrupt-from-tonumber-number-symbol.js")]
        public void Test_return﹏abrupt﹏from﹏tonumber﹏number﹏symbol_js()
        {
            RunTest("built-ins/isNaN/return-abrupt-from-tonumber-number-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/return-abrupt-from-tonumber-number.js")]
        public void Test_return﹏abrupt﹏from﹏tonumber﹏number_js()
        {
            RunTest("built-ins/isNaN/return-abrupt-from-tonumber-number.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/return-false-not-nan-numbers.js")]
        public void Test_return﹏false﹏not﹏nan﹏numbers_js()
        {
            RunTest("built-ins/isNaN/return-false-not-nan-numbers.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/return-true-nan.js")]
        public void Test_return﹏true﹏nan_js()
        {
            RunTest("built-ins/isNaN/return-true-nan.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/S15.1.2.4_A2.6.js")]
        public void Test_S15_1_2_4_A2_6_js()
        {
            RunTest("built-ins/isNaN/S15.1.2.4_A2.6.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/S15.1.2.4_A2.7.js")]
        public void Test_S15_1_2_4_A2_7_js()
        {
            RunTest("built-ins/isNaN/S15.1.2.4_A2.7.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/tonumber-operations.js")]
        public void Test_tonumber﹏operations_js()
        {
            RunTest("built-ins/isNaN/tonumber-operations.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/toprimitive-call-abrupt.js")]
        public void Test_toprimitive﹏call﹏abrupt_js()
        {
            RunTest("built-ins/isNaN/toprimitive-call-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/toprimitive-get-abrupt.js")]
        public void Test_toprimitive﹏get﹏abrupt_js()
        {
            RunTest("built-ins/isNaN/toprimitive-get-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/toprimitive-not-callable-throws.js")]
        public void Test_toprimitive﹏not﹏callable﹏throws_js()
        {
            RunTest("built-ins/isNaN/toprimitive-not-callable-throws.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/toprimitive-result-is-object-throws.js")]
        public void Test_toprimitive﹏result﹏is﹏object﹏throws_js()
        {
            RunTest("built-ins/isNaN/toprimitive-result-is-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/toprimitive-result-is-symbol-throws.js")]
        public void Test_toprimitive﹏result﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/isNaN/toprimitive-result-is-symbol-throws.js");
        }

        [Fact(DisplayName = "/built-ins/isNaN/toprimitive-valid-result.js")]
        public void Test_toprimitive﹏valid﹏result_js()
        {
            RunTest("built-ins/isNaN/toprimitive-valid-result.js");
        }
    }
}
