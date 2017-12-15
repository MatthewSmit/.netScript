using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_Reflect : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/object-prototype.js")]
        public void Test_object﹏prototype_js()
        {
            RunTest("built-ins/Reflect/object-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/properties.js")]
        public void Test_properties_js()
        {
            RunTest("built-ins/Reflect/properties.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/Reflect.js")]
        public void Test_Reflect_js()
        {
            RunTest("built-ins/Reflect/Reflect.js");
        }
    }
}
