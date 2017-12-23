using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
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

        internal static bool CreateMethodProperty([NotNull] ScriptObject obj, ScriptValue property, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-createmethodproperty
            Debug.Assert(IsPropertyKey(property));
            var newDescriptor = new PropertyDescriptor(value, true, false, true);
            return obj.DefineOwnProperty(property, newDescriptor);
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

        internal void DeletePropertyOrThrow([NotNull] ScriptObject obj, ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-deletepropertyorthrow
            Debug.Assert(IsPropertyKey(property));
            var success = obj.Delete(property);
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

        [NotNull]
        internal IReadOnlyList<ScriptValue> CreateListFromArrayLike(ScriptValue obj, ScriptValue.Type[] elementTypes = null)
        {
            //https://tc39.github.io/ecma262/#sec-createlistfromarraylike
            if (elementTypes == null)
            {
                elementTypes = new[]
                {
                    ScriptValue.Type.Undefined,
                    ScriptValue.Type.Null,
                    ScriptValue.Type.Boolean,
                    ScriptValue.Type.String,
                    ScriptValue.Type.Symbol,
                    ScriptValue.Type.Number,
                    ScriptValue.Type.Object
                };
            }

            if (!obj.IsObject)
            {
                throw CreateTypeError();
            }

            var length = ToLength(((ScriptObject)obj).Get("length"));

            var list = new List<ScriptValue>();
            var index = 0L;
            while (index < length)
            {
                var indexName = index.ToString(CultureInfo.InvariantCulture);
                var next = ((ScriptObject)obj).Get(indexName);
                if (!elementTypes.Contains(next.ValueType))
                {
                    throw CreateTypeError();
                }

                list.Add(next);
                index++;
            }

            return list;
        }

        internal ScriptValue Invoke(ScriptValue value, ScriptValue property, [NotNull] params ScriptValue[] arguments)
        {
            return Invoke(value, property, (IReadOnlyList<ScriptValue>)arguments);
        }

        private ScriptValue Invoke(ScriptValue value, ScriptValue property, [NotNull] IReadOnlyList<ScriptValue> arguments)
        {
            Debug.Assert(IsPropertyKey(property));
            var function = GetValue(value, property);
            return Call(function, value, arguments);
        }

        internal bool OrdinaryHasInstance(ScriptValue constructor, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-ordinaryhasinstance
            if (!IsCallable(constructor))
            {
                return false;
            }

            var constructorObject = (ScriptObject)constructor;

            if (constructorObject is ScriptBoundFunctionObject)
            {
                //Let BC be C.[[BoundTargetFunction]].
                //Return ? InstanceofOperator(O, BC).
                throw new NotImplementedException();
            }

            if (!value.IsObject)
            {
                return false;
            }

            var prototype = constructorObject.Get("prototype", constructor);
            if (!prototype.IsObject)
            {
                throw CreateTypeError();
            }

            var obj = (ScriptObject)value;

            while (true)
            {
                obj = obj.GetPrototypeOf();
                if (obj == null)
                {
                    return false;
                }

                if (prototype.SameValue(obj))
                {
                    return true;
                }
            }
        }

        [NotNull]
        internal ScriptObject SpeciesConstructor([NotNull] ScriptObject obj, [NotNull] ScriptFunctionObject defaultConstructor)
        {
            //https://tc39.github.io/ecma262/#sec-speciesconstructor
            var constructor = obj.Get("constructor");
            if (constructor == ScriptValue.Undefined)
            {
                return defaultConstructor;
            }

            if (!constructor.IsObject)
            {
                throw CreateTypeError();
            }

            var species = ((ScriptObject)constructor).Get(Symbol.Species);
            if (species == ScriptValue.Undefined || species == ScriptValue.Null)
            {
                return defaultConstructor;
            }

            if (IsConstructor(species))
            {
                return (ScriptObject)species;
            }

            throw CreateTypeError();
        }

        [NotNull]
        internal Realm GetFunctionRealm([NotNull] ScriptObject obj)
        {
            //https://tc39.github.io/ecma262/#sec-getfunctionrealm
            Debug.Assert(obj.IsCallable);
            if (obj is ScriptFunctionObject functionObject)
            {
                return functionObject.Realm;
            }

            if (obj is ScriptBoundFunctionObject boundFunctionObject)
            {
                //Let target be obj.[[BoundTargetFunction]].
                //Return ? GetFunctionRealm(target).
                throw new NotImplementedException();
            }

            if (obj is ScriptProxyObject proxyObject)
            {
                //    If obj.[[ProxyHandler]] is null, throw a TypeError exception.
                //    Let proxyTarget be obj.[[ProxyTarget]].
                //    Return ? GetFunctionRealm(proxyTarget).
                throw new NotImplementedException();
            }

            return Realm;
        }

        //https://tc39.github.io/ecma262/#sec-ordinary-object-internal-methods-and-internal-slots

        [NotNull]
        internal ScriptObject ObjectCreate([CanBeNull] ScriptObject prototype, SpecialObjectType specialObjectType = SpecialObjectType.None)
        {
            //https://tc39.github.io/ecma262/#sec-objectcreate

            return new ScriptObject(prototype?.Realm ?? Realm, prototype, true, specialObjectType);
        }

        [NotNull]
        internal static ScriptObject ObjectCreate([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, SpecialObjectType specialObjectType = SpecialObjectType.None)
        {
            //https://tc39.github.io/ecma262/#sec-objectcreate

            return new ScriptObject(realm, prototype, true, specialObjectType);
        }

        [NotNull]
        internal ScriptObject OrdinaryCreateFromConstructor([NotNull] ScriptObject constructor, [NotNull] ScriptObject defaultPrototype, SpecialObjectType specialObjectType = SpecialObjectType.None)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarycreatefromconstructor
            var prototype = GetPrototypeFromConstructor(constructor, defaultPrototype);
            return ObjectCreate(prototype, specialObjectType);
        }

        [NotNull]
        internal static ScriptObject GetPrototypeFromConstructor([NotNull] ScriptObject constructor, [NotNull] ScriptObject defaultPrototype)
        {
            Debug.Assert(IsCallable(constructor));
            var prototype = constructor.Get("prototype");
            if (!prototype.IsObject)
            {
                Debug.Assert(defaultPrototype.Realm == constructor.Realm);
                prototype = defaultPrototype;
            }

            return (ScriptObject)prototype;
        }
    }
}
