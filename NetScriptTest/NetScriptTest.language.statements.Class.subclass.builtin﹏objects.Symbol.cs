using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_Symbol : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Symbol/new-symbol-with-super-throws.js")]
        public void Test_new﹏symbol﹏with﹏super﹏throws_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Symbol/new-symbol-with-super-throws.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Symbol/symbol-valid-as-extends-value.js")]
        public void Test_symbol﹏valid﹏as﹏extends﹏value_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Symbol/symbol-valid-as-extends-value.js");
        }
    }
}
