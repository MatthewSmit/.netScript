using Xunit;

namespace NetScriptTest.built﹏ins.ArrayIteratorPrototype
{
    public sealed class Test_Symbol_toStringTag : BaseTest
    {
        [Fact(DisplayName = "/built-ins/ArrayIteratorPrototype/Symbol.toStringTag/property-descriptor.js")]
        public void Test_property﹏descriptor_js()
        {
            RunTest("built-ins/ArrayIteratorPrototype/Symbol.toStringTag/property-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayIteratorPrototype/Symbol.toStringTag/value-direct.js")]
        public void Test_value﹏direct_js()
        {
            RunTest("built-ins/ArrayIteratorPrototype/Symbol.toStringTag/value-direct.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayIteratorPrototype/Symbol.toStringTag/value-from-to-string.js")]
        public void Test_value﹏from﹏to﹏string_js()
        {
            RunTest("built-ins/ArrayIteratorPrototype/Symbol.toStringTag/value-from-to-string.js");
        }
    }
}
