using System;
using System.Collections.Generic;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class FunctionIntrinsics
    {
        [NotNull]
        public static ScriptFunctionObject Initialise([NotNull] Realm realm, [NotNull] ScriptObject functionPrototype)
        {
            //https://tc39.github.io/ecma262/#sec-function-objects

            var function = Intrinsics.CreateBuiltinFunction(realm, Function, functionPrototype, 1, "Function", ConstructorKind.Base);
            Intrinsics.DefineDataProperty(function, "prototype", functionPrototype, false, false, false);

            Intrinsics.DefineDataProperty(functionPrototype, "length", 0);
            Intrinsics.DefineDataProperty(functionPrototype, "name", "");

            Intrinsics.DefineFunction(functionPrototype, "apply", 2, realm, Apply);
            Intrinsics.DefineFunction(functionPrototype, "bind", 1, realm, Bind);
            Intrinsics.DefineFunction(functionPrototype, "call", 1, realm, Call);
            Intrinsics.DefineDataProperty(functionPrototype, "constructor", function);
            Intrinsics.DefineFunction(functionPrototype, "toString", 0, realm, ToString);
            Intrinsics.DefineDataProperty(functionPrototype, Symbol.HasInstance, Intrinsics.CreateBuiltinFunction(realm, HasInstance, functionPrototype, 1, "[Symbol.hasInstance]"), false, false, false);

            return function;
        }

        private static ScriptValue Function([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-function-p1-p2-pn-body
            return CreateDynamicFunction(arg.Function, arg.NewTarget, FunctionKind.Normal, arg);
        }

        private static ScriptValue Apply([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-function.prototype.apply
            if (!Agent.IsCallable(arg.ThisValue))
            {
                throw arg.Agent.CreateTypeError();
            }

            if (arg[1] == ScriptValue.Undefined || arg[1] == ScriptValue.Null)
            {
                return arg.Agent.Call((ScriptObject)arg.ThisValue, arg[0]);
            }

            var argList = arg.Agent.CreateListFromArrayLike(arg[1]);
            return arg.Agent.Call((ScriptObject)arg.ThisValue, arg[0], argList);
        }

        private static ScriptValue Bind([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-function.prototype.bind
            var target = arg.ThisValue;
            if (!Agent.IsCallable(target))
            {
                throw arg.Agent.CreateTypeError();
            }

            var targetObject = (ScriptObject)target;

            var arguments = new ScriptValue[Math.Max(arg.Count - 1, 0)];
            for (var i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arg[i + 1];
            }

            var function = new ScriptBoundFunctionObject(targetObject, arg[0], arguments);
            var targetHasLength = targetObject.HasOwnProperty("length");
            int length;
            if (targetHasLength)
            {
                var targetLength = targetObject.Get("length");
                if (!targetLength.IsNumber)
                {
                    length = 0;
                }
                else
                {
                    var number = arg.Agent.ToInteger(targetLength);
                    length = Math.Max(0, (int)number - arg.Count + 1);
                }
            }
            else
            {
                length = 0;
            }

            arg.Agent.DefinePropertyOrThrow(function, "length", new PropertyDescriptor(length, false, false, true));
            var targetName = targetObject.Get("name");
            if (!targetName.IsString)
            {
                targetName = "";
            }

            arg.Agent.SetFunctionName(function, targetName, "bound");
            return function;
        }

        private static ScriptValue Call([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-function.prototype.call
            var function = arg.ThisValue;
            if (!Agent.IsCallable(function))
            {
                throw arg.Agent.CreateTypeError();
            }

            var argumentList = new List<ScriptValue>();
            for (var i = 1; i < arg.Count; i++)
            {
                argumentList.Add(arg[i]);
            }

            return arg.Agent.Call((ScriptObject)function, arg[0], argumentList);
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-function.prototype.tostring
            var func = arg.ThisValue;
            if (func.IsObject && (ScriptObject)func is ScriptBoundFunctionObject)
            {
                //Return an implementation-dependent String source code representation of func. The representation must conform to the rules below. It is implementation-dependent whether the representation includes bound function information or information about the target function.
                throw new NotImplementedException();
            }

            if (func.IsObject && (ScriptObject)func is ScriptFunctionObject)
            {
                //Return an implementation-dependent String source code representation of func. The representation must conform to the rules below.
                //TODO:
                return "throw new SyntaxError();";
            }

            throw arg.Agent.CreateTypeError();
        }

        private static ScriptValue HasInstance([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-function.prototype-@@hasinstance
            var function = arg.ThisValue;
            return arg.Agent.OrdinaryHasInstance(function, arg[0]);
        }


        internal static ScriptValue CreateDynamicFunction([NotNull] ScriptObject constructor, ScriptObject newTarget, FunctionKind kind, [NotNull] ScriptArguments args)
        {
            //https://tc39.github.io/ecma262/#sec-createdynamicfunction

            var callerContext = args.Agent.RunningExecutionContext.Realm;
            var calleeRealm = constructor.Realm;
            args.Agent.HostEnsureCanCompileStrings(callerContext, calleeRealm);

            if (newTarget == null)
            {
                newTarget = constructor;
            }

            string startFunction;
            ScriptObject fallbackPrototype;
            switch (kind)
            {
                case FunctionKind.Normal:
                    startFunction = "function anonymous(";
                    fallbackPrototype = newTarget.Realm.FunctionPrototype;
                    break;
                case FunctionKind.Generator:
                    startFunction = "function *anonymous(";
                    fallbackPrototype = newTarget.Realm.Generator;
                    break;
                case FunctionKind.Async:
                    startFunction = "async function anonymous(";
                    fallbackPrototype = newTarget.Realm.AsyncFunctionPrototype;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }

            var parameters = "";
            string bodyText;
            if (args.Count == 0)
            {
                bodyText = "";
            }
            else if (args.Count == 1)
            {
                bodyText = args.Agent.ToString(args[0]);
            }
            else
            {
                for (var k = 0; k < args.Count - 1; k++)
                {
                    if (k > 0)
                    {
                        parameters += ",";
                    }

                    parameters += args.Agent.ToString(args[k]);
                }

                bodyText = args.Agent.ToString(args[args.Count - 1]);
            }

            startFunction += parameters + "){" + bodyText + "}";
            var script = (NodeScript)args.Agent.ParseScript(startFunction, null, false, false);
            var functionNode = (FunctionDeclarationNode)script.Node.Body[0];

            //TODO
            //Let strict be ContainsUseStrict of body.
            //If any static semantics errors are detected for parameters or body, throw a SyntaxError or a ReferenceError exception, depending on the type of the error. If strict is true, the Early Error rules for UniqueFormalParameters:FormalParameters are applied. Parsing and early error detection may be interweaved in an implementation-dependent manner.
            //If strict is true and IsSimpleParameterList of parameters is false, throw a SyntaxError exception.
            //If any element of the BoundNames of parameters also occurs in the LexicallyDeclaredNames of body, throw a SyntaxError exception.
            //If body Contains SuperCall is true, throw a SyntaxError exception.
            //If parameters Contains SuperCall is true, throw a SyntaxError exception.
            //If body Contains SuperProperty is true, throw a SyntaxError exception.
            //If parameters Contains SuperProperty is true, throw a SyntaxError exception.
            //If kind is "generator", then
            //    If parameters Contains YieldExpression is true, throw a SyntaxError exception.
            //If kind is "async", then
            //    If parameters Contains AwaitExpression is true, throw a SyntaxError exception.
            //If strict is true, then
            //    If BoundNames of parameters contains any duplicate elements, throw a SyntaxError exception.

            var prototype = Agent.GetPrototypeFromConstructor(newTarget, fallbackPrototype);
            var function = Agent.FunctionAllocate(prototype, script.Strict, kind);
            args.Agent.FunctionInitialise(function, FunctionKind.Normal, functionNode.Parameters, functionNode.Body, function.Realm.GlobalEnvironment);

            if (kind == FunctionKind.Generator)
            {
                var generatorPrototype = args.Agent.ObjectCreate(args.Agent.Realm.GeneratorPrototype);
                args.Agent.DefinePropertyOrThrow(function, "prototype", new PropertyDescriptor(generatorPrototype, true, false, false));
            }
            else if (kind == FunctionKind.Normal)
            {
                args.Agent.MakeConstructor(function);
            }

            args.Agent.SetFunctionName(function, "anonymous");
            return function;
        }
    }
}
