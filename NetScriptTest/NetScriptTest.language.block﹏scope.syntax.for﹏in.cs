using Xunit;

namespace NetScriptTest.language.block﹏scope.syntax
{
    public sealed class Test_for﹏in : BaseTest
    {
        [Fact(DisplayName = "/language/block-scope/syntax/for-in/acquire-properties-from-array.js")]
        public void Test_acquire﹏properties﹏from﹏array_js()
        {
            RunTest("language/block-scope/syntax/for-in/acquire-properties-from-array.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/for-in/acquire-properties-from-object.js")]
        public void Test_acquire﹏properties﹏from﹏object_js()
        {
            RunTest("language/block-scope/syntax/for-in/acquire-properties-from-object.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/for-in/disallow-initialization-assignment.js")]
        public void Test_disallow﹏initialization﹏assignment_js()
        {
            RunTest("language/block-scope/syntax/for-in/disallow-initialization-assignment.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings-with-and-without-initializer.js")]
        public void Test_disallow﹏multiple﹏lexical﹏bindings﹏with﹏and﹏without﹏initializer_js()
        {
            RunTest("language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings-with-and-without-initializer.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings-with-initializer.js")]
        public void Test_disallow﹏multiple﹏lexical﹏bindings﹏with﹏initializer_js()
        {
            RunTest("language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings-with-initializer.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings-without-and-with-initializer.js")]
        public void Test_disallow﹏multiple﹏lexical﹏bindings﹏without﹏and﹏with﹏initializer_js()
        {
            RunTest("language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings-without-and-with-initializer.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings.js")]
        public void Test_disallow﹏multiple﹏lexical﹏bindings_js()
        {
            RunTest("language/block-scope/syntax/for-in/disallow-multiple-lexical-bindings.js");
        }

        [Fact(DisplayName = "/language/block-scope/syntax/for-in/mixed-values-in-iteration.js")]
        public void Test_mixed﹏values﹏in﹏iteration_js()
        {
            RunTest("language/block-scope/syntax/for-in/mixed-values-in-iteration.js");
        }
    }
}
