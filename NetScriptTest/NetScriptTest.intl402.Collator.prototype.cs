using Xunit;

namespace NetScriptTest.intl402.Collator
{
    public sealed class Test_prototype : BaseTest
    {
        [Fact(DisplayName = "/intl402/Collator/prototype/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Collator/prototype/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/Collator/prototype/prop-desc.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/this-value-collator-prototype.js")]
        public void Test_this﹏value﹏collator﹏prototype_js()
        {
            RunTest("intl402/Collator/prototype/this-value-collator-prototype.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/this-value-not-collator.js")]
        public void Test_this﹏value﹏not﹏collator_js()
        {
            RunTest("intl402/Collator/prototype/this-value-not-collator.js");
        }
    }
}
