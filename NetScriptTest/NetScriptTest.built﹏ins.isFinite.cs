using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_isFinite : BaseTest
    {
        [Fact(DisplayName = "/built-ins/isFinite/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/isFinite/length.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/isFinite/name.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/isFinite/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/return-abrupt-from-tonumber-number-symbol.js")]
        public void Test_return﹏abrupt﹏from﹏tonumber﹏number﹏symbol_js()
        {
            RunTest("built-ins/isFinite/return-abrupt-from-tonumber-number-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/return-abrupt-from-tonumber-number.js")]
        public void Test_return﹏abrupt﹏from﹏tonumber﹏number_js()
        {
            RunTest("built-ins/isFinite/return-abrupt-from-tonumber-number.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/return-false-on-nan-or-infinities.js")]
        public void Test_return﹏false﹏on﹏nan﹏or﹏infinities_js()
        {
            RunTest("built-ins/isFinite/return-false-on-nan-or-infinities.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/return-true-for-valid-finite-numbers.js")]
        public void Test_return﹏true﹏for﹏valid﹏finite﹏numbers_js()
        {
            RunTest("built-ins/isFinite/return-true-for-valid-finite-numbers.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/S15.1.2.5_A2.6.js")]
        public void Test_S15_1_2_5_A2_6_js()
        {
            RunTest("built-ins/isFinite/S15.1.2.5_A2.6.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/S15.1.2.5_A2.7.js")]
        public void Test_S15_1_2_5_A2_7_js()
        {
            RunTest("built-ins/isFinite/S15.1.2.5_A2.7.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/tonumber-operations.js")]
        public void Test_tonumber﹏operations_js()
        {
            RunTest("built-ins/isFinite/tonumber-operations.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/toprimitive-call-abrupt.js")]
        public void Test_toprimitive﹏call﹏abrupt_js()
        {
            RunTest("built-ins/isFinite/toprimitive-call-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/toprimitive-get-abrupt.js")]
        public void Test_toprimitive﹏get﹏abrupt_js()
        {
            RunTest("built-ins/isFinite/toprimitive-get-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/toprimitive-not-callable-throws.js")]
        public void Test_toprimitive﹏not﹏callable﹏throws_js()
        {
            RunTest("built-ins/isFinite/toprimitive-not-callable-throws.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/toprimitive-result-is-object-throws.js")]
        public void Test_toprimitive﹏result﹏is﹏object﹏throws_js()
        {
            RunTest("built-ins/isFinite/toprimitive-result-is-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/toprimitive-result-is-symbol-throws.js")]
        public void Test_toprimitive﹏result﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/isFinite/toprimitive-result-is-symbol-throws.js");
        }

        [Fact(DisplayName = "/built-ins/isFinite/toprimitive-valid-result.js")]
        public void Test_toprimitive﹏valid﹏result_js()
        {
            RunTest("built-ins/isFinite/toprimitive-valid-result.js");
        }
    }
}
