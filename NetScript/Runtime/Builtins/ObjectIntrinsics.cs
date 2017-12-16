using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class ObjectIntrinsics
    {
        private enum IntegrityLevel
        {
            Sealed,
            Frozen
        }

        public static (ScriptFunctionObject objectConstructor,
            ScriptFunctionObject objectPrototypeToString,
            ScriptFunctionObject objectPrototypeValueOf) Initialise([NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var objectConstructor = Intrinsics.CreateBuiltinFunction(realm, Object, functionPrototype, 1, "Object", ConstructorKind.Base);
            Intrinsics.DefineFunction(objectConstructor, "assign", 2, realm, Assign);
            Intrinsics.DefineFunction(objectConstructor, "create", 2, realm, Create);
            Intrinsics.DefineFunction(objectConstructor, "defineProperties", 2, realm, DefineProperties);
            Intrinsics.DefineFunction(objectConstructor, "defineProperty", 3, realm, DefineProperty);
            Intrinsics.DefineFunction(objectConstructor, "entries", 1, realm, Entries);
            Intrinsics.DefineFunction(objectConstructor, "freeze", 1, realm, Freeze);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertyDescriptor", 2, realm, GetOwnPropertyDescriptor);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertyDescriptors", 1, realm, GetOwnPropertyDescriptors);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertyNames", 1, realm, GetOwnPropertyNames);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertySymbols", 1, realm, GetOwnPropertySymbols);
            Intrinsics.DefineFunction(objectConstructor, "getPrototypeOf", 1, realm, GetPrototypeOf);
            Intrinsics.DefineFunction(objectConstructor, "is", 2, realm, Is);
            Intrinsics.DefineFunction(objectConstructor, "isExtensible", 1, realm, IsExtensible);
            Intrinsics.DefineFunction(objectConstructor, "isFrozen", 1, realm, IsFrozen);
            Intrinsics.DefineFunction(objectConstructor, "isSealed", 1, realm, IsSealed);
            Intrinsics.DefineFunction(objectConstructor, "keys", 1, realm, Keys);
            Intrinsics.DefineFunction(objectConstructor, "preventExtensions", 1, realm, PreventExtensions);
            Intrinsics.DefineDataProperty(objectConstructor, "prototype", objectPrototype, false, false, false);
            Intrinsics.DefineFunction(objectConstructor, "seal", 1, realm, Seal);
            Intrinsics.DefineFunction(objectConstructor, "setPrototypeOf", 2, realm, SetPrototypeOf);
            Intrinsics.DefineFunction(objectConstructor, "values", 1, realm, Values);

            Intrinsics.DefineDataProperty(objectPrototype, "constructor", objectConstructor);
            Intrinsics.DefineFunction(objectPrototype, "hasOwnProperty", 1, realm, HasOwnProperty);
            Intrinsics.DefineFunction(objectPrototype, "isPrototypeOf", 1, realm, IsPrototypeOf);
            Intrinsics.DefineFunction(objectPrototype, "propertyIsEnumerable", 1, realm, PropertyIsEnumerable);
            Intrinsics.DefineFunction(objectPrototype, "toLocaleString", 0, realm, ToLocaleString);
            var objectPrototypeToString = Intrinsics.DefineFunction(objectPrototype, "toString", 0, realm, ToString);
            var objectPrototypeValueOf = Intrinsics.DefineFunction(objectPrototype, "valueOf", 0, realm, ValueOf);

            return (objectConstructor, objectPrototypeToString, objectPrototypeValueOf);
        }

        private static ScriptValue Object([NotNull] ScriptArguments arg)
        {
            if (arg.NewTarget != null && arg.NewTarget != arg.Agent.Realm.ObjectConstructor)
            {
                return arg.Agent.OrdinaryCreateFromConstructor(arg.NewTarget, arg.NewTarget.Realm.ObjectPrototype);
            }

            var value = arg[0];
            if (value == ScriptValue.Null || value == ScriptValue.Undefined)
            {
                return arg.Agent.ObjectCreate(arg.Agent.Realm.ObjectPrototype);
            }

            return arg.Agent.ToObject(value);
        }

        private static ScriptValue Assign([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.assign
            var to = arg.Agent.ToObject(arg[0]);
            if (arg.Count == 1)
            {
                return to;
            }

            for (var i = 1; i < arg.Count; i++)
            {
                var nextSource = arg[i];
                if (nextSource != ScriptValue.Undefined && nextSource != ScriptValue.Null)
                {
                    var from = arg.Agent.ToObject(nextSource);
                    var keys = from.OwnPropertyKeys();
                    foreach (var nextKey in keys)
                    {
                        var descriptor = from.GetOwnProperty(nextKey);
                        if (descriptor != null && descriptor.Enumerable)
                        {
                            var propertyValue = from.Get(nextKey);
                            arg.Agent.Set(to, nextKey, propertyValue, true);
                        }
                    }
                }
            }

            return to;
        }

        private static ScriptValue Create([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.create
            if (!arg[0].IsObject && arg[0] != ScriptValue.Null)
            {
                throw arg.Agent.CreateTypeError();
            }

            var obj = arg.Agent.ObjectCreate(arg[0] == ScriptValue.Null ? null : (ScriptObject)arg[0]);
            if (arg[1] != ScriptValue.Undefined)
            {
                return ObjectDefineProperties(arg.Agent, obj, arg[1]);
            }

            return obj;
        }

        private static ScriptValue DefineProperties([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.defineproperties
            return ObjectDefineProperties(arg.Agent, arg[0], arg[1]);
        }

        private static ScriptValue DefineProperty([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.defineproperty

            var obj = arg[0];
            if (!obj.IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            var key = arg.Agent.ToPropertyKey(arg[1]);
            var descriptor = ToPropertyDescriptor(arg.Agent, arg[2]);
            arg.Agent.DefinePropertyOrThrow((ScriptObject)obj, key, descriptor);
            return obj;
        }

        private static ScriptValue Entries(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Freeze([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.freeze
            if (!arg[0].IsObject)
            {
                return arg[0];
            }

            var status = SetIntegrityLevel(arg.Agent, (ScriptObject)arg[0], IntegrityLevel.Frozen);
            if (!status)
            {
                throw arg.Agent.CreateTypeError();
            }

            return arg[0];
        }

        private static ScriptValue GetOwnPropertyDescriptor([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.getownpropertydescriptor
            var obj = arg.Agent.ToObject(arg[0]);
            var key = arg.Agent.ToPropertyKey(arg[1]);
            var descriptor = obj.GetOwnProperty(key);
            return FromPropertyDescriptor(arg.Agent, descriptor);
        }

        private static ScriptValue GetOwnPropertyDescriptors([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.getownpropertydescriptors
            var obj = arg.Agent.ToObject(arg[0]);
            var ownKeys = obj.OwnPropertyKeys();
            var descriptors = arg.Agent.ObjectCreate(arg.Function.Realm.ObjectPrototype);
            foreach (var key in ownKeys)
            {
                var desc = obj.GetOwnProperty(key);
                var descriptor = FromPropertyDescriptor(arg.Agent, desc);
                if (descriptor != ScriptValue.Undefined)
                {
                    descriptors.CreateDataProperty(key, descriptor);
                }
            }
            return descriptors;
        }

        private static ScriptValue GetOwnPropertyNames([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.getownpropertynames
            return GetOwnPropertyKeys(arg.Agent, arg[0], ScriptValue.Type.String);
        }

        private static ScriptValue GetOwnPropertySymbols([NotNull] ScriptArguments arg)
        {
            return GetOwnPropertyKeys(arg.Agent, arg[0], ScriptValue.Type.Symbol);
        }

        private static ScriptValue GetPrototypeOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.getprototypeof
            var obj = arg.Agent.ToObject(arg[0]);
            return obj.GetPrototypeOf();
        }

        private static ScriptValue Is([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.is
            return arg[0].SameValue(arg[1]);
        }

        private static ScriptValue IsExtensible([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.isextensible
            var obj = arg[0];
            if (!obj.IsObject)
            {
                return false;
            }

            return ((ScriptObject)obj).IsExtensible;
        }

        private static ScriptValue IsFrozen([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.isfrozen
            if (!arg[0].IsObject)
            {
                return true;
            }

            return TestIntegrityLevel((ScriptObject)arg[0], IntegrityLevel.Frozen);
        }

        private static ScriptValue IsSealed([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.issealed
            if (!arg[0].IsObject)
            {
                return true;
            }

            return TestIntegrityLevel((ScriptObject)arg[0], IntegrityLevel.Sealed);
        }

        private static ScriptValue Keys([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.keys
            var obj = arg.Agent.ToObject(arg[0]);
            var nameList = EnumerableOwnProperties(arg.Agent, obj, EnumerateType.Key);
            return ArrayIntrinsics.CreateArrayFromList(arg.Agent, nameList);
        }

        private static ScriptValue PreventExtensions([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.preventextensions
            var obj = arg[0];
            if (!obj.IsObject)
            {
                return obj;
            }

            var status = ((ScriptObject)obj).PreventExtensions();
            if (!status)
            {
                throw arg.Agent.CreateTypeError();
            }

            return obj;
        }

        private static ScriptValue Seal([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.seal
            if (!arg[0].IsObject)
            {
                return arg[0];
            }

            var status = SetIntegrityLevel(arg.Agent, (ScriptObject)arg[0], IntegrityLevel.Sealed);
            if (!status)
            {
                throw arg.Agent.CreateTypeError();
            }

            return arg[0];
        }

        private static ScriptValue SetPrototypeOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.setprototypeof
            var obj = arg.Agent.RequireObjectCoercible(arg[0]);
            var proto = arg[1];
            if (proto != ScriptValue.Null && !proto.IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            if (!obj.IsObject)
            {
                return obj;
            }

            var status = ((ScriptObject)obj).SetPrototypeOf(proto == ScriptValue.Null ? null : (ScriptObject)proto);
            if (!status)
            {
                throw arg.Agent.CreateTypeError();
            }

            return obj;
        }

        private static ScriptValue Values([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.values
            var obj = arg.Agent.ToObject(arg[0]);
            var nameList = EnumerableOwnProperties(arg.Agent, obj, EnumerateType.Value);
            return ArrayIntrinsics.CreateArrayFromList(arg.Agent, nameList);
        }

        private static ScriptValue HasOwnProperty([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.prototype.hasownproperty
            var property = arg.Agent.ToPropertyKey(arg[0]);
            var obj = arg.Agent.ToObject(arg.ThisValue);
            return obj.HasOwnProperty(property);
        }

        private static ScriptValue IsPrototypeOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.prototype.isprototypeof
            if (!arg[0].IsObject)
            {
                return false;
            }

            var obj = arg.Agent.ToObject(arg.ThisValue);
            var value = (ScriptObject)arg[0];
            while (true)
            {
                value = value.GetPrototypeOf();
                if (value == null)
                {
                    return false;
                }

                if (obj == value)
                {
                    return true;
                }
            }
        }

        private static ScriptValue PropertyIsEnumerable([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.prototype.propertyisenumerable
            var property = arg.Agent.ToPropertyKey(arg[0]);
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var descriptor = obj.GetOwnProperty(property);
            if (descriptor == null)
            {
                return false;
            }

            return (bool)descriptor.Enumerable;
        }

        private static ScriptValue ToLocaleString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.prototype.tolocalestring
            var obj = arg.ThisValue;
            return arg.Agent.Invoke(obj, "toString");
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.prototype.tostring
            if (arg.ThisValue == ScriptValue.Undefined)
            {
                return "[object Undefined]";
            }

            if (arg.ThisValue == ScriptValue.Null)
            {
                return "[object Null]";
            }

            var obj = arg.Agent.ToObject(arg.ThisValue);
            string builtinTag;
            if (arg.Agent.IsArray(obj))
            {
                builtinTag = "Array";
            }
            else if (obj is ScriptStringObject)
            {
                builtinTag = "String";
            }
            else if (obj is ScriptArgumentsObject || obj.SpecialObjectType == SpecialObjectType.Parameter)
            {
                builtinTag = "Arguments";
            }
            else if (obj.IsCallable)
            {
                builtinTag = "Function";
            }
            else
            {
                switch (obj.SpecialObjectType)
                {
                    case SpecialObjectType.Error:
                        builtinTag = "Error";
                        break;
                    case SpecialObjectType.Boolean:
                        builtinTag = "Boolean";
                        break;
                    case SpecialObjectType.Number:
                        builtinTag = "Number";
                        break;
                    case SpecialObjectType.Date:
                        builtinTag = "Date";
                        break;
                    case SpecialObjectType.RegExp:
                        builtinTag = "RegExp";
                        break;
                    default:
                        builtinTag = "Object";
                        break;
                }
            }

            var tag = obj.Get(Symbol.ToStringTag);
            if (tag.IsString)
            {
                builtinTag = (string)tag;
            }

            return $"[object {builtinTag}]";
        }

        private static ScriptValue ValueOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.prototype.valueof
            return arg.Agent.ToObject(arg.ThisValue);
        }


        [NotNull]
        private static IEnumerable<ScriptValue> EnumerableOwnProperties([NotNull] Agent agent, [NotNull] ScriptObject obj, EnumerateType type)
        {
            //https://tc39.github.io/ecma262/#sec-enumerableownproperties

            var ownKeys = obj.OwnPropertyKeys();
            var properties = new List<ScriptValue>();
            foreach (var key in ownKeys)
            {
                if (key.IsString)
                {
                    var descriptor = obj.GetOwnProperty(key);
                    if (descriptor != null && descriptor.Enumerable)
                    {
                        switch (type)
                        {
                            case EnumerateType.Key:
                                properties.Add(key);
                                break;
                            case EnumerateType.Value:
                                properties.Add(obj.Get(key));
                                break;
                            case EnumerateType.KeyValue:
                                properties.Add(ArrayIntrinsics.CreateArrayFromList(agent, new[] {key, obj.Get(key)}));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(type), type, null);
                        }
                    }
                }
            }
            return properties;
        }

        internal static ScriptValue FromPropertyDescriptor([NotNull] Agent agent, [CanBeNull] PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-frompropertydescriptor
            if (descriptor == null)
            {
                return ScriptValue.Undefined;
            }

            var obj = agent.CreateObject();
            var result = true;
            if (descriptor.IsDataDescriptor)
            {
                result = obj.CreateDataProperty("value", descriptor.Value ?? ScriptValue.Undefined);
                result = result && obj.CreateDataProperty("writable", (bool)descriptor.Writable);
                result = result && obj.CreateDataProperty("enumerable", (bool)descriptor.Enumerable);
                result = result && obj.CreateDataProperty("configurable", (bool)descriptor.Configurable);
            }
            else if (descriptor.IsAccessorDescriptor)
            {
                result = obj.CreateDataProperty("get", descriptor.Get ?? ScriptValue.Undefined);
                result = result && obj.CreateDataProperty("set", descriptor.Set ?? ScriptValue.Undefined);
                result = result && obj.CreateDataProperty("enumerable", (bool)descriptor.Enumerable);
                result = result && obj.CreateDataProperty("configurable", (bool)descriptor.Configurable);
            }
            else
            {
                if (descriptor.Value.HasValue)
                {
                    result = obj.CreateDataProperty("value", descriptor.Value.Value);
                }
                if (descriptor.Writable.HasValue)
                {
                    result = result && obj.CreateDataProperty("writable", (bool)descriptor.Writable);
                }
                if (descriptor.Get != null)
                {
                    result = result && obj.CreateDataProperty("get", descriptor.Get);
                }
                if (descriptor.Set != null)
                {
                    result = result && obj.CreateDataProperty("set", descriptor.Set);
                }
                if (descriptor.Enumerable.HasValue)
                {
                    result = result && obj.CreateDataProperty("enumerable", (bool)descriptor.Enumerable);
                }
                if (descriptor.Configurable.HasValue)
                {
                    result = result && obj.CreateDataProperty("configurable", (bool)descriptor.Configurable);
                }
                throw new NotImplementedException();
            }

            Debug.Assert(result);

            return obj;
        }

        private static ScriptValue GetOwnPropertyKeys([NotNull] Agent agent, ScriptValue value, ScriptValue.Type type)
        {
            //https://tc39.github.io/ecma262/#sec-getownpropertykeys
            var obj = agent.ToObject(value);
            var keys = obj.OwnPropertyKeys();
            var nameList = keys.Where(x => x.ValueType == type);
            return ArrayIntrinsics.CreateArrayFromList(agent, nameList);
        }

        private static ScriptValue ObjectDefineProperties([NotNull] Agent agent, ScriptValue obj, ScriptValue propertiesValue)
        {
            //https://tc39.github.io/ecma262/#sec-objectdefineproperties

            if (!obj.IsObject)
            {
                throw agent.CreateTypeError();
            }

            var properties = agent.ToObject(propertiesValue);
            var keys = properties.OwnPropertyKeys();

            var descriptors = new List<(ScriptValue, PropertyDescriptor)>();

            //Let descriptors be a new empty List.
            foreach (var nextKey in keys)
            {
                var propertyDescriptor = properties.GetOwnProperty(nextKey);
                if (propertyDescriptor != null && propertyDescriptor.Enumerable)
                {
                    var descriptorObject = properties.Get(nextKey);
                    var descriptor = ToPropertyDescriptor(agent, descriptorObject);
                    descriptors.Add((nextKey, descriptor));
                }
            }

            foreach (var (property, descriptor) in descriptors)
            {
                agent.DefinePropertyOrThrow((ScriptObject)obj, property, descriptor);
            }

            return obj;
        }

        private static bool SetIntegrityLevel([NotNull] Agent agent, [NotNull] ScriptObject obj, IntegrityLevel level)
        {
            //https://tc39.github.io/ecma262/#sec-setintegritylevel
            var status = obj.PreventExtensions();
            if (!status)
            {
                return false;
            }

            var keys = obj.OwnPropertyKeys();
            switch (level)
            {
                case IntegrityLevel.Sealed:
                    foreach (var key in keys)
                    {
                        agent.DefinePropertyOrThrow(obj, key, new PropertyDescriptor
                        {
                            Configurable = false
                        });
                    }
                    break;
                case IntegrityLevel.Frozen:
                    foreach (var key in keys)
                    {
                        var currentDescriptor = obj.GetOwnProperty(key);
                        if (currentDescriptor != null)
                        {
                            PropertyDescriptor descriptor;
                            if (currentDescriptor.IsAccessorDescriptor)
                            {
                                descriptor = new PropertyDescriptor
                                {
                                    Configurable = false
                                };
                            }
                            else
                            {
                                descriptor = new PropertyDescriptor
                                {
                                    Configurable = false,
                                    Writable = false
                                };
                            }

                            agent.DefinePropertyOrThrow(obj, key, descriptor);
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level));
            }

            return true;
        }

        private static bool TestIntegrityLevel([NotNull] ScriptObject obj, IntegrityLevel level)
        {
            //https://tc39.github.io/ecma262/#sec-testintegritylevel
            var status = obj.IsExtensible;
            if (status)
            {
                return false;
            }
            //NOTE: If the object is extensible, none of its properties are examined.
            var keys = obj.OwnPropertyKeys();
            foreach (var key in keys)
            {
                var currentDescriptor = obj.GetOwnProperty(key);
                if (currentDescriptor != null)
                {
                    if (currentDescriptor.Configurable)
                    {
                        return false;
                    }

                    if (level == IntegrityLevel.Frozen && currentDescriptor.IsDataDescriptor)
                    {
                        if (currentDescriptor.Writable)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        [NotNull]
        internal static PropertyDescriptor ToPropertyDescriptor([NotNull] Agent agent, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-topropertydescriptor
            if (!value.IsObject)
            {
                throw agent.CreateTypeError();
            }

            var obj = (ScriptObject)value;

            var descriptor = new PropertyDescriptor();
            if (obj.HasProperty("enumerable"))
            {
                descriptor.Enumerable = Agent.RealToBoolean(obj["enumerable"]);
            }
            if (obj.HasProperty("configurable"))
            {
                descriptor.Configurable = Agent.RealToBoolean(obj["configurable"]);
            }
            if (obj.HasProperty("value"))
            {
                descriptor.Value = obj["value"];
            }
            if (obj.HasProperty("writable"))
            {
                descriptor.Writable = Agent.RealToBoolean(obj["writable"]);
            }
            if (obj.HasProperty("get"))
            {
                var getter = obj["get"];
                if (!Agent.IsCallable(getter) && getter != ScriptValue.Undefined)
                {
                    throw agent.CreateTypeError();
                }

                descriptor.Get = getter == ScriptValue.Undefined ? null : (ScriptObject)getter;
            }
            if (obj.HasProperty("set"))
            {
                var setter = obj["set"];
                if (!Agent.IsCallable(setter) && setter != ScriptValue.Undefined)
                {
                    throw agent.CreateTypeError();
                }

                descriptor.Set = setter == ScriptValue.Undefined ? null : (ScriptObject)setter;
            }

            if ((descriptor.Get != null || descriptor.Set != null) && (descriptor.Value.HasValue || descriptor.Writable.HasValue))
            {
                throw agent.CreateTypeError();
            }

            return descriptor;
        }
    }
}