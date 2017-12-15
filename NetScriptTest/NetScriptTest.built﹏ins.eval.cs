using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_eval : BaseTest
    {
        [Fact(DisplayName = "/built-ins/eval/length-enumerable.js")]
        public void Test_length﹏enumerable_js()
        {
            RunTest("built-ins/eval/length-enumerable.js");
        }

        [Fact(DisplayName = "/built-ins/eval/length-non-configurable.js")]
        public void Test_length﹏non﹏configurable_js()
        {
            RunTest("built-ins/eval/length-non-configurable.js");
        }

        [Fact(DisplayName = "/built-ins/eval/length-non-writable.js")]
        public void Test_length﹏non﹏writable_js()
        {
            RunTest("built-ins/eval/length-non-writable.js");
        }

        [Fact(DisplayName = "/built-ins/eval/length-value.js")]
        public void Test_length﹏value_js()
        {
            RunTest("built-ins/eval/length-value.js");
        }

        [Fact(DisplayName = "/built-ins/eval/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/eval/name.js");
        }

        [Fact(DisplayName = "/built-ins/eval/no-construct.js")]
        public void Test_no﹏construct_js()
        {
            RunTest("built-ins/eval/no-construct.js");
        }

        [Fact(DisplayName = "/built-ins/eval/no-proto.js")]
        public void Test_no﹏proto_js()
        {
            RunTest("built-ins/eval/no-proto.js");
        }

        [Fact(DisplayName = "/built-ins/eval/prop-desc-enumerable.js")]
        public void Test_prop﹏desc﹏enumerable_js()
        {
            RunTest("built-ins/eval/prop-desc-enumerable.js");
        }
    }
}
