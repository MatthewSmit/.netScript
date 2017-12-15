using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_defineProperty : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/define-properties.js")]
        public void Test_define﹏properties_js()
        {
            RunTest("built-ins/Reflect/defineProperty/define-properties.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/define-symbol-properties.js")]
        public void Test_define﹏symbol﹏properties_js()
        {
            RunTest("built-ins/Reflect/defineProperty/define-symbol-properties.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/defineProperty.js")]
        public void Test_defineProperty_js()
        {
            RunTest("built-ins/Reflect/defineProperty/defineProperty.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/defineProperty/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/defineProperty/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/return-abrupt-from-attributes.js")]
        public void Test_return﹏abrupt﹏from﹏attributes_js()
        {
            RunTest("built-ins/Reflect/defineProperty/return-abrupt-from-attributes.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/return-abrupt-from-property-key.js")]
        public void Test_return﹏abrupt﹏from﹏property﹏key_js()
        {
            RunTest("built-ins/Reflect/defineProperty/return-abrupt-from-property-key.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/defineProperty/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/return-boolean.js")]
        public void Test_return﹏boolean_js()
        {
            RunTest("built-ins/Reflect/defineProperty/return-boolean.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/defineProperty/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/defineProperty/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/defineProperty/target-is-symbol-throws.js");
        }
    }
}
