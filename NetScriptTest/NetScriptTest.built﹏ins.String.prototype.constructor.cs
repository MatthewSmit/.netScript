using Xunit;

namespace NetScriptTest.built﹏ins.String.prototype
{
    public sealed class Test_constructor : BaseTest
    {
        [Fact(DisplayName = "/built-ins/String/prototype/constructor/S15.5.4.1_A1_T1.js")]
        public void Test_S15_5_4_1_A1_T1_js()
        {
            RunTest("built-ins/String/prototype/constructor/S15.5.4.1_A1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/String/prototype/constructor/S15.5.4.1_A1_T2.js")]
        public void Test_S15_5_4_1_A1_T2_js()
        {
            RunTest("built-ins/String/prototype/constructor/S15.5.4.1_A1_T2.js");
        }
    }
}
