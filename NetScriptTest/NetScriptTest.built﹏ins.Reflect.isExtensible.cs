using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_isExtensible : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/isExtensible/isExtensible.js")]
        public void Test_isExtensible_js()
        {
            RunTest("built-ins/Reflect/isExtensible/isExtensible.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/isExtensible/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/isExtensible/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/isExtensible/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/isExtensible/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/isExtensible/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/isExtensible/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/isExtensible/return-boolean.js")]
        public void Test_return﹏boolean_js()
        {
            RunTest("built-ins/Reflect/isExtensible/return-boolean.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/isExtensible/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/isExtensible/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/isExtensible/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/isExtensible/target-is-symbol-throws.js");
        }
    }
}
