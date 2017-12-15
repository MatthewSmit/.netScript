using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_getOwnPropertyDescriptor : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined-target-is-not-extensible.js")]
        public void Test_result﹏is﹏undefined﹏target﹏is﹏not﹏extensible_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined-target-is-not-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined-targetdesc-is-not-configurable.js")]
        public void Test_result﹏is﹏undefined﹏targetdesc﹏is﹏not﹏configurable_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined-targetdesc-is-not-configurable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined-targetdesc-is-undefined.js")]
        public void Test_result﹏is﹏undefined﹏targetdesc﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined-targetdesc-is-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined.js")]
        public void Test_result﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/result-is-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/result-type-is-not-object-nor-undefined-realm.js")]
        public void Test_result﹏type﹏is﹏not﹏object﹏nor﹏undefined﹏realm_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/result-type-is-not-object-nor-undefined-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/result-type-is-not-object-nor-undefined.js")]
        public void Test_result﹏type﹏is﹏not﹏object﹏nor﹏undefined_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/result-type-is-not-object-nor-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-is-invalid-descriptor.js")]
        public void Test_resultdesc﹏is﹏invalid﹏descriptor_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-is-invalid-descriptor.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-is-not-configurable-targetdesc-is-configurable.js")]
        public void Test_resultdesc﹏is﹏not﹏configurable﹏targetdesc﹏is﹏configurable_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-is-not-configurable-targetdesc-is-configurable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-is-not-configurable-targetdesc-is-undefined.js")]
        public void Test_resultdesc﹏is﹏not﹏configurable﹏targetdesc﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-is-not-configurable-targetdesc-is-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-return-configurable.js")]
        public void Test_resultdesc﹏return﹏configurable_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-return-configurable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-return-not-configurable.js")]
        public void Test_resultdesc﹏return﹏not﹏configurable_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/resultdesc-return-not-configurable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/return-is-abrupt.js")]
        public void Test_return﹏is﹏abrupt_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/return-is-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getOwnPropertyDescriptor/trap-is-undefined.js")]
        public void Test_trap﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/getOwnPropertyDescriptor/trap-is-undefined.js");
        }
    }
}
