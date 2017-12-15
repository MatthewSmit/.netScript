using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_keyFor : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/keyFor/arg-non-symbol.js")]
        public void Test_arg﹏non﹏symbol_js()
        {
            RunTest("built-ins/Symbol/keyFor/arg-non-symbol.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/keyFor/arg-symbol-registry-hit.js")]
        public void Test_arg﹏symbol﹏registry﹏hit_js()
        {
            RunTest("built-ins/Symbol/keyFor/arg-symbol-registry-hit.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/keyFor/arg-symbol-registry-miss.js")]
        public void Test_arg﹏symbol﹏registry﹏miss_js()
        {
            RunTest("built-ins/Symbol/keyFor/arg-symbol-registry-miss.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/keyFor/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/keyFor/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/keyFor/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Symbol/keyFor/length.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/keyFor/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Symbol/keyFor/name.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/keyFor/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/keyFor/prop-desc.js");
        }
    }
}
