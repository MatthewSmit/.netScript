using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_deleteProperty : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/boolean-trap-result-boolean-false.js")]
        public void Test_boolean﹏trap﹏result﹏boolean﹏false_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/boolean-trap-result-boolean-false.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/boolean-trap-result-boolean-true.js")]
        public void Test_boolean﹏trap﹏result﹏boolean﹏true_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/boolean-trap-result-boolean-true.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/return-false-not-strict.js")]
        public void Test_return﹏false﹏not﹏strict_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/return-false-not-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/return-false-strict.js")]
        public void Test_return﹏false﹏strict_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/return-false-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/return-is-abrupt.js")]
        public void Test_return﹏is﹏abrupt_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/return-is-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/targetdesc-is-not-configurable.js")]
        public void Test_targetdesc﹏is﹏not﹏configurable_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/targetdesc-is-not-configurable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/targetdesc-is-undefined-return-true.js")]
        public void Test_targetdesc﹏is﹏undefined﹏return﹏true_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/targetdesc-is-undefined-return-true.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/trap-is-undefined-not-strict.js")]
        public void Test_trap﹏is﹏undefined﹏not﹏strict_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/trap-is-undefined-not-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/deleteProperty/trap-is-undefined-strict.js")]
        public void Test_trap﹏is﹏undefined﹏strict_js()
        {
            RunTest("built-ins/Proxy/deleteProperty/trap-is-undefined-strict.js");
        }
    }
}
