using Xunit;

namespace NetScriptTest.built﹏ins.Proxy
{
    public sealed class Test_setPrototypeOf : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/call-parameters.js")]
        public void Test_call﹏parameters_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/call-parameters.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/internals-call-order.js")]
        public void Test_internals﹏call﹏order_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/internals-call-order.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/not-extensible-target-not-same-target-prototype.js")]
        public void Test_not﹏extensible﹏target﹏not﹏same﹏target﹏prototype_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/not-extensible-target-not-same-target-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/not-extensible-target-same-target-prototype.js")]
        public void Test_not﹏extensible﹏target﹏same﹏target﹏prototype_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/not-extensible-target-same-target-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/null-handler.js")]
        public void Test_null﹏handler_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/null-handler.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/return-abrupt-from-get-trap.js")]
        public void Test_return﹏abrupt﹏from﹏get﹏trap_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/return-abrupt-from-get-trap.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/return-abrupt-from-isextensible-target.js")]
        public void Test_return﹏abrupt﹏from﹏isextensible﹏target_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/return-abrupt-from-isextensible-target.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/return-abrupt-from-target-getprototypeof.js")]
        public void Test_return﹏abrupt﹏from﹏target﹏getprototypeof_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/return-abrupt-from-target-getprototypeof.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/return-abrupt-from-trap.js")]
        public void Test_return﹏abrupt﹏from﹏trap_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/return-abrupt-from-trap.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/toboolean-trap-result-false.js")]
        public void Test_toboolean﹏trap﹏result﹏false_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/toboolean-trap-result-false.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/toboolean-trap-result-true-target-is-extensible.js")]
        public void Test_toboolean﹏trap﹏result﹏true﹏target﹏is﹏extensible_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/toboolean-trap-result-true-target-is-extensible.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/trap-is-not-callable-realm.js")]
        public void Test_trap﹏is﹏not﹏callable﹏realm_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/trap-is-not-callable-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/trap-is-not-callable.js")]
        public void Test_trap﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/trap-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Proxy/setPrototypeOf/trap-is-undefined-or-null.js")]
        public void Test_trap﹏is﹏undefined﹏or﹏null_js()
        {
            RunTest("built-ins/Proxy/setPrototypeOf/trap-is-undefined-or-null.js");
        }
    }
}
