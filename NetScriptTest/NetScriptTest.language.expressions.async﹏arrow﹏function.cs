using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_async﹏arrow﹏function : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/async-arrow-function/arrow-returns-promise.js")]
        public void Test_arrow﹏returns﹏promise_js()
        {
            RunTest("language/expressions/async-arrow-function/arrow-returns-promise.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/async-lineterminator-identifier-throws.js")]
        public void Test_async﹏lineterminator﹏identifier﹏throws_js()
        {
            RunTest("language/expressions/async-arrow-function/async-lineterminator-identifier-throws.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/await-as-binding-identifier-escaped.js")]
        public void Test_await﹏as﹏binding﹏identifier﹏escaped_js()
        {
            RunTest("language/expressions/async-arrow-function/await-as-binding-identifier-escaped.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/await-as-binding-identifier.js")]
        public void Test_await﹏as﹏binding﹏identifier_js()
        {
            RunTest("language/expressions/async-arrow-function/await-as-binding-identifier.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/await-as-identifier-reference-escaped.js")]
        public void Test_await﹏as﹏identifier﹏reference﹏escaped_js()
        {
            RunTest("language/expressions/async-arrow-function/await-as-identifier-reference-escaped.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/await-as-identifier-reference.js")]
        public void Test_await﹏as﹏identifier﹏reference_js()
        {
            RunTest("language/expressions/async-arrow-function/await-as-identifier-reference.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/await-as-label-identifier-escaped.js")]
        public void Test_await﹏as﹏label﹏identifier﹏escaped_js()
        {
            RunTest("language/expressions/async-arrow-function/await-as-label-identifier-escaped.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/await-as-label-identifier.js")]
        public void Test_await﹏as﹏label﹏identifier_js()
        {
            RunTest("language/expressions/async-arrow-function/await-as-label-identifier.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-abrupt.js")]
        public void Test_dflt﹏params﹏abrupt_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-abrupt.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-arg-val-not-undefined.js")]
        public void Test_dflt﹏params﹏arg﹏val﹏not﹏undefined_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-arg-val-not-undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-arg-val-undefined.js")]
        public void Test_dflt﹏params﹏arg﹏val﹏undefined_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-arg-val-undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-duplicates.js")]
        public void Test_dflt﹏params﹏duplicates_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-duplicates.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-ref-later.js")]
        public void Test_dflt﹏params﹏ref﹏later_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-ref-later.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-ref-prior.js")]
        public void Test_dflt﹏params﹏ref﹏prior_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-ref-prior.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-ref-self.js")]
        public void Test_dflt﹏params﹏ref﹏self_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-ref-self.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-rest.js")]
        public void Test_dflt﹏params﹏rest_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-rest.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/dflt-params-trailing-comma.js")]
        public void Test_dflt﹏params﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/async-arrow-function/dflt-params-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-arguments-in-formal-parameters.js")]
        public void Test_early﹏errors﹏arrow﹏arguments﹏in﹏formal﹏parameters_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-arguments-in-formal-parameters.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-await-in-formals-default.js")]
        public void Test_early﹏errors﹏arrow﹏await﹏in﹏formals﹏default_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-await-in-formals-default.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-await-in-formals.js")]
        public void Test_early﹏errors﹏arrow﹏await﹏in﹏formals_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-await-in-formals.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-body-contains-super-call.js")]
        public void Test_early﹏errors﹏arrow﹏body﹏contains﹏super﹏call_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-body-contains-super-call.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-body-contains-super-property.js")]
        public void Test_early﹏errors﹏arrow﹏body﹏contains﹏super﹏property_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-body-contains-super-property.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-duplicate-parameters.js")]
        public void Test_early﹏errors﹏arrow﹏duplicate﹏parameters_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-duplicate-parameters.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-eval-in-formal-parameters.js")]
        public void Test_early﹏errors﹏arrow﹏eval﹏in﹏formal﹏parameters_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-eval-in-formal-parameters.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-formals-body-duplicate.js")]
        public void Test_early﹏errors﹏arrow﹏formals﹏body﹏duplicate_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-formals-body-duplicate.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-formals-contains-super-call.js")]
        public void Test_early﹏errors﹏arrow﹏formals﹏contains﹏super﹏call_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-formals-contains-super-call.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-formals-contains-super-property.js")]
        public void Test_early﹏errors﹏arrow﹏formals﹏contains﹏super﹏property_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-formals-contains-super-property.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-formals-lineterminator.js")]
        public void Test_early﹏errors﹏arrow﹏formals﹏lineterminator_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-formals-lineterminator.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/early-errors-arrow-NSPL-with-USD.js")]
        public void Test_early﹏errors﹏arrow﹏NSPL﹏with﹏USD_js()
        {
            RunTest("language/expressions/async-arrow-function/early-errors-arrow-NSPL-with-USD.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/escaped-async.js")]
        public void Test_escaped﹏async_js()
        {
            RunTest("language/expressions/async-arrow-function/escaped-async.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/params-trailing-comma-multiple.js")]
        public void Test_params﹏trailing﹏comma﹏multiple_js()
        {
            RunTest("language/expressions/async-arrow-function/params-trailing-comma-multiple.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/params-trailing-comma-single.js")]
        public void Test_params﹏trailing﹏comma﹏single_js()
        {
            RunTest("language/expressions/async-arrow-function/params-trailing-comma-single.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/rest-params-trailing-comma-early-error.js")]
        public void Test_rest﹏params﹏trailing﹏comma﹏early﹏error_js()
        {
            RunTest("language/expressions/async-arrow-function/rest-params-trailing-comma-early-error.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-reject-finally-reject.js")]
        public void Test_try﹏reject﹏finally﹏reject_js()
        {
            RunTest("language/expressions/async-arrow-function/try-reject-finally-reject.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-reject-finally-return.js")]
        public void Test_try﹏reject﹏finally﹏return_js()
        {
            RunTest("language/expressions/async-arrow-function/try-reject-finally-return.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-reject-finally-throw.js")]
        public void Test_try﹏reject﹏finally﹏throw_js()
        {
            RunTest("language/expressions/async-arrow-function/try-reject-finally-throw.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-return-finally-reject.js")]
        public void Test_try﹏return﹏finally﹏reject_js()
        {
            RunTest("language/expressions/async-arrow-function/try-return-finally-reject.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-return-finally-return.js")]
        public void Test_try﹏return﹏finally﹏return_js()
        {
            RunTest("language/expressions/async-arrow-function/try-return-finally-return.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-return-finally-throw.js")]
        public void Test_try﹏return﹏finally﹏throw_js()
        {
            RunTest("language/expressions/async-arrow-function/try-return-finally-throw.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-throw-finally-reject.js")]
        public void Test_try﹏throw﹏finally﹏reject_js()
        {
            RunTest("language/expressions/async-arrow-function/try-throw-finally-reject.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-throw-finally-return.js")]
        public void Test_try﹏throw﹏finally﹏return_js()
        {
            RunTest("language/expressions/async-arrow-function/try-throw-finally-return.js");
        }

        [Fact(DisplayName = "/language/expressions/async-arrow-function/try-throw-finally-throw.js")]
        public void Test_try﹏throw﹏finally﹏throw_js()
        {
            RunTest("language/expressions/async-arrow-function/try-throw-finally-throw.js");
        }
    }
}
