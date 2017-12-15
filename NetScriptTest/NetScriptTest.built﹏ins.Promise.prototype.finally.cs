using Xunit;

namespace NetScriptTest.built﹏ins.Promise.prototype
{
    public sealed class Test_finally : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/invokes-then-with-function.js")]
        public void Test_invokes﹏then﹏with﹏function_js()
        {
            RunTest("built-ins/Promise/prototype/finally/invokes-then-with-function.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/invokes-then-with-non-function.js")]
        public void Test_invokes﹏then﹏with﹏non﹏function_js()
        {
            RunTest("built-ins/Promise/prototype/finally/invokes-then-with-non-function.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/is-a-function.js")]
        public void Test_is﹏a﹏function_js()
        {
            RunTest("built-ins/Promise/prototype/finally/is-a-function.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/is-a-method.js")]
        public void Test_is﹏a﹏method_js()
        {
            RunTest("built-ins/Promise/prototype/finally/is-a-method.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Promise/prototype/finally/length.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Promise/prototype/finally/name.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Promise/prototype/finally/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/rejected-observable-then-calls.js")]
        public void Test_rejected﹏observable﹏then﹏calls_js()
        {
            RunTest("built-ins/Promise/prototype/finally/rejected-observable-then-calls.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/rejection-reason-no-fulfill.js")]
        public void Test_rejection﹏reason﹏no﹏fulfill_js()
        {
            RunTest("built-ins/Promise/prototype/finally/rejection-reason-no-fulfill.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/rejection-reason-override-with-throw.js")]
        public void Test_rejection﹏reason﹏override﹏with﹏throw_js()
        {
            RunTest("built-ins/Promise/prototype/finally/rejection-reason-override-with-throw.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/resolution-value-no-override.js")]
        public void Test_resolution﹏value﹏no﹏override_js()
        {
            RunTest("built-ins/Promise/prototype/finally/resolution-value-no-override.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/resolved-observable-then-calls.js")]
        public void Test_resolved﹏observable﹏then﹏calls_js()
        {
            RunTest("built-ins/Promise/prototype/finally/resolved-observable-then-calls.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/species-constructor.js")]
        public void Test_species﹏constructor_js()
        {
            RunTest("built-ins/Promise/prototype/finally/species-constructor.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/species-symbol.js")]
        public void Test_species﹏symbol_js()
        {
            RunTest("built-ins/Promise/prototype/finally/species-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/this-value-non-object.js")]
        public void Test_this﹏value﹏non﹏object_js()
        {
            RunTest("built-ins/Promise/prototype/finally/this-value-non-object.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/this-value-then-not-callable.js")]
        public void Test_this﹏value﹏then﹏not﹏callable_js()
        {
            RunTest("built-ins/Promise/prototype/finally/this-value-then-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/this-value-then-poisoned.js")]
        public void Test_this﹏value﹏then﹏poisoned_js()
        {
            RunTest("built-ins/Promise/prototype/finally/this-value-then-poisoned.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/finally/this-value-then-throws.js")]
        public void Test_this﹏value﹏then﹏throws_js()
        {
            RunTest("built-ins/Promise/prototype/finally/this-value-then-throws.js");
        }
    }
}
