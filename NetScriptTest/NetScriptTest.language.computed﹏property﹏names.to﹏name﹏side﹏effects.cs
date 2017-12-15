using Xunit;

namespace NetScriptTest.language.computed﹏property﹏names
{
    public sealed class Test_to﹏name﹏side﹏effects : BaseTest
    {
        [Fact(DisplayName = "/language/computed-property-names/to-name-side-effects/class.js")]
        public void Test_class_js()
        {
            RunTest("language/computed-property-names/to-name-side-effects/class.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/to-name-side-effects/numbers-class.js")]
        public void Test_numbers﹏class_js()
        {
            RunTest("language/computed-property-names/to-name-side-effects/numbers-class.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/to-name-side-effects/numbers-object.js")]
        public void Test_numbers﹏object_js()
        {
            RunTest("language/computed-property-names/to-name-side-effects/numbers-object.js");
        }

        [Fact(DisplayName = "/language/computed-property-names/to-name-side-effects/object.js")]
        public void Test_object_js()
        {
            RunTest("language/computed-property-names/to-name-side-effects/object.js");
        }
    }
}
