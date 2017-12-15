using Xunit;

namespace NetScriptTest.built﹏ins.Object
{
    public sealed class Test_getOwnPropertySymbols : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Object/getOwnPropertySymbols/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Object/getOwnPropertySymbols/length.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertySymbols/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Object/getOwnPropertySymbols/name.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertySymbols/object-contains-symbol-property-with-description.js")]
        public void Test_object﹏contains﹏symbol﹏property﹏with﹏description_js()
        {
            RunTest("built-ins/Object/getOwnPropertySymbols/object-contains-symbol-property-with-description.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertySymbols/object-contains-symbol-property-without-description.js")]
        public void Test_object﹏contains﹏symbol﹏property﹏without﹏description_js()
        {
            RunTest("built-ins/Object/getOwnPropertySymbols/object-contains-symbol-property-without-description.js");
        }
    }
}
