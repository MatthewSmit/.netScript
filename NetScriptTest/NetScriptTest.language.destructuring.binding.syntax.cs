using Xunit;

namespace NetScriptTest.language.destructuring.binding
{
    public sealed class Test_syntax : BaseTest
    {
        [Fact(DisplayName = "/language/destructuring/binding/syntax/array-elements-with-initializer.js")]
        public void Test_array﹏elements﹏with﹏initializer_js()
        {
            RunTest("language/destructuring/binding/syntax/array-elements-with-initializer.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/array-elements-with-object-patterns.js")]
        public void Test_array﹏elements﹏with﹏object﹏patterns_js()
        {
            RunTest("language/destructuring/binding/syntax/array-elements-with-object-patterns.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/array-elements-without-initializer.js")]
        public void Test_array﹏elements﹏without﹏initializer_js()
        {
            RunTest("language/destructuring/binding/syntax/array-elements-without-initializer.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/array-pattern-with-elisions.js")]
        public void Test_array﹏pattern﹏with﹏elisions_js()
        {
            RunTest("language/destructuring/binding/syntax/array-pattern-with-elisions.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/array-pattern-with-no-elements.js")]
        public void Test_array﹏pattern﹏with﹏no﹏elements_js()
        {
            RunTest("language/destructuring/binding/syntax/array-pattern-with-no-elements.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/array-rest-elements.js")]
        public void Test_array﹏rest﹏elements_js()
        {
            RunTest("language/destructuring/binding/syntax/array-rest-elements.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/object-pattern-with-no-property-list.js")]
        public void Test_object﹏pattern﹏with﹏no﹏property﹏list_js()
        {
            RunTest("language/destructuring/binding/syntax/object-pattern-with-no-property-list.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/property-list-bindings-elements.js")]
        public void Test_property﹏list﹏bindings﹏elements_js()
        {
            RunTest("language/destructuring/binding/syntax/property-list-bindings-elements.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/property-list-followed-by-a-single-comma.js")]
        public void Test_property﹏list﹏followed﹏by﹏a﹏single﹏comma_js()
        {
            RunTest("language/destructuring/binding/syntax/property-list-followed-by-a-single-comma.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/property-list-single-name-bindings.js")]
        public void Test_property﹏list﹏single﹏name﹏bindings_js()
        {
            RunTest("language/destructuring/binding/syntax/property-list-single-name-bindings.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/property-list-with-property-list.js")]
        public void Test_property﹏list﹏with﹏property﹏list_js()
        {
            RunTest("language/destructuring/binding/syntax/property-list-with-property-list.js");
        }

        [Fact(DisplayName = "/language/destructuring/binding/syntax/recursive-array-and-object-patterns.js")]
        public void Test_recursive﹏array﹏and﹏object﹏patterns_js()
        {
            RunTest("language/destructuring/binding/syntax/recursive-array-and-object-patterns.js");
        }
    }
}
