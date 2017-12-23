using System;
using System.Collections.Generic;
using System.Diagnostics;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed partial class Agent
    {
        //https://tc39.github.io/ecma262/#sec-ecmascript-function-objects

        [NotNull]
        internal static ScriptFunctionObject FunctionAllocate([NotNull] ScriptObject functionPrototype, bool strict, FunctionKind functionKind)
        {
            //https://tc39.github.io/ecma262/#sec-functionallocate
            Debug.Assert(functionPrototype != null);
            var needsConstruct = functionKind == FunctionKind.Normal;
            if (functionKind == FunctionKind.NonConstructor)
            {
                functionKind = FunctionKind.Normal;
            }

            return new ScriptFunctionObject(functionPrototype.Realm, functionPrototype, true, functionKind, needsConstruct ? ConstructorKind.Base : ConstructorKind.None, strict);
        }

        [NotNull]
        internal ScriptFunctionObject FunctionInitialise([NotNull] ScriptFunctionObject function, FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope)
        {
            //https://tc39.github.io/ecma262/#sec-functioninitialize
            Debug.Assert(function.IsExtensible && function.GetOwnProperty("length") == null);
            var length = ExpectedArgumentCount(parameters);
            DefinePropertyOrThrow(function, "length", new PropertyDescriptor(length, false, false, true));

            var strict = function.Strict;
            function.Environment = scope;
            function.FormalParameters = parameters;
            function.ECMAScriptCode = new FunctionNode(body);
            function.ScriptOrModule = GetActiveScriptOrModule();
            if (kind == FunctionKind.Arrow)
            {
                function.ThisMode = ThisMode.Lexical;
            }
            else if (strict)
            {
                function.ThisMode = ThisMode.Strict;
            }
            else
            {
                function.ThisMode = ThisMode.Global;
            }
            return function;
        }

        [NotNull]
        internal ScriptFunctionObject FunctionCreate(FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope, bool strict, ScriptObject prototype = null)
        {
            if (prototype == null)
            {
                prototype = RunningExecutionContext.Realm.FunctionPrototype;
            }

            var function = FunctionAllocate(prototype, strict, kind == FunctionKind.Normal ? FunctionKind.Normal : FunctionKind.NonConstructor);
            return FunctionInitialise(function, kind, parameters, body, scope);
        }

        [NotNull]
        internal ScriptFunctionObject GeneratorFunctionCreate(FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-generatorfunctioncreate

            var function = FunctionAllocate(Realm.Generator, strict, FunctionKind.Generator);
            return FunctionInitialise(function, kind, parameters, body, scope);
        }

        [NotNull]
        internal ScriptFunctionObject AsyncFunctionCreate(FunctionKind kind, [NotNull] IReadOnlyList<ExpressionNode> parameters, [NotNull] BaseNode body, [NotNull] LexicalEnvironment scope, bool strict)
        {
            //https://tc39.github.io/ecma262/#sec-async-functions-abstract-operations-async-function-create
            var function = FunctionAllocate(Realm.AsyncFunctionPrototype, strict, FunctionKind.Async);
            return FunctionInitialise(function, kind, parameters, body, scope);
        }

        internal void MakeConstructor([NotNull] ScriptFunctionObject function, bool writablePrototype = true, [CanBeNull] ScriptObject prototype = null)
        {
            //https://tc39.github.io/ecma262/#sec-makeconstructor

            Debug.Assert(function.ConstructorKind != ConstructorKind.None);
            Debug.Assert(function.IsExtensible);
            Debug.Assert(!function.HasOwnProperty("prototype"));

            if (prototype == null)
            {
                prototype = ObjectCreate(RunningExecutionContext.Realm.ObjectPrototype);
                DefinePropertyOrThrow(prototype, "constructor", new PropertyDescriptor(function, writablePrototype, false, true));
            }

            DefinePropertyOrThrow(function, "prototype", new PropertyDescriptor(prototype, writablePrototype, false, false));
        }

        internal static void MakeClassConstructor([NotNull] ScriptFunctionObject function)
        {
            //https://tc39.github.io/ecma262/#sec-makeclassconstructor
            Debug.Assert(function.FunctionKind == FunctionKind.Normal);
            function.FunctionKind = FunctionKind.ClassConstructor;
        }

        internal static void MakeMethod([NotNull] ScriptFunctionObject function, ScriptObject homeObject)
        {
            //https://tc39.github.io/ecma262/#sec-makemethod
            function.HomeObject = homeObject;
        }

        internal void SetFunctionName([NotNull] ScriptObject function, ScriptValue name, [CanBeNull] string prefix = null)
        {
            //https://tc39.github.io/ecma262/#sec-setfunctionname
            Debug.Assert(function.IsExtensible && !function.HasOwnProperty("name"));
            Debug.Assert(name.IsSymbol || name.IsString);

            string realName;
            if (name.IsSymbol)
            {
                var nameSymbol = (Symbol)name;
                var description = nameSymbol.Description;
                if (description == null)
                {
                    realName = "";
                }
                else
                {
                    realName = "[" + description + "]";
                }
            }
            else
            {
                realName = (string)name;
            }

            if (prefix != null)
            {
                realName = prefix + " " + realName;
            }

            DefinePropertyOrThrow(function, "name", new PropertyDescriptor(realName, false, false, true));
        }

        //https://tc39.github.io/ecma262/#sec-built-in-function-objects

        [NotNull]
        internal static ScriptFunctionObject CreateBuiltinFunction([NotNull] Realm realm, [NotNull] Func<ScriptArguments, ScriptValue> callback, [CanBeNull] ScriptObject prototype)
        {
            //https://tc39.github.io/ecma262/#sec-createbuiltinfunction
            return new ScriptFunctionObject(realm, prototype, true, callback);
        }
    }
}
