using Xunit;

namespace NetScriptTest.annexB.built﹏ins.String.prototype
{
    public sealed class Test_fixed : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/String/prototype/fixed/B.2.3.6.js")]
        public void Test_B_2_3_6_js()
        {
            RunTest("annexB/built-ins/String/prototype/fixed/B.2.3.6.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/fixed/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/String/prototype/fixed/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/fixed/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/String/prototype/fixed/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/fixed/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("annexB/built-ins/String/prototype/fixed/prop-desc.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/fixed/this-val-tostring-err.js")]
        public void Test_this﹏val﹏tostring﹏err_js()
        {
            RunTest("annexB/built-ins/String/prototype/fixed/this-val-tostring-err.js");
        }
    }
}
