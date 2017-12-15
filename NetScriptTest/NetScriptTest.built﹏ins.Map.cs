using Xunit;

namespace NetScriptTest.built﹏ins
{
    public sealed class Test_Map : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Map/constructor.js")]
        public void Test_constructor_js()
        {
            RunTest("built-ins/Map/constructor.js");
        }

        [Fact(DisplayName = "/built-ins/Map/does-not-throw-when-set-is-not-callable.js")]
        public void Test_does﹏not﹏throw﹏when﹏set﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Map/does-not-throw-when-set-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Map/get-set-method-failure.js")]
        public void Test_get﹏set﹏method﹏failure_js()
        {
            RunTest("built-ins/Map/get-set-method-failure.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterable-calls-set.js")]
        public void Test_iterable﹏calls﹏set_js()
        {
            RunTest("built-ins/Map/iterable-calls-set.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterator-close-after-set-failure.js")]
        public void Test_iterator﹏close﹏after﹏set﹏failure_js()
        {
            RunTest("built-ins/Map/iterator-close-after-set-failure.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterator-item-first-entry-returns-abrupt.js")]
        public void Test_iterator﹏item﹏first﹏entry﹏returns﹏abrupt_js()
        {
            RunTest("built-ins/Map/iterator-item-first-entry-returns-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterator-item-second-entry-returns-abrupt.js")]
        public void Test_iterator﹏item﹏second﹏entry﹏returns﹏abrupt_js()
        {
            RunTest("built-ins/Map/iterator-item-second-entry-returns-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterator-items-are-not-object-close-iterator.js")]
        public void Test_iterator﹏items﹏are﹏not﹏object﹏close﹏iterator_js()
        {
            RunTest("built-ins/Map/iterator-items-are-not-object-close-iterator.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterator-items-are-not-object.js")]
        public void Test_iterator﹏items﹏are﹏not﹏object_js()
        {
            RunTest("built-ins/Map/iterator-items-are-not-object.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterator-next-failure.js")]
        public void Test_iterator﹏next﹏failure_js()
        {
            RunTest("built-ins/Map/iterator-next-failure.js");
        }

        [Fact(DisplayName = "/built-ins/Map/iterator-value-failure.js")]
        public void Test_iterator﹏value﹏failure_js()
        {
            RunTest("built-ins/Map/iterator-value-failure.js");
        }

        [Fact(DisplayName = "/built-ins/Map/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Map/length.js");
        }

        [Fact(DisplayName = "/built-ins/Map/map-iterable-empty-does-not-call-set.js")]
        public void Test_map﹏iterable﹏empty﹏does﹏not﹏call﹏set_js()
        {
            RunTest("built-ins/Map/map-iterable-empty-does-not-call-set.js");
        }

        [Fact(DisplayName = "/built-ins/Map/map-iterable-throws-when-set-is-not-callable.js")]
        public void Test_map﹏iterable﹏throws﹏when﹏set﹏is﹏not﹏callable_js()
        {
            RunTest("built-ins/Map/map-iterable-throws-when-set-is-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Map/map-iterable.js")]
        public void Test_map﹏iterable_js()
        {
            RunTest("built-ins/Map/map-iterable.js");
        }

        [Fact(DisplayName = "/built-ins/Map/map-no-iterable-does-not-call-set.js")]
        public void Test_map﹏no﹏iterable﹏does﹏not﹏call﹏set_js()
        {
            RunTest("built-ins/Map/map-no-iterable-does-not-call-set.js");
        }

        [Fact(DisplayName = "/built-ins/Map/map-no-iterable.js")]
        public void Test_map﹏no﹏iterable_js()
        {
            RunTest("built-ins/Map/map-no-iterable.js");
        }

        [Fact(DisplayName = "/built-ins/Map/map.js")]
        public void Test_map_js()
        {
            RunTest("built-ins/Map/map.js");
        }

        [Fact(DisplayName = "/built-ins/Map/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Map/name.js");
        }

        [Fact(DisplayName = "/built-ins/Map/newtarget.js")]
        public void Test_newtarget_js()
        {
            RunTest("built-ins/Map/newtarget.js");
        }

        [Fact(DisplayName = "/built-ins/Map/properties-of-map-instances.js")]
        public void Test_properties﹏of﹏map﹏instances_js()
        {
            RunTest("built-ins/Map/properties-of-map-instances.js");
        }

        [Fact(DisplayName = "/built-ins/Map/properties-of-the-map-prototype-object.js")]
        public void Test_properties﹏of﹏the﹏map﹏prototype﹏object_js()
        {
            RunTest("built-ins/Map/properties-of-the-map-prototype-object.js");
        }

        [Fact(DisplayName = "/built-ins/Map/proto-from-ctor-realm.js")]
        public void Test_proto﹏from﹏ctor﹏realm_js()
        {
            RunTest("built-ins/Map/proto-from-ctor-realm.js");
        }

        [Fact(DisplayName = "/built-ins/Map/prototype-of-map.js")]
        public void Test_prototype﹏of﹏map_js()
        {
            RunTest("built-ins/Map/prototype-of-map.js");
        }

        [Fact(DisplayName = "/built-ins/Map/symbol-as-entry-key.js")]
        public void Test_symbol﹏as﹏entry﹏key_js()
        {
            RunTest("built-ins/Map/symbol-as-entry-key.js");
        }

        [Fact(DisplayName = "/built-ins/Map/undefined-newtarget.js")]
        public void Test_undefined﹏newtarget_js()
        {
            RunTest("built-ins/Map/undefined-newtarget.js");
        }
    }
}
