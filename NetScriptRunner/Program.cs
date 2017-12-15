using System;
using NetScript.Runtime;
using NetScriptTest;

namespace NetScriptRunner
{
    internal static class Program
    {
        private static void Main()
        {
//            Test1();
//            return;

//            TestSpeed();
//            return;

            BaseTest.
                RunTest("language/statements/with/S12.10_A1.5_T1.js");
        }

        private static void TestSpeed()
        {
            var scriptAgent = new Agent();
            scriptAgent.Global["load"] = scriptAgent.CreateCallbackObject(arguments =>
            {
                var file = @"C:\Work\arewefastyet\benchmarks\octane\" + arguments[0].ToString();
                return scriptAgent.RunFile(file);
            });

            var performance = scriptAgent.Global["performance"] = scriptAgent.CreateObject();
            performance["now"] = scriptAgent.CreateCallbackObject(arguments => { throw new NotImplementedException(); });

            scriptAgent.QueueFile(@"C:\Work\arewefastyet\benchmarks\octane\run.js");
            scriptAgent.RunAllJobs();
        }

        private static void Test1()
        {
            var scriptAgent = new Agent();
            scriptAgent.Global["print"] = scriptAgent.CreateCallbackObject(arguments =>
            {
                Console.WriteLine(arguments[0].ToString());
                return ScriptValue.Undefined;
            });
            scriptAgent.QueueCode(@"function foo({y: x = 42}) {}; foo({});");
            scriptAgent.RunAllJobs();
        }
    }
}
