using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_ownKeys : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/ownKeys/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/ownKeys/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/ownKeys.js")]
        public void Test_ownKeys_js()
        {
            RunTest("built-ins/Reflect/ownKeys/ownKeys.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/ownKeys/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/return-array-with-own-keys-only.js")]
        public void Test_return﹏array﹏with﹏own﹏keys﹏only_js()
        {
            RunTest("built-ins/Reflect/ownKeys/return-array-with-own-keys-only.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/return-empty-array.js")]
        public void Test_return﹏empty﹏array_js()
        {
            RunTest("built-ins/Reflect/ownKeys/return-empty-array.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/return-non-enumerable-keys.js")]
        public void Test_return﹏non﹏enumerable﹏keys_js()
        {
            RunTest("built-ins/Reflect/ownKeys/return-non-enumerable-keys.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/return-on-corresponding-order.js")]
        public void Test_return﹏on﹏corresponding﹏order_js()
        {
            RunTest("built-ins/Reflect/ownKeys/return-on-corresponding-order.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/ownKeys/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/ownKeys/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/ownKeys/target-is-symbol-throws.js");
        }
    }
}
