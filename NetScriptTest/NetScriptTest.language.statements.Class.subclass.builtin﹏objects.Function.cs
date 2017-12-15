using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_Function : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Function/instance-length.js")]
        public void Test_instance﹏length_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Function/instance-length.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Function/instance-name.js")]
        public void Test_instance﹏name_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Function/instance-name.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Function/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Function/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Function/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Function/super-must-be-called.js");
        }
    }
}
