using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_deleteProperty : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/delete-properties.js")]
        public void Test_delete﹏properties_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/delete-properties.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/delete-symbol-properties.js")]
        public void Test_delete﹏symbol﹏properties_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/delete-symbol-properties.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/deleteProperty.js")]
        public void Test_deleteProperty_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/deleteProperty.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/return-abrupt-from-property-key.js")]
        public void Test_return﹏abrupt﹏from﹏property﹏key_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/return-abrupt-from-property-key.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/return-boolean.js")]
        public void Test_return﹏boolean_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/return-boolean.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/deleteProperty/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/deleteProperty/target-is-symbol-throws.js");
        }
    }
}
