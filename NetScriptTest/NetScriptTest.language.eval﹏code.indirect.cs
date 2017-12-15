using Xunit;

namespace NetScriptTest.language.eval﹏code
{
    public sealed class Test_indirect : BaseTest
    {
        [Fact(DisplayName = "/language/eval-code/indirect/always-non-strict.js")]
        public void Test_always﹏non﹏strict_js()
        {
            RunTest("language/eval-code/indirect/always-non-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/block-decl-strict.js")]
        public void Test_block﹏decl﹏strict_js()
        {
            RunTest("language/eval-code/indirect/block-decl-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-block.js")]
        public void Test_cptn﹏nrml﹏empty﹏block_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-block.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-do-while.js")]
        public void Test_cptn﹏nrml﹏empty﹏do﹏while_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-do-while.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-empty.js")]
        public void Test_cptn﹏nrml﹏empty﹏empty_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-empty.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-for.js")]
        public void Test_cptn﹏nrml﹏empty﹏for_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-for.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-if.js")]
        public void Test_cptn﹏nrml﹏empty﹏if_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-if.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-switch.js")]
        public void Test_cptn﹏nrml﹏empty﹏switch_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-switch.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-var.js")]
        public void Test_cptn﹏nrml﹏empty﹏var_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-var.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-empty-while.js")]
        public void Test_cptn﹏nrml﹏empty﹏while_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-empty-while.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-expr-obj.js")]
        public void Test_cptn﹏nrml﹏expr﹏obj_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-expr-obj.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/cptn-nrml-expr-prim.js")]
        public void Test_cptn﹏nrml﹏expr﹏prim_js()
        {
            RunTest("language/eval-code/indirect/cptn-nrml-expr-prim.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/export.js")]
        public void Test_export_js()
        {
            RunTest("language/eval-code/indirect/export.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/global-env-rec-catch.js")]
        public void Test_global﹏env﹏rec﹏catch_js()
        {
            RunTest("language/eval-code/indirect/global-env-rec-catch.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/global-env-rec-eval.js")]
        public void Test_global﹏env﹏rec﹏eval_js()
        {
            RunTest("language/eval-code/indirect/global-env-rec-eval.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/global-env-rec-fun.js")]
        public void Test_global﹏env﹏rec﹏fun_js()
        {
            RunTest("language/eval-code/indirect/global-env-rec-fun.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/global-env-rec-with.js")]
        public void Test_global﹏env﹏rec﹏with_js()
        {
            RunTest("language/eval-code/indirect/global-env-rec-with.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/global-env-rec.js")]
        public void Test_global﹏env﹏rec_js()
        {
            RunTest("language/eval-code/indirect/global-env-rec.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/import.js")]
        public void Test_import_js()
        {
            RunTest("language/eval-code/indirect/import.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/lex-env-distinct-cls.js")]
        public void Test_lex﹏env﹏distinct﹏cls_js()
        {
            RunTest("language/eval-code/indirect/lex-env-distinct-cls.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/lex-env-distinct-const.js")]
        public void Test_lex﹏env﹏distinct﹏const_js()
        {
            RunTest("language/eval-code/indirect/lex-env-distinct-const.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/lex-env-distinct-let.js")]
        public void Test_lex﹏env﹏distinct﹏let_js()
        {
            RunTest("language/eval-code/indirect/lex-env-distinct-let.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/lex-env-heritage.js")]
        public void Test_lex﹏env﹏heritage_js()
        {
            RunTest("language/eval-code/indirect/lex-env-heritage.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/lex-env-no-init-cls.js")]
        public void Test_lex﹏env﹏no﹏init﹏cls_js()
        {
            RunTest("language/eval-code/indirect/lex-env-no-init-cls.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/lex-env-no-init-const.js")]
        public void Test_lex﹏env﹏no﹏init﹏const_js()
        {
            RunTest("language/eval-code/indirect/lex-env-no-init-const.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/lex-env-no-init-let.js")]
        public void Test_lex﹏env﹏no﹏init﹏let_js()
        {
            RunTest("language/eval-code/indirect/lex-env-no-init-let.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/new.target.js")]
        public void Test_new_target_js()
        {
            RunTest("language/eval-code/indirect/new.target.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/non-definable-function-with-function.js")]
        public void Test_non﹏definable﹏function﹏with﹏function_js()
        {
            RunTest("language/eval-code/indirect/non-definable-function-with-function.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/non-definable-function-with-variable.js")]
        public void Test_non﹏definable﹏function﹏with﹏variable_js()
        {
            RunTest("language/eval-code/indirect/non-definable-function-with-variable.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/non-definable-global-function.js")]
        public void Test_non﹏definable﹏global﹏function_js()
        {
            RunTest("language/eval-code/indirect/non-definable-global-function.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/non-definable-global-generator.js")]
        public void Test_non﹏definable﹏global﹏generator_js()
        {
            RunTest("language/eval-code/indirect/non-definable-global-generator.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/non-definable-global-var.js")]
        public void Test_non﹏definable﹏global﹏var_js()
        {
            RunTest("language/eval-code/indirect/non-definable-global-var.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/non-string-object.js")]
        public void Test_non﹏string﹏object_js()
        {
            RunTest("language/eval-code/indirect/non-string-object.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/non-string-primitive.js")]
        public void Test_non﹏string﹏primitive_js()
        {
            RunTest("language/eval-code/indirect/non-string-primitive.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/parse-failure-1.js")]
        public void Test_parse﹏failure﹏1_js()
        {
            RunTest("language/eval-code/indirect/parse-failure-1.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/parse-failure-2.js")]
        public void Test_parse﹏failure﹏2_js()
        {
            RunTest("language/eval-code/indirect/parse-failure-2.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/parse-failure-3.js")]
        public void Test_parse﹏failure﹏3_js()
        {
            RunTest("language/eval-code/indirect/parse-failure-3.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/parse-failure-4.js")]
        public void Test_parse﹏failure﹏4_js()
        {
            RunTest("language/eval-code/indirect/parse-failure-4.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/parse-failure-5.js")]
        public void Test_parse﹏failure﹏5_js()
        {
            RunTest("language/eval-code/indirect/parse-failure-5.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/realm.js")]
        public void Test_realm_js()
        {
            RunTest("language/eval-code/indirect/realm.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/super-call.js")]
        public void Test_super﹏call_js()
        {
            RunTest("language/eval-code/indirect/super-call.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/super-prop.js")]
        public void Test_super﹏prop_js()
        {
            RunTest("language/eval-code/indirect/super-prop.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/switch-case-decl-strict.js")]
        public void Test_switch﹏case﹏decl﹏strict_js()
        {
            RunTest("language/eval-code/indirect/switch-case-decl-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/switch-dflt-decl-strict.js")]
        public void Test_switch﹏dflt﹏decl﹏strict_js()
        {
            RunTest("language/eval-code/indirect/switch-dflt-decl-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/this-value-func.js")]
        public void Test_this﹏value﹏func_js()
        {
            RunTest("language/eval-code/indirect/this-value-func.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/this-value-global.js")]
        public void Test_this﹏value﹏global_js()
        {
            RunTest("language/eval-code/indirect/this-value-global.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-func-init-global-new.js")]
        public void Test_var﹏env﹏func﹏init﹏global﹏new_js()
        {
            RunTest("language/eval-code/indirect/var-env-func-init-global-new.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-func-init-global-update-configurable.js")]
        public void Test_var﹏env﹏func﹏init﹏global﹏update﹏configurable_js()
        {
            RunTest("language/eval-code/indirect/var-env-func-init-global-update-configurable.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-func-init-global-update-non-configurable.js")]
        public void Test_var﹏env﹏func﹏init﹏global﹏update﹏non﹏configurable_js()
        {
            RunTest("language/eval-code/indirect/var-env-func-init-global-update-non-configurable.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-func-init-multi.js")]
        public void Test_var﹏env﹏func﹏init﹏multi_js()
        {
            RunTest("language/eval-code/indirect/var-env-func-init-multi.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-func-non-strict.js")]
        public void Test_var﹏env﹏func﹏non﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-func-non-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-func-strict.js")]
        public void Test_var﹏env﹏func﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-func-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-global-lex-non-strict.js")]
        public void Test_var﹏env﹏global﹏lex﹏non﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-global-lex-non-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-global-lex-strict.js")]
        public void Test_var﹏env﹏global﹏lex﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-global-lex-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-lower-lex-non-strict.js")]
        public void Test_var﹏env﹏lower﹏lex﹏non﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-lower-lex-non-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-lower-lex-strict.js")]
        public void Test_var﹏env﹏lower﹏lex﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-lower-lex-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-var-init-global-exstng.js")]
        public void Test_var﹏env﹏var﹏init﹏global﹏exstng_js()
        {
            RunTest("language/eval-code/indirect/var-env-var-init-global-exstng.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-var-init-global-new.js")]
        public void Test_var﹏env﹏var﹏init﹏global﹏new_js()
        {
            RunTest("language/eval-code/indirect/var-env-var-init-global-new.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-var-non-strict.js")]
        public void Test_var﹏env﹏var﹏non﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-var-non-strict.js");
        }

        [Fact(DisplayName = "/language/eval-code/indirect/var-env-var-strict.js")]
        public void Test_var﹏env﹏var﹏strict_js()
        {
            RunTest("language/eval-code/indirect/var-env-var-strict.js");
        }
    }
}
