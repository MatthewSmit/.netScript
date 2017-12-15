using Xunit;

namespace NetScriptTest.built﹏ins.String.prototype
{
    public sealed class Test_repeat : BaseTest
    {
        [Fact(DisplayName = "/built-ins/String/prototype/repeat/count-coerced-to-zero-returns-empty-string.js")]
        public void Test_count﹏coerced﹏to﹏zero﹏returns﹏empty﹏string_js()
        {
            RunTest("built-ins/String/prototype/repeat/count-coerced-to-zero-returns-empty-string.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/count-is-infinity-throws.js")]
        public void Test_count﹏is﹏infinity﹏throws_js()
        {
            RunTest("built-ins/String/prototype/repeat/count-is-infinity-throws.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/count-is-zero-returns-empty-string.js")]
        public void Test_count﹏is﹏zero﹏returns﹏empty﹏string_js()
        {
            RunTest("built-ins/String/prototype/repeat/count-is-zero-returns-empty-string.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/count-less-than-zero-throws.js")]
        public void Test_count﹏less﹏than﹏zero﹏throws_js()
        {
            RunTest("built-ins/String/prototype/repeat/count-less-than-zero-throws.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/empty-string-returns-empty.js")]
        public void Test_empty﹏string﹏returns﹏empty_js()
        {
            RunTest("built-ins/String/prototype/repeat/empty-string-returns-empty.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/String/prototype/repeat/length.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/String/prototype/repeat/name.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/repeat-string-n-times.js")]
        public void Test_repeat﹏string﹏n﹏times_js()
        {
            RunTest("built-ins/String/prototype/repeat/repeat-string-n-times.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/repeat.js")]
        public void Test_repeat_js()
        {
            RunTest("built-ins/String/prototype/repeat/repeat.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/return-abrupt-from-count-as-symbol.js")]
        public void Test_return﹏abrupt﹏from﹏count﹏as﹏symbol_js()
        {
            RunTest("built-ins/String/prototype/repeat/return-abrupt-from-count-as-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/return-abrupt-from-count.js")]
        public void Test_return﹏abrupt﹏from﹏count_js()
        {
            RunTest("built-ins/String/prototype/repeat/return-abrupt-from-count.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/return-abrupt-from-this-as-symbol.js")]
        public void Test_return﹏abrupt﹏from﹏this﹏as﹏symbol_js()
        {
            RunTest("built-ins/String/prototype/repeat/return-abrupt-from-this-as-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/return-abrupt-from-this.js")]
        public void Test_return﹏abrupt﹏from﹏this_js()
        {
            RunTest("built-ins/String/prototype/repeat/return-abrupt-from-this.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/this-is-null-throws.js")]
        public void Test_this﹏is﹏null﹏throws_js()
        {
            RunTest("built-ins/String/prototype/repeat/this-is-null-throws.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/repeat/this-is-undefined-throws.js")]
        public void Test_this﹏is﹏undefined﹏throws_js()
        {
            RunTest("built-ins/String/prototype/repeat/this-is-undefined-throws.js");
        }
    }
}
