using Xunit;

namespace NetScriptTest.built﹏ins.String
{
    public sealed class Test_fromCodePoint : BaseTest
    {
        [Fact(DisplayName = "/built-ins/String/fromCodePoint/argument-is-not-integer.js")]
        public void Test_argument﹏is﹏not﹏integer_js()
        {
            RunTest("built-ins/String/fromCodePoint/argument-is-not-integer.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/argument-is-Symbol.js")]
        public void Test_argument﹏is﹏Symbol_js()
        {
            RunTest("built-ins/String/fromCodePoint/argument-is-Symbol.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/argument-not-coercible.js")]
        public void Test_argument﹏not﹏coercible_js()
        {
            RunTest("built-ins/String/fromCodePoint/argument-not-coercible.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/arguments-is-empty.js")]
        public void Test_arguments﹏is﹏empty_js()
        {
            RunTest("built-ins/String/fromCodePoint/arguments-is-empty.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/fromCodePoint.js")]
        public void Test_fromCodePoint_js()
        {
            RunTest("built-ins/String/fromCodePoint/fromCodePoint.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/String/fromCodePoint/length.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/String/fromCodePoint/name.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/number-is-out-of-range.js")]
        public void Test_number﹏is﹏out﹏of﹏range_js()
        {
            RunTest("built-ins/String/fromCodePoint/number-is-out-of-range.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/return-string-value.js")]
        public void Test_return﹏string﹏value_js()
        {
            RunTest("built-ins/String/fromCodePoint/return-string-value.js");
        }

        [Fact(DisplayName = "/built-ins/String/fromCodePoint/to-number-conversions.js")]
        public void Test_to﹏number﹏conversions_js()
        {
            RunTest("built-ins/String/fromCodePoint/to-number-conversions.js");
        }
    }
}
