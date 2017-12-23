using Xunit;

namespace NetScriptTest.intl402
{
    public sealed class Test_NumberFormat : BaseTest
    {
        [Fact(DisplayName = "/intl402/NumberFormat/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/NumberFormat/builtin.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/currency-code-invalid.js")]
        public void Test_currency﹏code﹏invalid_js()
        {
            RunTest("intl402/NumberFormat/currency-code-invalid.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/currency-code-well-formed.js")]
        public void Test_currency﹏code﹏well﹏formed_js()
        {
            RunTest("intl402/NumberFormat/currency-code-well-formed.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/currency-digits.js")]
        public void Test_currency﹏digits_js()
        {
            RunTest("intl402/NumberFormat/currency-digits.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/default-minimum-singificant-digits.js")]
        public void Test_default﹏minimum﹏singificant﹏digits_js()
        {
            RunTest("intl402/NumberFormat/default-minimum-singificant-digits.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/default-options-object-prototype.js")]
        public void Test_default﹏options﹏object﹏prototype_js()
        {
            RunTest("intl402/NumberFormat/default-options-object-prototype.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/dft-currency-mnfd-range-check-mxfd.js")]
        public void Test_dft﹏currency﹏mnfd﹏range﹏check﹏mxfd_js()
        {
            RunTest("intl402/NumberFormat/dft-currency-mnfd-range-check-mxfd.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/fraction-digit-options-read-once.js")]
        public void Test_fraction﹏digit﹏options﹏read﹏once_js()
        {
            RunTest("intl402/NumberFormat/fraction-digit-options-read-once.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/ignore-invalid-unicode-ext-values.js")]
        public void Test_ignore﹏invalid﹏unicode﹏ext﹏values_js()
        {
            RunTest("intl402/NumberFormat/ignore-invalid-unicode-ext-values.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/instance-class.js")]
        public void Test_instance﹏class_js()
        {
            RunTest("intl402/NumberFormat/instance-class.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/instance-proto-and-extensible.js")]
        public void Test_instance﹏proto﹏and﹏extensible_js()
        {
            RunTest("intl402/NumberFormat/instance-proto-and-extensible.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/legacy-regexp-statics-not-modified.js")]
        public void Test_legacy﹏regexp﹏statics﹏not﹏modified_js()
        {
            RunTest("intl402/NumberFormat/legacy-regexp-statics-not-modified.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/NumberFormat/length.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/NumberFormat/name.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/NumberFormat/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/significant-digits-options-get-sequence.js")]
        public void Test_significant﹏digits﹏options﹏get﹏sequence_js()
        {
            RunTest("intl402/NumberFormat/significant-digits-options-get-sequence.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/subclassing.js")]
        public void Test_subclassing_js()
        {
            RunTest("intl402/NumberFormat/subclassing.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/taint-Object-prototype.js")]
        public void Test_taint﹏Object﹏prototype_js()
        {
            RunTest("intl402/NumberFormat/taint-Object-prototype.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/test-option-currency.js")]
        public void Test_test﹏option﹏currency_js()
        {
            RunTest("intl402/NumberFormat/test-option-currency.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/test-option-currencyDisplay.js")]
        public void Test_test﹏option﹏currencyDisplay_js()
        {
            RunTest("intl402/NumberFormat/test-option-currencyDisplay.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/test-option-localeMatcher.js")]
        public void Test_test﹏option﹏localeMatcher_js()
        {
            RunTest("intl402/NumberFormat/test-option-localeMatcher.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/test-option-style.js")]
        public void Test_test﹏option﹏style_js()
        {
            RunTest("intl402/NumberFormat/test-option-style.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/test-option-useGrouping.js")]
        public void Test_test﹏option﹏useGrouping_js()
        {
            RunTest("intl402/NumberFormat/test-option-useGrouping.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/this-value-ignored.js")]
        public void Test_this﹏value﹏ignored_js()
        {
            RunTest("intl402/NumberFormat/this-value-ignored.js");
        }

        [Fact(DisplayName = "/intl402/NumberFormat/throws-for-currency-style-without-currency-option.js")]
        public void Test_throws﹏for﹏currency﹏style﹏without﹏currency﹏option_js()
        {
            RunTest("intl402/NumberFormat/throws-for-currency-style-without-currency-option.js");
        }
    }
}
