using Xunit;

namespace NetScriptTest.intl402.Collator.prototype
{
    public sealed class Test_resolvedOptions : BaseTest
    {
        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/basic.js")]
        public void Test_basic_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/basic.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/builtin.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/length.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/name.js");
        }

        [Fact(DisplayName = "/intl402/Collator/prototype/resolvedOptions/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("intl402/Collator/prototype/resolvedOptions/prop-desc.js");
        }
    }
}
