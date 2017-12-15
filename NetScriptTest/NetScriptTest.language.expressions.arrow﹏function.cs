using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_arrow﹏function : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/arrow-function/ArrowFunction_restricted-properties.js")]
        public void Test_ArrowFunction_restricted﹏properties_js()
        {
            RunTest("language/expressions/arrow-function/ArrowFunction_restricted-properties.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/cannot-override-this-with-thisArg.js")]
        public void Test_cannot﹏override﹏this﹏with﹏thisArg_js()
        {
            RunTest("language/expressions/arrow-function/cannot-override-this-with-thisArg.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-abrupt.js")]
        public void Test_dflt﹏params﹏abrupt_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-abrupt.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-arg-val-not-undefined.js")]
        public void Test_dflt﹏params﹏arg﹏val﹏not﹏undefined_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-arg-val-not-undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-arg-val-undefined.js")]
        public void Test_dflt﹏params﹏arg﹏val﹏undefined_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-arg-val-undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-duplicates.js")]
        public void Test_dflt﹏params﹏duplicates_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-duplicates.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-ref-later.js")]
        public void Test_dflt﹏params﹏ref﹏later_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-ref-later.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-ref-prior.js")]
        public void Test_dflt﹏params﹏ref﹏prior_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-ref-prior.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-ref-self.js")]
        public void Test_dflt﹏params﹏ref﹏self_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-ref-self.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-rest.js")]
        public void Test_dflt﹏params﹏rest_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-rest.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dflt-params-trailing-comma.js")]
        public void Test_dflt﹏params﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/arrow-function/dflt-params-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-init-iter-close.js")]
        public void Test_dstr﹏ary﹏init﹏iter﹏close_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-init-iter-close.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-init-iter-get-err.js")]
        public void Test_dstr﹏ary﹏init﹏iter﹏get﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-init-iter-get-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-init-iter-no-close.js")]
        public void Test_dstr﹏ary﹏init﹏iter﹏no﹏close_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-init-iter-no-close.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-name-iter-val.js")]
        public void Test_dstr﹏ary﹏name﹏iter﹏val_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-name-iter-val.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elem-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elem﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elem-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elem-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elem﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elem-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elision-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elision﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elision-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elision-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏elision﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-elision-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-empty-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏empty﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-empty-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-empty-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏empty﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-empty-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-rest-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏rest﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-rest-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-rest-iter.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏rest﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-rest-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-val-null.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏ary﹏val﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-ary-val-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-exhausted.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏exhausted_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-exhausted.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-arrow.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏arrow_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-arrow.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-class.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏class_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-class.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-cover.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏cover_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-cover.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-fn.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏fn_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-fn.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-gen.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏gen_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-fn-name-gen.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-hole.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏hole_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-hole.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-skipped.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏skipped_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-throws.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏throws_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-undef.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏undef_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-undef.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-unresolvable.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-complete.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏complete_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-complete.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-done.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏done_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-done.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-step-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏step﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-step-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-val-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏val﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-val-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-val.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏id﹏iter﹏val_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-id-iter-val.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-id-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏id﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-id-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-prop-id-init.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏prop﹏id﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-prop-id-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-prop-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏prop﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-prop-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-val-null.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏val﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-val-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-val-undef.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elem﹏obj﹏val﹏undef_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elem-obj-val-undef.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elision-exhausted.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elision﹏exhausted_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elision-exhausted.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elision-step-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elision﹏step﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elision-step-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-elision.js")]
        public void Test_dstr﹏ary﹏ptrn﹏elision_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-elision.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-empty.js")]
        public void Test_dstr﹏ary﹏ptrn﹏empty_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-empty.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-elem.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏elem_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-elem.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-elision.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏elision_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-elision.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-empty.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏empty_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-empty.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-rest.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏ary﹏rest_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-ary-rest.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-id-elision-next-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏elision﹏next﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-id-elision-next-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-id-elision.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏elision_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-id-elision.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-id-exhausted.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏exhausted_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-id-exhausted.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-id-iter-step-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏iter﹏step﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-id-iter-step-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-id-iter-val-err.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id﹏iter﹏val﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-id-iter-val-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-init-ary.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏init﹏ary_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-init-ary.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-init-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏init﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-init-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-init-obj.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏init﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-init-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-not-final-ary.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏not﹏final﹏ary_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-not-final-ary.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-not-final-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏not﹏final﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-not-final-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-not-final-obj.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏not﹏final﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-not-final-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-obj-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏obj﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-obj-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-ary-ptrn-rest-obj-prop-id.js")]
        public void Test_dstr﹏ary﹏ptrn﹏rest﹏obj﹏prop﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-ary-ptrn-rest-obj-prop-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-init-iter-close.js")]
        public void Test_dstr﹏dflt﹏ary﹏init﹏iter﹏close_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-init-iter-close.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-init-iter-get-err.js")]
        public void Test_dstr﹏dflt﹏ary﹏init﹏iter﹏get﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-init-iter-get-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-init-iter-no-close.js")]
        public void Test_dstr﹏dflt﹏ary﹏init﹏iter﹏no﹏close_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-init-iter-no-close.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-name-iter-val.js")]
        public void Test_dstr﹏dflt﹏ary﹏name﹏iter﹏val_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-name-iter-val.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elem-init.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏elem﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elem-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elem-iter.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏elem﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elem-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elision-init.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏elision﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elision-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elision-iter.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏elision﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-elision-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-empty-init.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏empty﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-empty-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-empty-iter.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏empty﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-empty-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-rest-init.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏rest﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-rest-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-rest-iter.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏rest﹏iter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-rest-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-val-null.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏ary﹏val﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-ary-val-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-exhausted.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏exhausted_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-exhausted.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-arrow.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏arrow_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-arrow.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-class.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏class_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-class.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-cover.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏cover_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-cover.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-fn.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏fn_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-fn.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-gen.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏fn﹏name﹏gen_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-fn-name-gen.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-hole.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏hole_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-hole.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-skipped.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏skipped_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-throws.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏throws_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-undef.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏undef_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-undef.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-unresolvable.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-complete.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏iter﹏complete_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-complete.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-done.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏iter﹏done_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-done.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-step-err.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏iter﹏step﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-step-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-val-err.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏iter﹏val﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-val-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-val.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏id﹏iter﹏val_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-id-iter-val.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-id-init.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏obj﹏id﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-id-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-id.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏obj﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-prop-id-init.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏obj﹏prop﹏id﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-prop-id-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-prop-id.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏obj﹏prop﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-prop-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-val-null.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏obj﹏val﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-val-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-val-undef.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elem﹏obj﹏val﹏undef_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elem-obj-val-undef.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elision-exhausted.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elision﹏exhausted_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elision-exhausted.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elision-step-err.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elision﹏step﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elision-step-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-elision.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏elision_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-elision.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-empty.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏empty_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-empty.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-elem.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏ary﹏elem_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-elem.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-elision.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏ary﹏elision_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-elision.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-empty.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏ary﹏empty_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-empty.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-rest.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏ary﹏rest_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-ary-rest.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-elision-next-err.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏id﹏elision﹏next﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-elision-next-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-elision.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏id﹏elision_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-elision.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-exhausted.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏id﹏exhausted_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-exhausted.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-iter-step-err.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏id﹏iter﹏step﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-iter-step-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-iter-val-err.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏id﹏iter﹏val﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id-iter-val-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-init-ary.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏init﹏ary_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-init-ary.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-init-id.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏init﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-init-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-init-obj.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏init﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-init-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-not-final-ary.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏not﹏final﹏ary_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-not-final-ary.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-not-final-id.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏not﹏final﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-not-final-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-not-final-obj.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏not﹏final﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-not-final-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-obj-id.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏obj﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-obj-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-obj-prop-id.js")]
        public void Test_dstr﹏dflt﹏ary﹏ptrn﹏rest﹏obj﹏prop﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-ary-ptrn-rest-obj-prop-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-init-null.js")]
        public void Test_dstr﹏dflt﹏obj﹏init﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-init-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-init-undefined.js")]
        public void Test_dstr﹏dflt﹏obj﹏init﹏undefined_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-init-undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-empty.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏empty_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-empty.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-get-value-err.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏get﹏value﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-get-value-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-arrow.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏arrow_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-arrow.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-class.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏class_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-class.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-cover.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏cover_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-cover.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-fn.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏fn_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-fn.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-gen.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏gen_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-fn-name-gen.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-skipped.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏skipped_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-throws.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏throws_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-unresolvable.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-trailing-comma.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏id﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-id-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-list-err.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏list﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-list-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary-init.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏ary﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary-trailing-comma.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏ary﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary-value-null.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏ary﹏value﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary-value-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏ary_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-ary.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-eval-err.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏eval﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-eval-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-get-value-err.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏id﹏get﹏value﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-get-value-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init-skipped.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏id﹏init﹏skipped_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init-throws.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏id﹏init﹏throws_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init-unresolvable.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏id﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-trailing-comma.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏id﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj-init.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏obj﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj-value-null.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏obj﹏value﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj-value-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj-value-undef.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏obj﹏value﹏undef_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj-value-undef.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏prop﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-prop-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-rest-getter.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏rest﹏getter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-rest-getter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-rest-skip-non-enumerable.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏rest﹏skip﹏non﹏enumerable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-rest-skip-non-enumerable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-dflt-obj-ptrn-rest-val-obj.js")]
        public void Test_dstr﹏dflt﹏obj﹏ptrn﹏rest﹏val﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-dflt-obj-ptrn-rest-val-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-init-null.js")]
        public void Test_dstr﹏obj﹏init﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-init-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-init-undefined.js")]
        public void Test_dstr﹏obj﹏init﹏undefined_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-init-undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-empty.js")]
        public void Test_dstr﹏obj﹏ptrn﹏empty_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-empty.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-get-value-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏get﹏value﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-get-value-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-arrow.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏arrow_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-arrow.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-class.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏class_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-class.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-cover.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏cover_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-cover.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-fn.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏fn_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-fn.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-gen.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏fn﹏name﹏gen_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-fn-name-gen.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-skipped.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏skipped_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-throws.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏throws_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-init-unresolvable.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-id-trailing-comma.js")]
        public void Test_dstr﹏obj﹏ptrn﹏id﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-id-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-list-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏list﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-list-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-ary-init.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-ary-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-ary-trailing-comma.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-ary-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-ary-value-null.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary﹏value﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-ary-value-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-ary.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏ary_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-ary.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-eval-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏eval﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-eval-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-id-get-value-err.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏get﹏value﹏err_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-id-get-value-err.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init-skipped.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init﹏skipped_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init-skipped.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init-throws.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init﹏throws_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init-throws.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init-unresolvable.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init﹏unresolvable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-id-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-id-trailing-comma.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id﹏trailing﹏comma_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-id-trailing-comma.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-id.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏id_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-id.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-obj-init.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj﹏init_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-obj-init.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-obj-value-null.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj﹏value﹏null_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-obj-value-null.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-obj-value-undef.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj﹏value﹏undef_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-obj-value-undef.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-prop-obj.js")]
        public void Test_dstr﹏obj﹏ptrn﹏prop﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-prop-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-rest-getter.js")]
        public void Test_dstr﹏obj﹏ptrn﹏rest﹏getter_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-rest-getter.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-rest-skip-non-enumerable.js")]
        public void Test_dstr﹏obj﹏ptrn﹏rest﹏skip﹏non﹏enumerable_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-rest-skip-non-enumerable.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/dstr-obj-ptrn-rest-val-obj.js")]
        public void Test_dstr﹏obj﹏ptrn﹏rest﹏val﹏obj_js()
        {
            RunTest("language/expressions/arrow-function/dstr-obj-ptrn-rest-val-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/empty-function-body-returns-undefined.js")]
        public void Test_empty﹏function﹏body﹏returns﹏undefined_js()
        {
            RunTest("language/expressions/arrow-function/empty-function-body-returns-undefined.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/expression-body-implicit-return.js")]
        public void Test_expression﹏body﹏implicit﹏return_js()
        {
            RunTest("language/expressions/arrow-function/expression-body-implicit-return.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/length-dflt.js")]
        public void Test_length﹏dflt_js()
        {
            RunTest("language/expressions/arrow-function/length-dflt.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-arguments.js")]
        public void Test_lexical﹏arguments_js()
        {
            RunTest("language/expressions/arrow-function/lexical-arguments.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-bindings-overriden-by-formal-parameters-non-strict.js")]
        public void Test_lexical﹏bindings﹏overriden﹏by﹏formal﹏parameters﹏non﹏strict_js()
        {
            RunTest("language/expressions/arrow-function/lexical-bindings-overriden-by-formal-parameters-non-strict.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-new.target-closure-returned.js")]
        public void Test_lexical﹏new_target﹏closure﹏returned_js()
        {
            RunTest("language/expressions/arrow-function/lexical-new.target-closure-returned.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-new.target.js")]
        public void Test_lexical﹏new_target_js()
        {
            RunTest("language/expressions/arrow-function/lexical-new.target.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-super-call-from-within-constructor.js")]
        public void Test_lexical﹏super﹏call﹏from﹏within﹏constructor_js()
        {
            RunTest("language/expressions/arrow-function/lexical-super-call-from-within-constructor.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-super-property-from-within-constructor.js")]
        public void Test_lexical﹏super﹏property﹏from﹏within﹏constructor_js()
        {
            RunTest("language/expressions/arrow-function/lexical-super-property-from-within-constructor.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-super-property.js")]
        public void Test_lexical﹏super﹏property_js()
        {
            RunTest("language/expressions/arrow-function/lexical-super-property.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-supercall-from-immediately-invoked-arrow.js")]
        public void Test_lexical﹏supercall﹏from﹏immediately﹏invoked﹏arrow_js()
        {
            RunTest("language/expressions/arrow-function/lexical-supercall-from-immediately-invoked-arrow.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/lexical-this.js")]
        public void Test_lexical﹏this_js()
        {
            RunTest("language/expressions/arrow-function/lexical-this.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/low-precedence-expression-body-no-parens.js")]
        public void Test_low﹏precedence﹏expression﹏body﹏no﹏parens_js()
        {
            RunTest("language/expressions/arrow-function/low-precedence-expression-body-no-parens.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/non-strict.js")]
        public void Test_non﹏strict_js()
        {
            RunTest("language/expressions/arrow-function/non-strict.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/object-literal-return-requires-body-parens.js")]
        public void Test_object﹏literal﹏return﹏requires﹏body﹏parens_js()
        {
            RunTest("language/expressions/arrow-function/object-literal-return-requires-body-parens.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/param-dflt-yield-expr.js")]
        public void Test_param﹏dflt﹏yield﹏expr_js()
        {
            RunTest("language/expressions/arrow-function/param-dflt-yield-expr.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/param-dflt-yield-id-non-strict.js")]
        public void Test_param﹏dflt﹏yield﹏id﹏non﹏strict_js()
        {
            RunTest("language/expressions/arrow-function/param-dflt-yield-id-non-strict.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/param-dflt-yield-id-strict.js")]
        public void Test_param﹏dflt﹏yield﹏id﹏strict_js()
        {
            RunTest("language/expressions/arrow-function/param-dflt-yield-id-strict.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/params-trailing-comma-multiple.js")]
        public void Test_params﹏trailing﹏comma﹏multiple_js()
        {
            RunTest("language/expressions/arrow-function/params-trailing-comma-multiple.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/params-trailing-comma-single.js")]
        public void Test_params﹏trailing﹏comma﹏single_js()
        {
            RunTest("language/expressions/arrow-function/params-trailing-comma-single.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/prototype-rules.js")]
        public void Test_prototype﹏rules_js()
        {
            RunTest("language/expressions/arrow-function/prototype-rules.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/rest-params-trailing-comma-early-error.js")]
        public void Test_rest﹏params﹏trailing﹏comma﹏early﹏error_js()
        {
            RunTest("language/expressions/arrow-function/rest-params-trailing-comma-early-error.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/scope-body-lex-distinct.js")]
        public void Test_scope﹏body﹏lex﹏distinct_js()
        {
            RunTest("language/expressions/arrow-function/scope-body-lex-distinct.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/scope-param-elem-var-close.js")]
        public void Test_scope﹏param﹏elem﹏var﹏close_js()
        {
            RunTest("language/expressions/arrow-function/scope-param-elem-var-close.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/scope-param-elem-var-open.js")]
        public void Test_scope﹏param﹏elem﹏var﹏open_js()
        {
            RunTest("language/expressions/arrow-function/scope-param-elem-var-open.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/scope-param-rest-elem-var-close.js")]
        public void Test_scope﹏param﹏rest﹏elem﹏var﹏close_js()
        {
            RunTest("language/expressions/arrow-function/scope-param-rest-elem-var-close.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/scope-param-rest-elem-var-open.js")]
        public void Test_scope﹏param﹏rest﹏elem﹏var﹏open_js()
        {
            RunTest("language/expressions/arrow-function/scope-param-rest-elem-var-open.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/scope-paramsbody-var-close.js")]
        public void Test_scope﹏paramsbody﹏var﹏close_js()
        {
            RunTest("language/expressions/arrow-function/scope-paramsbody-var-close.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/scope-paramsbody-var-open.js")]
        public void Test_scope﹏paramsbody﹏var﹏open_js()
        {
            RunTest("language/expressions/arrow-function/scope-paramsbody-var-open.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/statement-body-requires-braces-must-return-explicitly-missing.js")]
        public void Test_statement﹏body﹏requires﹏braces﹏must﹏return﹏explicitly﹏missing_js()
        {
            RunTest("language/expressions/arrow-function/statement-body-requires-braces-must-return-explicitly-missing.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/statement-body-requires-braces-must-return-explicitly.js")]
        public void Test_statement﹏body﹏requires﹏braces﹏must﹏return﹏explicitly_js()
        {
            RunTest("language/expressions/arrow-function/statement-body-requires-braces-must-return-explicitly.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/strict.js")]
        public void Test_strict_js()
        {
            RunTest("language/expressions/arrow-function/strict.js");
        }

        [Fact(DisplayName = "/language/expressions/arrow-function/throw-new.js")]
        public void Test_throw﹏new_js()
        {
            RunTest("language/expressions/arrow-function/throw-new.js");
        }
    }
}
