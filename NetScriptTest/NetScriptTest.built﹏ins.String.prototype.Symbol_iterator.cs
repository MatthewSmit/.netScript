using Xunit;

namespace NetScriptTest.built﹏ins.String.prototype
{
    public sealed class Test_Symbol_iterator : BaseTest
    {
        [Fact(DisplayName = "/built-ins/String/prototype/Symbol.iterator/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/String/prototype/Symbol.iterator/length.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/Symbol.iterator/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/String/prototype/Symbol.iterator/name.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/Symbol.iterator/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/String/prototype/Symbol.iterator/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/Symbol.iterator/this-val-non-obj-coercible.js")]
        public void Test_this﹏val﹏non﹏obj﹏coercible_js()
        {
            RunTest("built-ins/String/prototype/Symbol.iterator/this-val-non-obj-coercible.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/Symbol.iterator/this-val-to-str-err.js")]
        public void Test_this﹏val﹏to﹏str﹏err_js()
        {
            RunTest("built-ins/String/prototype/Symbol.iterator/this-val-to-str-err.js");
        }
    }
}
