using Xunit;

namespace NetScriptTest.language
{
    public sealed class Test_global﹏code : BaseTest
    {
        [Fact(DisplayName = "/language/global-code/block-decl-strict.js")]
        public void Test_block﹏decl﹏strict_js()
        {
            RunTest("language/global-code/block-decl-strict.js");
        }

        [Fact(DisplayName = "/language/global-code/decl-func-dup.js")]
        public void Test_decl﹏func﹏dup_js()
        {
            RunTest("language/global-code/decl-func-dup.js");
        }

        [Fact(DisplayName = "/language/global-code/decl-func.js")]
        public void Test_decl﹏func_js()
        {
            RunTest("language/global-code/decl-func.js");
        }

        [Fact(DisplayName = "/language/global-code/decl-lex-configurable-global.js")]
        public void Test_decl﹏lex﹏configurable﹏global_js()
        {
            RunTest("language/global-code/decl-lex-configurable-global.js");
        }

        [Fact(DisplayName = "/language/global-code/decl-lex-deletion.js")]
        public void Test_decl﹏lex﹏deletion_js()
        {
            RunTest("language/global-code/decl-lex-deletion.js");
        }

        [Fact(DisplayName = "/language/global-code/decl-lex-restricted-global.js")]
        public void Test_decl﹏lex﹏restricted﹏global_js()
        {
            RunTest("language/global-code/decl-lex-restricted-global.js");
        }

        [Fact(DisplayName = "/language/global-code/decl-lex.js")]
        public void Test_decl﹏lex_js()
        {
            RunTest("language/global-code/decl-lex.js");
        }

        [Fact(DisplayName = "/language/global-code/decl-var.js")]
        public void Test_decl﹏var_js()
        {
            RunTest("language/global-code/decl-var.js");
        }

        [Fact(DisplayName = "/language/global-code/export.js")]
        public void Test_export_js()
        {
            RunTest("language/global-code/export.js");
        }

        [Fact(DisplayName = "/language/global-code/import.js")]
        public void Test_import_js()
        {
            RunTest("language/global-code/import.js");
        }

        [Fact(DisplayName = "/language/global-code/new.target-arrow.js")]
        public void Test_new_target﹏arrow_js()
        {
            RunTest("language/global-code/new.target-arrow.js");
        }

        [Fact(DisplayName = "/language/global-code/new.target.js")]
        public void Test_new_target_js()
        {
            RunTest("language/global-code/new.target.js");
        }

        [Fact(DisplayName = "/language/global-code/return.js")]
        public void Test_return_js()
        {
            RunTest("language/global-code/return.js");
        }

        [Fact(DisplayName = "/language/global-code/S10.1.7_A1_T1.js")]
        public void Test_S10_1_7_A1_T1_js()
        {
            RunTest("language/global-code/S10.1.7_A1_T1.js");
        }

        [Fact(DisplayName = "/language/global-code/S10.4.1_A1_T1.js")]
        public void Test_S10_4_1_A1_T1_js()
        {
            RunTest("language/global-code/S10.4.1_A1_T1.js");
        }

        [Fact(DisplayName = "/language/global-code/S10.4.1_A1_T2.js")]
        public void Test_S10_4_1_A1_T2_js()
        {
            RunTest("language/global-code/S10.4.1_A1_T2.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-func-dups.js")]
        public void Test_script﹏decl﹏func﹏dups_js()
        {
            RunTest("language/global-code/script-decl-func-dups.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-func-err-non-configurable.js")]
        public void Test_script﹏decl﹏func﹏err﹏non﹏configurable_js()
        {
            RunTest("language/global-code/script-decl-func-err-non-configurable.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-func-err-non-extensible.js")]
        public void Test_script﹏decl﹏func﹏err﹏non﹏extensible_js()
        {
            RunTest("language/global-code/script-decl-func-err-non-extensible.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-func.js")]
        public void Test_script﹏decl﹏func_js()
        {
            RunTest("language/global-code/script-decl-func.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-lex-deletion.js")]
        public void Test_script﹏decl﹏lex﹏deletion_js()
        {
            RunTest("language/global-code/script-decl-lex-deletion.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-lex-lex.js")]
        public void Test_script﹏decl﹏lex﹏lex_js()
        {
            RunTest("language/global-code/script-decl-lex-lex.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-lex-restricted-global.js")]
        public void Test_script﹏decl﹏lex﹏restricted﹏global_js()
        {
            RunTest("language/global-code/script-decl-lex-restricted-global.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-lex-var.js")]
        public void Test_script﹏decl﹏lex﹏var_js()
        {
            RunTest("language/global-code/script-decl-lex-var.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-lex.js")]
        public void Test_script﹏decl﹏lex_js()
        {
            RunTest("language/global-code/script-decl-lex.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-var-collision.js")]
        public void Test_script﹏decl﹏var﹏collision_js()
        {
            RunTest("language/global-code/script-decl-var-collision.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-var-err.js")]
        public void Test_script﹏decl﹏var﹏err_js()
        {
            RunTest("language/global-code/script-decl-var-err.js");
        }

        [Fact(DisplayName = "/language/global-code/script-decl-var.js")]
        public void Test_script﹏decl﹏var_js()
        {
            RunTest("language/global-code/script-decl-var.js");
        }

        [Fact(DisplayName = "/language/global-code/super-call-arrow.js")]
        public void Test_super﹏call﹏arrow_js()
        {
            RunTest("language/global-code/super-call-arrow.js");
        }

        [Fact(DisplayName = "/language/global-code/super-call.js")]
        public void Test_super﹏call_js()
        {
            RunTest("language/global-code/super-call.js");
        }

        [Fact(DisplayName = "/language/global-code/super-prop-arrow.js")]
        public void Test_super﹏prop﹏arrow_js()
        {
            RunTest("language/global-code/super-prop-arrow.js");
        }

        [Fact(DisplayName = "/language/global-code/super-prop.js")]
        public void Test_super﹏prop_js()
        {
            RunTest("language/global-code/super-prop.js");
        }

        [Fact(DisplayName = "/language/global-code/switch-case-decl-strict.js")]
        public void Test_switch﹏case﹏decl﹏strict_js()
        {
            RunTest("language/global-code/switch-case-decl-strict.js");
        }

        [Fact(DisplayName = "/language/global-code/switch-dflt-decl-strict.js")]
        public void Test_switch﹏dflt﹏decl﹏strict_js()
        {
            RunTest("language/global-code/switch-dflt-decl-strict.js");
        }

        [Fact(DisplayName = "/language/global-code/unscopables-ignored.js")]
        public void Test_unscopables﹏ignored_js()
        {
            RunTest("language/global-code/unscopables-ignored.js");
        }

        [Fact(DisplayName = "/language/global-code/yield-non-strict.js")]
        public void Test_yield﹏non﹏strict_js()
        {
            RunTest("language/global-code/yield-non-strict.js");
        }

        [Fact(DisplayName = "/language/global-code/yield-strict.js")]
        public void Test_yield﹏strict_js()
        {
            RunTest("language/global-code/yield-strict.js");
        }
    }
}
