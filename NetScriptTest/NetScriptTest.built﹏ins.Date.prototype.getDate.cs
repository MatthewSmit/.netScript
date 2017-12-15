using Xunit;

namespace NetScriptTest.built﹏ins.Date.prototype
{
    public sealed class Test_getDate : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Date/prototype/getDate/name.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/S15.9.5.14_A1_T1.js")]
        public void Test_S15_9_5_14_A1_T1_js()
        {
            RunTest("built-ins/Date/prototype/getDate/S15.9.5.14_A1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/S15.9.5.14_A1_T2.js")]
        public void Test_S15_9_5_14_A1_T2_js()
        {
            RunTest("built-ins/Date/prototype/getDate/S15.9.5.14_A1_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/S15.9.5.14_A1_T3.js")]
        public void Test_S15_9_5_14_A1_T3_js()
        {
            RunTest("built-ins/Date/prototype/getDate/S15.9.5.14_A1_T3.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/S15.9.5.14_A2_T1.js")]
        public void Test_S15_9_5_14_A2_T1_js()
        {
            RunTest("built-ins/Date/prototype/getDate/S15.9.5.14_A2_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/S15.9.5.14_A3_T1.js")]
        public void Test_S15_9_5_14_A3_T1_js()
        {
            RunTest("built-ins/Date/prototype/getDate/S15.9.5.14_A3_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/S15.9.5.14_A3_T2.js")]
        public void Test_S15_9_5_14_A3_T2_js()
        {
            RunTest("built-ins/Date/prototype/getDate/S15.9.5.14_A3_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/S15.9.5.14_A3_T3.js")]
        public void Test_S15_9_5_14_A3_T3_js()
        {
            RunTest("built-ins/Date/prototype/getDate/S15.9.5.14_A3_T3.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/this-value-invalid-date.js")]
        public void Test_this﹏value﹏invalid﹏date_js()
        {
            RunTest("built-ins/Date/prototype/getDate/this-value-invalid-date.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/this-value-non-date.js")]
        public void Test_this﹏value﹏non﹏date_js()
        {
            RunTest("built-ins/Date/prototype/getDate/this-value-non-date.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/this-value-non-object.js")]
        public void Test_this﹏value﹏non﹏object_js()
        {
            RunTest("built-ins/Date/prototype/getDate/this-value-non-object.js");
        }

        [Fact(DisplayName = "/built-ins/Date/prototype/getDate/this-value-valid-date.js")]
        public void Test_this﹏value﹏valid﹏date_js()
        {
            RunTest("built-ins/Date/prototype/getDate/this-value-valid-date.js");
        }
    }
}
