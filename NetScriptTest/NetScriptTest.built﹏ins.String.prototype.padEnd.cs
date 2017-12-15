using Xunit;

namespace NetScriptTest.built﹏ins.String.prototype
{
    public sealed class Test_padEnd : BaseTest
    {
        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/exception-fill-string-symbol.js")]
        public void Test_exception﹏fill﹏string﹏symbol_js()
        {
            RunTest("built-ins/String/prototype/padEnd/exception-fill-string-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/exception-not-object-coercible.js")]
        public void Test_exception﹏not﹏object﹏coercible_js()
        {
            RunTest("built-ins/String/prototype/padEnd/exception-not-object-coercible.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/exception-symbol.js")]
        public void Test_exception﹏symbol_js()
        {
            RunTest("built-ins/String/prototype/padEnd/exception-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/fill-string-empty.js")]
        public void Test_fill﹏string﹏empty_js()
        {
            RunTest("built-ins/String/prototype/padEnd/fill-string-empty.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/fill-string-non-strings.js")]
        public void Test_fill﹏string﹏non﹏strings_js()
        {
            RunTest("built-ins/String/prototype/padEnd/fill-string-non-strings.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/fill-string-omitted.js")]
        public void Test_fill﹏string﹏omitted_js()
        {
            RunTest("built-ins/String/prototype/padEnd/fill-string-omitted.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/function-length.js")]
        public void Test_function﹏length_js()
        {
            RunTest("built-ins/String/prototype/padEnd/function-length.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/function-name.js")]
        public void Test_function﹏name_js()
        {
            RunTest("built-ins/String/prototype/padEnd/function-name.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/function-property-descriptor.js")]
        public void Test_function﹏property﹏descriptor_js()
        {
            RunTest("built-ins/String/prototype/padEnd/function-property-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/max-length-not-greater-than-string.js")]
        public void Test_max﹏length﹏not﹏greater﹏than﹏string_js()
        {
            RunTest("built-ins/String/prototype/padEnd/max-length-not-greater-than-string.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/normal-operation.js")]
        public void Test_normal﹏operation_js()
        {
            RunTest("built-ins/String/prototype/padEnd/normal-operation.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/padEnd/observable-operations.js")]
        public void Test_observable﹏operations_js()
        {
            RunTest("built-ins/String/prototype/padEnd/observable-operations.js");
        }
    }
}
