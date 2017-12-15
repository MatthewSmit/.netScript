using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_Symbol : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/auto-boxing-non-strict.js")]
        public void Test_auto﹏boxing﹏non﹏strict_js()
        {
            RunTest("built-ins/Symbol/auto-boxing-non-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/auto-boxing-strict.js")]
        public void Test_auto﹏boxing﹏strict_js()
        {
            RunTest("built-ins/Symbol/auto-boxing-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/Symbol/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/desc-to-string-symbol.js")]
        public void Test_desc﹏to﹏string﹏symbol_js()
        {
            RunTest("built-ins/Symbol/desc-to-string-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/desc-to-string.js")]
        public void Test_desc﹏to﹏string_js()
        {
            RunTest("built-ins/Symbol/desc-to-string.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/invoked-with-new.js")]
        public void Test_invoked﹏with﹏new_js()
        {
            RunTest("built-ins/Symbol/invoked-with-new.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Symbol/length.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Symbol/name.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/symbol.js")]
        public void Test_symbol_js()
        {
            RunTest("built-ins/Symbol/symbol.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/uniqueness.js")]
        public void Test_uniqueness_js()
        {
            RunTest("built-ins/Symbol/uniqueness.js");
        }
    }
}
