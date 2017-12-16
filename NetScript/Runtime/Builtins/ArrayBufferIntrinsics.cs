using System;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class ArrayBufferIntrinsics
    {
        public static (ScriptFunctionObject ArrayBuffer, ScriptObject ArrayBufferPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var arrayBuffer = Intrinsics.CreateBuiltinFunction(realm, ArrayBuffer, realm.FunctionPrototype, 1, "ArrayBuffer", ConstructorKind.Base);

            Intrinsics.DefineFunction(arrayBuffer, "isView", 1, realm, IsView);

            Intrinsics.DefineAccessorProperty(arrayBuffer, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            var arrayBufferPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineAccessorProperty(arrayBufferPrototype, "byteLength", Intrinsics.CreateBuiltinFunction(realm, GetByteLength, realm.FunctionPrototype, 0, "get byteLength"), null);
            Intrinsics.DefineDataProperty(arrayBufferPrototype, "constructor", arrayBuffer);
            Intrinsics.DefineFunction(arrayBufferPrototype, "slice", 2, realm, Slice);
            Intrinsics.DefineDataProperty(arrayBufferPrototype, Symbol.ToStringTag, "ArrayBuffer", false);

            Intrinsics.DefineDataProperty(arrayBuffer, "prototype", arrayBufferPrototype, false, false, false);

            return (arrayBuffer, arrayBufferPrototype);
        }

        private static ScriptValue ArrayBuffer(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IsView(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetByteLength(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Slice(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }


        [NotNull]
        public static ScriptObject AllocateArrayBuffer([NotNull] Agent agent, [NotNull] ScriptFunctionObject constructor, ulong byteLength)
        {
            var obj = agent.OrdinaryCreateFromConstructor(constructor, constructor.Realm.ArrayBufferPrototype, SpecialObjectType.ArrayBuffer);
            var block = new byte[byteLength];
            obj.ArrayBuffer.Data = block;
            return obj;
        }

        public static bool IsDetachedBuffer([NotNull] ScriptObject arrayBuffer)
        {
            //https://tc39.github.io/ecma262/#sec-isdetachedbuffer
            Debug.Assert(arrayBuffer.SpecialObjectType == SpecialObjectType.ArrayBuffer);
            return arrayBuffer.ArrayBuffer.Data == null;
        }

        public static unsafe void SetValueInBuffer([NotNull] Agent agent, [NotNull] ScriptObject arrayBuffer, ulong byteIndex, [NotNull] TypeDescription description, double value, bool isTypedArray, OrderType order, bool isLittleEndian)
        {
            //https://tc39.github.io/ecma262/#sec-setvalueinbuffer
            Debug.Assert(!IsDetachedBuffer(arrayBuffer));
            var block = arrayBuffer.ArrayBuffer.Data;
            Debug.Assert(byteIndex + description.Size <= (ulong)block.Length);
            byte* rawBytes = stackalloc byte[8];
            NumberToRawBytes(description, value, isLittleEndian, rawBytes);
            if (SharedArrayBufferIntrinsics.IsSharedArrayBuffer(arrayBuffer))
            {
                //Let execution be the [[CandidateExecution]] field of the surrounding agent's Agent Record.
                //Let eventList be the [[EventList]] field of the element in execution.[[EventLists]] whose [[AgentSignifier]] is AgentSignifier().
                //If isTypedArray is true and type is "Int8", "Uint8", "Int16", "Uint16", "Int32", or "Uint32", let noTear be true; otherwise let noTear be false.
                //Append WriteSharedMemory{ [[Order]]: order, [[NoTear]]: noTear, [[Block]]: block, [[ByteIndex]]: byteIndex, [[ElementSize]]: elementSize, [[Payload]]: rawBytes } to eventList.
                throw new NotImplementedException();
            }
            else
            {
                for (var i = 0u; i < description.Size; i++)
                {
                    block[byteIndex + i] = rawBytes[i];
                }
            }
        }

        private static unsafe void NumberToRawBytes([NotNull] TypeDescription description, double value, bool isLittleEndian, byte* rawBytes)
        {
            //https://tc39.github.io/ecma262/#sec-numbertorawbytes
            description.ConversionToBytes(value, (IntPtr)rawBytes);

            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Swap(rawBytes, description.Size);
            }
        }

        public static unsafe double GetValueFromBuffer([NotNull] Agent agent, [NotNull] ScriptObject arrayBuffer, ulong byteIndex, [NotNull] TypeDescription description, bool isTypedArray, OrderType order, bool isLittleEndian)
        {
            //https://tc39.github.io/ecma262/#sec-getvaluefrombuffer
            Debug.Assert(!IsDetachedBuffer(arrayBuffer));
            var block = arrayBuffer.ArrayBuffer.Data;
            Debug.Assert(byteIndex + description.Size <= (ulong)block.Length);

            byte* rawBytes = stackalloc byte[8];
            if (SharedArrayBufferIntrinsics.IsSharedArrayBuffer(arrayBuffer))
            {
                //Let execution be the [[CandidateExecution]] field of the surrounding agent's Agent Record.
                //Let eventList be the [[EventList]] field of the element in execution.[[EventLists]] whose [[AgentSignifier]] is AgentSignifier().
                //If isTypedArray is true and type is "Int8", "Uint8", "Int16", "Uint16", "Int32", or "Uint32", let noTear be true; otherwise let noTear be false.
                //Let rawValue be a List of length elementSize of nondeterministically chosen byte values.
                //NOTE: In implementations, rawValue is the result of a non-atomic or atomic read instruction on the underlying hardware. The nondeterminism is a semantic prescription of the memory model to describe observable behaviour of hardware with weak consistency.
                //Let readEvent be ReadSharedMemory{ [[Order]]: order, [[NoTear]]: noTear, [[Block]]: block, [[ByteIndex]]: byteIndex, [[ElementSize]]: elementSize }.
                //Append readEvent to eventList.
                //Append Chosen Value Record { [[Event]]: readEvent, [[ChosenValue]]: rawValue } to execution.[[ChosenValues]].
                throw new NotImplementedException();
            }
            else
            {
                for (var i = 0u; i < description.Size; i++)
                {
                    rawBytes[i] = block[byteIndex + i];
                }
            }

            return RawBytesToNumber(description, rawBytes, isLittleEndian);
        }

        private static unsafe double RawBytesToNumber([NotNull] TypeDescription description, byte* rawBytes, bool isLittleEndian)
        {
            //https://tc39.github.io/ecma262/#sec-rawbytestonumber
            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Swap(rawBytes, description.Size);
            }

            return description.ConversionFromBytes((IntPtr)rawBytes);
        }

        private static unsafe void Swap(byte* rawBytes, uint size)
        {
            size /= 2;
            for (var i = 0; i < size; i++)
            {
                var tmp = rawBytes[i];
                rawBytes[i] = rawBytes[size - i - 1];
                rawBytes[size - i - 1] = tmp;
            }
        }
    }
}