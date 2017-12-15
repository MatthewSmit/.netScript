using Xunit;

namespace NetScriptTest.language.statements.Class.subclass.builtin﹏objects
{
    public sealed class Test_Array : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Array/contructor-calls-super-multiple-arguments.js")]
        public void Test_contructor﹏calls﹏super﹏multiple﹏arguments_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Array/contructor-calls-super-multiple-arguments.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Array/contructor-calls-super-single-argument.js")]
        public void Test_contructor﹏calls﹏super﹏single﹏argument_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Array/contructor-calls-super-single-argument.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Array/length.js")]
        public void Test_length_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Array/length.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Array/regular-subclassing.js")]
        public void Test_regular﹏subclassing_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Array/regular-subclassing.js");
        }

        [Fact(DisplayName = "/language/statements/class/subclass/builtin-objects/Array/super-must-be-called.js")]
        public void Test_super﹏must﹏be﹏called_js()
        {
            RunTest("language/statements/class/subclass/builtin-objects/Array/super-must-be-called.js");
        }
    }
}
