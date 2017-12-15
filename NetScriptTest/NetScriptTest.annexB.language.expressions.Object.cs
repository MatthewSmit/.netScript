using Xunit;

namespace NetScriptTest.annexB.language.expressions
{
    public sealed class Test_Object : BaseTest
    {
        [Fact(DisplayName = "/annexB/language/expressions/object/__proto__-duplicate-computed.js")]
        public void Test___proto__﹏duplicate﹏computed_js()
        {
            RunTest("annexB/language/expressions/object/__proto__-duplicate-computed.js");
        }

        [Fact(DisplayName = "/annexB/language/expressions/object/__proto__-duplicate.js")]
        public void Test___proto__﹏duplicate_js()
        {
            RunTest("annexB/language/expressions/object/__proto__-duplicate.js");
        }

        [Fact(DisplayName = "/annexB/language/expressions/object/__proto__-fn-name.js")]
        public void Test___proto__﹏fn﹏name_js()
        {
            RunTest("annexB/language/expressions/object/__proto__-fn-name.js");
        }

        [Fact(DisplayName = "/annexB/language/expressions/object/__proto__-value-non-object.js")]
        public void Test___proto__﹏value﹏non﹏object_js()
        {
            RunTest("annexB/language/expressions/object/__proto__-value-non-object.js");
        }

        [Fact(DisplayName = "/annexB/language/expressions/object/__proto__-value-null.js")]
        public void Test___proto__﹏value﹏null_js()
        {
            RunTest("annexB/language/expressions/object/__proto__-value-null.js");
        }

        [Fact(DisplayName = "/annexB/language/expressions/object/__proto__-value-obj.js")]
        public void Test___proto__﹏value﹏obj_js()
        {
            RunTest("annexB/language/expressions/object/__proto__-value-obj.js");
        }
    }
}
