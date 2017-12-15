using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays.internals
{
    public sealed class Test_DefineOwnProperty : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/conversion-operation-consistent-nan.js")]
        public void Test_conversion﹏operation﹏consistent﹏nan_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/conversion-operation-consistent-nan.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/conversion-operation.js")]
        public void Test_conversion﹏operation_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/conversion-operation.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/desc-value-throws.js")]
        public void Test_desc﹏value﹏throws_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/desc-value-throws.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/detached-buffer-realm.js")]
        public void Test_detached﹏buffer﹏realm_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/detached-buffer-realm.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/detached-buffer.js")]
        public void Test_detached﹏buffer_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/detached-buffer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-greater-than-last-index.js")]
        public void Test_key﹏is﹏greater﹏than﹏last﹏index_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-greater-than-last-index.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-lower-than-zero.js")]
        public void Test_key﹏is﹏lower﹏than﹏zero_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-lower-than-zero.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-minus-zero.js")]
        public void Test_key﹏is﹏minus﹏zero_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-minus-zero.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-not-canonical-index.js")]
        public void Test_key﹏is﹏not﹏canonical﹏index_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-not-canonical-index.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-not-integer.js")]
        public void Test_key﹏is﹏not﹏integer_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-not-integer.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-not-numeric-index.js")]
        public void Test_key﹏is﹏not﹏numeric﹏index_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-not-numeric-index.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-accessor-desc.js")]
        public void Test_key﹏is﹏numericindex﹏accessor﹏desc_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-accessor-desc.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-desc-configurable.js")]
        public void Test_key﹏is﹏numericindex﹏desc﹏configurable_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-desc-configurable.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-desc-not-enumerable.js")]
        public void Test_key﹏is﹏numericindex﹏desc﹏not﹏enumerable_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-desc-not-enumerable.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-desc-not-writable.js")]
        public void Test_key﹏is﹏numericindex﹏desc﹏not﹏writable_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex-desc-not-writable.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex.js")]
        public void Test_key﹏is﹏numericindex_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-numericindex.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/key-is-symbol.js")]
        public void Test_key﹏is﹏symbol_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/key-is-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/non-extensible-new-key.js")]
        public void Test_non﹏extensible﹏new﹏key_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/non-extensible-new-key.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/non-extensible-redefine-key.js")]
        public void Test_non﹏extensible﹏redefine﹏key_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/non-extensible-redefine-key.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/set-value.js")]
        public void Test_set﹏value_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/set-value.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/this-is-not-extensible.js")]
        public void Test_this﹏is﹏not﹏extensible_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/this-is-not-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/DefineOwnProperty/tonumber-value-detached-buffer.js")]
        public void Test_tonumber﹏value﹏detached﹏buffer_js()
        {
            RunTest("built-ins/TypedArrays/internals/DefineOwnProperty/tonumber-value-detached-buffer.js");
        }
    }
}
