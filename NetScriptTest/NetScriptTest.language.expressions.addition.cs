using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_addition : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/addition/bigint-arithmetic.js")]
        public void Test_bigint﹏arithmetic_js()
        {
            RunTest("language/expressions/addition/bigint-arithmetic.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/coerce-bigint-to-string.js")]
        public void Test_coerce﹏bigint﹏to﹏string_js()
        {
            RunTest("language/expressions/addition/coerce-bigint-to-string.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/coerce-symbol-to-prim-err.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏err_js()
        {
            RunTest("language/expressions/addition/coerce-symbol-to-prim-err.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/coerce-symbol-to-prim-invocation.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏invocation_js()
        {
            RunTest("language/expressions/addition/coerce-symbol-to-prim-invocation.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/coerce-symbol-to-prim-return-obj.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏return﹏obj_js()
        {
            RunTest("language/expressions/addition/coerce-symbol-to-prim-return-obj.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/coerce-symbol-to-prim-return-prim.js")]
        public void Test_coerce﹏symbol﹏to﹏prim﹏return﹏prim_js()
        {
            RunTest("language/expressions/addition/coerce-symbol-to-prim-return-prim.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/get-symbol-to-prim-err.js")]
        public void Test_get﹏symbol﹏to﹏prim﹏err_js()
        {
            RunTest("language/expressions/addition/get-symbol-to-prim-err.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A1.js")]
        public void Test_S11_6_1_A1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.1_T1.js")]
        public void Test_S11_6_1_A2_1_T1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.1_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.1_T2.js")]
        public void Test_S11_6_1_A2_1_T2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.1_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.1_T3.js")]
        public void Test_S11_6_1_A2_1_T3_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.1_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.2_T1.js")]
        public void Test_S11_6_1_A2_2_T1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.2_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.2_T2.js")]
        public void Test_S11_6_1_A2_2_T2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.2_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.2_T3.js")]
        public void Test_S11_6_1_A2_2_T3_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.2_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.3_T1.js")]
        public void Test_S11_6_1_A2_3_T1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.3_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.4_T1.js")]
        public void Test_S11_6_1_A2_4_T1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.4_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.4_T2.js")]
        public void Test_S11_6_1_A2_4_T2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.4_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.4_T3.js")]
        public void Test_S11_6_1_A2_4_T3_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.4_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A2.4_T4.js")]
        public void Test_S11_6_1_A2_4_T4_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A2.4_T4.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T1.1.js")]
        public void Test_S11_6_1_A3_1_T1_1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T1.1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T1.2.js")]
        public void Test_S11_6_1_A3_1_T1_2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T1.2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T1.3.js")]
        public void Test_S11_6_1_A3_1_T1_3_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T1.3.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T2.1.js")]
        public void Test_S11_6_1_A3_1_T2_1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T2.1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T2.2.js")]
        public void Test_S11_6_1_A3_1_T2_2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T2.2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T2.3.js")]
        public void Test_S11_6_1_A3_1_T2_3_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T2.3.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T2.4.js")]
        public void Test_S11_6_1_A3_1_T2_4_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T2.4.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.1_T2.5.js")]
        public void Test_S11_6_1_A3_1_T2_5_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.1_T2.5.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.2_T1.1.js")]
        public void Test_S11_6_1_A3_2_T1_1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.2_T1.1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.2_T1.2.js")]
        public void Test_S11_6_1_A3_2_T1_2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.2_T1.2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.2_T2.1.js")]
        public void Test_S11_6_1_A3_2_T2_1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.2_T2.1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.2_T2.2.js")]
        public void Test_S11_6_1_A3_2_T2_2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.2_T2.2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.2_T2.3.js")]
        public void Test_S11_6_1_A3_2_T2_3_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.2_T2.3.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A3.2_T2.4.js")]
        public void Test_S11_6_1_A3_2_T2_4_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A3.2_T2.4.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T1.js")]
        public void Test_S11_6_1_A4_T1_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T1.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T2.js")]
        public void Test_S11_6_1_A4_T2_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T2.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T3.js")]
        public void Test_S11_6_1_A4_T3_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T3.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T4.js")]
        public void Test_S11_6_1_A4_T4_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T4.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T5.js")]
        public void Test_S11_6_1_A4_T5_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T5.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T6.js")]
        public void Test_S11_6_1_A4_T6_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T6.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T7.js")]
        public void Test_S11_6_1_A4_T7_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T7.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T8.js")]
        public void Test_S11_6_1_A4_T8_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T8.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/S11.6.1_A4_T9.js")]
        public void Test_S11_6_1_A4_T9_js()
        {
            RunTest("language/expressions/addition/S11.6.1_A4_T9.js");
        }

        [Fact(DisplayName = "/language/expressions/addition/symbol-to-string.js")]
        public void Test_symbol﹏to﹏string_js()
        {
            RunTest("language/expressions/addition/symbol-to-string.js");
        }
    }
}
