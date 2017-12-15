using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_construct : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/construct/arguments-list-is-not-array-like.js")]
        public void Test_arguments﹏list﹏is﹏not﹏array﹏like_js()
        {
            RunTest("built-ins/Reflect/construct/arguments-list-is-not-array-like.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/construct.js")]
        public void Test_construct_js()
        {
            RunTest("built-ins/Reflect/construct/construct.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/construct/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/construct/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/newtarget-is-not-constructor-throws.js")]
        public void Test_newtarget﹏is﹏not﹏constructor﹏throws_js()
        {
            RunTest("built-ins/Reflect/construct/newtarget-is-not-constructor-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/return-with-newtarget-argument.js")]
        public void Test_return﹏with﹏newtarget﹏argument_js()
        {
            RunTest("built-ins/Reflect/construct/return-with-newtarget-argument.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/return-without-newtarget-argument.js")]
        public void Test_return﹏without﹏newtarget﹏argument_js()
        {
            RunTest("built-ins/Reflect/construct/return-without-newtarget-argument.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/target-is-not-constructor-throws.js")]
        public void Test_target﹏is﹏not﹏constructor﹏throws_js()
        {
            RunTest("built-ins/Reflect/construct/target-is-not-constructor-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/construct/use-arguments-list.js")]
        public void Test_use﹏arguments﹏list_js()
        {
            RunTest("built-ins/Reflect/construct/use-arguments-list.js");
        }
    }
}
