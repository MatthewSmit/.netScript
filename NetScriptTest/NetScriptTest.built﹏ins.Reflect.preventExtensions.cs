using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_preventExtensions : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/always-return-true-from-ordinary-object.js")]
        public void Test_always﹏return﹏true﹏from﹏ordinary﹏object_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/always-return-true-from-ordinary-object.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/prevent-extensions.js")]
        public void Test_prevent﹏extensions_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/prevent-extensions.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/preventExtensions.js")]
        public void Test_preventExtensions_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/preventExtensions.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/return-boolean-from-proxy-object.js")]
        public void Test_return﹏boolean﹏from﹏proxy﹏object_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/return-boolean-from-proxy-object.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/preventExtensions/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/preventExtensions/target-is-symbol-throws.js");
        }
    }
}
