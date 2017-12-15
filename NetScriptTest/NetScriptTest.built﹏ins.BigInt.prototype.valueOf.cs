using Xunit;

namespace NetScriptTest.built﹏ins.BigInt.prototype
{
    public sealed class Test_valueOf : BaseTest
    {
        [Fact(DisplayName = "/built-ins/BigInt/prototype/valueOf/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/BigInt/prototype/valueOf/length.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/valueOf/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/BigInt/prototype/valueOf/name.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/valueOf/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/BigInt/prototype/valueOf/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/valueOf/return.js")]
        public void Test_return_js()
        {
            RunTest("built-ins/BigInt/prototype/valueOf/return.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/valueOf/this-value-invalid-object-throws.js")]
        public void Test_this﹏value﹏invalid﹏object﹏throws_js()
        {
            RunTest("built-ins/BigInt/prototype/valueOf/this-value-invalid-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/valueOf/this-value-invalid-primitive-throws.js")]
        public void Test_this﹏value﹏invalid﹏primitive﹏throws_js()
        {
            RunTest("built-ins/BigInt/prototype/valueOf/this-value-invalid-primitive-throws.js");
        }
    }
}
