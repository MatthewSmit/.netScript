using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_get : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/get/get.js")]
        public void Test_get_js()
        {
            RunTest("built-ins/Reflect/get/get.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/get/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/get/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/return-abrupt-from-property-key.js")]
        public void Test_return﹏abrupt﹏from﹏property﹏key_js()
        {
            RunTest("built-ins/Reflect/get/return-abrupt-from-property-key.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/get/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/return-value-from-receiver.js")]
        public void Test_return﹏value﹏from﹏receiver_js()
        {
            RunTest("built-ins/Reflect/get/return-value-from-receiver.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/return-value-from-symbol-key.js")]
        public void Test_return﹏value﹏from﹏symbol﹏key_js()
        {
            RunTest("built-ins/Reflect/get/return-value-from-symbol-key.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/return-value.js")]
        public void Test_return﹏value_js()
        {
            RunTest("built-ins/Reflect/get/return-value.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/get/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/get/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/get/target-is-symbol-throws.js");
        }
    }
}
