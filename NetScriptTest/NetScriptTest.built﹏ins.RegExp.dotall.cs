using Xunit;

namespace NetScriptTest.built﹏ins.RegExp
{
    public sealed class Test_dotall : BaseTest
    {
        [Fact(DisplayName = "/built-ins/RegExp/dotall/with-dotall-unicode.js")]
        public void Test_with﹏dotall﹏unicode_js()
        {
            RunTest("built-ins/RegExp/dotall/with-dotall-unicode.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/dotall/with-dotall.js")]
        public void Test_with﹏dotall_js()
        {
            RunTest("built-ins/RegExp/dotall/with-dotall.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/dotall/without-dotall-unicode.js")]
        public void Test_without﹏dotall﹏unicode_js()
        {
            RunTest("built-ins/RegExp/dotall/without-dotall-unicode.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/dotall/without-dotall.js")]
        public void Test_without﹏dotall_js()
        {
            RunTest("built-ins/RegExp/dotall/without-dotall.js");
        }
    }
}
