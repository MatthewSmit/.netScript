using Xunit;

namespace NetScriptTest
{
    public sealed class Test_intl402 : BaseTest
    {
        [Fact(DisplayName = "/intl402/constructors-string-and-single-element-array.js")]
        public void Test_constructors﹏string﹏and﹏single﹏element﹏array_js()
        {
            RunTest("intl402/constructors-string-and-single-element-array.js");
        }

        [Fact(DisplayName = "/intl402/constructors-taint-Object-prototype-2.js")]
        public void Test_constructors﹏taint﹏Object﹏prototype﹏2_js()
        {
            RunTest("intl402/constructors-taint-Object-prototype-2.js");
        }

        [Fact(DisplayName = "/intl402/constructors-taint-Object-prototype.js")]
        public void Test_constructors﹏taint﹏Object﹏prototype_js()
        {
            RunTest("intl402/constructors-taint-Object-prototype.js");
        }

        [Fact(DisplayName = "/intl402/default-locale-is-canonicalized.js")]
        public void Test_default﹏locale﹏is﹏canonicalized_js()
        {
            RunTest("intl402/default-locale-is-canonicalized.js");
        }

        [Fact(DisplayName = "/intl402/default-locale-is-supported.js")]
        public void Test_default﹏locale﹏is﹏supported_js()
        {
            RunTest("intl402/default-locale-is-supported.js");
        }

        [Fact(DisplayName = "/intl402/fallback-locales-are-supported.js")]
        public void Test_fallback﹏locales﹏are﹏supported_js()
        {
            RunTest("intl402/fallback-locales-are-supported.js");
        }

        [Fact(DisplayName = "/intl402/language-tags-canonicalized.js")]
        public void Test_language﹏tags﹏canonicalized_js()
        {
            RunTest("intl402/language-tags-canonicalized.js");
        }

        [Fact(DisplayName = "/intl402/language-tags-invalid.js")]
        public void Test_language﹏tags﹏invalid_js()
        {
            RunTest("intl402/language-tags-invalid.js");
        }

        [Fact(DisplayName = "/intl402/language-tags-valid.js")]
        public void Test_language﹏tags﹏valid_js()
        {
            RunTest("intl402/language-tags-valid.js");
        }

        [Fact(DisplayName = "/intl402/language-tags-with-underscore.js")]
        public void Test_language﹏tags﹏with﹏underscore_js()
        {
            RunTest("intl402/language-tags-with-underscore.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-consistent-with-resolvedOptions.js")]
        public void Test_supportedLocalesOf﹏consistent﹏with﹏resolvedOptions_js()
        {
            RunTest("intl402/supportedLocalesOf-consistent-with-resolvedOptions.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-default-locale-and-zxx-locale.js")]
        public void Test_supportedLocalesOf﹏default﹏locale﹏and﹏zxx﹏locale_js()
        {
            RunTest("intl402/supportedLocalesOf-default-locale-and-zxx-locale.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-duplicate-elements-removed.js")]
        public void Test_supportedLocalesOf﹏duplicate﹏elements﹏removed_js()
        {
            RunTest("intl402/supportedLocalesOf-duplicate-elements-removed.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-empty-and-undefined.js")]
        public void Test_supportedLocalesOf﹏empty﹏and﹏undefined_js()
        {
            RunTest("intl402/supportedLocalesOf-empty-and-undefined.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-locales-arg-coered-to-object.js")]
        public void Test_supportedLocalesOf﹏locales﹏arg﹏coered﹏to﹏object_js()
        {
            RunTest("intl402/supportedLocalesOf-locales-arg-coered-to-object.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-locales-arg-empty-array.js")]
        public void Test_supportedLocalesOf﹏locales﹏arg﹏empty﹏array_js()
        {
            RunTest("intl402/supportedLocalesOf-locales-arg-empty-array.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-returned-array-elements-are-frozen.js")]
        public void Test_supportedLocalesOf﹏returned﹏array﹏elements﹏are﹏frozen_js()
        {
            RunTest("intl402/supportedLocalesOf-returned-array-elements-are-frozen.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-taint-Array-2.js")]
        public void Test_supportedLocalesOf﹏taint﹏Array﹏2_js()
        {
            RunTest("intl402/supportedLocalesOf-taint-Array-2.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-taint-Array.js")]
        public void Test_supportedLocalesOf﹏taint﹏Array_js()
        {
            RunTest("intl402/supportedLocalesOf-taint-Array.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-test-option-localeMatcher.js")]
        public void Test_supportedLocalesOf﹏test﹏option﹏localeMatcher_js()
        {
            RunTest("intl402/supportedLocalesOf-test-option-localeMatcher.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-throws-if-element-not-string-or-object.js")]
        public void Test_supportedLocalesOf﹏throws﹏if﹏element﹏not﹏string﹏or﹏object_js()
        {
            RunTest("intl402/supportedLocalesOf-throws-if-element-not-string-or-object.js");
        }

        [Fact(DisplayName = "/intl402/supportedLocalesOf-unicode-extensions-ignored.js")]
        public void Test_supportedLocalesOf﹏unicode﹏extensions﹏ignored_js()
        {
            RunTest("intl402/supportedLocalesOf-unicode-extensions-ignored.js");
        }
    }
}
