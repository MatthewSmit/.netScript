using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_apply : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/apply/apply.js")]
        public void Test_apply_js()
        {
            RunTest("built-ins/Reflect/apply/apply.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/apply/arguments-list-is-not-array-like.js")]
        public void Test_arguments﹏list﹏is﹏not﹏array﹏like_js()
        {
            RunTest("built-ins/Reflect/apply/arguments-list-is-not-array-like.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/apply/call-target.js")]
        public void Test_call﹏target_js()
        {
            RunTest("built-ins/Reflect/apply/call-target.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/apply/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/apply/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/apply/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/apply/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/apply/return-target-call-result.js")]
        public void Test_return﹏target﹏call﹏result_js()
        {
            RunTest("built-ins/Reflect/apply/return-target-call-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/apply/target-is-not-callable-throws.js")]
        public void Test_target﹏is﹏not﹏callable﹏throws_js()
        {
            RunTest("built-ins/Reflect/apply/target-is-not-callable-throws.js");
        }
    }
}
