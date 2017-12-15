using Xunit;

namespace NetScriptTest.language.statements
{
    public sealed class Test_if : BaseTest
    {
        [Fact(DisplayName = "/language/statements/if/cptn-else-false-abrupt-empty.js")]
        public void Test_cptn﹏else﹏false﹏abrupt﹏empty_js()
        {
            RunTest("language/statements/if/cptn-else-false-abrupt-empty.js");
        }

        [Fact(DisplayName = "/language/statements/if/cptn-else-false-nrml.js")]
        public void Test_cptn﹏else﹏false﹏nrml_js()
        {
            RunTest("language/statements/if/cptn-else-false-nrml.js");
        }

        [Fact(DisplayName = "/language/statements/if/cptn-else-true-abrupt-empty.js")]
        public void Test_cptn﹏else﹏true﹏abrupt﹏empty_js()
        {
            RunTest("language/statements/if/cptn-else-true-abrupt-empty.js");
        }

        [Fact(DisplayName = "/language/statements/if/cptn-else-true-nrml.js")]
        public void Test_cptn﹏else﹏true﹏nrml_js()
        {
            RunTest("language/statements/if/cptn-else-true-nrml.js");
        }

        [Fact(DisplayName = "/language/statements/if/cptn-no-else-false.js")]
        public void Test_cptn﹏no﹏else﹏false_js()
        {
            RunTest("language/statements/if/cptn-no-else-false.js");
        }

        [Fact(DisplayName = "/language/statements/if/cptn-no-else-true-abrupt-empty.js")]
        public void Test_cptn﹏no﹏else﹏true﹏abrupt﹏empty_js()
        {
            RunTest("language/statements/if/cptn-no-else-true-abrupt-empty.js");
        }

