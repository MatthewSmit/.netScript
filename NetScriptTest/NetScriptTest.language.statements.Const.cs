using Xunit;

namespace NetScriptTest.language.statements
{
    public sealed class Test_Const : BaseTest
    {
        [Fact(DisplayName = "/language/statements/const/block-local-closure-get-before-initialization.js")]
        public void Test_block﹏local﹏closure﹏get﹏before﹏initialization_js()
        {
            RunTest("language/statements/const/block-local-closure-get-before-initialization.js");
        }

        [Fact(DisplayName = "/language/statements/const/block-local-use-before-initialization-in-declaration-statement.js")]
        public void Test_block﹏local﹏use﹏before﹏initialization﹏in﹏declaration﹏statement_js()
        {
            RunTest("language/statements/const/block-local-use-before-initialization-in-declaration-statement.js");
        }

        [Fact(DisplayName = "/language/statements/const/block-local-use-before-initialization-in-prior-statement.js")]
        public void Test_block﹏local﹏use﹏before﹏initialization﹏in﹏prior﹏statement_js()
        {
            RunTest("language/statements/const/block-local-use-before-initialization-in-prior-statement.js");
        }

        [Fact(DisplayName = "/language/statements/const/cptn-value.js")]
        public void Test_cptn﹏value_js()
        {
            RunTest("language/statements/const/cptn-value.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-init-iter-close.js")]
        public void Test_dstr﹏ary﹏init﹏iter﹏close_js()
        {
            RunTest("language/statements/const/dstr-ary-init-iter-close.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-init-iter-get-err.js")]
        public void Test_dstr﹏ary﹏init﹏iter﹏get﹏err_js()
        {
            RunTest("language/statements/const/dstr-ary-init-iter-get-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-init-iter-no-close.js")]
        public void Test_dstr﹏ary﹏init﹏iter﹏no﹏close_js()
        {
            RunTest("language/statements/const/dstr-ary-init-iter-no-close.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-name-iter-val.js")]
        public void Test_dstr﹏ary﹏name﹏iter﹏val_js()
        {
            RunTest("language/statements/const/dstr-ary-name-iter-val.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-elem-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elem﹏init_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-elem-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-elem-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elem﹏iter_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-elem-iter.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-elision-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elision﹏init_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-elision-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-elision-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elision﹏iter_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-elision-iter.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-empty-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏empty﹏init_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-empty-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-empty-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏empty﹏iter_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-empty-iter.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-rest-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏rest﹏init_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-rest-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-rest-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏rest﹏iter_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-rest-iter.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-ary-val-null.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏val﹏null_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-ary-val-null.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-exhausted.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏exhausted_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-exhausted.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-arrow.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏arrow_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-arrow.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-class.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏class_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-class.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-cover.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏cover_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-cover.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-fn.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏fn_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-fn.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-gen.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏gen_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-fn-name-gen.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-hole.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏hole_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-hole.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-skipped.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏skipped_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-throws.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏throws_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-undef.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏undef_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-undef.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-init-unresolvable.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-iter-complete.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏complete_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-iter-complete.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-iter-done.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏done_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-iter-done.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-iter-step-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏step﹏err_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-iter-step-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-iter-val-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏val﹏err_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-iter-val-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-id-iter-val.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏val_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-id-iter-val.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-obj-id-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏id﹏init_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-obj-id-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-obj-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏id_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-obj-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-obj-prop-id-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏prop﹏id﹏init_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-obj-prop-id-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-obj-prop-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏prop﹏id_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-obj-prop-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-obj-val-null.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏val﹏null_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-obj-val-null.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elem-obj-val-undef.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏val﹏undef_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elem-obj-val-undef.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elision-exhausted.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elision﹏exhausted_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elision-exhausted.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elision-step-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elision﹏step﹏err_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elision-step-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-elision.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elision_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-elision.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-empty.js")]
        public void Test_dstr﹏ary﹏ptrn﹏empty_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-empty.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-ary-elem.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏elem_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-ary-elem.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-ary-elision.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏elision_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-ary-elision.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-ary-empty.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏empty_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-ary-empty.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-ary-rest.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏rest_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-ary-rest.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-id-elision-next-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏elision﹏next﹏err_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-id-elision-next-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-id-elision.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏elision_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-id-elision.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-id-exhausted.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏exhausted_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-id-exhausted.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-id-iter-step-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏iter﹏step﹏err_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-id-iter-step-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-id-iter-val-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏iter﹏val﹏err_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-id-iter-val-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-init-ary.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏init﹏ary_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-init-ary.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-init-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏init﹏id_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-init-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-init-obj.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏init﹏obj_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-init-obj.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-not-final-ary.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏not﹏final﹏ary_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-not-final-ary.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-not-final-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏not﹏final﹏id_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-not-final-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-not-final-obj.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏not﹏final﹏obj_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-not-final-obj.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-obj-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏obj﹏id_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-obj-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-ary-ptrn-rest-obj-prop-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏obj﹏prop﹏id_js()
        {
            RunTest("language/statements/const/dstr-ary-ptrn-rest-obj-prop-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-init-null.js")]
        public void Test_dstr﹏obj﹏init﹏null_js()
        {
            RunTest("language/statements/const/dstr-obj-init-null.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-init-undefined.js")]
        public void Test_dstr﹏obj﹏init﹏undefined_js()
        {
            RunTest("language/statements/const/dstr-obj-init-undefined.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-empty.js")]
        public void Test_dstr﹏obj﹏ptrn﹏empty_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-empty.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-get-value-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏get﹏value﹏err_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-get-value-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-fn-name-arrow.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏arrow_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-fn-name-arrow.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-fn-name-class.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏class_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-fn-name-class.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-fn-name-cover.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏cover_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-fn-name-cover.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-fn-name-fn.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏fn_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-fn-name-fn.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-fn-name-gen.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏gen_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-fn-name-gen.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-skipped.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏skipped_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-throws.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏throws_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-init-unresolvable.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-id-trailing-comma.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏trailing﹏comma_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-id-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-list-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏list﹏err_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-list-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-ary-init.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary﹏init_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-ary-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-ary-trailing-comma.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary﹏trailing﹏comma_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-ary-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-ary-value-null.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary﹏value﹏null_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-ary-value-null.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-ary.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-ary.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-eval-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏eval﹏err_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-eval-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-id-get-value-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏get﹏value﹏err_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-id-get-value-err.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-id-init-skipped.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init﹏skipped_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-id-init-throws.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init﹏throws_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-id-init-unresolvable.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-id-init.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-id-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-id-trailing-comma.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏trailing﹏comma_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-id-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-id.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-id.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-obj-init.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj﹏init_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-obj-init.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-obj-value-null.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj﹏value﹏null_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-obj-value-null.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-obj-value-undef.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj﹏value﹏undef_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-obj-value-undef.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-prop-obj.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-prop-obj.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-rest-getter.js")]
        public void Test_dstr﹏obj﹏ptrn﹏rest﹏getter_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-rest-getter.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-rest-skip-non-enumerable.js")]
        public void Test_dstr﹏obj﹏ptrn﹏rest﹏skip﹏non﹏enumerable_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-rest-skip-non-enumerable.js");
        }

