using Xunit;

namespace NetScriptTest.built﹏ins.RegExp.prototype
{
    public sealed class Test_sticky : BaseTest
    {
        [Fact(DisplayName = "/built-ins/RegExp/prototype/sticky/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/RegExp/prototype/sticky/length.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/sticky/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/RegExp/prototype/sticky/name.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/sticky/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/RegExp/prototype/sticky/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/sticky/this-val-invalid-obj.js")]
        public void Test_this﹏val﹏invalid﹏obj_js()
        {
            RunTest("built-ins/RegExp/prototype/sticky/this-val-invalid-obj.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/sticky/this-val-non-obj.js")]
        public void Test_this﹏val﹏non﹏obj_js()
        {
            RunTest("built-ins/RegExp/prototype/sticky/this-val-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/sticky/this-val-regexp-prototype.js")]
        public void Test_this﹏val﹏regexp﹏prototype_js()
        {
            RunTest("built-ins/RegExp/prototype/sticky/this-val-regexp-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/RegExp/prototype/sticky/this-val-regexp.js")]
        public void Test_this﹏val﹏regexp_js()
        {
            RunTest("built-ins/RegExp/prototype/sticky/this-val-regexp.js");
        }
    }
}
