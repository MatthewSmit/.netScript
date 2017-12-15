using Xunit;

namespace NetScriptTest.built﹏ins.Symbol.prototype
{
    public sealed class Test_Symbol_toPrimitive : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toPrimitive/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toPrimitive/length.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toPrimitive/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toPrimitive/name.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toPrimitive/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toPrimitive/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-non-obj.js")]
        public void Test_this﹏val﹏non﹏obj_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-obj-non-symbol-wrapper.js")]
        public void Test_this﹏val﹏obj﹏non﹏symbol﹏wrapper_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-obj-non-symbol-wrapper.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-obj-symbol-wrapper.js")]
        public void Test_this﹏val﹏obj﹏symbol﹏wrapper_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-obj-symbol-wrapper.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-symbol.js")]
        public void Test_this﹏val﹏symbol_js()
        {
            RunTest("built-ins/Symbol/prototype/Symbol.toPrimitive/this-val-symbol.js");
        }
    }
}
