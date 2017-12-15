using Xunit;

namespace NetScriptTest.built﹏ins.Symbol.prototype
{
    public sealed class Test_valueOf : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/prototype/valueOf/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Symbol/prototype/valueOf/length.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/valueOf/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Symbol/prototype/valueOf/name.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/valueOf/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/prototype/valueOf/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/valueOf/this-val-non-obj.js")]
        public void Test_this﹏val﹏non﹏obj_js()
        {
            RunTest("built-ins/Symbol/prototype/valueOf/this-val-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/valueOf/this-val-obj-non-symbol.js")]
        public void Test_this﹏val﹏obj﹏non﹏symbol_js()
        {
            RunTest("built-ins/Symbol/prototype/valueOf/this-val-obj-non-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/valueOf/this-val-obj-symbol.js")]
        public void Test_this﹏val﹏obj﹏symbol_js()
        {
            RunTest("built-ins/Symbol/prototype/valueOf/this-val-obj-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/valueOf/this-val-symbol.js")]
        public void Test_this﹏val﹏symbol_js()
        {
            RunTest("built-ins/Symbol/prototype/valueOf/this-val-symbol.js");
        }
    }
}
