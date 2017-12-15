using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_preventExtensions : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/return-false.js")]
        public void Test_return﹏false_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/return-false.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/return-is-abrupt.js")]
        public void Test_return﹏is﹏abrupt_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/return-is-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/return-true-target-is-extensible.js")]
        public void Test_return﹏true﹏target﹏is﹏extensible_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/return-true-target-is-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/return-true-target-is-not-extensible.js")]
        public void Test_return﹏true﹏target﹏is﹏not﹏extensible_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/return-true-target-is-not-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/preventExtensions/trap-is-undefined.js")]
        public void Test_trap﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/preventExtensions/trap-is-undefined.js");
        }
    }
}
