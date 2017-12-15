using Xunit;

namespace NetScriptTest.language.statements.Class
{
    public sealed class Test_super : BaseTest
    {
        [Fact(DisplayName = "/language/statements/class/super/in-constructor.js")]
        public void Test_in﹏constructor_js()
        {
            RunTest("language/statements/class/super/in-constructor.js");
        }

        [Fact(DisplayName = "/language/statements/class/super/in-getter.js")]
        public void Test_in﹏getter_js()
        {
            RunTest("language/statements/class/super/in-getter.js");
        }

        [Fact(DisplayName = "/language/statements/class/super/in-methods.js")]
        public void Test_in﹏methods_js()
        {
            RunTest("language/statements/class/super/in-methods.js");
        }

        [Fact(DisplayName = "/language/statements/class/super/in-setter.js")]
        public void Test_in﹏setter_js()
        {
            RunTest("language/statements/class/super/in-setter.js");
        }

        [Fact(DisplayName = "/language/statements/class/super/in-static-getter.js")]
        public void Test_in﹏static﹏getter_js()
        {
            RunTest("language/statements/class/super/in-static-getter.js");
        }

        [Fact(DisplayName = "/language/statements/class/super/in-static-methods.js")]
        public void Test_in﹏static﹏methods_js()
        {
            RunTest("language/statements/class/super/in-static-methods.js");
        }

        [Fact(DisplayName = "/language/statements/class/super/in-static-setter.js")]
        public void Test_in﹏static﹏setter_js()
        {
            RunTest("language/statements/class/super/in-static-setter.js");
        }
    }
}
