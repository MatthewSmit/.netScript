using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class ArrayIntrinsics
    {
        public static (ScriptFunctionObject Array,
            ScriptObject ArrayPrototype,
            ScriptObject ArrayIteratorPrototype,
            ScriptFunctionObject ArrayProtoEntries,
            ScriptFunctionObject ArrayProtoForEach,
            ScriptFunctionObject ArrayProtoKeys,
            ScriptFunctionObject ArrayProtoValues) Initialise([NotNull] Agent agent, [NotNull] Realm realm, ScriptObject objectPrototype, ScriptObject functionPrototype)
        {
            var array = Intrinsics.CreateBuiltinFunction(realm, Array, functionPrototype, 1, "Array", ConstructorKind.Base);
            Intrinsics.DefineFunction(array, "from", 1, realm, From);
            Intrinsics.DefineFunction(array, "isArray", 1, realm, IsArray);
            Intrinsics.DefineFunction(array, "of", 0, realm, Of);
            Intrinsics.DefineAccessorProperty(array, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, arguments => arguments.ThisValue, functionPrototype, 0, "get [Symbol.species]"), null);

            var arrayPrototype = new ScriptArrayObject(realm, objectPrototype, true, 0);
            Intrinsics.DefineFunction(arrayPrototype, "concat", 1, realm, Concat);
            Intrinsics.DefineDataProperty(arrayPrototype, "constructor", array);
            Intrinsics.DefineFunction(arrayPrototype, "copyWithin", 2, realm, CopyWithin);
            var arrayProtoEntries = Intrinsics.DefineFunction(arrayPrototype, "entries", 0, realm, Entries);
            Intrinsics.DefineFunction(arrayPrototype, "every", 1, realm, Every);
            Intrinsics.DefineFunction(arrayPrototype, "fill", 1, realm, Fill);
            Intrinsics.DefineFunction(arrayPrototype, "filter", 1, realm, Filter);
            Intrinsics.DefineFunction(arrayPrototype, "find", 1, realm, Find);
            Intrinsics.DefineFunction(arrayPrototype, "findIndex", 1, realm, FindIndex);
            var arrayProtoForEach = Intrinsics.DefineFunction(arrayPrototype, "forEach", 1, realm, ForEach);
            Intrinsics.DefineFunction(arrayPrototype, "includes", 1, realm, Includes);
            Intrinsics.DefineFunction(arrayPrototype, "indexOf", 1, realm, IndexOf);
            Intrinsics.DefineFunction(arrayPrototype, "join", 1, realm, Join);
            var arrayProtoKeys = Intrinsics.DefineFunction(arrayPrototype, "keys", 0, realm, Keys);
            Intrinsics.DefineFunction(arrayPrototype, "lastIndexOf", 1, realm, LastIndexOf);
            Intrinsics.DefineFunction(arrayPrototype, "map", 1, realm, Map);
            Intrinsics.DefineFunction(arrayPrototype, "pop", 0, realm, Pop);
            Intrinsics.DefineFunction(arrayPrototype, "push", 1, realm, Push);
            Intrinsics.DefineFunction(arrayPrototype, "reduce", 1, realm, Reduce);
            Intrinsics.DefineFunction(arrayPrototype, "reduceRight", 1, realm, ReduceRight);
            Intrinsics.DefineFunction(arrayPrototype, "reverse", 0, realm, Reverse);
            Intrinsics.DefineFunction(arrayPrototype, "shift", 0, realm, Shift);
            Intrinsics.DefineFunction(arrayPrototype, "slice", 2, realm, Slice);
            Intrinsics.DefineFunction(arrayPrototype, "some", 1, realm, Some);
            Intrinsics.DefineFunction(arrayPrototype, "sort", 1, realm, Sort);
            Intrinsics.DefineFunction(arrayPrototype, "splice", 2, realm, Splice);
            Intrinsics.DefineFunction(arrayPrototype, "toLocaleString", 0, realm, ToLocaleString);
            Intrinsics.DefineFunction(arrayPrototype, "toString", 0, realm, ToString);
            Intrinsics.DefineFunction(arrayPrototype, "unshift", 1, realm, Unshift);
            var arrayProtoValues = Intrinsics.DefineFunction(arrayPrototype, "values", 0, realm, Values);
            Intrinsics.DefineDataProperty(arrayPrototype, Symbol.Iterator, arrayProtoValues);

            var unscopableList = Agent.ObjectCreate(realm, null);
            unscopableList.CreateDataProperty("copyWithin", true);
            unscopableList.CreateDataProperty("entries", true);
            unscopableList.CreateDataProperty("fill", true);
            unscopableList.CreateDataProperty("find", true);
            unscopableList.CreateDataProperty("findIndex", true);
            unscopableList.CreateDataProperty("includes", true);
            unscopableList.CreateDataProperty("keys", true);
            unscopableList.CreateDataProperty("values", true);
            Intrinsics.DefineDataProperty(arrayPrototype, Symbol.Unscopables, unscopableList, false);

            var arrayIteratorPrototype = agent.ObjectCreate(realm.IteratorPrototype);
            Intrinsics.DefineFunction(arrayIteratorPrototype, "next", 0, realm, Next);
            Intrinsics.DefineDataProperty(arrayIteratorPrototype, Symbol.ToStringTag, "Array Iterator", false);

            Intrinsics.DefineDataProperty(array, "prototype", arrayPrototype, false, false, false);

            return (array, arrayPrototype, arrayIteratorPrototype, arrayProtoEntries, arrayProtoForEach, arrayProtoKeys, arrayProtoValues);
        }

        private static ScriptValue Array([NotNull] ScriptArguments arg)
        {
            var newTarget = arg.NewTarget ?? arg.Function;
            var prototype = Agent.GetPrototypeFromConstructor(newTarget, arg.Function.Realm.ArrayPrototype);

            if (arg.Count == 0)
            {
                //https://tc39.github.io/ecma262/#sec-array-constructor-array
                return ArrayCreate(arg.Agent, 0, prototype);
            }

            if (arg.Count == 1)
            {
                //https://tc39.github.io/ecma262/#sec-array-len
                var array = ArrayCreate(arg.Agent, 0, prototype);

                uint intLength;
                if (!arg[0].IsNumber)
                {
                    var defineStatus = array.CreateDataProperty("0", arg[0]);
                    Debug.Assert(defineStatus);
                    intLength = 1;
                }
                else
                {
                    intLength = arg.Agent.ToUint32(arg[0]);
                    if (intLength != (double)arg[0])
                    {
                        throw arg.Agent.CreateRangeError();
                    }
                }

                arg.Agent.Set(array, "length", intLength, true);
                return array;
            }
            else
            {
                //https://tc39.github.io/ecma262/#sec-array-items
                var array = ArrayCreate(arg.Agent, arg.Count, prototype);
                for (var k = 0; k < arg.Count; k++)
                {
                    var propertyKey = k.ToString();
                    var item = arg[k];
                    var defineStatus = array.CreateDataProperty(propertyKey, item);
                    Debug.Assert(defineStatus);
                }

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                Debug.Assert((double)array["length"] == arg.Count);
                return array;
            }
        }

        private static ScriptValue From(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IsArray([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.isarray
            return arg.Agent.IsArray(arg[0]);
        }

        private static ScriptValue Of(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Concat([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.concat
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var array = ArraySpeciesCreate(arg.Agent, obj, 0);
            var length = 0L;
            var argumentIndex = -1;

            ScriptValue element = obj;
            while (true)
            {
                var spreadable = IsConcatSpreadable(arg.Agent, element);
                if (spreadable)
                {
                    //Let k be 0.
                    var elementLength = arg.Agent.ToLength(((ScriptObject)element).Get("length"));
                    if (length + elementLength > Agent.MAX_DOUBLE_L)
                    {
                        throw arg.Agent.CreateTypeError();
                    }

                    for (var k = 0L; k < elementLength; k++)
                    {
                        var property = k.ToString(CultureInfo.InvariantCulture);
                        var exists = ((ScriptObject)element).HasProperty(property);
                        if (exists)
                        {
                            var subElement = ((ScriptObject)element).Get(property);
                            arg.Agent.CreateDataPropertyOrThrow(array, length.ToString(CultureInfo.InvariantCulture), subElement);
                        }

                        length++;
                    }
                }
                else
                {
                    if (length >= Agent.MAX_DOUBLE_L)
                    {
                        throw arg.Agent.CreateTypeError();
                    }

                    arg.Agent.CreateDataPropertyOrThrow(array, length.ToString(CultureInfo.InvariantCulture), element);
                    length++;
                }

                argumentIndex++;
                if (argumentIndex >= arg.Count)
                {
                    break;
                }

                element = arg[argumentIndex];
            }

            arg.Agent.Set(array, "length", length, true);
            return array;
        }

        private static ScriptValue CopyWithin(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Entries([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.entries
            var obj = arg.Agent.ToObject(arg.ThisValue);
            return CreateArrayIterator(arg.Agent, obj, EnumerateType.KeyValue);
        }

        private static ScriptValue Every([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.every
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length"));
            if (!Agent.IsCallable(arg[0]))
            {
                throw arg.Agent.CreateTypeError();
            }

            var callbackFunction = (ScriptObject)arg[0];
            var thisArg = arg[1];
            for (var k = 0L; k < length; k++)
            {
                var propertyKey = k.ToString(CultureInfo.InvariantCulture);
                var keyPresent = obj.HasProperty(propertyKey);
                if (keyPresent)
                {
                    var keyValue = obj.Get(propertyKey);
                    var testResult = Agent.ToBoolean(arg.Agent.Call(callbackFunction, thisArg, keyValue, k, obj));
                    if (!testResult)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static ScriptValue Fill(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Filter([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.filter
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length"));
            if (!Agent.IsCallable(arg[0]))
            {
                throw arg.Agent.CreateTypeError();
            }

            var callbackFunction = (ScriptObject)arg[0];
            var thisArg = arg[1];
            var array = ArraySpeciesCreate(arg.Agent, obj, 0);
            for (long k = 0, to = 0; k < length; k++)
            {
                var propertyKey = k.ToString(CultureInfo.InvariantCulture);
                var keyPresent = obj.HasProperty(propertyKey);
                if (keyPresent)
                {
                    var keyValue = obj.Get(propertyKey);
                    var selected = Agent.ToBoolean(arg.Agent.Call(callbackFunction, thisArg, keyValue, k, obj));
                    if (selected)
                    {
                        arg.Agent.CreateDataPropertyOrThrow(array, to.ToString(CultureInfo.InvariantCulture), keyValue);
                        to++;
                    }
                }
            }
            return array;
        }

        private static ScriptValue Find(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue FindIndex(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ForEach([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.foreach
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length"));

            if (!Agent.IsCallable(arg[0]))
            {
                throw arg.Agent.CreateTypeError();
            }

            var thisArg = arg[1];
            for (var k = 0L; k < length; k++)
            {
                var propertyKey = k.ToString(CultureInfo.InvariantCulture);
                var keyPresent = obj.HasProperty(propertyKey);
                if (keyPresent)
                {
                    var keyValue = obj.Get(propertyKey);
                    arg.Agent.Call((ScriptObject)arg[0], thisArg, keyValue, k, obj);
                }
            }

            return ScriptValue.Undefined;
        }

        private static ScriptValue Includes(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IndexOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.indexof
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length"));
            if (length == 0)
            {
                return -1;
            }

            var n = arg.Agent.ToInteger(arg[1]);
            if (n >= length)
            {
                return -1;
            }

            uint k;
            if (n >= 0)
            {
                k = (uint)n;
            }
            else
            {
                n += length;
                k = n < 0 ? 0 : (uint)n;
            }

            while (k < length)
            {
                var present = obj.HasProperty(k.ToString(CultureInfo.InvariantCulture));
                if (present)
                {
                    var element = obj.Get(k.ToString(CultureInfo.InvariantCulture));
                    if (Agent.StrictEquality(arg[0], element))
                    {
                        return k;
                    }
                }

                k++;
            }

            return -1;
        }

        private static ScriptValue Join([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.join
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length"));
            var seperator = arg[0] == ScriptValue.Undefined ? "," : arg.Agent.ToString(arg[0]);

            var result = new StringBuilder();
            for (var k = 0L; k < length; k++)
            {
                if (k > 0)
                {
                    result.Append(seperator);
                }

                var element = obj.Get(k.ToString());
                var next = element == ScriptValue.Undefined || element == ScriptValue.Null ? "" : arg.Agent.ToString(element);
                result.Append(next);
            }

            return result.ToString();
        }

        private static ScriptValue Keys([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.keys
            var obj = arg.Agent.ToObject(arg.ThisValue);
            return CreateArrayIterator(arg.Agent, obj, EnumerateType.Key);
        }

        private static ScriptValue LastIndexOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Map(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Pop([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.pop
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length"));
            if (length == 0)
            {
                arg.Agent.Set(obj, "length", 0, true);
                return ScriptValue.Undefined;
            }

            var newLength = length - 1;
            var index = newLength.ToString(CultureInfo.InvariantCulture);
            var element = obj.Get(index);
            arg.Agent.DeletePropertyOrThrow(obj, index);
            arg.Agent.Set(obj, "length", newLength, true);
            return element;
        }

        private static ScriptValue Push([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.push
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length", obj));
            //Let items be a List whose elements are, in left to right order, the arguments that were passed to this function invocation.
            var argumentCount = arg.Count;
            if (length + argumentCount > Agent.MAX_DOUBLE_L)
            {
                throw arg.Agent.CreateTypeError();
            }

            for (var i = 0; i < arg.Count; i++)
            {
                var element = arg[i];
                arg.Agent.Set(obj, length.ToString(CultureInfo.InvariantCulture), element, true);
                length += 1;
            }

            arg.Agent.Set(obj, "length", length, true);
            return length;
        }

        private static ScriptValue Reduce(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ReduceRight(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Reverse(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Shift(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Slice(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Some(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Sort(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Splice(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLocaleString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.tostring
            var array = arg.Agent.ToObject(arg.ThisValue);
            var function = array.Get("join");
            if (!Agent.IsCallable(function))
            {
                function = arg.Agent.Realm.ObjProtoToString;
            }

            return arg.Agent.Call((ScriptObject)function, array);
        }

        private static ScriptValue Unshift(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Values([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.values
            var obj = arg.Agent.ToObject(arg.ThisValue);
            return CreateArrayIterator(arg.Agent, obj, EnumerateType.Value);
        }

        private static ScriptValue Next([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-%arrayiteratorprototype%.next

            if (!arg.ThisValue.IsObject)
            {
                throw arg.Agent.CreateTypeError();
            }

            var obj = (ScriptObject)arg.ThisValue;
            if (obj.SpecialObjectType != SpecialObjectType.ArrayIterator)
            {
                throw arg.Agent.CreateTypeError();
            }

            var array = obj.IteratedObject;
            if (array == null)
            {
                return arg.Agent.CreateIterResultObject(ScriptValue.Undefined, true);
            }

            var index = obj.ArrayIteratorNextIndex;
            var itemKind = obj.ArrayIterationKind;
            long length;
            if (array.SpecialObjectType == SpecialObjectType.TypedArray)
            {
                //If IsDetachedBuffer(a.[[ViewedArrayBuffer]]) is true, throw a TypeError exception.
                //Let len be a.[[ArrayLength]].
                throw new NotImplementedException();
            }
            else
            {
                length = arg.Agent.ToLength(array.Get("length"));
            }

            if (index >= length)
            {
                obj.IteratedObject = null;
                return arg.Agent.CreateIterResultObject(ScriptValue.Undefined, true);
            }

            obj.ArrayIteratorNextIndex += 1;

            if (itemKind == EnumerateType.Key)
            {
                return arg.Agent.CreateIterResultObject(index, false);
            }

            var elementKey = index.ToString();
            var elementValue = array.Get(elementKey);
            ScriptValue result;
            if (itemKind == EnumerateType.Value)
            {
                result = elementValue;
            }
            else
            {
                result = CreateArrayFromList(arg.Agent, new[] {index, elementValue});
            }

            return arg.Agent.CreateIterResultObject(result, false);
        }


        [NotNull]
        internal static ScriptObject ArrayCreate([NotNull] Agent agent, long length, ScriptObject prototype = null)
        {
            //https://tc39.github.io/ecma262/#sec-arraycreate
            Debug.Assert(length >= 0);
            if (length >= uint.MaxValue)
            {
                throw agent.CreateRangeError();
            }

            if (prototype == null)
            {
                prototype = agent.RunningExecutionContext.Realm.ArrayPrototype;
            }

            return new ScriptArrayObject(prototype.Realm, prototype, true, (uint)length);
        }

        [NotNull]
        private static ScriptObject ArraySpeciesCreate([NotNull] Agent agent, [CanBeNull] ScriptObject originalArray, long length)
        {
            //https://tc39.github.io/ecma262/#sec-arrayspeciescreate
            Debug.Assert(length >= 0);
            var isArray = agent.IsArray(originalArray);
            if (!isArray)
            {
                return ArrayCreate(agent, length);
            }

            Debug.Assert(originalArray != null, nameof(originalArray) + " != null");
            var constructor = originalArray.Get("constructor");
            if (Agent.IsConstructor(constructor))
            {
                var thisRealm = agent.Realm;
                var realmConstructor = agent.GetFunctionRealm((ScriptObject)constructor);
                if (thisRealm != realmConstructor)
                {
                    if (constructor.SameValue(realmConstructor.Array))
                    {
                        constructor = ScriptValue.Undefined;
                    }
                }
            }

            if (constructor.IsObject)
            {
                constructor = ((ScriptObject)constructor).Get(Symbol.Species);
                if (constructor == ScriptValue.Null)
                {
                    constructor = ScriptValue.Undefined;
                }
            }

            if (constructor == ScriptValue.Undefined)
            {
                return ArrayCreate(agent, length);
            }

            if (!Agent.IsConstructor(constructor))
            {
                throw agent.CreateTypeError();
            }

            return (ScriptObject)Agent.Construct((ScriptObject)constructor, new ScriptValue[] {length});
        }

        internal static ScriptValue CreateArrayFromList([NotNull] Agent agent, [NotNull] IEnumerable<ScriptValue> elements)
        {
            //https://tc39.github.io/ecma262/#sec-createarrayfromlist
            var array = ArrayCreate(agent, 0);

            var i = 0;
            foreach (var element in elements)
            {
                var status = array.CreateDataProperty(i.ToString(), element);
                Debug.Assert(status);
                i++;
            }

            return array;
        }

        private static ScriptValue CreateArrayIterator([NotNull] Agent agent, [NotNull] ScriptObject array, EnumerateType kind)
        {
            //https://tc39.github.io/ecma262/#sec-createarrayiterator
            var iterator = agent.ObjectCreate(agent.Realm.ArrayIteratorPrototype, SpecialObjectType.ArrayIterator);
            iterator.IteratedObject = array;
            iterator.ArrayIteratorNextIndex = 0;
            iterator.ArrayIterationKind = kind;
            return iterator;
        }

        private static bool IsConcatSpreadable([NotNull] Agent agent, ScriptValue obj)
        {
            //https://tc39.github.io/ecma262/#sec-isconcatspreadable
            if (!obj.IsObject)
            {
                return false;
            }

            var spreadable = ((ScriptObject)obj).Get(Symbol.IsConcatSpreadable);
            if (spreadable != ScriptValue.Undefined)
            {
                return Agent.ToBoolean(spreadable);
            }

            return agent.IsArray(obj);
        }
    }
}
