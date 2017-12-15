using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_get : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/get/accessor-get-is-undefined-throws.js")]
        public void Test_accessor﹏get﹏is﹏undefined﹏throws_js()
        {
            RunTest("built-ins/Proxy/get/accessor-get-is-undefined-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/get/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/not-same-value-configurable-false-writable-false-throws.js")]
        public void Test_not﹏same﹏value﹏configurable﹏false﹏writable﹏false﹏throws_js()
        {
            RunTest("built-ins/Proxy/get/not-same-value-configurable-false-writable-false-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/get/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/return-is-abrupt.js")]
        public void Test_return﹏is﹏abrupt_js()
        {
            RunTest("built-ins/Proxy/get/return-is-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/return-trap-result-accessor-property.js")]
        public void Test_return﹏trap﹏result﹏accessor﹏property_js()
        {
            RunTest("built-ins/Proxy/get/return-trap-result-accessor-property.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/return-trap-result-configurable-false-writable-true.js")]
        public void Test_return﹏trap﹏result﹏configurable﹏false﹏writable﹏true_js()
        {
            RunTest("built-ins/Proxy/get/return-trap-result-configurable-false-writable-true.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/return-trap-result-configurable-true-assessor-get-undefined.js")]
        public void Test_return﹏trap﹏result﹏configurable﹏true﹏assessor﹏get﹏undefined_js()
        {
            RunTest("built-ins/Proxy/get/return-trap-result-configurable-true-assessor-get-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/return-trap-result-configurable-true-writable-false.js")]
        public void Test_return﹏trap﹏result﹏configurable﹏true﹏writable﹏false_js()
        {
            RunTest("built-ins/Proxy/get/return-trap-result-configurable-true-writable-false.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/return-trap-result-same-value-configurable-false-writable-false.js")]
        public void Test_return﹏trap﹏result﹏same﹏value﹏configurable﹏false﹏writable﹏false_js()
        {
            RunTest("built-ins/Proxy/get/return-trap-result-same-value-configurable-false-writable-false.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/return-trap-result.js")]
        public void Test_return﹏trap﹏result_js()
        {
            RunTest("built-ins/Proxy/get/return-trap-result.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/get/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/get/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/trap-is-undefined-no-property.js")]
        public void Test_trap﹏is﹏undefined﹏no﹏property_js()
        {
            RunTest("built-ins/Proxy/get/trap-is-undefined-no-property.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/trap-is-undefined-receiver.js")]
        public void Test_trap﹏is﹏undefined﹏receiver_js()
        {
            RunTest("built-ins/Proxy/get/trap-is-undefined-receiver.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/get/trap-is-undefined.js")]
        public void Test_trap﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/get/trap-is-undefined.js");
        }
    }
}
