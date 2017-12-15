using Xunit;

namespace NetScriptTest.annexB.built﹏ins
{
    public sealed class Test_unescape : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/unescape/empty-string.js")]
        public void Test_empty﹏string_js()
        {
            RunTest("annexB/built-ins/unescape/empty-string.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/four-ignore-bad-u.js")]
        public void Test_four﹏ignore﹏bad﹏u_js()
        {
            RunTest("annexB/built-ins/unescape/four-ignore-bad-u.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/four-ignore-end-str.js")]
        public void Test_four﹏ignore﹏end﹏str_js()
        {
            RunTest("annexB/built-ins/unescape/four-ignore-end-str.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/four-ignore-non-hex.js")]
        public void Test_four﹏ignore﹏non﹏hex_js()
        {
            RunTest("annexB/built-ins/unescape/four-ignore-non-hex.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/four.js")]
        public void Test_four_js()
        {
            RunTest("annexB/built-ins/unescape/four.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/unescape/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/unescape/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("annexB/built-ins/unescape/prop-desc.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/to-string-err-symbol.js")]
        public void Test_to﹏string﹏err﹏symbol_js()
        {
            RunTest("annexB/built-ins/unescape/to-string-err-symbol.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/to-string-err.js")]
        public void Test_to﹏string﹏err_js()
        {
            RunTest("annexB/built-ins/unescape/to-string-err.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/to-string-observe.js")]
        public void Test_to﹏string﹏observe_js()
        {
            RunTest("annexB/built-ins/unescape/to-string-observe.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/two-ignore-end-str.js")]
        public void Test_two﹏ignore﹏end﹏str_js()
        {
            RunTest("annexB/built-ins/unescape/two-ignore-end-str.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/two-ignore-non-hex.js")]
        public void Test_two﹏ignore﹏non﹏hex_js()
        {
            RunTest("annexB/built-ins/unescape/two-ignore-non-hex.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/unescape/two.js")]
        public void Test_two_js()
        {
            RunTest("annexB/built-ins/unescape/two.js");
        }
    }
}
