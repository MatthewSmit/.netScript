using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_GeneratorPrototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/GeneratorPrototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/GeneratorPrototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/GeneratorPrototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/GeneratorPrototype/Symbol.toStringTag.js");
        }
    }
}
