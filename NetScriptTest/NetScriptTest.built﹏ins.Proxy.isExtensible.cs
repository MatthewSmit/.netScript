using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_isExtensible : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/isExtensible/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/isExtensible/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/return-is-abrupt.js")]
        public void Test_return﹏is﹏abrupt_js()
        {
            RunTest("built-ins/Proxy/isExtensible/return-is-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/return-is-boolean.js")]
        public void Test_return﹏is﹏boolean_js()
        {
            RunTest("built-ins/Proxy/isExtensible/return-is-boolean.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/return-is-different-from-target.js")]
        public void Test_return﹏is﹏different﹏from﹏target_js()
        {
            RunTest("built-ins/Proxy/isExtensible/return-is-different-from-target.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/return-same-result-from-target.js")]
        public void Test_return﹏same﹏result﹏from﹏target_js()
        {
            RunTest("built-ins/Proxy/isExtensible/return-same-result-from-target.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/isExtensible/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/isExtensible/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/isExtensible/trap-is-undefined.js")]
        public void Test_trap﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/isExtensible/trap-is-undefined.js");
        }
    }
}
