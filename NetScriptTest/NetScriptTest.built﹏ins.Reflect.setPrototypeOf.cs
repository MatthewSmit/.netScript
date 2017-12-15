using Xunit;

namespace NetScriptTest.built﹏ins.Reflect
{
    public sealed class Test_setPrototypeOf : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/length.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/name.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/proto-is-not-object-and-not-null-throws.js")]
        public void Test_proto﹏is﹏not﹏object﹏and﹏not﹏null﹏throws_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/proto-is-not-object-and-not-null-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/proto-is-symbol-throws.js")]
        public void Test_proto﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/proto-is-symbol-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/return-abrupt-from-result.js")]
        public void Test_return﹏abrupt﹏from﹏result_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/return-abrupt-from-result.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/return-false-if-target-and-proto-are-the-same.js")]
        public void Test_return﹏false﹏if﹏target﹏and﹏proto﹏are﹏the﹏same_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/return-false-if-target-and-proto-are-the-same.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/return-false-if-target-is-not-extensible.js")]
        public void Test_return﹏false﹏if﹏target﹏is﹏not﹏extensible_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/return-false-if-target-is-not-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/return-false-if-target-is-prototype-of-proto.js")]
        public void Test_return﹏false﹏if﹏target﹏is﹏prototype﹏of﹏proto_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/return-false-if-target-is-prototype-of-proto.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/return-true-if-new-prototype-is-set.js")]
        public void Test_return﹏true﹏if﹏new﹏prototype﹏is﹏set_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/return-true-if-new-prototype-is-set.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/return-true-if-proto-is-current.js")]
        public void Test_return﹏true﹏if﹏proto﹏is﹏current_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/return-true-if-proto-is-current.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/setPrototypeOf.js")]
        public void Test_setPrototypeOf_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/setPrototypeOf.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/target-is-not-object-throws.js")]
        public void Test_target﹏is﹏not﹏object﹏throws_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/target-is-not-object-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Reflect/setPrototypeOf/target-is-symbol-throws.js")]
        public void Test_target﹏is﹏symbol﹏throws_js()
        {
            RunTest("built-ins/Reflect/setPrototypeOf/target-is-symbol-throws.js");
        }
    }
}
