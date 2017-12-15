using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_has : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/has/has.js")]
        public void Test_has_js()
        {
            RunTest("built-ins/Reflect/has/has.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/has/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/has/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/return-abrupt-from-property-key.js")]
        public void Test_return﹏abrupt﹏from﹏property﹏key_js()
        {
            RunTest("built-ins/Reflect/has/return-abrupt-from-property-key.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/has/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/return-boolean.js")]
        public void Test_return﹏boolean_js()
        {
            RunTest("built-ins/Reflect/has/return-boolean.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/symbol-property.js")]
        public void Test_symbol﹏property_js()
        {
            RunTest("built-ins/Reflect/has/symbol-property.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/has/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/has/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/has/target-is-symbol-throws.js");
        }
    }
}
