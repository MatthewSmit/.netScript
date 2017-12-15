using Xunit;

namespace NetScriptTest.language.block﹏scope
{
    public sealed class Test_leave : BaseTest
    {
        [Fact(DisplayName = "/language/block-scope/leave/finally-block-let-declaration-only-shadows-outer-parameter-value-1.js")]
        public void Test_finally﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏1_js()
        {
            RunTest("language/block-scope/leave/finally-block-let-declaration-only-shadows-outer-parameter-value-1.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/finally-block-let-declaration-only-shadows-outer-parameter-value-2.js")]
        public void Test_finally﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏2_js()
        {
            RunTest("language/block-scope/leave/finally-block-let-declaration-only-shadows-outer-parameter-value-2.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/for-loop-block-let-declaration-only-shadows-outer-parameter-value-1.js")]
        public void Test_for﹏loop﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏1_js()
        {
            RunTest("language/block-scope/leave/for-loop-block-let-declaration-only-shadows-outer-parameter-value-1.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/for-loop-block-let-declaration-only-shadows-outer-parameter-value-2.js")]
        public void Test_for﹏loop﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏2_js()
        {
            RunTest("language/block-scope/leave/for-loop-block-let-declaration-only-shadows-outer-parameter-value-2.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/nested-block-let-declaration-only-shadows-outer-parameter-value-1.js")]
        public void Test_nested﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏1_js()
        {
            RunTest("language/block-scope/leave/nested-block-let-declaration-only-shadows-outer-parameter-value-1.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/nested-block-let-declaration-only-shadows-outer-parameter-value-2.js")]
        public void Test_nested﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏2_js()
        {
            RunTest("language/block-scope/leave/nested-block-let-declaration-only-shadows-outer-parameter-value-2.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/outermost-binding-updated-in-catch-block-nested-block-let-declaration-unseen-outside-of-block.js")]
        public void Test_outermost﹏binding﹏updated﹏in﹏catch﹏block﹏nested﹏block﹏let﹏declaration﹏unseen﹏outside﹏of﹏block_js()
        {
            RunTest("language/block-scope/leave/outermost-binding-updated-in-catch-block-nested-block-let-declaration-unseen-outside-of-block.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/try-block-let-declaration-only-shadows-outer-parameter-value-1.js")]
        public void Test_try﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏1_js()
        {
            RunTest("language/block-scope/leave/try-block-let-declaration-only-shadows-outer-parameter-value-1.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/try-block-let-declaration-only-shadows-outer-parameter-value-2.js")]
        public void Test_try﹏block﹏let﹏declaration﹏only﹏shadows﹏outer﹏parameter﹏value﹏2_js()
        {
            RunTest("language/block-scope/leave/try-block-let-declaration-only-shadows-outer-parameter-value-2.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/verify-context-in-finally-block.js")]
        public void Test_verify﹏context﹏in﹏finally﹏block_js()
        {
            RunTest("language/block-scope/leave/verify-context-in-finally-block.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/verify-context-in-for-loop-block.js")]
        public void Test_verify﹏context﹏in﹏for﹏loop﹏block_js()
        {
            RunTest("language/block-scope/leave/verify-context-in-for-loop-block.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/verify-context-in-labelled-block.js")]
        public void Test_verify﹏context﹏in﹏labelled﹏block_js()
        {
            RunTest("language/block-scope/leave/verify-context-in-labelled-block.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/verify-context-in-try-block.js")]
        public void Test_verify﹏context﹏in﹏try﹏block_js()
        {
            RunTest("language/block-scope/leave/verify-context-in-try-block.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/x-after-break-to-label.js")]
        public void Test_x﹏after﹏break﹏to﹏label_js()
        {
            RunTest("language/block-scope/leave/x-after-break-to-label.js");
        }

        [Fact(DisplayName = "/language/block-scope/leave/x-before-continue.js")]
        public void Test_x﹏before﹏continue_js()
        {
            RunTest("language/block-scope/leave/x-before-continue.js");
        }
    }
}
