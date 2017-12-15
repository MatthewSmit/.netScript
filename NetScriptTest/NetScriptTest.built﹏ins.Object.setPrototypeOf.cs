using Xunit;

namespace NetScriptTest.built﹏ins.Object
{
    public sealed class Test_setPrototypeOf : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/bigint.js")]
        public void Test_bigint_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/bigint.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/length.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/name.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/o-not-obj-coercible.js")]
        public void Test_o﹏not﹏obj﹏coercible_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/o-not-obj-coercible.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/o-not-obj.js")]
        public void Test_o﹏not﹏obj_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/o-not-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/property-descriptor.js")]
        public void Test_property﹏descriptor_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/property-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/proto-not-obj.js")]
        public void Test_proto﹏not﹏obj_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/proto-not-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/set-error.js")]
        public void Test_set﹏error_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/set-error.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/set-failure-cycle.js")]
        public void Test_set﹏failure﹏cycle_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/set-failure-cycle.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/set-failure-non-extensible.js")]
        public void Test_set﹏failure﹏non﹏extensible_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/set-failure-non-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/Object/setPrototypeOf/success.js")]
        public void Test_success_js()
        {
            RunTest("built-ins/Object/setPrototypeOf/success.js");
        }
    }
}
