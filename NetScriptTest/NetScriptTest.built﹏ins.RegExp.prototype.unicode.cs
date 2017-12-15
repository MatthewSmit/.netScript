using Xunit;

namespace NetScriptTest.built﹏ins.RegExp.prototype
{
    public sealed class Test_unicode : BaseTest
    {
        [Fact(DisplayName = "/built-ins/RegExp/prototype/unicode/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/RegExp/prototype/unicode/length.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/unicode/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/RegExp/prototype/unicode/name.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/unicode/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/RegExp/prototype/unicode/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/unicode/this-val-invalid-obj.js")]
        public void Test_this﹏val﹏invalid﹏obj_js()
        {
            RunTest("built-ins/RegExp/prototype/unicode/this-val-invalid-obj.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/unicode/this-val-non-obj.js")]
        public void Test_this﹏val﹏non﹏obj_js()
        {
            RunTest("built-ins/RegExp/prototype/unicode/this-val-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/unicode/this-val-regexp-prototype.js")]
        public void Test_this﹏val﹏regexp﹏prototype_js()
        {
            RunTest("built-ins/RegExp/prototype/unicode/this-val-regexp-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/unicode/this-val-regexp.js")]
        public void Test_this﹏val﹏regexp_js()
        {
            RunTest("built-ins/RegExp/prototype/unicode/this-val-regexp.js");
        }
    }
}
