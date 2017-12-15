using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_SharedArrayBuffer : BaseTest
    {
        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/allocation-limit.js")]
        public void Test_allocation﹏limit_js()
        {
            RunTest("built-ins/SharedArrayBuffer/allocation-limit.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/data-allocation-after-object-creation.js")]
        public void Test_data﹏allocation﹏after﹏object﹏creation_js()
        {
            RunTest("built-ins/SharedArrayBuffer/data-allocation-after-object-creation.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/init-zero.js")]
        public void Test_init﹏zero_js()
        {
            RunTest("built-ins/SharedArrayBuffer/init-zero.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/length-is-absent.js")]
        public void Test_length﹏is﹏absent_js()
        {
            RunTest("built-ins/SharedArrayBuffer/length-is-absent.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/length-is-too-large-throws.js")]
        public void Test_length﹏is﹏too﹏large﹏throws_js()
        {
            RunTest("built-ins/SharedArrayBuffer/length-is-too-large-throws.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/negative-length-throws.js")]
        public void Test_negative﹏length﹏throws_js()
        {
            RunTest("built-ins/SharedArrayBuffer/negative-length-throws.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/newtarget-prototype-is-not-object.js")]
        public void Test_newtarget﹏prototype﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/SharedArrayBuffer/newtarget-prototype-is-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/proto-from-ctor-realm.js")]
        public void Test_proto﹏from﹏ctor﹏realm_js()
        {
            RunTest("built-ins/SharedArrayBuffer/proto-from-ctor-realm.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/prototype-from-newtarget.js")]
        public void Test_prototype﹏from﹏newtarget_js()
        {
            RunTest("built-ins/SharedArrayBuffer/prototype-from-newtarget.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/return-abrupt-from-length-symbol.js")]
        public void Test_return﹏abrupt﹏from﹏length﹏symbol_js()
        {
            RunTest("built-ins/SharedArrayBuffer/return-abrupt-from-length-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/return-abrupt-from-length.js")]
        public void Test_return﹏abrupt﹏from﹏length_js()
        {
            RunTest("built-ins/SharedArrayBuffer/return-abrupt-from-length.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/toindex-length.js")]
        public void Test_toindex﹏length_js()
        {
            RunTest("built-ins/SharedArrayBuffer/toindex-length.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/undefined-newtarget-throws.js")]
        public void Test_undefined﹏newtarget﹏throws_js()
        {
            RunTest("built-ins/SharedArrayBuffer/undefined-newtarget-throws.js");
        }

        [Fact(DisplayName = "/built-ins/SharedArrayBuffer/zero-length.js")]
        public void Test_zero﹏length_js()
        {
            RunTest("built-ins/SharedArrayBuffer/zero-length.js");
        }
    }
}
