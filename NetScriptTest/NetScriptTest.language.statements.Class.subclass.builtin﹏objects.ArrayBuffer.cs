using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_ArrayBuffer : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/ArrayBuffer/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/ArrayBuffer/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/ArrayBuffer/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/ArrayBuffer/super-must-be-called.js");
        }
    }
}
