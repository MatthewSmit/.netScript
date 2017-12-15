using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_String : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/String/length.js")]
        public void Test_length_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/String/length.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/String/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/String/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/String/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/String/super-must-be-called.js");
        }
    }
}
