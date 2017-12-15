using Xunit;

namespace NetScriptTest.built﹏ins.Object
{
    public sealed class Test_getOwnPropertyDescriptors : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/exception-not-object-coercible.js")]
        public void Test_exception﹏not﹏object﹏coercible_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/exception-not-object-coercible.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/function-length.js")]
        public void Test_function﹏length_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/function-length.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/function-name.js")]
        public void Test_function﹏name_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/function-name.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/function-property-descriptor.js")]
        public void Test_function﹏property﹏descriptor_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/function-property-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/inherited-properties-omitted.js")]
        public void Test_inherited﹏properties﹏omitted_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/inherited-properties-omitted.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/normal-object.js")]
        public void Test_normal﹏object_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/normal-object.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/observable-operations.js")]
        public void Test_observable﹏operations_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/observable-operations.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/primitive-booleans.js")]
        public void Test_primitive﹏booleans_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/primitive-booleans.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/primitive-numbers.js")]
        public void Test_primitive﹏numbers_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/primitive-numbers.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/primitive-strings.js")]
        public void Test_primitive﹏strings_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/primitive-strings.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/primitive-symbols.js")]
        public void Test_primitive﹏symbols_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/primitive-symbols.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/proxy-undefined-descriptor.js")]
        public void Test_proxy﹏undefined﹏descriptor_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/proxy-undefined-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/symbols-included.js")]
        public void Test_symbols﹏included_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/symbols-included.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/tamper-with-global-object.js")]
        public void Test_tamper﹏with﹏global﹏object_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/tamper-with-global-object.js");
        }

        [Fact(DisplayName = "/built-ins/Object/getOwnPropertyDescriptors/tamper-with-object-keys.js")]
        public void Test_tamper﹏with﹏object﹏keys_js()
        {
            RunTest("built-ins/Object/getOwnPropertyDescriptors/tamper-with-object-keys.js");
        }
    }
}
