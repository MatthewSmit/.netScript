using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using NetScript.Runtime;
using YamlDotNet.RepresentationModel;

namespace NetScriptTest
{
    public abstract class BaseTest
    {
        private static readonly Regex metadataRegex = new Regex(@"^.*/\*---(.*)---\*/.*$", RegexOptions.Singleline | RegexOptions.Compiled);

        public static void RunTest([NotNull] string filePath)
        {
            var fileInfo = new FileInfo(Path.Combine(Environment.CurrentDirectory, "../../../test262/test/", filePath));
            var harnessDirectory = Path.Combine(Environment.CurrentDirectory, "../../../test262/harness");

            var testSource = File.ReadAllText(fileInfo.FullName);
            var metadataMatch = metadataRegex.Match(testSource);
            if (!metadataMatch.Success)
            {
                throw new NotImplementedException();
            }

            var metadataText = metadataMatch.Groups[1].Value;
            var metadata = ParseMetadata(metadataText);

            RunTest(harnessDirectory, metadata, testSource, fileInfo.FullName);
        }

        private static void RunTest(string harnessDirectory, [NotNull] TestMetadata metadata, string testSource, string fullName)
        {
            // Web browser only feature
            if (metadata.Features.Contains("caller"))
            {
                return;
            }

            // TODO
            if (metadata.Features.Contains("BigInt"))
            {
                return;
            }

            // TODO
            if (metadata.Features.Contains("async-iteration"))
            {
                return;
            }

            // TODO
            if (metadata.Features.Contains("generators"))
            {
                return;
            }

            // TODO
            if (metadata.Includes.Contains("tcoHelper.js"))
            {
                return;
            }

            // TODO
            if (metadata.Async)
            {
                return;
            }

            if (metadata.NegativePhase != null)
            {
                RunNegativeTest(harnessDirectory, metadata, testSource, fullName);
            }
            else if (metadata.Raw)
            {
                throw new NotImplementedException();
            }
            else if (metadata.Async)
            {
                if (!metadata.NoStrict)
                {
                    var agent = CreateAsyncTestAgent(harnessDirectory, metadata, true);
                    agent.QueueCode(testSource, new ScriptOptions
                    {
                        ScriptName = fullName,
                        Type = metadata.Module ? ScriptType.Module : ScriptType.Script,
                        ForceStrict = true
                    });
                    agent.RunAllJobs();
                }
                if (!metadata.OnlyStrict)
                {
                    var agent = CreateAsyncTestAgent(harnessDirectory, metadata, false);
                    agent.QueueCode(testSource, new ScriptOptions
                    {
                        ScriptName = fullName,
                        Type = metadata.Module ? ScriptType.Module : ScriptType.Script
                    });
                    agent.RunAllJobs();
                }
            }
            else
            {
                if (!metadata.NoStrict)
                {
                    var agent = CreateTestAgent(harnessDirectory, metadata, true);
                    agent.QueueCode(testSource, new ScriptOptions
                    {
                        ScriptName = fullName,
                        Type = metadata.Module ? ScriptType.Module : ScriptType.Script,
                        ForceStrict = true
                    });
                    agent.RunAllJobs();
                }
                if (!metadata.OnlyStrict)
                {
                    var agent = CreateTestAgent(harnessDirectory, metadata, false);
                    agent.QueueCode(testSource, new ScriptOptions
                    {
                        ScriptName = fullName,
                        Type = metadata.Module ? ScriptType.Module : ScriptType.Script
                    });
                    agent.RunAllJobs();
                }
            }
        }

