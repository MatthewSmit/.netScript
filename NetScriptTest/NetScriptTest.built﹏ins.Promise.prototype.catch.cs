using Xunit;

namespace NetScriptTest.built﹏ins.Promise.prototype
{
    public sealed class Test_catch : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/invokes-then.js")]
        public void Test_invokes﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/catch/invokes-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Promise/prototype/catch/length.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Promise/prototype/catch/name.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Promise/prototype/catch/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/S25.4.5.1_A1.1_T1.js")]
        public void Test_S25_4_5_1_A1_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/catch/S25.4.5.1_A1.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/S25.4.5.1_A2.1_T1.js")]
        public void Test_S25_4_5_1_A2_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/catch/S25.4.5.1_A2.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/S25.4.5.1_A3.1_T1.js")]
        public void Test_S25_4_5_1_A3_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/catch/S25.4.5.1_A3.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/S25.4.5.1_A3.1_T2.js")]
        public void Test_S25_4_5_1_A3_1_T2_js()
        {
            RunTest("built-ins/Promise/prototype/catch/S25.4.5.1_A3.1_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/this-value-non-object.js")]
        public void Test_this﹏value﹏non﹏object_js()
        {
            RunTest("built-ins/Promise/prototype/catch/this-value-non-object.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/this-value-obj-coercible.js")]
        public void Test_this﹏value﹏obj﹏coercible_js()
        {
            RunTest("built-ins/Promise/prototype/catch/this-value-obj-coercible.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/this-value-then-not-callable.js")]
        public void Test_this﹏value﹏then﹏not﹏callable_js()
        {
            RunTest("built-ins/Promise/prototype/catch/this-value-then-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/this-value-then-poisoned.js")]
        public void Test_this﹏value﹏then﹏poisoned_js()
        {
            RunTest("built-ins/Promise/prototype/catch/this-value-then-poisoned.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/catch/this-value-then-throws.js")]
        public void Test_this﹏value﹏then﹏throws_js()
        {
            RunTest("built-ins/Promise/prototype/catch/this-value-then-throws.js");
        }
    }
}
