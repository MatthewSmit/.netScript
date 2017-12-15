using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_GeneratorFunction : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/GeneratorFunction/instance-length.js")]
        public void Test_instance﹏length_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/GeneratorFunction/instance-length.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/GeneratorFunction/instance-name.js")]
        public void Test_instance﹏name_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/GeneratorFunction/instance-name.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/GeneratorFunction/instance-prototype.js")]
        public void Test_instance﹏prototype_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/GeneratorFunction/instance-prototype.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/GeneratorFunction/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/GeneratorFunction/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/GeneratorFunction/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/GeneratorFunction/super-must-be-called.js");
        }
    }
}