        private static void RunNegativeTest(string harnessDirectory, [NotNull] TestMetadata metadata, string testSource, string fullName)
        {
            if (metadata.Raw)
            {
                throw new NotImplementedException();
            }
            if (metadata.Async)
            {
                throw new NotImplementedException();
            }

            var isEarly = metadata.NegativePhase == "early";

            if (!metadata.NoStrict)
            {
                var threw = false;
                var agent = CreateTestAgent(harnessDirectory, metadata, true);
                try
                {
                    agent.QueueCode(testSource, new ScriptOptions
                    {
                        ScriptName = fullName,
                        Type = metadata.Module ? ScriptType.Module : ScriptType.Script,
                        ForceStrict = true
                    });
                    agent.RunAllJobs();
                }
                catch (ScriptException e)
                {
                    var syntaxError = agent.GetPrototypeOf(e.Value) == agent.Realm.SyntaxErrorPrototype;
                    if (isEarly && !syntaxError)
                    {
                        throw;
                    }

                    threw = true;
                }

                if (!threw)
                {
                    throw new InvalidOperationException();
                }
            }

            if (!metadata.OnlyStrict)
            {
                var threw = false;
                var agent = CreateTestAgent(harnessDirectory, metadata, false);
                try
                {
                    agent.QueueCode(testSource, new ScriptOptions
                    {
                        ScriptName = fullName,
                        Type = metadata.Module ? ScriptType.Module : ScriptType.Script
                    });
                    agent.RunAllJobs();
                }
                catch (ScriptException e)
                {
                    var syntaxError = agent.GetPrototypeOf(e.Value) == agent.Realm.SyntaxErrorPrototype;
                    if (isEarly && !syntaxError)
                    {
                        throw;
                    }

                    threw = true;
                }

                if (!threw)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        [NotNull]
        private static Agent CreateTestAgent(string harnessDirectory, [NotNull] TestMetadata metadata, bool isStrict)
        {
            var includes = new HashSet<string> { "assert.js", "sta.js" };
            foreach (var include in metadata.Includes)
            {
                includes.Add(include);
            }

            var agent = new Agent();
            SetupRealm(agent, agent.Realm);

            foreach (var include in includes)
            {
                var file = Path.Combine(harnessDirectory, include);
                agent.QueueFile(file, new ScriptOptions
                {
                    Type = ScriptType.Script,
                    ForceStrict = isStrict
                });
            }

            return agent;
        }

        [NotNull]
        private static Agent CreateAsyncTestAgent(string harnessDirectory, [NotNull] TestMetadata metadata, bool isStrict)
        {
            var includes = new HashSet<string> { "assert.js", "sta.js", "doneprintHandle.js" };
            foreach (var include in metadata.Includes)
            {
                includes.Add(include);
            }

            var agent = new Agent();
            SetupRealm(agent, agent.Realm);

            foreach (var include in includes)
            {
                var file = Path.Combine(harnessDirectory, include);
                agent.QueueFile(file, new ScriptOptions
                {
                    Type = ScriptType.Script,
                    ForceStrict = isStrict
                });
            }

            return agent;
        }

        private static void SetupRealm([NotNull] Agent agent, [NotNull] Realm realm)
        {
            realm.GlobalObject["print"] = agent.CreateUserFunction(arguments =>
            {
                Console.WriteLine(arguments[0].ToString());
                return ScriptValue.Undefined;
            });

            var object262 = realm.GlobalObject["$262"] = agent.CreateObject();
            object262["createRealm"] = agent.CreateUserFunction(arguments =>
            {
                var newRealm = agent.CreateRealm();
                SetupRealm(agent, newRealm);
                return newRealm.GlobalObject["$262"];
            });
            object262["detachArrayBuffer"] = agent.CreateUserFunction(arguments =>
            {
                throw new NotImplementedException();
            });
            object262["evalScript"] = agent.CreateUserFunction(arguments =>
            {
                throw new NotImplementedException();
            });
            object262["global"] = realm.GlobalObject;
            var scriptAgent = object262["agent"] = agent.CreateObject();
            scriptAgent["start"] = agent.CreateUserFunction(arguments =>
            {
                throw new NotImplementedException();
            });
            scriptAgent["broadcast"] = agent.CreateUserFunction(arguments =>
            {
                throw new NotImplementedException();
            });
            scriptAgent["getReport"] = agent.CreateUserFunction(arguments =>
            {
                throw new NotImplementedException();
            });
            scriptAgent["sleep"] = agent.CreateUserFunction(arguments =>
            {
                throw new NotImplementedException();
            });
        }

        [NotNull]
        private static TestMetadata ParseMetadata([NotNull] string metadataText)
        {
            var yaml = new YamlStream();
            yaml.Load(new StringReader(metadataText));

            var metadata = new TestMetadata();

            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            if (mapping.Children.TryGetValue("negative", out var negative))
            {
                metadata.NegativePhase = ((YamlScalarNode)negative["phase"]).Value;
                metadata.NegativeType = ((YamlScalarNode)negative["type"]).Value;
            }

            if (mapping.Children.TryGetValue("includes", out var includes))
            {
                var includesSequence = (YamlSequenceNode)includes;
                foreach (var yamlNode in includesSequence)
                {
                    var include = (YamlScalarNode)yamlNode;
                    metadata.Includes.Add(include.Value);
                }
            }

            if (mapping.Children.TryGetValue("features", out var features))
            {
                var featuresSequence = (YamlSequenceNode)features;
                foreach (var yamlNode in featuresSequence)
                {
                    var feature = (YamlScalarNode)yamlNode;
                    metadata.Features.Add(feature.Value);
                }
            }

            if (mapping.Children.TryGetValue("flags", out var flags))
            {
                var flagsNode = (YamlSequenceNode)flags;
                foreach (var yamlNode in flagsNode)
                {
                    var flag = (YamlScalarNode)yamlNode;
                    switch (flag.Value)
                    {
                        case "onlyStrict":
                            metadata.OnlyStrict = true;
                            break;
                        case "noStrict":
                            metadata.NoStrict = true;
                            break;
                        case "module":
                            metadata.Module = true;
                            break;
                        case "raw":
                            metadata.Raw = true;
                            break;
                        case "async":
                            metadata.Async = true;
                            break;
                        case "generated":
                            metadata.Generated = true;
                            break;
                    }
                }
            }

            if (mapping.Children.TryGetValue("info", out var info))
            {
                var infoNode = (YamlScalarNode)info;
                metadata.Info = infoNode.Value;
            }

            if (mapping.Children.TryGetValue("esid", out var esid))
            {
                var esidNode = (YamlScalarNode)esid;
                metadata.EsId = esidNode.Value;
            }

            if (mapping.Children.TryGetValue("es5id", out var es5Id))
            {
                var es5IdNode = (YamlScalarNode)es5Id;
                metadata.Es5Id = es5IdNode.Value;
            }

            if (mapping.Children.TryGetValue("es6id", out var es6Id))
            {
                var es6IdNode = (YamlScalarNode)es6Id;
                metadata.Es6Id = es6IdNode.Value;
            }

            if (mapping.Children.TryGetValue("description", out var description))
            {
                var descriptionNode = (YamlScalarNode)description;
                metadata.Description = descriptionNode.Value;
            }

            if (mapping.Children.TryGetValue("author", out var author))
            {
                var authorNode = (YamlScalarNode)author;
                metadata.Author = authorNode.Value;
            }

            return metadata;
        }
    }
}
