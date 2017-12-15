using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_Error : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Error/message-property-assignment.js")]
        public void Test_message﹏property﹏assignment_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Error/message-property-assignment.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Error/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Error/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Error/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Error/super-must-be-called.js");
        }
    }
}