        [Fact(DisplayName = "/language/statements/if/cptn-no-else-true-nrml.js")]
        public void Test_cptn﹏no﹏else﹏true﹏nrml_js()
        {
            RunTest("language/statements/if/cptn-no-else-true-nrml.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-async-fun-else-async-fun.js")]
        public void Test_if﹏async﹏fun﹏else﹏async﹏fun_js()
        {
            RunTest("language/statements/if/if-async-fun-else-async-fun.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-async-fun-else-stmt.js")]
        public void Test_if﹏async﹏fun﹏else﹏stmt_js()
        {
            RunTest("language/statements/if/if-async-fun-else-stmt.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-async-fun-no-else.js")]
        public void Test_if﹏async﹏fun﹏no﹏else_js()
        {
            RunTest("language/statements/if/if-async-fun-no-else.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-async-gen-else-async-gen.js")]
        public void Test_if﹏async﹏gen﹏else﹏async﹏gen_js()
        {
            RunTest("language/statements/if/if-async-gen-else-async-gen.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-async-gen-else-stmt.js")]
        public void Test_if﹏async﹏gen﹏else﹏stmt_js()
        {
            RunTest("language/statements/if/if-async-gen-else-stmt.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-async-gen-no-else.js")]
        public void Test_if﹏async﹏gen﹏no﹏else_js()
        {
            RunTest("language/statements/if/if-async-gen-no-else.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-cls-else-cls.js")]
        public void Test_if﹏cls﹏else﹏cls_js()
        {
            RunTest("language/statements/if/if-cls-else-cls.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-cls-else-stmt.js")]
        public void Test_if﹏cls﹏else﹏stmt_js()
        {
            RunTest("language/statements/if/if-cls-else-stmt.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-cls-no-else.js")]
        public void Test_if﹏cls﹏no﹏else_js()
        {
            RunTest("language/statements/if/if-cls-no-else.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-const-else-const.js")]
        public void Test_if﹏const﹏else﹏const_js()
        {
            RunTest("language/statements/if/if-const-else-const.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-const-else-stmt.js")]
        public void Test_if﹏const﹏else﹏stmt_js()
        {
            RunTest("language/statements/if/if-const-else-stmt.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-const-no-else.js")]
        public void Test_if﹏const﹏no﹏else_js()
        {
            RunTest("language/statements/if/if-const-no-else.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-decl-else-decl-strict.js")]
        public void Test_if﹏decl﹏else﹏decl﹏strict_js()
        {
            RunTest("language/statements/if/if-decl-else-decl-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-decl-else-stmt-strict.js")]
        public void Test_if﹏decl﹏else﹏stmt﹏strict_js()
        {
            RunTest("language/statements/if/if-decl-else-stmt-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-decl-no-else-strict.js")]
        public void Test_if﹏decl﹏no﹏else﹏strict_js()
        {
            RunTest("language/statements/if/if-decl-no-else-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-fun-else-fun-strict.js")]
        public void Test_if﹏fun﹏else﹏fun﹏strict_js()
        {
            RunTest("language/statements/if/if-fun-else-fun-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-fun-else-stmt-strict.js")]
        public void Test_if﹏fun﹏else﹏stmt﹏strict_js()
        {
            RunTest("language/statements/if/if-fun-else-stmt-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-fun-no-else-strict.js")]
        public void Test_if﹏fun﹏no﹏else﹏strict_js()
        {
            RunTest("language/statements/if/if-fun-no-else-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-gen-else-gen.js")]
        public void Test_if﹏gen﹏else﹏gen_js()
        {
            RunTest("language/statements/if/if-gen-else-gen.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-gen-else-stmt.js")]
        public void Test_if﹏gen﹏else﹏stmt_js()
        {
            RunTest("language/statements/if/if-gen-else-stmt.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-gen-no-else.js")]
        public void Test_if﹏gen﹏no﹏else_js()
        {
            RunTest("language/statements/if/if-gen-no-else.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-let-else-let.js")]
        public void Test_if﹏let﹏else﹏let_js()
        {
            RunTest("language/statements/if/if-let-else-let.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-let-else-stmt.js")]
        public void Test_if﹏let﹏else﹏stmt_js()
        {
            RunTest("language/statements/if/if-let-else-stmt.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-let-no-else.js")]
        public void Test_if﹏let﹏no﹏else_js()
        {
            RunTest("language/statements/if/if-let-no-else.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-async-fun.js")]
        public void Test_if﹏stmt﹏else﹏async﹏fun_js()
        {
            RunTest("language/statements/if/if-stmt-else-async-fun.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-async-gen.js")]
        public void Test_if﹏stmt﹏else﹏async﹏gen_js()
        {
            RunTest("language/statements/if/if-stmt-else-async-gen.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-cls.js")]
        public void Test_if﹏stmt﹏else﹏cls_js()
        {
            RunTest("language/statements/if/if-stmt-else-cls.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-const.js")]
        public void Test_if﹏stmt﹏else﹏const_js()
        {
            RunTest("language/statements/if/if-stmt-else-const.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-decl-strict.js")]
        public void Test_if﹏stmt﹏else﹏decl﹏strict_js()
        {
            RunTest("language/statements/if/if-stmt-else-decl-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-fun-strict.js")]
        public void Test_if﹏stmt﹏else﹏fun﹏strict_js()
        {
            RunTest("language/statements/if/if-stmt-else-fun-strict.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-gen.js")]
        public void Test_if﹏stmt﹏else﹏gen_js()
        {
            RunTest("language/statements/if/if-stmt-else-gen.js");
        }

        [Fact(DisplayName = "/language/statements/if/if-stmt-else-let.js")]
        public void Test_if﹏stmt﹏else﹏let_js()
        {
            RunTest("language/statements/if/if-stmt-else-let.js");
        }

        [Fact(DisplayName = "/language/statements/if/labelled-fn-stmt-first.js")]
        public void Test_labelled﹏fn﹏stmt﹏first_js()
        {
            RunTest("language/statements/if/labelled-fn-stmt-first.js");
        }

        [Fact(DisplayName = "/language/statements/if/labelled-fn-stmt-lone.js")]
        public void Test_labelled﹏fn﹏stmt﹏lone_js()
        {
            RunTest("language/statements/if/labelled-fn-stmt-lone.js");
        }

        [Fact(DisplayName = "/language/statements/if/labelled-fn-stmt-second.js")]
        public void Test_labelled﹏fn﹏stmt﹏second_js()
        {
            RunTest("language/statements/if/labelled-fn-stmt-second.js");
        }

