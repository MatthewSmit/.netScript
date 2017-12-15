using Xunit;

namespace NetScriptTest.built﹏ins.BigInt.prototype
{
    public sealed class Test_toString : BaseTest
    {
        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/length.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/name.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/prototype-call.js")]
        public void Test_prototype﹏call_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/prototype-call.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/radix-2-to-36.js")]
        public void Test_radix﹏2﹏to﹏36_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/radix-2-to-36.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/radix-err.js")]
        public void Test_radix﹏err_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/radix-err.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/string-is-code-units-of-decimal-digits-only.js")]
        public void Test_string﹏is﹏code﹏units﹏of﹏decimal﹏digits﹏only_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/string-is-code-units-of-decimal-digits-only.js");
        }

        [Fact(DisplayName = "/built-ins/BigInt/prototype/toString/thisbigintvalue-not-valid-throws.js")]
        public void Test_thisbigintvalue﹏not﹏valid﹏throws_js()
        {
            RunTest("built-ins/BigInt/prototype/toString/thisbigintvalue-not-valid-throws.js");
        }
    }
}
