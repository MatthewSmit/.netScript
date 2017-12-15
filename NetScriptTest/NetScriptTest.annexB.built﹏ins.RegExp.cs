using Xunit;

namespace NetScriptTest.annexB.built﹏ins
{
    public sealed class Test_RegExp : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/RegExp/incomplete_hex_unicode_escape.js")]
        public void Test_incomplete_hex_unicode_escape_js()
        {
            RunTest("annexB/built-ins/RegExp/incomplete_hex_unicode_escape.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-control-escape-russian-letter.js")]
        public void Test_RegExp﹏control﹏escape﹏russian﹏letter_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-control-escape-russian-letter.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-decimal-escape-class-range.js")]
        public void Test_RegExp﹏decimal﹏escape﹏class﹏range_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-decimal-escape-class-range.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-decimal-escape-not-capturing.js")]
        public void Test_RegExp﹏decimal﹏escape﹏not﹏capturing_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-decimal-escape-not-capturing.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-invalid-control-escape-character-class-range.js")]
        public void Test_RegExp﹏invalid﹏control﹏escape﹏character﹏class﹏range_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-invalid-control-escape-character-class-range.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-invalid-control-escape-character-class.js")]
        public void Test_RegExp﹏invalid﹏control﹏escape﹏character﹏class_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-invalid-control-escape-character-class.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-leading-escape-BMP.js")]
        public void Test_RegExp﹏leading﹏escape﹏BMP_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-leading-escape-BMP.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-leading-escape.js")]
        public void Test_RegExp﹏leading﹏escape_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-leading-escape.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-trailing-escape-BMP.js")]
        public void Test_RegExp﹏trailing﹏escape﹏BMP_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-trailing-escape-BMP.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/RegExp/RegExp-trailing-escape.js")]
        public void Test_RegExp﹏trailing﹏escape_js()
        {
            RunTest("annexB/built-ins/RegExp/RegExp-trailing-escape.js");
        }
    }
}
