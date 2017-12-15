using Xunit;

namespace NetScriptTest.annexB.built﹏ins.String.prototype
{
    public sealed class Test_substr : BaseTest
    {
        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/B.2.3.js")]
        public void Test_B_2_3_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/B.2.3.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/length-falsey.js")]
        public void Test_length﹏falsey_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/length-falsey.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/length-negative.js")]
        public void Test_length﹏negative_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/length-negative.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/length-positive.js")]
        public void Test_length﹏positive_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/length-positive.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/length-to-int-err.js")]
        public void Test_length﹏to﹏int﹏err_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/length-to-int-err.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/length-undef.js")]
        public void Test_length﹏undef_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/length-undef.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/length.js")]
        public void Test_length_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/length.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/name.js")]
        public void Test_name_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/name.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/start-negative.js")]
        public void Test_start﹏negative_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/start-negative.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/start-to-int-err.js")]
        public void Test_start﹏to﹏int﹏err_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/start-to-int-err.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/surrogate-pairs.js")]
        public void Test_surrogate﹏pairs_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/surrogate-pairs.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/this-non-obj-coerce.js")]
        public void Test_this﹏non﹏obj﹏coerce_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/this-non-obj-coerce.js");
        }

        [Fact(DisplayName = "/annexB/built-ins/String/prototype/substr/this-to-str-err.js")]
        public void Test_this﹏to﹏str﹏err_js()
        {
            RunTest("annexB/built-ins/String/prototype/substr/this-to-str-err.js");
        }
    }
}
