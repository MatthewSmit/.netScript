using Xunit;

namespace NetScriptTest.language.expressions
{
    public sealed class Test_new_target : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/new.target/asi.js")]
        public void Test_asi_js()
        {
            RunTest("language/expressions/new.target/asi.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/escaped-new.js")]
        public void Test_escaped﹏new_js()
        {
            RunTest("language/expressions/new.target/escaped-new.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/escaped-target.js")]
        public void Test_escaped﹏target_js()
        {
            RunTest("language/expressions/new.target/escaped-target.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-call.js")]
        public void Test_value﹏via﹏call_js()
        {
            RunTest("language/expressions/new.target/value-via-call.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-fpapply.js")]
        public void Test_value﹏via﹏fpapply_js()
        {
            RunTest("language/expressions/new.target/value-via-fpapply.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-fpcall.js")]
        public void Test_value﹏via﹏fpcall_js()
        {
            RunTest("language/expressions/new.target/value-via-fpcall.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-member.js")]
        public void Test_value﹏via﹏member_js()
        {
            RunTest("language/expressions/new.target/value-via-member.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-new.js")]
        public void Test_value﹏via﹏new_js()
        {
            RunTest("language/expressions/new.target/value-via-new.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-reflect-apply.js")]
        public void Test_value﹏via﹏reflect﹏apply_js()
        {
            RunTest("language/expressions/new.target/value-via-reflect-apply.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-reflect-construct.js")]
        public void Test_value﹏via﹏reflect﹏construct_js()
        {
            RunTest("language/expressions/new.target/value-via-reflect-construct.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-super-call.js")]
        public void Test_value﹏via﹏super﹏call_js()
        {
            RunTest("language/expressions/new.target/value-via-super-call.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-super-property.js")]
        public void Test_value﹏via﹏super﹏property_js()
        {
            RunTest("language/expressions/new.target/value-via-super-property.js");
        }

        [Fact(DisplayName = "/language/expressions/new.target/value-via-tagged-template.js")]
        public void Test_value﹏via﹏tagged﹏template_js()
        {
            RunTest("language/expressions/new.target/value-via-tagged-template.js");
        }
    }
}
