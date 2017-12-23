using System;
using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed partial class Agent
    {
        /// <summary>
        /// Creates an Agent.
        /// </summary>
        public Agent()
        {
            //https://tc39.github.io/ecma262/#sec-initializehostdefinedrealm

            var realm = new Realm(this, "Default");
            var newContext = new ExecutionContext(realm, null, true);
            ExecutionContexts.Add(newContext);
            RunningExecutionContext = newContext;
            realm.SetRealmGlobalObject(null, null);
            realm.SetDefaultGlobalBindings();
        }

        /// <summary>
        /// Queues ECMAScript code to be run when RunNextJob/RunAllJobs is next called.
        /// </summary>
        /// <param name="source">The source code for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        public void QueueCode([NotNull] string source, ScriptOptions options = default)
        {
            EnqueueJob(scriptJobs, () => RunCode(source, options));
        }

        /// <summary>
        /// Queues ECMAScript code to be run when RunNextJob/RunAllJobs is next called.
        /// </summary>
        /// <param name="fileName">The file name for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        public void QueueFile([NotNull] string fileName, ScriptOptions options = default)
        {
            if (options.ScriptName == null)
            {
                options.ScriptName = fileName;
            }

            QueueCode(File.ReadAllText(fileName), options);
        }

        /// <summary>
        /// Immediately runs the ECMAScript code.
        /// </summary>
        /// <param name="source">The source code for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        /// <returns>The value of the last expression run.</returns>
        public ScriptValue RunCode([NotNull] string source,ScriptOptions options = default)
        {
            if (options.ForceStrict)
            {
                source = "'use strict';" + source;
            }

            switch (options.Type)
            {
                case ScriptType.Script:
                    var script = ParseScript(source, options.ScriptName, false, false);
                    return ScriptEvaluation((RunningExecutionContext.Realm, script));
                case ScriptType.Module:
                    var module = ParseModule(source, options.ScriptName);
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Immediately runs the ECMAScript code.
        /// </summary>
        /// <param name="fileName">The file name for the ECMAScript code.</param>
        /// <param name="options">Options used to customise the compilation and execution.</param>
        /// <returns>The value of the last expression run.</returns>
        public ScriptValue RunFile([NotNull] string fileName, ScriptOptions options = default)
        {
            if (options.ScriptName == null)
            {
                options.ScriptName = fileName;
            }

            return RunCode(File.ReadAllText(fileName), options);
        }

        /// <summary>
        /// Runs jobs until the queue is empty.
        /// </summary>
        public void RunAllJobs()
        {
            while (scriptJobs.Count > 0 || promiseJobs.Count > 0)
            {
                RunNextJob();
            }
        }

        /// <summary>
        /// Runs the next job.
        /// </summary>
        public void RunNextJob()
        {
            Debug.Assert(ExecutionContexts.Count == 1 && RunningExecutionContext == ExecutionContexts[0]);
            ExecutionContexts.Clear();

            var nextQueue = promiseJobs.Count > 0 ? promiseJobs : scriptJobs;
            var nextPending = nextQueue.Dequeue();
            var newContext = new ExecutionContext(nextPending.Realm, nextPending.ScriptOrModule, true);
            ExecutionContexts.Add(newContext);
            RunningExecutionContext = newContext;
            nextPending.Callback();
        }

        /// <summary>
        /// Creates a new realm.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public Realm CreateRealm(string name = "")
        {
            var newRealm = new Realm(this, name);
            newRealm.SetRealmGlobalObject(null, null);
            newRealm.SetDefaultGlobalBindings();
            return newRealm;
        }

        /// <summary>
        /// Creates a new ECMAScript object.
        /// </summary>
        /// <param name="prototype">The prototype of the new object. Will use the object prototype if null.</param>
        /// <returns>The new ECMAScript object.</returns>
        [NotNull]
        public ScriptObject CreateObject(ScriptObject prototype = null)
        {
            if (prototype == null)
            {
                prototype = Realm.ObjectPrototype;
            }

            return ObjectCreate(prototype);
        }

        /// <summary>
        /// Creates an ECMAScript function that calls managed code.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        [NotNull]
        public ScriptFunctionObject CreateUserFunction([NotNull] Func<ScriptArguments, ScriptValue> callback)
        {
            return new ScriptFunctionObject(Realm, Realm.FunctionPrototype, true, callback);
        }

        /// <summary>
        /// Returns the prototype of a script value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [CanBeNull]
        public ScriptObject GetPrototypeOf(ScriptValue value)
        {
            var obj = ToObject(value);
            return obj.GetPrototypeOf();
        }

        /// <summary>
        /// Returns the global object for the current Realm.
        /// </summary>
        public ScriptObject Global => Realm.GlobalObject;

        /// <summary>
        /// Returns the current execution contexts Realm.
        /// </summary>
        [NotNull]
        public Realm Realm => RunningExecutionContext.Realm;

        public bool LittleEndian => BitConverter.IsLittleEndian;
    }
}
