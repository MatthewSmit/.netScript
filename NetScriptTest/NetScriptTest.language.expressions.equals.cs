using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_equals : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/equals/bigint-and-bigint.js")]
        public void Test_bigint﹏and﹏bigint_js()
        {
            RunTest("language/expressions/equals/bigint-and-bigint.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/bigint-and-boolean.js")]
        public void Test_bigint﹏and﹏boolean_js()
        {
            RunTest("language/expressions/equals/bigint-and-boolean.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/bigint-and-incomparable-primitive.js")]
        public void Test_bigint﹏and﹏incomparable﹏primitive_js()
        {
            RunTest("language/expressions/equals/bigint-and-incomparable-primitive.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/bigint-and-non-finite.js")]
        public void Test_bigint﹏and﹏non﹏finite_js()
        {
            RunTest("language/expressions/equals/bigint-and-non-finite.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/bigint-and-number-extremes.js")]
        public void Test_bigint﹏and﹏number﹏extremes_js()
        {
            RunTest("language/expressions/equals/bigint-and-number-extremes.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/bigint-and-number.js")]
        public void Test_bigint﹏and﹏number_js()
        {
            RunTest("language/expressions/equals/bigint-and-number.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/bigint-and-object.js")]
        public void Test_bigint﹏and﹏object_js()
        {
            RunTest("language/expressions/equals/bigint-and-object.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/bigint-and-string.js")]
        public void Test_bigint﹏and﹏string_js()
        {
            RunTest("language/expressions/equals/bigint-and-string.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/coerce-symbol-to-prim-err.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏err_js()
        {
            RunTest("language/expressions/equals/coerce-symbol-to-prim-err.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/coerce-symbol-to-prim-invocation.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏invocation_js()
        {
            RunTest("language/expressions/equals/coerce-symbol-to-prim-invocation.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/coerce-symbol-to-prim-return-obj.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏return﹏obj_js()
        {
            RunTest("language/expressions/equals/coerce-symbol-to-prim-return-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/coerce-symbol-to-prim-return-prim.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏return﹏prim_js()
        {
            RunTest("language/expressions/equals/coerce-symbol-to-prim-return-prim.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/get-symbol-to-prim-err.js")]
        public void Test_get﹏symbol﹏to﹏prim﹏err_js()
        {
            RunTest("language/expressions/equals/get-symbol-to-prim-err.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A1.js")]
        public void Test_S11_9_1_A1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A2.1_T1.js")]
        public void Test_S11_9_1_A2_1_T1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A2.1_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A2.1_T2.js")]
        public void Test_S11_9_1_A2_1_T2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A2.1_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A2.1_T3.js")]
        public void Test_S11_9_1_A2_1_T3_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A2.1_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A2.4_T1.js")]
        public void Test_S11_9_1_A2_4_T1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A2.4_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A2.4_T2.js")]
        public void Test_S11_9_1_A2_4_T2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A2.4_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A2.4_T3.js")]
        public void Test_S11_9_1_A2_4_T3_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A2.4_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A2.4_T4.js")]
        public void Test_S11_9_1_A2_4_T4_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A2.4_T4.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A3.1.js")]
        public void Test_S11_9_1_A3_1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A3.1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A3.2.js")]
        public void Test_S11_9_1_A3_2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A3.2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A3.3.js")]
        public void Test_S11_9_1_A3_3_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A3.3.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A4.1_T1.js")]
        public void Test_S11_9_1_A4_1_T1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A4.1_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A4.1_T2.js")]
        public void Test_S11_9_1_A4_1_T2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A4.1_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A4.2.js")]
        public void Test_S11_9_1_A4_2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A4.2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A4.3.js")]
        public void Test_S11_9_1_A4_3_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A4.3.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A5.1.js")]
        public void Test_S11_9_1_A5_1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A5.1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A5.2.js")]
        public void Test_S11_9_1_A5_2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A5.2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A5.3.js")]
        public void Test_S11_9_1_A5_3_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A5.3.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A6.1.js")]
        public void Test_S11_9_1_A6_1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A6.1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A6.2_T1.js")]
        public void Test_S11_9_1_A6_2_T1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A6.2_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A6.2_T2.js")]
        public void Test_S11_9_1_A6_2_T2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A6.2_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.1.js")]
        public void Test_S11_9_1_A7_1_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.1.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.2.js")]
        public void Test_S11_9_1_A7_2_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.2.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.3.js")]
        public void Test_S11_9_1_A7_3_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.3.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.4.js")]
        public void Test_S11_9_1_A7_4_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.4.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.5.js")]
        public void Test_S11_9_1_A7_5_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.5.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.6.js")]
        public void Test_S11_9_1_A7_6_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.6.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.7.js")]
        public void Test_S11_9_1_A7_7_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.7.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.8.js")]
        public void Test_S11_9_1_A7_8_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.8.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S11.9.1_A7.9.js")]
        public void Test_S11_9_1_A7_9_js()
        {
            RunTest("language/expressions/equals/S11.9.1_A7.9.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/S9.1_A1_T3.js")]
        public void Test_S9_1_A1_T3_js()
        {
            RunTest("language/expressions/equals/S9.1_A1_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/symbol-abstract-equality-comparison.js")]
        public void Test_symbol﹏abstract﹏equality﹏comparison_js()
        {
            RunTest("language/expressions/equals/symbol-abstract-equality-comparison.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/symbol-strict-equality-comparison.js")]
        public void Test_symbol﹏strict﹏equality﹏comparison_js()
        {
            RunTest("language/expressions/equals/symbol-strict-equality-comparison.js");
        }

        [Fact(DisplayName = "/language/expressions/equals/to-prim-hint.js")]
        public void Test_to﹏prim﹏hint_js()
        {
            RunTest("language/expressions/equals/to-prim-hint.js");
        }
    }
}
