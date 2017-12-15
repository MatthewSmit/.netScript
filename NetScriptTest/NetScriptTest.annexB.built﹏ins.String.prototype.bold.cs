using Xunit;

namespace NetScriptTest.annexB.built﹏ins.String.prototype
{
    public sealed class Test_bold : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/String/prototype/bold/B.2.3.5.js")]
        public void Test_B_2_3_5_js()
        {
            RunTest("annexB/built-ins/String/prototype/bold/B.2.3.5.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/bold/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/String/prototype/bold/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/bold/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/String/prototype/bold/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/bold/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("annexB/built-ins/String/prototype/bold/prop-desc.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/bold/this-val-tostring-err.js")]
        public void Test_this﹏val﹏tostring﹏err_js()
        {
            RunTest("annexB/built-ins/String/prototype/bold/this-val-tostring-err.js");
        }
    }
}
