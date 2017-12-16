using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed partial class Agent
    {
        //https://tc39.github.io/ecma262/#sec-operations-on-objects

        internal ScriptValue GetValue(ScriptValue value, ScriptValue property)
        {
            Debug.Assert(IsPropertyKey(property));
            var obj = ToObject(value);
            return obj.Get(property, value);
        }

        internal bool Set([NotNull] ScriptObject scriptObject, ScriptValue property, ScriptValue value, bool shouldThrow)
        {
            Debug.Assert(IsPropertyKey(property));
            var success = scriptObject.Set(property, value, scriptObject);
            if (!success && shouldThrow)
            {
                throw CreateTypeError();
            }

            return success;
        }

        internal void CreateDataPropertyOrThrow([NotNull] ScriptObject scriptObject, ScriptValue property, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-createdatapropertyorthrow
            Debug.Assert(IsPropertyKey(property));

            var success = scriptObject.CreateDataProperty(property, value);

            if (!success)
            {
                throw CreateTypeError();
            }
        }

        internal void DefinePropertyOrThrow([NotNull] ScriptObject obj, ScriptValue property, [NotNull] PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-definepropertyorthrow
            Debug.Assert(IsPropertyKey(property));
            var success = obj.DefineOwnProperty(property, descriptor);
            if (!success)
            {
                throw CreateTypeError();
            }
        }

        [CanBeNull]
        internal ScriptFunctionObject GetMethod(ScriptValue value, ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-getmethod
            Debug.Assert(IsPropertyKey(property));

            var function = GetValue(value, property);

            if (function == ScriptValue.Undefined || function == ScriptValue.Null)
            {
                return null;
            }

            if (!IsCallable(function))
            {
                throw CreateTypeError();
            }

            return (ScriptFunctionObject)function;
        }

        internal ScriptValue Call([CanBeNull] ScriptObject function, ScriptValue thisValue, [NotNull] params ScriptValue[] arguments)
        {
            return Call(function, thisValue, (IReadOnlyList<ScriptValue>)arguments);
        }

        internal ScriptValue Call([CanBeNull] ScriptObject function, ScriptValue thisValue, [NotNull] IReadOnlyList<ScriptValue> arguments)
        {
            //https://tc39.github.io/ecma262/#sec-call
            if (function == null || !function.IsCallable)
            {
                throw CreateTypeError();
            }
            return function.Call(thisValue, arguments);
        }

        internal ScriptValue Call(ScriptValue function, ScriptValue thisValue, [NotNull] IReadOnlyList<ScriptValue> arguments)
        {
            //https://tc39.github.io/ecma262/#sec-call
            if (!IsCallable(function))
            {
                throw CreateTypeError();
            }
            return ((ScriptObject)function).Call(thisValue, arguments);
        }

        internal static ScriptValue Construct([NotNull] ScriptObject constructor, [NotNull] IReadOnlyList<ScriptValue> argumentList, ScriptObject newTarget = null)
        {
            //https://tc39.github.io/ecma262/#sec-construct

            if (newTarget == null)
            {
                newTarget = constructor;
            }

            Debug.Assert(IsConstructor(constructor));
            Debug.Assert(IsConstructor(newTarget));
            return constructor.Construct(argumentList, newTarget);
        }
    }
}
