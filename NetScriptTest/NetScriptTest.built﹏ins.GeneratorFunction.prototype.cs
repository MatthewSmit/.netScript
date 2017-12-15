using Xunit;

namespace NetScriptTest.built﹏ins.GeneratorFunction
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/built-ins/GeneratorFunction/prototype/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/GeneratorFunction/prototype/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/GeneratorFunction/prototype/extensibility.js")]
        public void Test_extensibility_js()
        {
            RunTest("built-ins/GeneratorFunction/prototype/extensibility.js");
        }

        [Fact(DisplayName = "/built-ins/GeneratorFunction/prototype/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/GeneratorFunction/prototype/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/GeneratorFunction/prototype/prototype.js")]
        public void Test_prototype_js()
        {
            RunTest("built-ins/GeneratorFunction/prototype/prototype.js");
        }

        [Fact(DisplayName = "/built-ins/GeneratorFunction/prototype/Symbol.toStringTag.js")]
        public void Test_Symbol_toStringTag_js()
        {
            RunTest("built-ins/GeneratorFunction/prototype/Symbol.toStringTag.js");
        }
    }
}
