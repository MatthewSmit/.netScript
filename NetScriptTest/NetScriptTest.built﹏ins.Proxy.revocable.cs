using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_revocable : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/revocable/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Proxy/revocable/length.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Proxy/revocable/name.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/proxy.js")]
        public void Test_proxy_js()
        {
            RunTest("built-ins/Proxy/revocable/proxy.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revocation-function-extensible.js")]
        public void Test_revocation﹏function﹏extensible_js()
        {
            RunTest("built-ins/Proxy/revocable/revocation-function-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revocation-function-length.js")]
        public void Test_revocation﹏function﹏length_js()
        {
            RunTest("built-ins/Proxy/revocable/revocation-function-length.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revocation-function-name.js")]
        public void Test_revocation﹏function﹏name_js()
        {
            RunTest("built-ins/Proxy/revocable/revocation-function-name.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revocation-function-nonconstructor.js")]
        public void Test_revocation﹏function﹏nonconstructor_js()
        {
            RunTest("built-ins/Proxy/revocable/revocation-function-nonconstructor.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revocation-function-prototype.js")]
        public void Test_revocation﹏function﹏prototype_js()
        {
            RunTest("built-ins/Proxy/revocable/revocation-function-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revoke-consecutive-call-returns-undefined.js")]
        public void Test_revoke﹏consecutive﹏call﹏returns﹏undefined_js()
        {
            RunTest("built-ins/Proxy/revocable/revoke-consecutive-call-returns-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revoke-returns-undefined.js")]
        public void Test_revoke﹏returns﹏undefined_js()
        {
            RunTest("built-ins/Proxy/revocable/revoke-returns-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/revocable/revoke.js")]
        public void Test_revoke_js()
        {
            RunTest("built-ins/Proxy/revocable/revoke.js");
        }
    }
}
