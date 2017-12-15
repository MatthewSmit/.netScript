using Xunit;

namespace NetScriptTest.annexB.built﹏ins.String.prototype
{
    public sealed class Test_big : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/String/prototype/big/B.2.3.3.js")]
        public void Test_B_2_3_3_js()
        {
            RunTest("annexB/built-ins/String/prototype/big/B.2.3.3.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/big/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/String/prototype/big/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/big/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/String/prototype/big/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/big/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("annexB/built-ins/String/prototype/big/prop-desc.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/big/this-val-tostring-err.js")]
        public void Test_this﹏val﹏tostring﹏err_js()
        {
            RunTest("annexB/built-ins/String/prototype/big/this-val-tostring-err.js");
        }
    }
}
