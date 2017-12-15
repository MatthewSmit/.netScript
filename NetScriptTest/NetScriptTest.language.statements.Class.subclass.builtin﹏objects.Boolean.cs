using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_Boolean : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Boolean/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Boolean/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Boolean/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Boolean/super-must-be-called.js");
        }
    }
}
