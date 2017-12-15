using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_NativeErrors : BaseTest
    {
        [Fact(DisplayName = "/built-ins/NativeErrors/message_property_native_error.js")]
        public void Test_message_property_native_error_js()
        {
            RunTest("built-ins/NativeErrors/message_property_native_error.js");
        }
    }
}
