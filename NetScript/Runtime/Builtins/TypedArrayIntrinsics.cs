using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class TypedArrayIntrinsics
    {
        public static (ScriptFunctionObject TypedArray, ScriptObject TypedArrayPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var typedArray = Intrinsics.CreateBuiltinFunction(realm, TypedArray, realm.FunctionPrototype, 0, "TypedArray", ConstructorKind.Base);
            Intrinsics.DefineFunction(typedArray, "from", 1, realm, From);
            Intrinsics.DefineFunction(typedArray, "of", 1, realm, Of);
            Intrinsics.DefineAccessorProperty(typedArray, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            var typedArrayPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineAccessorProperty(typedArrayPrototype, "buffer", Intrinsics.CreateBuiltinFunction(realm, GetBuffer, realm.FunctionPrototype, 0, "get buffer"), null);
            Intrinsics.DefineAccessorProperty(typedArrayPrototype, "byteLength", Intrinsics.CreateBuiltinFunction(realm, GetByteLength, realm.FunctionPrototype, 0, "get byteLength"), null);
            Intrinsics.DefineAccessorProperty(typedArrayPrototype, "byteOffset", Intrinsics.CreateBuiltinFunction(realm, GetByteOffset, realm.FunctionPrototype, 0, "get byteOffset"), null);
            Intrinsics.DefineDataProperty(typedArrayPrototype, "constructor", typedArray);
            Intrinsics.DefineFunction(typedArrayPrototype, "copyWithin", 2, realm, CopyWithin);
            Intrinsics.DefineFunction(typedArrayPrototype, "entries", 0, realm, Entries);
            Intrinsics.DefineFunction(typedArrayPrototype, "every", 1, realm, Every);
            Intrinsics.DefineFunction(typedArrayPrototype, "fill", 1, realm, Fill);
            Intrinsics.DefineFunction(typedArrayPrototype, "findIndex", 1, realm, FindIndex);
            Intrinsics.DefineFunction(typedArrayPrototype, "forEach", 1, realm, ForEach);
            Intrinsics.DefineFunction(typedArrayPrototype, "includes", 1, realm, Includes);
            Intrinsics.DefineFunction(typedArrayPrototype, "indexOf", 1, realm, IndexOf);
            Intrinsics.DefineFunction(typedArrayPrototype, "join", 1, realm, Join);
            Intrinsics.DefineFunction(typedArrayPrototype, "keys", 0, realm, Keys);
            Intrinsics.DefineFunction(typedArrayPrototype, "lastIndexOf", 1, realm, LastIndexOf);
            Intrinsics.DefineAccessorProperty(typedArrayPrototype, "length", Intrinsics.CreateBuiltinFunction(realm, GetLength, realm.FunctionPrototype, 0, "get length"), null);
            Intrinsics.DefineFunction(typedArrayPrototype, "map", 1, realm, Map);
            Intrinsics.DefineFunction(typedArrayPrototype, "reduce", 1, realm, Reduce);
            Intrinsics.DefineFunction(typedArrayPrototype, "reduceRight", 1, realm, ReduceRight);
            Intrinsics.DefineFunction(typedArrayPrototype, "reverse", 0, realm, Reverse);
            Intrinsics.DefineFunction(typedArrayPrototype, "set", 1, realm, Set);
            Intrinsics.DefineFunction(typedArrayPrototype, "slice", 2, realm, Slice);
            Intrinsics.DefineFunction(typedArrayPrototype, "some", 1, realm, Some);
            Intrinsics.DefineFunction(typedArrayPrototype, "sort", 1, realm, Sort);
            Intrinsics.DefineFunction(typedArrayPrototype, "subarray", 2, realm, Subarray);
            Intrinsics.DefineFunction(typedArrayPrototype, "toLocaleString", 0, realm, ToLocaleString);
            Intrinsics.DefineFunction(typedArrayPrototype, "toString", 0, realm, ToString);
            var values = Intrinsics.DefineFunction(typedArrayPrototype, "values", 0, realm, Values);
            Intrinsics.DefineDataProperty(typedArrayPrototype, Symbol.Iterator, values);
            Intrinsics.DefineAccessorProperty(typedArrayPrototype, Symbol.ToStringTag, Intrinsics.CreateBuiltinFunction(realm, GetToStringTag, realm.FunctionPrototype, 0, "get [Symbol.toStringTag]"), null);

            Intrinsics.DefineDataProperty(typedArray, "prototype", typedArrayPrototype, false, false, false);

            return (typedArray, typedArrayPrototype);
        }

        private static ScriptValue TypedArray(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue From(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Of(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetBuffer(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetByteLength(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetByteOffset(ScriptArguments arg)
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

        private static ScriptValue Join(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Keys(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue LastIndexOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetLength(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Map(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Set(ScriptArguments arg)
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

        private static ScriptValue Subarray(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLocaleString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Values(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetToStringTag(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static readonly Dictionary<Type, TypeDescription> types = new Dictionary<Type, TypeDescription>
        {
            { typeof(sbyte), new TypeDescription("Int8Array", ToInt8, 1) },
            { typeof(byte), new TypeDescription("Uint8Array", ToUint8, 1) },
            { typeof(short), new TypeDescription("Int16Array", ToInt16, 2) },
            { typeof(ushort), new TypeDescription("Uint16Array", ToUint16, 2) },
            { typeof(int), new TypeDescription("Int32Array", ToInt32, 4) },
            { typeof(uint), new TypeDescription("Uint32Array", ToUint32, 4) },
            { typeof(float), new TypeDescription("Float32Array", ToFloat32, 4) },
            { typeof(double), new TypeDescription("Float64Array", ToFloat64, 8) }
        };

        private static readonly TypeDescription clampedUInt8 = new TypeDescription("Uint8ClampedArray", ToUint8Clamp, 1);

        public static (ScriptFunctionObject TypedArray, ScriptObject TypedArrayPrototype) InitialiseType<T>([NotNull] Agent agent, [NotNull] Realm realm, bool clamped = false)
            where T : struct
        {
            var description = clamped ? clampedUInt8 : types[typeof(T)];
            Debug.Assert(!clamped || typeof(T) == typeof(byte));

            var typedArrayPrototype = agent.ObjectCreate(realm.TypedArrayPrototype);
            Intrinsics.DefineDataProperty(typedArrayPrototype, "BYTES_PER_ELEMENT", description.Size, false, false, false);

            var typedArray = Intrinsics.CreateBuiltinFunction(realm, arguments => TypedArray(arguments, description, typedArrayPrototype), realm.FunctionPrototype, 3, description.Name, ConstructorKind.Base);
            Intrinsics.DefineDataProperty(typedArray, "BYTES_PER_ELEMENT", description.Size, false, false, false);
            Intrinsics.DefineDataProperty(typedArray, "prototype", typedArrayPrototype, false, false, false);

            Intrinsics.DefineDataProperty(typedArrayPrototype, "constructor", typedArray);

            return (typedArray, typedArrayPrototype);
        }

        private static void ToInt8(double value, IntPtr ptr)
        {
            throw new NotImplementedException();
        }

        private static unsafe void ToUint8(double value, IntPtr ptr)
        {
            var rawBytes = (byte*)ptr;

            if (double.IsNaN(value) || double.IsInfinity(value) || value == 0)
            {
                *rawBytes = 0;
            }
            else
            {
                *rawBytes = (byte)(Math.Sign(value) * Math.Floor(Math.Abs(value)));
            }
        }

        private static void ToUint8Clamp(double value, IntPtr ptr)
        {
            throw new NotImplementedException();
        }

        private static void ToInt16(double value, IntPtr ptr)
        {
            throw new NotImplementedException();
        }

        private static unsafe void ToUint16(double value, IntPtr ptr)
        {
            var rawBytes = (ushort*)ptr;

            if (double.IsNaN(value) || double.IsInfinity(value) || value == 0)
            {
                *rawBytes = 0;
            }
            else
            {
                *rawBytes = (ushort)(Math.Sign(value) * Math.Floor(Math.Abs(value)));
            }
        }

        private static unsafe void ToInt32(double value, IntPtr ptr)
        {
            var rawBytes = (int*)ptr;

            if (value == 0 || double.IsNaN(value) || double.IsInfinity(value))
            {
                *rawBytes = 0;
            }
            else
            {
                *rawBytes = Math.Sign(value) * (int)(uint)Math.Floor(Math.Abs(value));
            }
        }

        private static unsafe void ToUint32(double value, IntPtr ptr)
        {
            var rawBytes = (uint*)ptr;

            if (double.IsNaN(value) || double.IsInfinity(value) || value == 0)
            {
                *rawBytes = 0;
            }
            else
            {
                *rawBytes = (uint)(Math.Sign(value) * Math.Floor(Math.Abs(value)));
            }
        }

        private static unsafe void ToFloat32(double value, IntPtr ptr)
        {
            var rawBytes = (float*)ptr;
            if (double.IsNaN(value))
            {
                *rawBytes = float.NaN;
            }
            else
            {
                *rawBytes = (float)value;
            }
        }

        private static unsafe void ToFloat64(double value, IntPtr ptr)
        {
            var rawBytes = (double*)ptr;
            if (double.IsNaN(value))
            {
                *rawBytes = double.NaN;
            }
            else
            {
                *rawBytes = value;
            }
        }

        private static ScriptValue TypedArray([NotNull] ScriptArguments arg, [NotNull] TypeDescription description, [NotNull] ScriptObject typedArrayPrototype)
        {
            if (arg.Count == 0)
            {
                //https://tc39.github.io/ecma262/#sec-typedarray
                throw new NotImplementedException();
            }

            if (arg[0].IsObject)
            {
                var obj = (ScriptObject)arg[0];
                if (obj.SpecialObjectType == SpecialObjectType.TypedArray)
                {
                    //https://tc39.github.io/ecma262/#sec-typedarray-typedarray
                    throw new NotImplementedException();
                }
                else if (obj.SpecialObjectType == SpecialObjectType.ArrayBuffer)
                {
                    //https://tc39.github.io/ecma262/#sec-typedarray-buffer-byteoffset-length
                    throw new NotImplementedException();
                }
                else
                {
                    return TypedArrayObject(arg, description, typedArrayPrototype);
                }
            }
            else
            {
                //https://tc39.github.io/ecma262/#sec-typedarray-length
                if (arg.NewTarget == null)
                {
                    throw arg.Agent.CreateTypeError();
                }

                var elementLength = arg.Agent.ToIndex(arg[0]);
                return AllocateTypedArray(arg.Agent, arg.Function.Realm, description, arg.NewTarget, typedArrayPrototype, elementLength);
            }
        }

        private static ScriptValue TypedArrayObject([NotNull] ScriptArguments arg, [NotNull] TypeDescription description, [NotNull] ScriptObject typedArrayPrototype)
        {
            //https://tc39.github.io/ecma262/#sec-typedarray-object
            var obj = (ScriptObject)arg[0];
            Debug.Assert(obj.SpecialObjectType != SpecialObjectType.TypedArray && obj.SpecialObjectType != SpecialObjectType.ArrayBuffer);

            if (arg.NewTarget == null)
            {
                throw arg.Agent.CreateTypeError();
            }

            var typedArray = AllocateTypedArray(arg.Agent, arg.Function.Realm, description, arg.NewTarget, typedArrayPrototype);
            var usingIterator = arg.Agent.GetMethod(obj, Symbol.Iterator);
            if (usingIterator != null)
            {
                var values = IterableToList(arg.Agent, obj, usingIterator);
                var length = values.Count;
                AllocateTypedArrayBuffer(arg.Agent, arg.Function.Realm, typedArray, (ulong)length);
                for (var k = 0; k < length; k++)
                {
                    var propertyKey = k.ToString(CultureInfo.InvariantCulture);
                    var keyValue = values[k];
                    arg.Agent.Set(typedArray, propertyKey, keyValue, true);
                }
                return typedArray;
            }

            //NOTE: object is not an Iterable so assume it is already an array-like object.
            //Let arrayLike be object.
            //Let len be ? ToLength(? Get(arrayLike, "length")).
            //Perform ? AllocateTypedArrayBuffer(O, len).
            //Let k be 0.
            //Repeat, while k < len
            //    Let Pk be ! ToString(k).
            //    Let kValue be ? Get(arrayLike, Pk).
            //    Perform ? Set(O, Pk, kValue, true).
            //    Increase k by 1.
            //Return O.
            throw new NotImplementedException();
        }


        [NotNull]
        private static ScriptIntegerIndexedObject AllocateTypedArray([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] TypeDescription description, [NotNull] ScriptObject newTarget, [NotNull] ScriptObject defaultPrototype, ulong? length = null)
        {
            //https://tc39.github.io/ecma262/#sec-allocatetypedarray
            var prototype = Agent.GetPrototypeFromConstructor(newTarget, defaultPrototype);
            var obj = new ScriptIntegerIndexedObject(prototype.Realm, prototype, description);
            if (length.HasValue)
            {
                AllocateTypedArrayBuffer(agent, realm, obj, length.Value);
            }
            return obj;
        }

        private static void AllocateTypedArrayBuffer([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptIntegerIndexedObject obj, ulong length)
        {
            //https://tc39.github.io/ecma262/#sec-allocatetypedarraybuffer
            Debug.Assert(obj.ViewedArrayBuffer == null);
            var elementSize = obj.Description.Size;
            var byteLength = elementSize * length;
            obj.ViewedArrayBuffer = ArrayBufferIntrinsics.AllocateArrayBuffer(agent, realm.ArrayBuffer, byteLength);
            obj.ByteLength = byteLength;
            obj.ByteOffset = 0;
            obj.ArrayLength = length;
        }

        [NotNull]
        private static IReadOnlyList<ScriptValue> IterableToList([NotNull] Agent agent, [NotNull] ScriptObject items, [NotNull] ScriptFunctionObject method)
        {
            //https://tc39.github.io/ecma262/#sec-iterabletolist
            var iteratorRecord = agent.GetIterator(items, method);
            var values = new List<ScriptValue>();
            while (true)
            {
                var step = agent.IteratorStep(iteratorRecord);
                if (step != false)
                {
                    var nextValue = Agent.IteratorValue((ScriptObject)step);
                    values.Add(nextValue);
                }
                else
                {
                    break;
                }
            }

            return values;
        }
    }
}