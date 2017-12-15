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
        public static (ScriptObject objectConstructor, ScriptObject objectPrototypeToString, ScriptObject objectPrototypeValueOf) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var objectConstructor = Intrinsics.CreateBuiltinFunction(agent, realm, Object, functionPrototype, 1, "Object", ConstructorKind.Base);
            Intrinsics.DefineFunction(objectConstructor, "assign", 2, agent, realm, Assign);
            Intrinsics.DefineFunction(objectConstructor, "create", 2, agent, realm, Create);
            Intrinsics.DefineFunction(objectConstructor, "defineProperties", 2, agent, realm, DefineProperties);
            Intrinsics.DefineFunction(objectConstructor, "defineProperty", 3, agent, realm, DefineProperty);
            Intrinsics.DefineFunction(objectConstructor, "entries", 1, agent, realm, Entries);
            Intrinsics.DefineFunction(objectConstructor, "freeze", 1, agent, realm, Freeze);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertyDescriptor", 2, agent, realm, GetOwnPropertyDescriptor);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertyDescriptors", 1, agent, realm, GetOwnPropertyDescriptors);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertyNames", 1, agent, realm, GetOwnPropertyNames);
            Intrinsics.DefineFunction(objectConstructor, "getOwnPropertySymbols", 1, agent, realm, GetOwnPropertySymbols);
            Intrinsics.DefineFunction(objectConstructor, "getPrototypeOf", 1, agent, realm, GetPrototypeOf);
            Intrinsics.DefineFunction(objectConstructor, "is", 2, agent, realm, Is);
            Intrinsics.DefineFunction(objectConstructor, "isExtensible", 1, agent, realm, IsExtensible);
            Intrinsics.DefineFunction(objectConstructor, "isFrozen", 1, agent, realm, IsFrozen);
            Intrinsics.DefineFunction(objectConstructor, "isSealed", 1, agent, realm, IsSealed);
            Intrinsics.DefineFunction(objectConstructor, "keys", 1, agent, realm, Keys);
            Intrinsics.DefineFunction(objectConstructor, "preventExtensions", 1, agent, realm, PreventExtensions);
            Intrinsics.DefineDataProperty(objectConstructor, "prototype", objectPrototype, false, false, false);
            Intrinsics.DefineFunction(objectConstructor, "seal", 1, agent, realm, Seal);
            Intrinsics.DefineFunction(objectConstructor, "setPrototypeOf", 2, agent, realm, SetPrototypeOf);
            Intrinsics.DefineFunction(objectConstructor, "values", 1, agent, realm, Values);

            Intrinsics.DefineDataProperty(objectPrototype, "constructor", objectConstructor);
            Intrinsics.DefineFunction(objectPrototype, "hasOwnProperty", 1, agent, realm, HasOwnProperty);
            Intrinsics.DefineFunction(objectPrototype, "isPrototypeOf", 1, agent, realm, IsPrototypeOf);
            Intrinsics.DefineFunction(objectPrototype, "propertyIsEnumerable", 1, agent, realm, PropertyIsEnumerable);
            Intrinsics.DefineFunction(objectPrototype, "toLocaleString", 0, agent, realm, ToLocaleString);
            var objectPrototypeToString = Intrinsics.DefineFunction(objectPrototype, "toString", 0, agent, realm, ToString);
            var objectPrototypeValueOf = Intrinsics.DefineFunction(objectPrototype, "valueOf", 0, agent, realm, ValueOf);

            return (objectConstructor, objectPrototypeToString, objectPrototypeValueOf);
        }

        private static ScriptValue Object([NotNull] ScriptArguments arg)
        {
            if (arg.NewTarget != null && arg.NewTarget != arg.Agent.Realm.ObjectConstructor)
            {
                throw new NotImplementedException();
//                return OrdinaryCreateFromConstructor(arg.NewTarget, arg.Agent.Realm.ObjectPrototype);
            }

            var value = arg[0];
            if (value == ScriptValue.Null || value == ScriptValue.Undefined)
            {
                return arg.Agent.ObjectCreate(arg.Agent.Realm.ObjectPrototype);
            }

            return arg.Agent.ToObject(value);
        }

        private static ScriptValue Assign(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Create(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Freeze(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetOwnPropertyDescriptor([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.getownpropertydescriptor
            var obj = arg.Agent.ToObject(arg[0]);
            var key = arg.Agent.ToPropertyKey(arg[1]);
            var descriptor = obj.GetOwnProperty(key);
            return FromPropertyDescriptor(arg.Agent, descriptor);
        }

        private static ScriptValue GetOwnPropertyDescriptors(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue GetPrototypeOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Is(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue IsFrozen(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IsSealed(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Seal(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Values(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue HasOwnProperty([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-object.prototype.hasownproperty
            var property = arg.Agent.ToPropertyKey(arg[0]);
            var obj = arg.Agent.ToObject(arg.ThisValue);
            return obj.HasOwnProperty(property);
        }

        private static ScriptValue IsPrototypeOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue ToLocaleString(ScriptArguments arg)
        {
            throw new NotImplementedException();
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
            else switch (obj.SpecialObjectType)
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

            var tag = obj.Get(arg.Agent.Realm.SymbolToStringTag);
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

        private static ScriptValue FromPropertyDescriptor([NotNull] Agent agent, [CanBeNull] PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-frompropertydescriptor
            if (descriptor == null)
            {
                return ScriptValue.Undefined;
            }

            var obj = agent.CreateObject();
            var result = true;
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

        [NotNull]
        private static PropertyDescriptor ToPropertyDescriptor([NotNull] Agent agent, ScriptValue value)
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