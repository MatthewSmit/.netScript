using Xunit;

namespace NetScriptTest.language
{
    public sealed class Test_rest﹏parameters : BaseTest
    {
        [Fact(DisplayName = "/language/rest-parameters/array-pattern.js")]
        public void Test_array﹏pattern_js()
        {
            RunTest("language/rest-parameters/array-pattern.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/arrow-function.js")]
        public void Test_arrow﹏function_js()
        {
            RunTest("language/rest-parameters/arrow-function.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/expected-argument-count.js")]
        public void Test_expected﹏argument﹏count_js()
        {
            RunTest("language/rest-parameters/expected-argument-count.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/no-alias-arguments.js")]
        public void Test_no﹏alias﹏arguments_js()
        {
            RunTest("language/rest-parameters/no-alias-arguments.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/object-pattern.js")]
        public void Test_object﹏pattern_js()
        {
            RunTest("language/rest-parameters/object-pattern.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/position-invalid.js")]
        public void Test_position﹏invalid_js()
        {
            RunTest("language/rest-parameters/position-invalid.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/rest-index.js")]
        public void Test_rest﹏index_js()
        {
            RunTest("language/rest-parameters/rest-index.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/rest-parameters-apply.js")]
        public void Test_rest﹏parameters﹏apply_js()
        {
            RunTest("language/rest-parameters/rest-parameters-apply.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/rest-parameters-call.js")]
        public void Test_rest﹏parameters﹏call_js()
        {
            RunTest("language/rest-parameters/rest-parameters-call.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/rest-parameters-produce-an-array.js")]
        public void Test_rest﹏parameters﹏produce﹏an﹏array_js()
        {
            RunTest("language/rest-parameters/rest-parameters-produce-an-array.js");
        }

        [Fact(DisplayName = "/language/rest-parameters/with-new-target.js")]
        public void Test_with﹏new﹏target_js()
        {
            RunTest("language/rest-parameters/with-new-target.js");
        }
    }
}
