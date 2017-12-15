using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_RegExp : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/RegExp/lastIndex.js")]
        public void Test_lastIndex_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/RegExp/lastIndex.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/RegExp/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/RegExp/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/RegExp/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/RegExp/super-must-be-called.js");
        }
    }
}
