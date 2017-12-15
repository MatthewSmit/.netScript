using Xunit;

namespace NetScriptTest.language.literals
{
    public sealed class Test_bigint : BaseTest
    {
        [Fact(DisplayName = "/language/literals/bigint/binary-invalid-digit.js")]
        public void Test_binary﹏invalid﹏digit_js()
        {
            RunTest("language/literals/bigint/binary-invalid-digit.js");
        }

        [Fact(DisplayName = "/language/literals/bigint/exponent-part.js")]
        public void Test_exponent﹏part_js()
        {
            RunTest("language/literals/bigint/exponent-part.js");
        }

        [Fact(DisplayName = "/language/literals/bigint/hexadecimal-invalid-digit.js")]
        public void Test_hexadecimal﹏invalid﹏digit_js()
        {
            RunTest("language/literals/bigint/hexadecimal-invalid-digit.js");
        }

        [Fact(DisplayName = "/language/literals/bigint/mv-is-not-integer-dil-dot-dds.js")]
        public void Test_mv﹏is﹏not﹏integer﹏dil﹏dot﹏dds_js()
        {
            RunTest("language/literals/bigint/mv-is-not-integer-dil-dot-dds.js");
        }

        [Fact(DisplayName = "/language/literals/bigint/mv-is-not-integer-dot-dds.js")]
        public void Test_mv﹏is﹏not﹏integer﹏dot﹏dds_js()
        {
            RunTest("language/literals/bigint/mv-is-not-integer-dot-dds.js");
        }

        [Fact(DisplayName = "/language/literals/bigint/octal-invalid-digit.js")]
        public void Test_octal﹏invalid﹏digit_js()
        {
            RunTest("language/literals/bigint/octal-invalid-digit.js");
        }
    }
}
