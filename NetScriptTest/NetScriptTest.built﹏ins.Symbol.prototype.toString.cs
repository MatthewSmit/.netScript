using Xunit;

namespace NetScriptTest.built﹏ins.Symbol.prototype
{
    public sealed class Test_toString : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/prototype/toString/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Symbol/prototype/toString/length.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/toString/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Symbol/prototype/toString/name.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/toString/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/prototype/toString/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/toString/toString-default-attributes-non-strict.js")]
        public void Test_toString﹏default﹏attributes﹏non﹏strict_js()
        {
            RunTest("built-ins/Symbol/prototype/toString/toString-default-attributes-non-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/toString/toString-default-attributes-strict.js")]
        public void Test_toString﹏default﹏attributes﹏strict_js()
        {
            RunTest("built-ins/Symbol/prototype/toString/toString-default-attributes-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/toString/toString.js")]
        public void Test_toString_js()
        {
            RunTest("built-ins/Symbol/prototype/toString/toString.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/prototype/toString/undefined.js")]
        public void Test_undefined_js()
        {
            RunTest("built-ins/Symbol/prototype/toString/undefined.js");
        }
    }
}