        [Fact(DisplayName = "/language/statements/if/let-array-with-newline.js")]
        public void Test_let﹏array﹏with﹏newline_js()
        {
            RunTest("language/statements/if/let-array-with-newline.js");
        }

        [Fact(DisplayName = "/language/statements/if/let-block-with-newline.js")]
        public void Test_let﹏block﹏with﹏newline_js()
        {
            RunTest("language/statements/if/let-block-with-newline.js");
        }

        [Fact(DisplayName = "/language/statements/if/let-identifier-with-newline.js")]
        public void Test_let﹏identifier﹏with﹏newline_js()
        {
            RunTest("language/statements/if/let-identifier-with-newline.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A1.1_T1.js")]
        public void Test_S12_5_A1_1_T1_js()
        {
            RunTest("language/statements/if/S12.5_A1.1_T1.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A1.1_T2.js")]
        public void Test_S12_5_A1_1_T2_js()
        {
            RunTest("language/statements/if/S12.5_A1.1_T2.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A1.2_T1.js")]
        public void Test_S12_5_A1_2_T1_js()
        {
            RunTest("language/statements/if/S12.5_A1.2_T1.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A1.2_T2.js")]
        public void Test_S12_5_A1_2_T2_js()
        {
            RunTest("language/statements/if/S12.5_A1.2_T2.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A10_T1.js")]
        public void Test_S12_5_A10_T1_js()
        {
            RunTest("language/statements/if/S12.5_A10_T1.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A10_T2.js")]
        public void Test_S12_5_A10_T2_js()
        {
            RunTest("language/statements/if/S12.5_A10_T2.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A11.js")]
        public void Test_S12_5_A11_js()
        {
            RunTest("language/statements/if/S12.5_A11.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A12_T1.js")]
        public void Test_S12_5_A12_T1_js()
        {
            RunTest("language/statements/if/S12.5_A12_T1.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A12_T2.js")]
        public void Test_S12_5_A12_T2_js()
        {
            RunTest("language/statements/if/S12.5_A12_T2.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A12_T3.js")]
        public void Test_S12_5_A12_T3_js()
        {
            RunTest("language/statements/if/S12.5_A12_T3.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A12_T4.js")]
        public void Test_S12_5_A12_T4_js()
        {
            RunTest("language/statements/if/S12.5_A12_T4.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A1_T1.js")]
        public void Test_S12_5_A1_T1_js()
        {
            RunTest("language/statements/if/S12.5_A1_T1.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A1_T2.js")]
        public void Test_S12_5_A1_T2_js()
        {
            RunTest("language/statements/if/S12.5_A1_T2.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A2.js")]
        public void Test_S12_5_A2_js()
        {
            RunTest("language/statements/if/S12.5_A2.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A3.js")]
        public void Test_S12_5_A3_js()
        {
            RunTest("language/statements/if/S12.5_A3.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A4.js")]
        public void Test_S12_5_A4_js()
        {
            RunTest("language/statements/if/S12.5_A4.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A5.js")]
        public void Test_S12_5_A5_js()
        {
            RunTest("language/statements/if/S12.5_A5.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A6_T1.js")]
        public void Test_S12_5_A6_T1_js()
        {
            RunTest("language/statements/if/S12.5_A6_T1.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A6_T2.js")]
        public void Test_S12_5_A6_T2_js()
        {
            RunTest("language/statements/if/S12.5_A6_T2.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A7.js")]
        public void Test_S12_5_A7_js()
        {
            RunTest("language/statements/if/S12.5_A7.js");
        }

        [Fact(DisplayName = "/language/statements/if/S12.5_A8.js")]
        public void Test_S12_5_A8_js()
        {
            RunTest("language/statements/if/S12.5_A8.js");
        }

        [Fact(DisplayName = "/language/statements/if/tco-else-body.js")]
        public void Test_tco﹏else﹏body_js()
        {
            RunTest("language/statements/if/tco-else-body.js");
        }

        [Fact(DisplayName = "/language/statements/if/tco-if-body.js")]
        public void Test_tco﹏if﹏body_js()
        {
            RunTest("language/statements/if/tco-if-body.js");
        }
    }
}
