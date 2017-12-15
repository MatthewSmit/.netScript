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
        public static (ScriptObject Array,
            ScriptObject ArrayPrototype,
            ScriptObject ArrayIteratorPrototype,
            ScriptObject ArrayProtoEntries,
            ScriptObject ArrayProtoForEach,
            ScriptObject ArrayProtoKeys,
            ScriptObject ArrayProtoValues) Initialise([NotNull] Agent agent, [NotNull] Realm realm, ScriptObject objectPrototype, ScriptObject functionPrototype)
        {
            var array = Intrinsics.CreateBuiltinFunction(agent, realm, Array, functionPrototype, 1, "Array", ConstructorKind.Base);
            Intrinsics.DefineFunction(array, "from", 1, agent, realm, From);
            Intrinsics.DefineFunction(array, "isArray", 1, agent, realm, IsArray);
            Intrinsics.DefineFunction(array, "of", 0, agent, realm, Of);
            Intrinsics.DefineAccessorProperty(array, realm.SymbolSpecies, Intrinsics.CreateBuiltinFunction(agent, realm, arguments => arguments.ThisValue, functionPrototype, 0, "get [Symbol.species]"), null);

            var arrayPrototype = new ScriptArrayObject(agent, objectPrototype, true, 0);
            Intrinsics.DefineFunction(arrayPrototype, "concat", 1, agent, realm, Concat);
            Intrinsics.DefineDataProperty(arrayPrototype, "constructor", array);
            Intrinsics.DefineFunction(arrayPrototype, "copyWithin", 2, agent, realm, CopyWithin);
            var arrayProtoEntries = Intrinsics.DefineFunction(arrayPrototype, "entries", 0, agent, realm, Entries);
            Intrinsics.DefineFunction(arrayPrototype, "every", 1, agent, realm, Every);
            Intrinsics.DefineFunction(arrayPrototype, "fill", 1, agent, realm, Fill);
            Intrinsics.DefineFunction(arrayPrototype, "filter", 1, agent, realm, Filter);
            Intrinsics.DefineFunction(arrayPrototype, "find", 1, agent, realm, Find);
            Intrinsics.DefineFunction(arrayPrototype, "findIndex", 1, agent, realm, FindIndex);
            var arrayProtoForEach = Intrinsics.DefineFunction(arrayPrototype, "forEach", 1, agent, realm, ForEach);
            Intrinsics.DefineFunction(arrayPrototype, "includes", 1, agent, realm, Includes);
            Intrinsics.DefineFunction(arrayPrototype, "indexOf", 1, agent, realm, IndexOf);
            Intrinsics.DefineFunction(arrayPrototype, "join", 1, agent, realm, Join);
            var arrayProtoKeys = Intrinsics.DefineFunction(arrayPrototype, "keys", 0, agent, realm, Keys);
            Intrinsics.DefineFunction(arrayPrototype, "lastIndexOf", 1, agent, realm, LastIndexOf);
            Intrinsics.DefineFunction(arrayPrototype, "map", 1, agent, realm, Map);
            Intrinsics.DefineFunction(arrayPrototype, "pop", 0, agent, realm, Pop);
            Intrinsics.DefineFunction(arrayPrototype, "push", 1, agent, realm, Push);
            Intrinsics.DefineFunction(arrayPrototype, "reduce", 1, agent, realm, Reduce);
            Intrinsics.DefineFunction(arrayPrototype, "reduceRight", 1, agent, realm, ReduceRight);
            Intrinsics.DefineFunction(arrayPrototype, "reverse", 0, agent, realm, Reverse);
            Intrinsics.DefineFunction(arrayPrototype, "shift", 0, agent, realm, Shift);
            Intrinsics.DefineFunction(arrayPrototype, "slice", 2, agent, realm, Slice);
            Intrinsics.DefineFunction(arrayPrototype, "some", 1, agent, realm, Some);
            Intrinsics.DefineFunction(arrayPrototype, "sort", 1, agent, realm, Sort);
            Intrinsics.DefineFunction(arrayPrototype, "splice", 2, agent, realm, Splice);
            Intrinsics.DefineFunction(arrayPrototype, "toLocaleString", 0, agent, realm, ToLocaleString);
            Intrinsics.DefineFunction(arrayPrototype, "toString", 0, agent, realm, ToString);
            Intrinsics.DefineFunction(arrayPrototype, "unshift", 1, agent, realm, Unshift);
            var arrayProtoValues = Intrinsics.DefineFunction(arrayPrototype, "values", 0, agent, realm, Values);
            Intrinsics.DefineDataProperty(arrayPrototype, realm.SymbolIterator, arrayProtoValues);

            var unscopableList = agent.ObjectCreate(null);
            unscopableList.CreateDataProperty("copyWithin", true);
            unscopableList.CreateDataProperty("entries", true);
            unscopableList.CreateDataProperty("fill", true);
            unscopableList.CreateDataProperty("find", true);
            unscopableList.CreateDataProperty("findIndex", true);
            unscopableList.CreateDataProperty("includes", true);
            unscopableList.CreateDataProperty("keys", true);
            unscopableList.CreateDataProperty("values", true);
            Intrinsics.DefineDataProperty(arrayPrototype, realm.SymbolUnscopables, unscopableList, false);

            var arrayIteratorPrototype = agent.ObjectCreate(realm.IteratorPrototype);
            Intrinsics.DefineFunction(arrayIteratorPrototype, "next", 0, agent, realm, Next);
            Intrinsics.DefineDataProperty(arrayIteratorPrototype, realm.SymbolToStringTag, "Array Iterator", false);

            Intrinsics.DefineDataProperty(array, "prototype", arrayPrototype, false, false, false);

            return (array, arrayPrototype, arrayIteratorPrototype, arrayProtoEntries, arrayProtoForEach, arrayProtoKeys, arrayProtoValues);
        }

        private static ScriptValue Array([NotNull] ScriptArguments arg)
        {
            var newTarget = arg.NewTarget ?? arg.Function;
            var prototype = Agent.GetPrototypeFromConstructor(newTarget, arg.Agent.Realm.ArrayPrototype);

            if (arg.Count == 0)
            {
                //https://tc39.github.io/ecma262/#sec-array-constructor-array
                return arg.Agent.ArrayCreate(0, prototype);
            }

            if (arg.Count == 1)
            {
                //https://tc39.github.io/ecma262/#sec-array-len
                var array = arg.Agent.ArrayCreate(0, prototype);

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
                var array = arg.Agent.ArrayCreate(arg.Count, prototype);
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

        private static ScriptValue IsArray(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Of(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Concat(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue CopyWithin(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Entries(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Every(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Fill(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Filter(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Find(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue FindIndex(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ForEach(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Includes(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IndexOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Join([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.join
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length"));
            var seperator = arg[0] == ScriptValue.Undefined ? "," : arg.Agent.ToString(arg[0]);

            var result = new StringBuilder();
            for (var k = 0UL; k < length; k++)
            {
                if (k > 0)
                {
                    result.Append(seperator);
                }

                var element = obj.Get(k.ToString());
                var next = element == ScriptValue.Undefined || element == ScriptValue.Null ? "" : arg.Agent.ToString(element);
                result.Append(element);
            }

            return result.ToString();
        }

        private static ScriptValue Keys(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue LastIndexOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Map(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Pop(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Push([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-array.prototype.push
            var obj = arg.Agent.ToObject(arg.ThisValue);
            var length = arg.Agent.ToLength(obj.Get("length", obj));
            //Let items be a List whose elements are, in left to right order, the arguments that were passed to this function invocation.
            var argumentCount = arg.Count;
            if (length + (uint)argumentCount > Agent.MAX_DOUBLE_U)
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
            ulong length;
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


        internal static ScriptValue CreateArrayFromList([NotNull] Agent agent, [NotNull] IEnumerable<ScriptValue> elements)
        {
            //https://tc39.github.io/ecma262/#sec-createarrayfromlist
            var array = agent.ArrayCreate(0);

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
    }
}
