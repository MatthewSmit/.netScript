using Xunit;

namespace NetScriptTest.built﹏ins.Promise.prototype
{
    public sealed class Test_then : BaseTest
    {
        [Fact(DisplayName = "/built-ins/Promise/prototype/then/capability-executor-called-twice.js")]
        public void Test_capability﹏executor﹏called﹏twice_js()
        {
            RunTest("built-ins/Promise/prototype/then/capability-executor-called-twice.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/capability-executor-not-callable.js")]
        public void Test_capability﹏executor﹏not﹏callable_js()
        {
            RunTest("built-ins/Promise/prototype/then/capability-executor-not-callable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/context-check-on-entry.js")]
        public void Test_context﹏check﹏on﹏entry_js()
        {
            RunTest("built-ins/Promise/prototype/then/context-check-on-entry.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/ctor-access-count.js")]
        public void Test_ctor﹏access﹏count_js()
        {
            RunTest("built-ins/Promise/prototype/then/ctor-access-count.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/ctor-custom.js")]
        public void Test_ctor﹏custom_js()
        {
            RunTest("built-ins/Promise/prototype/then/ctor-custom.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/ctor-null.js")]
        public void Test_ctor﹏null_js()
        {
            RunTest("built-ins/Promise/prototype/then/ctor-null.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/ctor-poisoned.js")]
        public void Test_ctor﹏poisoned_js()
        {
            RunTest("built-ins/Promise/prototype/then/ctor-poisoned.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/ctor-throws.js")]
        public void Test_ctor﹏throws_js()
        {
            RunTest("built-ins/Promise/prototype/then/ctor-throws.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/ctor-undef.js")]
        public void Test_ctor﹏undef_js()
        {
            RunTest("built-ins/Promise/prototype/then/ctor-undef.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/deferred-is-resolved-value.js")]
        public void Test_deferred﹏is﹏resolved﹏value_js()
        {
            RunTest("built-ins/Promise/prototype/then/deferred-is-resolved-value.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/length.js")]
        public void Test_length_js()
        {
            RunTest("built-ins/Promise/prototype/then/length.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/name.js")]
        public void Test_name_js()
        {
            RunTest("built-ins/Promise/prototype/then/name.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/prfm-fulfilled.js")]
        public void Test_prfm﹏fulfilled_js()
        {
            RunTest("built-ins/Promise/prototype/then/prfm-fulfilled.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/prfm-pending-fulfulled.js")]
        public void Test_prfm﹏pending﹏fulfulled_js()
        {
            RunTest("built-ins/Promise/prototype/then/prfm-pending-fulfulled.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/prfm-pending-rejected.js")]
        public void Test_prfm﹏pending﹏rejected_js()
        {
            RunTest("built-ins/Promise/prototype/then/prfm-pending-rejected.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/prfm-rejected.js")]
        public void Test_prfm﹏rejected_js()
        {
            RunTest("built-ins/Promise/prototype/then/prfm-rejected.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/prop-desc.js")]
        public void Test_prop﹏desc_js()
        {
            RunTest("built-ins/Promise/prototype/then/prop-desc.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/reject-pending-fulfilled.js")]
        public void Test_reject﹏pending﹏fulfilled_js()
        {
            RunTest("built-ins/Promise/prototype/then/reject-pending-fulfilled.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/reject-pending-rejected.js")]
        public void Test_reject﹏pending﹏rejected_js()
        {
            RunTest("built-ins/Promise/prototype/then/reject-pending-rejected.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/reject-settled-fulfilled.js")]
        public void Test_reject﹏settled﹏fulfilled_js()
        {
            RunTest("built-ins/Promise/prototype/then/reject-settled-fulfilled.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/reject-settled-rejected.js")]
        public void Test_reject﹏settled﹏rejected_js()
        {
            RunTest("built-ins/Promise/prototype/then/reject-settled-rejected.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-fulfilled-non-obj.js")]
        public void Test_resolve﹏pending﹏fulfilled﹏non﹏obj_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-fulfilled-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-fulfilled-non-thenable.js")]
        public void Test_resolve﹏pending﹏fulfilled﹏non﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-fulfilled-non-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-fulfilled-poisoned-then.js")]
        public void Test_resolve﹏pending﹏fulfilled﹏poisoned﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-fulfilled-poisoned-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-fulfilled-prms-cstm-then.js")]
        public void Test_resolve﹏pending﹏fulfilled﹏prms﹏cstm﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-fulfilled-prms-cstm-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-fulfilled-self.js")]
        public void Test_resolve﹏pending﹏fulfilled﹏self_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-fulfilled-self.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-fulfilled-thenable.js")]
        public void Test_resolve﹏pending﹏fulfilled﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-fulfilled-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-rejected-non-obj.js")]
        public void Test_resolve﹏pending﹏rejected﹏non﹏obj_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-rejected-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-rejected-non-thenable.js")]
        public void Test_resolve﹏pending﹏rejected﹏non﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-rejected-non-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-rejected-poisoned-then.js")]
        public void Test_resolve﹏pending﹏rejected﹏poisoned﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-rejected-poisoned-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-rejected-prms-cstm-then.js")]
        public void Test_resolve﹏pending﹏rejected﹏prms﹏cstm﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-rejected-prms-cstm-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-rejected-self.js")]
        public void Test_resolve﹏pending﹏rejected﹏self_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-rejected-self.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-pending-rejected-thenable.js")]
        public void Test_resolve﹏pending﹏rejected﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-pending-rejected-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-fulfilled-non-obj.js")]
        public void Test_resolve﹏settled﹏fulfilled﹏non﹏obj_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-fulfilled-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-fulfilled-non-thenable.js")]
        public void Test_resolve﹏settled﹏fulfilled﹏non﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-fulfilled-non-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-fulfilled-poisoned-then.js")]
        public void Test_resolve﹏settled﹏fulfilled﹏poisoned﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-fulfilled-poisoned-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-fulfilled-prms-cstm-then.js")]
        public void Test_resolve﹏settled﹏fulfilled﹏prms﹏cstm﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-fulfilled-prms-cstm-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-fulfilled-self.js")]
        public void Test_resolve﹏settled﹏fulfilled﹏self_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-fulfilled-self.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-fulfilled-thenable.js")]
        public void Test_resolve﹏settled﹏fulfilled﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-fulfilled-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-rejected-non-obj.js")]
        public void Test_resolve﹏settled﹏rejected﹏non﹏obj_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-rejected-non-obj.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-rejected-non-thenable.js")]
        public void Test_resolve﹏settled﹏rejected﹏non﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-rejected-non-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-rejected-poisoned-then.js")]
        public void Test_resolve﹏settled﹏rejected﹏poisoned﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-rejected-poisoned-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-rejected-prms-cstm-then.js")]
        public void Test_resolve﹏settled﹏rejected﹏prms﹏cstm﹏then_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-rejected-prms-cstm-then.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-rejected-self.js")]
        public void Test_resolve﹏settled﹏rejected﹏self_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-rejected-self.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/resolve-settled-rejected-thenable.js")]
        public void Test_resolve﹏settled﹏rejected﹏thenable_js()
        {
            RunTest("built-ins/Promise/prototype/then/resolve-settled-rejected-thenable.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-fulfilled-invoke-nonstrict.js")]
        public void Test_rxn﹏handler﹏fulfilled﹏invoke﹏nonstrict_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-fulfilled-invoke-nonstrict.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-fulfilled-invoke-strict.js")]
        public void Test_rxn﹏handler﹏fulfilled﹏invoke﹏strict_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-fulfilled-invoke-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-fulfilled-next-abrupt.js")]
        public void Test_rxn﹏handler﹏fulfilled﹏next﹏abrupt_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-fulfilled-next-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-fulfilled-next.js")]
        public void Test_rxn﹏handler﹏fulfilled﹏next_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-fulfilled-next.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-fulfilled-return-abrupt.js")]
        public void Test_rxn﹏handler﹏fulfilled﹏return﹏abrupt_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-fulfilled-return-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-fulfilled-return-normal.js")]
        public void Test_rxn﹏handler﹏fulfilled﹏return﹏normal_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-fulfilled-return-normal.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-identity.js")]
        public void Test_rxn﹏handler﹏identity_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-identity.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-rejected-invoke-nonstrict.js")]
        public void Test_rxn﹏handler﹏rejected﹏invoke﹏nonstrict_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-rejected-invoke-nonstrict.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-rejected-invoke-strict.js")]
        public void Test_rxn﹏handler﹏rejected﹏invoke﹏strict_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-rejected-invoke-strict.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-rejected-next-abrupt.js")]
        public void Test_rxn﹏handler﹏rejected﹏next﹏abrupt_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-rejected-next-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-rejected-next.js")]
        public void Test_rxn﹏handler﹏rejected﹏next_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-rejected-next.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-rejected-return-abrupt.js")]
        public void Test_rxn﹏handler﹏rejected﹏return﹏abrupt_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-rejected-return-abrupt.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-rejected-return-normal.js")]
        public void Test_rxn﹏handler﹏rejected﹏return﹏normal_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-rejected-return-normal.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/rxn-handler-thrower.js")]
        public void Test_rxn﹏handler﹏thrower_js()
        {
            RunTest("built-ins/Promise/prototype/then/rxn-handler-thrower.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.4_A1.1_T1.js")]
        public void Test_S25_4_4_A1_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.4_A1.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.4_A2.1_T1.js")]
        public void Test_S25_4_4_A2_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.4_A2.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.4_A2.1_T2.js")]
        public void Test_S25_4_4_A2_1_T2_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.4_A2.1_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.4_A2.1_T3.js")]
        public void Test_S25_4_4_A2_1_T3_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.4_A2.1_T3.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A1.1_T1.js")]
        public void Test_S25_4_5_3_A1_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A1.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A1.1_T2.js")]
        public void Test_S25_4_5_3_A1_1_T2_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A1.1_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A2.1_T1.js")]
        public void Test_S25_4_5_3_A2_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A2.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A2.1_T2.js")]
        public void Test_S25_4_5_3_A2_1_T2_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A2.1_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A4.1_T1.js")]
        public void Test_S25_4_5_3_A4_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A4.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A4.1_T2.js")]
        public void Test_S25_4_5_3_A4_1_T2_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A4.1_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A4.2_T1.js")]
        public void Test_S25_4_5_3_A4_2_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A4.2_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A4.2_T2.js")]
        public void Test_S25_4_5_3_A4_2_T2_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A4.2_T2.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A5.1_T1.js")]
        public void Test_S25_4_5_3_A5_1_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A5.1_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A5.2_T1.js")]
        public void Test_S25_4_5_3_A5_2_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A5.2_T1.js");
        }

        [Fact(DisplayName = "/built-ins/Promise/prototype/then/S25.4.5.3_A5.3_T1.js")]
        public void Test_S25_4_5_3_A5_3_T1_js()
        {
            RunTest("built-ins/Promise/prototype/then/S25.4.5.3_A5.3_T1.js");
        }
    }
}
