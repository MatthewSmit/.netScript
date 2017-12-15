using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_apply : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/apply/arguments-realm.js")]
        public void Test_arguments﹏realm_js()
        {
            RunTest("built-ins/Proxy/apply/arguments-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/apply/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/call-result.js")]
        public void Test_call﹏result_js()
        {
            RunTest("built-ins/Proxy/apply/call-result.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/apply/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/return-abrupt.js")]
        public void Test_return﹏abrupt_js()
        {
            RunTest("built-ins/Proxy/apply/return-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/apply/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/apply/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/trap-is-null.js")]
        public void Test_trap﹏is﹏null_js()
        {
            RunTest("built-ins/Proxy/apply/trap-is-null.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/trap-is-undefined-no-property.js")]
        public void Test_trap﹏is﹏undefined﹏no﹏property_js()
        {
            RunTest("built-ins/Proxy/apply/trap-is-undefined-no-property.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/apply/trap-is-undefined.js")]
        public void Test_trap﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/apply/trap-is-undefined.js");
        }
    }
}
