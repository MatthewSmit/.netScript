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
//            TestSpeed();
//            TestCompat();

            BaseTest.
                RunTest("built-ins/Object/getOwnPropertyDescriptor/15.2.3.3-4-123.js");
        }

//        private static void TestCompat()
//        {
//            CompatTest("es5");
//            CompatTest("es6");
//            CompatTest("es2016plus");
//            CompatTest("esintl");
//            CompatTest("esnext");
//            CompatTest("non-standard");
//        }
//
//        private static void CompatTest(string es5)
//        {
//            var tests = JsonConvert.DeserializeObject<Dictionary<int, JObject>>(File.ReadAllText($@"C:\Work\compat-table\test_{es5}.json"));
//            var results = new Dictionary<string, Dictionary<string, bool>>();
//            Dictionary<string, bool> currentDictionary = null;
//
//            foreach (var test in tests.Values)
//            {
//                if (test["desc"].ToString().Length == 0)
//                {
//                    continue;
//                }
//
//                var name = test["desc"].ToString().Substring(1).Trim();
//                if (!test["tests"].HasValues)
//                {
//                    currentDictionary = new Dictionary<string, bool>();
//                    results[name] = currentDictionary;
//                }
//                else
//                {
//                    var testCodes = test["tests"].Select(x => x.ToString()).ToArray();
//                    bool[] result = {false};
//
//                    if (!string.Equals(name, "direct recursion", StringComparison.Ordinal) &&
//                        !string.Equals(name, "mutual recursion", StringComparison.Ordinal))
//                    {
//                        var agent = new Agent();
//                        agent.Global["test"] = agent.CreateUserFunction(arguments =>
//                        {
//                            result[0] = result[0] || agent.ToBoolean(arguments[0]);
//                            return ScriptValue.Undefined;
//                        });
//
//                        agent.Global["asyncPassed"] = agent.CreateUserFunction(arguments =>
//                        {
//                            result[0] = true;
//                            return ScriptValue.Undefined;
//                        });
//
//                        agent.Global["__createIterableObject"] = agent.CreateUserFunction(arguments =>
//                        {
//                            /*global.__createIterableObject = function (arr, methods) {
//                              methods = methods || {};
//                              if (typeof Symbol !== 'function' || !Symbol.iterator)
//                                return {};
//                              arr.length++;
//                              var iterator = {
//                                next: function() {
//                                  return { value: arr.shift(), done: arr.length <= 0 };
//                                },
//                                'return': methods['return'],
//                                'throw': methods['throw']
//                              };
//                              var iterable = {};
//                              iterable[Symbol.iterator] = function(){ return iterator; };
//                              return iterable;
//                            };*/
//
//                            throw new NotImplementedException();
//                        });
//
//                        try
//                        {
//                            foreach (var testCode in testCodes)
//                            {
//                                agent.QueueCode(testCode);
//                                agent.RunAllJobs();
//                            }
//                        }
//                        catch (Exception)
//                        {
//                            result[0] = false;
//                        }
//                    }
//
//                    Debug.Assert(currentDictionary != null, nameof(currentDictionary) + " != null");
//                    currentDictionary[name] = result[0];
//                }
//            }
//
//            File.WriteAllText($"results_{es5}.json", JsonConvert.SerializeObject(results, Formatting.Indented));
//        }

        private static void TestSpeed()
        {
            var agent = new Agent();
            agent.Global["load"] = agent.CreateUserFunction(arguments =>
            {
                var file = @"C:\Work\arewefastyet\benchmarks\octane\" + arguments[0].ToString();
                return agent.RunFile(file);
            });

            agent.Global["print"] = agent.CreateUserFunction(arguments =>
            {
                Console.WriteLine(arguments[0]);
                return ScriptValue.Undefined;
            });

            var performance = agent.Global["performance"] = agent.CreateObject();
            performance["now"] = agent.CreateUserFunction(arguments => { throw new NotImplementedException(); });

            agent.QueueFile(@"C:\Work\arewefastyet\benchmarks\octane\run.js");
            agent.RunAllJobs();
        }

        private static void Test1()
        {
            var agent = new Agent();
            agent.Global["print"] = agent.CreateUserFunction(arguments =>
            {
                Console.WriteLine(arguments[0].ToString());
                return ScriptValue.Undefined;
            });
            agent.RunCode(@"1.797693134862315808e+308 === +Infinity");
        }
    }
}