        [Fact(DisplayName = "/language/statements/const/dstr-obj-ptrn-rest-val-obj.js")]
        public void Test_dstr﹏obj﹏ptrn﹏rest﹏val﹏obj_js()
        {
            RunTest("language/statements/const/dstr-obj-ptrn-rest-val-obj.js");
        }

        [Fact(DisplayName = "/language/statements/const/fn-name-arrow.js")]
        public void Test_fn﹏name﹏arrow_js()
        {
            RunTest("language/statements/const/fn-name-arrow.js");
        }

        [Fact(DisplayName = "/language/statements/const/fn-name-class.js")]
        public void Test_fn﹏name﹏class_js()
        {
            RunTest("language/statements/const/fn-name-class.js");
        }

        [Fact(DisplayName = "/language/statements/const/fn-name-cover.js")]
        public void Test_fn﹏name﹏cover_js()
        {
            RunTest("language/statements/const/fn-name-cover.js");
        }

        [Fact(DisplayName = "/language/statements/const/fn-name-fn.js")]
        public void Test_fn﹏name﹏fn_js()
        {
            RunTest("language/statements/const/fn-name-fn.js");
        }

        [Fact(DisplayName = "/language/statements/const/fn-name-gen.js")]
        public void Test_fn﹏name﹏gen_js()
        {
            RunTest("language/statements/const/fn-name-gen.js");
        }

        [Fact(DisplayName = "/language/statements/const/function-local-closure-get-before-initialization.js")]
        public void Test_function﹏local﹏closure﹏get﹏before﹏initialization_js()
        {
            RunTest("language/statements/const/function-local-closure-get-before-initialization.js");
        }

        [Fact(DisplayName = "/language/statements/const/function-local-use-before-initialization-in-declaration-statement.js")]
        public void Test_function﹏local﹏use﹏before﹏initialization﹏in﹏declaration﹏statement_js()
        {
            RunTest("language/statements/const/function-local-use-before-initialization-in-declaration-statement.js");
        }

        [Fact(DisplayName = "/language/statements/const/function-local-use-before-initialization-in-prior-statement.js")]
        public void Test_function﹏local﹏use﹏before﹏initialization﹏in﹏prior﹏statement_js()
        {
            RunTest("language/statements/const/function-local-use-before-initialization-in-prior-statement.js");
        }

        [Fact(DisplayName = "/language/statements/const/global-closure-get-before-initialization.js")]
        public void Test_global﹏closure﹏get﹏before﹏initialization_js()
        {
            RunTest("language/statements/const/global-closure-get-before-initialization.js");
        }

        [Fact(DisplayName = "/language/statements/const/global-use-before-initialization-in-declaration-statement.js")]
        public void Test_global﹏use﹏before﹏initialization﹏in﹏declaration﹏statement_js()
        {
            RunTest("language/statements/const/global-use-before-initialization-in-declaration-statement.js");
        }

        [Fact(DisplayName = "/language/statements/const/global-use-before-initialization-in-prior-statement.js")]
        public void Test_global﹏use﹏before﹏initialization﹏in﹏prior﹏statement_js()
        {
            RunTest("language/statements/const/global-use-before-initialization-in-prior-statement.js");
        }

        [Fact(DisplayName = "/language/statements/const/redeclaration-error-from-within-strict-mode-function-const.js")]
        public void Test_redeclaration﹏error﹏from﹏within﹏strict﹏mode﹏function﹏const_js()
        {
            RunTest("language/statements/const/redeclaration-error-from-within-strict-mode-function-const.js");
        }
    }
}
