using Xunit;

namespace NetScriptTest.annexB.built﹏ins
{
    public sealed class Test_escape : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/escape/empty-string.js")]
        public void Test_empty﹏string_js()
        {
            RunTest("annexB/built-ins/escape/empty-string.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/escape-above-astral.js")]
        public void Test_escape﹏above﹏astral_js()
        {
            RunTest("annexB/built-ins/escape/escape-above-astral.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/escape-above.js")]
        public void Test_escape﹏above_js()
        {
            RunTest("annexB/built-ins/escape/escape-above.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/escape-below.js")]
        public void Test_escape﹏below_js()
        {
            RunTest("annexB/built-ins/escape/escape-below.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/escape/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/escape/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("annexB/built-ins/escape/prop-desc.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/to-string-err-symbol.js")]
        public void Test_to﹏string﹏err﹏symbol_js()
        {
            RunTest("annexB/built-ins/escape/to-string-err-symbol.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/to-string-err.js")]
        public void Test_to﹏string﹏err_js()
        {
            RunTest("annexB/built-ins/escape/to-string-err.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/to-string-observe.js")]
        public void Test_to﹏string﹏observe_js()
        {
            RunTest("annexB/built-ins/escape/to-string-observe.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/escape/unmodified.js")]
        public void Test_unmodified_js()
        {
            RunTest("annexB/built-ins/escape/unmodified.js");
        }
    }
}
