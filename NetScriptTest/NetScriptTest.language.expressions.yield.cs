using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_yield : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/yield/arguments-object-attributes.js")]
        public void Test_arguments﹏object﹏attributes_js()
        {
            RunTest("language/expressions/yield/arguments-object-attributes.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/captured-free-vars.js")]
        public void Test_captured﹏free﹏vars_js()
        {
            RunTest("language/expressions/yield/captured-free-vars.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/formal-parameters-after-reassignment-non-strict.js")]
        public void Test_formal﹏parameters﹏after﹏reassignment﹏non﹏strict_js()
        {
            RunTest("language/expressions/yield/formal-parameters-after-reassignment-non-strict.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/formal-parameters-after-reassignment-strict.js")]
        public void Test_formal﹏parameters﹏after﹏reassignment﹏strict_js()
        {
            RunTest("language/expressions/yield/formal-parameters-after-reassignment-strict.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/formal-parameters.js")]
        public void Test_formal﹏parameters_js()
        {
            RunTest("language/expressions/yield/formal-parameters.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/from-catch.js")]
        public void Test_from﹏catch_js()
        {
            RunTest("language/expressions/yield/from-catch.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/from-try.js")]
        public void Test_from﹏try_js()
        {
            RunTest("language/expressions/yield/from-try.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/from-with.js")]
        public void Test_from﹏with_js()
        {
            RunTest("language/expressions/yield/from-with.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/in-iteration-stmt.js")]
        public void Test_in﹏iteration﹏stmt_js()
        {
            RunTest("language/expressions/yield/in-iteration-stmt.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/in-rltn-expr.js")]
        public void Test_in﹏rltn﹏expr_js()
        {
            RunTest("language/expressions/yield/in-rltn-expr.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/invalid-left-hand-side.js")]
        public void Test_invalid﹏left﹏hand﹏side_js()
        {
            RunTest("language/expressions/yield/invalid-left-hand-side.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/iter-value-specified.js")]
        public void Test_iter﹏value﹏specified_js()
        {
            RunTest("language/expressions/yield/iter-value-specified.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/iter-value-unspecified.js")]
        public void Test_iter﹏value﹏unspecified_js()
        {
            RunTest("language/expressions/yield/iter-value-unspecified.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/rhs-iter.js")]
        public void Test_rhs﹏iter_js()
        {
            RunTest("language/expressions/yield/rhs-iter.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/rhs-omitted.js")]
        public void Test_rhs﹏omitted_js()
        {
            RunTest("language/expressions/yield/rhs-omitted.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/rhs-primitive.js")]
        public void Test_rhs﹏primitive_js()
        {
            RunTest("language/expressions/yield/rhs-primitive.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/rhs-regexp.js")]
        public void Test_rhs﹏regexp_js()
        {
            RunTest("language/expressions/yield/rhs-regexp.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/rhs-template-middle.js")]
        public void Test_rhs﹏template﹏middle_js()
        {
            RunTest("language/expressions/yield/rhs-template-middle.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/rhs-unresolvable.js")]
        public void Test_rhs﹏unresolvable_js()
        {
            RunTest("language/expressions/yield/rhs-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/rhs-yield.js")]
        public void Test_rhs﹏yield_js()
        {
            RunTest("language/expressions/yield/rhs-yield.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-array.js")]
        public void Test_star﹏array_js()
        {
            RunTest("language/expressions/yield/star-array.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-in-iteration-stmt.js")]
        public void Test_star﹏in﹏iteration﹏stmt_js()
        {
            RunTest("language/expressions/yield/star-in-iteration-stmt.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-in-rltn-expr.js")]
        public void Test_star﹏in﹏rltn﹏expr_js()
        {
            RunTest("language/expressions/yield/star-in-rltn-expr.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-iterable.js")]
        public void Test_star﹏iterable_js()
        {
            RunTest("language/expressions/yield/star-iterable.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-get-call-err.js")]
        public void Test_star﹏rhs﹏iter﹏get﹏call﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-get-call-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-get-call-non-obj.js")]
        public void Test_star﹏rhs﹏iter﹏get﹏call﹏non﹏obj_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-get-call-non-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-get-get-err.js")]
        public void Test_star﹏rhs﹏iter﹏get﹏get﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-get-get-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-next-call-err.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏next﹏call﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-next-call-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-next-call-non-obj.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏next﹏call﹏non﹏obj_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-next-call-non-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-next-get-err.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏next﹏get﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-next-get-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-next-invoke.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏next﹏invoke_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-next-invoke.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-res-done-err.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏res﹏done﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-res-done-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-res-done-no-value.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏res﹏done﹏no﹏value_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-res-done-no-value.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-res-value-err.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏res﹏value﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-res-value-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-nrml-res-value-final.js")]
        public void Test_star﹏rhs﹏iter﹏nrml﹏res﹏value﹏final_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-nrml-res-value-final.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-no-rtrn.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏no﹏rtrn_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-no-rtrn.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-res-done-err.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏res﹏done﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-res-done-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-res-done-no-value.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏res﹏done﹏no﹏value_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-res-done-no-value.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-res-value-err.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏res﹏value﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-res-value-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-res-value-final.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏res﹏value﹏final_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-res-value-final.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-rtrn-call-err.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏rtrn﹏call﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-rtrn-call-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-rtrn-call-non-obj.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏rtrn﹏call﹏non﹏obj_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-rtrn-call-non-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-rtrn-get-err.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏rtrn﹏get﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-rtrn-get-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-rtrn-rtrn-invoke.js")]
        public void Test_star﹏rhs﹏iter﹏rtrn﹏rtrn﹏invoke_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-rtrn-rtrn-invoke.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-res-done-err.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏res﹏done﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-res-done-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-res-done-no-value.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏res﹏done﹏no﹏value_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-res-done-no-value.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-res-value-err.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏res﹏value﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-res-value-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-res-value-final.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏res﹏value﹏final_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-res-value-final.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-thrw-call-err.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏thrw﹏call﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-thrw-call-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-thrw-call-non-obj.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏thrw﹏call﹏non﹏obj_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-thrw-call-non-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-thrw-get-err.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏thrw﹏get﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-thrw-get-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-thrw-invoke.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏thrw﹏invoke_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-thrw-invoke.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-violation-no-rtrn.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏violation﹏no﹏rtrn_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-violation-no-rtrn.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-call-err.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏violation﹏rtrn﹏call﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-call-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-call-non-obj.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏violation﹏rtrn﹏call﹏non﹏obj_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-call-non-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-get-err.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏violation﹏rtrn﹏get﹏err_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-get-err.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-invoke.js")]
        public void Test_star﹏rhs﹏iter﹏thrw﹏violation﹏rtrn﹏invoke_js()
        {
            RunTest("language/expressions/yield/star-rhs-iter-thrw-violation-rtrn-invoke.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-rhs-unresolvable.js")]
        public void Test_star﹏rhs﹏unresolvable_js()
        {
            RunTest("language/expressions/yield/star-rhs-unresolvable.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/star-string.js")]
        public void Test_star﹏string_js()
        {
            RunTest("language/expressions/yield/star-string.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/then-return.js")]
        public void Test_then﹏return_js()
        {
            RunTest("language/expressions/yield/then-return.js");
        }

        [Fact(DisplayName = "/language/expressions/yield/within-for.js")]
        public void Test_within﹏for_js()
        {
            RunTest("language/expressions/yield/within-for.js");
        }
    }
}
