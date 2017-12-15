using Xunit;

namespace NetScriptTest.built﹏ins.Function.internals
{
    public sealed class Test_Construct : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Function/internals/Construct/base-ctor-revoked-proxy-realm.js")]
        public void Test_base﹏ctor﹏revoked﹏proxy﹏realm_js()
        {
            RunTest("built-ins/Function/internals/Construct/base-ctor-revoked-proxy-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Function/internals/Construct/base-ctor-revoked-proxy.js")]
        public void Test_base﹏ctor﹏revoked﹏proxy_js()
        {
            RunTest("built-ins/Function/internals/Construct/base-ctor-revoked-proxy.js");
        }

        [Fact(DisplayName = "/built-ins/Function/internals/Construct/derived-return-val-realm.js")]
        public void Test_derived﹏return﹏val﹏realm_js()
        {
            RunTest("built-ins/Function/internals/Construct/derived-return-val-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Function/internals/Construct/derived-return-val.js")]
        public void Test_derived﹏return﹏val_js()
        {
            RunTest("built-ins/Function/internals/Construct/derived-return-val.js");
        }

        [Fact(DisplayName = "/built-ins/Function/internals/Construct/derived-this-uninitialized-realm.js")]
        public void Test_derived﹏this﹏uninitialized﹏realm_js()
        {
            RunTest("built-ins/Function/internals/Construct/derived-this-uninitialized-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Function/internals/Construct/derived-this-uninitialized.js")]
        public void Test_derived﹏this﹏uninitialized_js()
        {
            RunTest("built-ins/Function/internals/Construct/derived-this-uninitialized.js");
        }
    }
}
