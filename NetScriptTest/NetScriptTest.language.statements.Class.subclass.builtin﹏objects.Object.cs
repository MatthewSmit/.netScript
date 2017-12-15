using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_Object : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Object/constructor-return-undefined-throws.js")]
        public void Test_constructor﹏return﹏undefined﹏throws_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Object/constructor-return-undefined-throws.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Object/constructor-returns-non-object.js")]
        public void Test_constructor﹏returns﹏non﹏object_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Object/constructor-returns-non-object.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Object/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Object/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Object/replacing-prototype.js")]
        public void Test_replacing﹏prototype_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Object/replacing-prototype.js");
        }
    }
}
