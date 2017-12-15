using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_ArrayBuffer : BaseTest
    {
        [Fact(DisplayName = "/built-ins/ArrayBuffer/allocation-limit.js")]
        public void Test_allocation﹏limit_js()
        {
            RunTest("built-ins/ArrayBuffer/allocation-limit.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/data-allocation-after-object-creation.js")]
        public void Test_data﹏allocation﹏after﹏object﹏creation_js()
        {
            RunTest("built-ins/ArrayBuffer/data-allocation-after-object-creation.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/init-zero.js")]
        public void Test_init﹏zero_js()
        {
            RunTest("built-ins/ArrayBuffer/init-zero.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/length-is-absent.js")]
        public void Test_length﹏is﹏absent_js()
        {
            RunTest("built-ins/ArrayBuffer/length-is-absent.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/length-is-too-large-throws.js")]
        public void Test_length﹏is﹏too﹏large﹏throws_js()
        {
            RunTest("built-ins/ArrayBuffer/length-is-too-large-throws.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/ArrayBuffer/length.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/ArrayBuffer/name.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/negative-length-throws.js")]
        public void Test_negative﹏length﹏throws_js()
        {
            RunTest("built-ins/ArrayBuffer/negative-length-throws.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/newtarget-prototype-is-not-object.js")]
        public void Test_newtarget﹏prototype﹏is﹏not﹏object_js()
        {
            RunTest("built-ins/ArrayBuffer/newtarget-prototype-is-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/ArrayBuffer/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/proto-from-ctor-realm.js")]
        public void Test_proto﹏from﹏ctor﹏realm_js()
        {
            RunTest("built-ins/ArrayBuffer/proto-from-ctor-realm.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/prototype-from-newtarget.js")]
        public void Test_prototype﹏from﹏newtarget_js()
        {
            RunTest("built-ins/ArrayBuffer/prototype-from-newtarget.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/return-abrupt-from-length-symbol.js")]
        public void Test_return﹏abrupt﹏from﹏length﹏symbol_js()
        {
            RunTest("built-ins/ArrayBuffer/return-abrupt-from-length-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/return-abrupt-from-length.js")]
        public void Test_return﹏abrupt﹏from﹏length_js()
        {
            RunTest("built-ins/ArrayBuffer/return-abrupt-from-length.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/toindex-length.js")]
        public void Test_toindex﹏length_js()
        {
            RunTest("built-ins/ArrayBuffer/toindex-length.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/undefined-newtarget-throws.js")]
        public void Test_undefined﹏newtarget﹏throws_js()
        {
            RunTest("built-ins/ArrayBuffer/undefined-newtarget-throws.js");
        }

        [Fact(DisplayName = "/built-ins/ArrayBuffer/zero-length.js")]
        public void Test_zero﹏length_js()
        {
            RunTest("built-ins/ArrayBuffer/zero-length.js");
        }
    }
}
