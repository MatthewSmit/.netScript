using Xunit;

namespace NetScriptTest.built﹏ins.TypedArrays.internals
{
    public sealed class Test_OwnPropertyKeys : BaseTest
    {
        [Fact(DisplayName = "/built-ins/TypedArrays/internals/OwnPropertyKeys/integer-indexes-and-string-and-symbol-keys-.js")]
        public void Test_integer﹏indexes﹏and﹏string﹏and﹏symbol﹏keys﹏_js()
        {
            RunTest("built-ins/TypedArrays/internals/OwnPropertyKeys/integer-indexes-and-string-and-symbol-keys-.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/OwnPropertyKeys/integer-indexes-and-string-keys.js")]
        public void Test_integer﹏indexes﹏and﹏string﹏keys_js()
        {
            RunTest("built-ins/TypedArrays/internals/OwnPropertyKeys/integer-indexes-and-string-keys.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/OwnPropertyKeys/integer-indexes.js")]
        public void Test_integer﹏indexes_js()
        {
            RunTest("built-ins/TypedArrays/internals/OwnPropertyKeys/integer-indexes.js");
        }

        [Fact(DisplayName = "/built-ins/TypedArrays/internals/OwnPropertyKeys/not-enumerable-keys.js")]
        public void Test_not﹏enumerable﹏keys_js()
        {
            RunTest("built-ins/TypedArrays/internals/OwnPropertyKeys/not-enumerable-keys.js");
        }
    }
}
