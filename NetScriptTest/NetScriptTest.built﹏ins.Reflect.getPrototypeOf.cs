using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_getPrototypeOf : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/getPrototypeOf.js")]
        public void Test_getPrototypeOf_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/getPrototypeOf.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/null-prototype.js")]
        public void Test_null﹏prototype_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/null-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/return-prototype.js")]
        public void Test_return﹏prototype_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/return-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/skip-own-properties.js")]
        public void Test_skip﹏own﹏properties_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/skip-own-properties.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getPrototypeOf/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/getPrototypeOf/target-is-symbol-throws.js");
        }
    }
}
