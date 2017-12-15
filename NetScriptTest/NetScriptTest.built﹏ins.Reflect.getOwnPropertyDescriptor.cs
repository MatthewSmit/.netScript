using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_getOwnPropertyDescriptor : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/getOwnPropertyDescriptor.js")]
        public void Test_getOwnPropertyDescriptor_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/getOwnPropertyDescriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/return-abrupt-from-property-key.js")]
        public void Test_return﹏abrupt﹏from﹏property﹏key_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/return-abrupt-from-property-key.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/return-from-accessor-descriptor.js")]
        public void Test_return﹏from﹏accessor﹏descriptor_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/return-from-accessor-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/return-from-data-descriptor.js")]
        public void Test_return﹏from﹏data﹏descriptor_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/return-from-data-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/symbol-property.js")]
        public void Test_symbol﹏property_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/symbol-property.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/target-is-symbol-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/undefined-own-property.js")]
        public void Test_undefined﹏own﹏property_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/undefined-own-property.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/getOwnPropertyDescriptor/undefined-property.js")]
        public void Test_undefined﹏property_js()
        {
            RunTest("built-ins/Reflect/getOwnPropertyDescriptor/undefined-property.js");
        }
    }
}
