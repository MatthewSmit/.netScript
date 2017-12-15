using Xunit;

namespace NetScriptTest.built﹏ins.Symbol
{
    public sealed class Test_for : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Symbol/for/create-value.js")]
        public void Test_create﹏value_js()
        {
            RunTest("built-ins/Symbol/for/create-value.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/for/cross-realm.js")]
        public void Test_cross﹏realm_js()
        {
            RunTest("built-ins/Symbol/for/cross-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/for/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Symbol/for/length.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/for/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Symbol/for/name.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/for/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Symbol/for/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/for/retrieve-value.js")]
        public void Test_retrieve﹏value_js()
        {
            RunTest("built-ins/Symbol/for/retrieve-value.js");
        }

        [Fact(DisplayName = "/built-ins/Symbol/for/to-string-err.js")]
        public void Test_to﹏string﹏err_js()
        {
            RunTest("built-ins/Symbol/for/to-string-err.js");
        }
    }
}
