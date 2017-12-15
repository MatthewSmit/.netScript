using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_Proxy : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Proxy/no-prototype-throws.js")]
        public void Test_no﹏prototype﹏throws_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Proxy/no-prototype-throws.js");
        }
    }
}
