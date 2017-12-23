using Xunit;

namespace NetScriptTest.intl402.String.prototype
{
    public sealed class Test_localeCompare : BaseTest
    {
        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/String/prototype/localeCompare/builtin.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/default-options-object-prototype.js")]
        public void Test_default﹏options﹏object﹏prototype_js()
        {
            RunTest("intl402/String/prototype/localeCompare/default-options-object-prototype.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/String/prototype/localeCompare/length.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/missing-arguments-coerced-to-undefined.js")]
        public void Test_missing﹏arguments﹏coerced﹏to﹏undefined_js()
        {
            RunTest("intl402/String/prototype/localeCompare/missing-arguments-coerced-to-undefined.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/return-abrupt-this-value.js")]
        public void Test_return﹏abrupt﹏this﹏value_js()
        {
            RunTest("intl402/String/prototype/localeCompare/return-abrupt-this-value.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/returns-same-results-as-Collator.js")]
        public void Test_returns﹏same﹏results﹏as﹏Collator_js()
        {
            RunTest("intl402/String/prototype/localeCompare/returns-same-results-as-Collator.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/taint-Intl-Collator.js")]
        public void Test_taint﹏Intl﹏Collator_js()
        {
            RunTest("intl402/String/prototype/localeCompare/taint-Intl-Collator.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/that-arg-coerced-to-string.js")]
        public void Test_that﹏arg﹏coerced﹏to﹏string_js()
        {
            RunTest("intl402/String/prototype/localeCompare/that-arg-coerced-to-string.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/this-value-coerced-to-string.js")]
        public void Test_this﹏value﹏coerced﹏to﹏string_js()
        {
            RunTest("intl402/String/prototype/localeCompare/this-value-coerced-to-string.js");
        }

        [Fact(DisplayName = "/intl402/String/prototype/localeCompare/throws-same-exceptions-as-Collator.js")]
        public void Test_throws﹏same﹏exceptions﹏as﹏Collator_js()
        {
            RunTest("intl402/String/prototype/localeCompare/throws-same-exceptions-as-Collator.js");
        }
    }
}
