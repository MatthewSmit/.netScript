using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_getPrototypeOf : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/extensible-target-return-handlerproto.js")]
        public void Test_extensible﹏target﹏return﹏handlerproto_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/extensible-target-return-handlerproto.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/not-extensible-not-same-proto-throws.js")]
        public void Test_not﹏extensible﹏not﹏same﹏proto﹏throws_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/not-extensible-not-same-proto-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/not-extensible-same-proto.js")]
        public void Test_not﹏extensible﹏same﹏proto_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/not-extensible-same-proto.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/return-is-abrupt.js")]
        public void Test_return﹏is﹏abrupt_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/return-is-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-is-undefined.js")]
        public void Test_trap﹏is﹏undefined_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-is-undefined.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-boolean.js")]
        public void Test_trap﹏result﹏neither﹏object﹏nor﹏null﹏throws﹏boolean_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-boolean.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-number.js")]
        public void Test_trap﹏result﹏neither﹏object﹏nor﹏null﹏throws﹏number_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-number.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-string.js")]
        public void Test_trap﹏result﹏neither﹏object﹏nor﹏null﹏throws﹏string_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-string.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-symbol.js")]
        public void Test_trap﹏result﹏neither﹏object﹏nor﹏null﹏throws﹏symbol_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-undefined.js")]
        public void Test_trap﹏result﹏neither﹏object﹏nor﹏null﹏throws﹏undefined_js()
        {
            RunTest("built-ins/Proxy/getPrototypeOf/trap-result-neither-object-nor-null-throws-undefined.js");
        }
    }
}
