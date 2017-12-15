using Xunit;

namespace NetScriptTest.annexB.language.literals
{
    public sealed class Test_regexp : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/literals/regexp/class-escape.js")]
        public void Test_class﹏escape_js()
        {
            RunTest("annexB/language/literals/regexp/class-escape.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/regexp/extended-pattern-char.js")]
        public void Test_extended﹏pattern﹏char_js()
        {
            RunTest("annexB/language/literals/regexp/extended-pattern-char.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/regexp/identity-escape.js")]
        public void Test_identity﹏escape_js()
        {
            RunTest("annexB/language/literals/regexp/identity-escape.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/regexp/legacy-octal-escape.js")]
        public void Test_legacy﹏octal﹏escape_js()
        {
            RunTest("annexB/language/literals/regexp/legacy-octal-escape.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/regexp/non-empty-class-ranges-no-dash.js")]
        public void Test_non﹏empty﹏class﹏ranges﹏no﹏dash_js()
        {
            RunTest("annexB/language/literals/regexp/non-empty-class-ranges-no-dash.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/regexp/non-empty-class-ranges.js")]
        public void Test_non﹏empty﹏class﹏ranges_js()
        {
            RunTest("annexB/language/literals/regexp/non-empty-class-ranges.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/regexp/quantifiable-assertion-followed-by.js")]
        public void Test_quantifiable﹏assertion﹏followed﹏by_js()
        {
            RunTest("annexB/language/literals/regexp/quantifiable-assertion-followed-by.js");
        }

        [Fact(DisplayName = "/annexB/language/literals/regexp/quantifiable-assertion-not-followed-by.js")]
        public void Test_quantifiable﹏assertion﹏not﹏followed﹏by_js()
        {
            RunTest("annexB/language/literals/regexp/quantifiable-assertion-not-followed-by.js");
        }
    }
}
