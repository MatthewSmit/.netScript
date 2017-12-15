using Xunit;

namespace NetScriptTest.annexB.built﹏ins.String.prototype
{
    public sealed class Test_small : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/String/prototype/small/B.2.3.11.js")]
        public void Test_B_2_3_11_js()
        {
            RunTest("annexB/built-ins/String/prototype/small/B.2.3.11.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/small/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/String/prototype/small/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/small/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/String/prototype/small/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/small/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("annexB/built-ins/String/prototype/small/prop-desc.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/small/this-val-tostring-err.js")]
        public void Test_this﹏val﹏tostring﹏err_js()
        {
            RunTest("annexB/built-ins/String/prototype/small/this-val-tostring-err.js");
        }
    }
}
