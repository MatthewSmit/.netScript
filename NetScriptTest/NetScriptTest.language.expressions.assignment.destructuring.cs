using Xunit;

namespace NetScriptTest.language.expressions.assignment
{
    public sealed class Test_destructuring : BaseTest
    {
        [Fact(DisplayName = "/language/expressions/assignment/destructuring/iterator-destructuring-property-reference-target-evaluation-order.js")]
        public void Test_iterator﹏destructuring﹏property﹏reference﹏target﹏evaluation﹏order_js()
        {
            RunTest("language/expressions/assignment/destructuring/iterator-destructuring-property-reference-target-evaluation-order.js");
        }

        [Fact(DisplayName = "/language/expressions/assignment/destructuring/keyed-destructuring-property-reference-target-evaluation-order.js")]
        public void Test_keyed﹏destructuring﹏property﹏reference﹏target﹏evaluation﹏order_js()
        {
            RunTest("language/expressions/assignment/destructuring/keyed-destructuring-property-reference-target-evaluation-order.js");
        }

        [Fact(DisplayName = "/language/expressions/assignment/destructuring/obj-prop-__proto__dup.js")]
        public void Test_obj﹏prop﹏__proto__dup_js()
        {
            RunTest("language/expressions/assignment/destructuring/obj-prop-__proto__dup.js");
        }
    }
}
