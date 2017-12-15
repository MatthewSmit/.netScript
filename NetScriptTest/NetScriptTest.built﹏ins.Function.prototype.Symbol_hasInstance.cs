using Xunit;

namespace NetScriptTest.built﹏ins.Function.prototype
{
    public sealed class Test_Symbol_hasInstance : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/length.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/name.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/this-val-bound-target.js")]
        public void Test_this﹏val﹏bound﹏target_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/this-val-bound-target.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/this-val-not-callable.js")]
        public void Test_this﹏val﹏not﹏callable_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/this-val-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/this-val-poisoned-prototype.js")]
        public void Test_this﹏val﹏poisoned﹏prototype_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/this-val-poisoned-prototype.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/this-val-prototype-non-obj.js")]
        public void Test_this﹏val﹏prototype﹏non﹏obj_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/this-val-prototype-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/value-get-prototype-of-err.js")]
        public void Test_value﹏get﹏prototype﹏of﹏err_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/value-get-prototype-of-err.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/value-negative.js")]
        public void Test_value﹏negative_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/value-negative.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/value-non-obj.js")]
        public void Test_value﹏non﹏obj_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/value-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Function/prototype/Symbol.hasInstance/value-positive.js")]
        public void Test_value﹏positive_js()
        {
            RunTest("built-ins/Function/prototype/Symbol.hasInstance/value-positive.js");
        }
    }
}
