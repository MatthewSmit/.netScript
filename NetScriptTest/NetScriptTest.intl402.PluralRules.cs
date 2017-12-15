using Xunit;

namespace NetScriptTest.intl402
{
    public sealed class Test_PluralRules : BaseTest
    {
        [Fact(DisplayName = "/intl402/PluralRules/builtin.js")]
        public void Test_builtin_js()
        {
            RunTest("intl402/PluralRules/builtin.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/can-be-subclassed.js")]
        public void Test_can﹏be﹏subclassed_js()
        {
            RunTest("intl402/PluralRules/can-be-subclassed.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/default-options-object-prototype.js")]
        public void Test_default﹏options﹏object﹏prototype_js()
        {
            RunTest("intl402/PluralRules/default-options-object-prototype.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/internals.js")]
        public void Test_internals_js()
        {
            RunTest("intl402/PluralRules/internals.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/length.js")]
        public void Test_length_js()
        {
            RunTest("intl402/PluralRules/length.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/name.js")]
        public void Test_name_js()
        {
            RunTest("intl402/PluralRules/name.js");
        }

        [Fact(DisplayName = "/intl402/PluralRules/undefined-newtarget-throws.js")]
        public void Test_undefined﹏newtarget﹏throws_js()
        {
            RunTest("intl402/PluralRules/undefined-newtarget-throws.js");
        }
    }
}
