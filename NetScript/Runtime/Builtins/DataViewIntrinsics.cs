﻿using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class DataViewIntrinsics
    {
        public static (ScriptFunctionObject DataView, ScriptObject DataViewPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var dataView = Intrinsics.CreateBuiltinFunction(realm, DataView, realm.FunctionPrototype, 1, "DataView", ConstructorKind.Base);

            var dataViewPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineAccessorProperty(dataViewPrototype, "buffer", Intrinsics.CreateBuiltinFunction(realm, GetBuffer, realm.FunctionPrototype, 0, "get buffer"), null);
            Intrinsics.DefineAccessorProperty(dataViewPrototype, "byteLength", Intrinsics.CreateBuiltinFunction(realm, GetByteLength, realm.FunctionPrototype, 0, "get byteLength"), null);
            Intrinsics.DefineAccessorProperty(dataViewPrototype, "byteOffset", Intrinsics.CreateBuiltinFunction(realm, GetByteOffset, realm.FunctionPrototype, 0, "get byteOffset"), null);
            Intrinsics.DefineDataProperty(dataViewPrototype, "constructor", dataView);
            Intrinsics.DefineFunction(dataViewPrototype, "getFloat32", 1, realm, GetFloat32);
            Intrinsics.DefineFunction(dataViewPrototype, "getFloat64", 1, realm, GetFloat64);
            Intrinsics.DefineFunction(dataViewPrototype, "getInt8", 1, realm, GetInt8);
            Intrinsics.DefineFunction(dataViewPrototype, "getInt16", 1, realm, GetInt16);
            Intrinsics.DefineFunction(dataViewPrototype, "getInt32", 1, realm, GetInt32);
            Intrinsics.DefineFunction(dataViewPrototype, "getUint8", 1, realm, GetUint8);
            Intrinsics.DefineFunction(dataViewPrototype, "getUint16", 1, realm, GetUint16);
            Intrinsics.DefineFunction(dataViewPrototype, "getUint32", 1, realm, GetUint32);
            Intrinsics.DefineFunction(dataViewPrototype, "setFloat32", 2, realm, SetFloat32);
            Intrinsics.DefineFunction(dataViewPrototype, "setFloat64", 2, realm, SetFloat64);
            Intrinsics.DefineFunction(dataViewPrototype, "setInt8", 2, realm, SetInt8);
            Intrinsics.DefineFunction(dataViewPrototype, "setInt16", 2, realm, SetInt16);
            Intrinsics.DefineFunction(dataViewPrototype, "setInt32", 2, realm, SetInt32);
            Intrinsics.DefineFunction(dataViewPrototype, "setUint8", 2, realm, SetUint8);
            Intrinsics.DefineFunction(dataViewPrototype, "setUint16", 2, realm, SetUint16);
            Intrinsics.DefineFunction(dataViewPrototype, "setUint32", 2, realm, SetUint32);
            Intrinsics.DefineDataProperty(dataViewPrototype, Symbol.ToStringTag, "DataView", false);

            Intrinsics.DefineDataProperty(dataView, "prototype", dataViewPrototype, false, false, false);

            return (dataView, dataViewPrototype);
        }

        private static ScriptValue DataView([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-dataview-buffer-byteoffset-bytelength
            if (arg.NewTarget == null)
            {
                throw arg.Agent.CreateTypeError();
            }

            var buffer = arg[0].AsObject(arg.Agent);
            if (buffer.SpecialObjectType != SpecialObjectType.ArrayBuffer)
            {
                throw arg.Agent.CreateTypeError();
            }

            var offset = arg.Agent.ToIndex(arg[1]);
            if (ArrayBufferIntrinsics.IsDetachedBuffer(buffer))
            {
                throw arg.Agent.CreateTypeError();
            }

            var bufferByteLength = buffer.ArrayBuffer.Data.LongLength;
            if (offset > bufferByteLength)
            {
                throw arg.Agent.CreateRangeError();
            }

            long viewByteLength;
            if (arg[2] == ScriptValue.Undefined)
            {
                viewByteLength = bufferByteLength - offset;
            }
            else
            {
                viewByteLength = arg.Agent.ToIndex(arg[2]);
                if (offset + viewByteLength > bufferByteLength)
                {
                    throw arg.Agent.CreateRangeError();
                }
            }

            var obj = arg.Agent.OrdinaryCreateFromConstructor(arg.NewTarget, arg.Function.Realm.DataViewPrototype, SpecialObjectType.DataView);
            obj.DataView.ViewedArrayBuffer = buffer;
            obj.DataView.ByteLength = viewByteLength;
            obj.DataView.ByteOffset = offset;
            return obj;
        }

        private static ScriptValue GetBuffer([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-get-dataview.prototype.buffer
            var obj = arg.ThisValue.AsObject(arg.Agent);
            if (obj.SpecialObjectType != SpecialObjectType.DataView)
            {
                throw arg.Agent.CreateTypeError();
            }

            return obj.DataView.ViewedArrayBuffer;
        }

        private static ScriptValue GetByteLength(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetByteOffset(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetFloat32(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetFloat64(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetInt8(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetInt16(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetInt32(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUint8(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUint16(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUint32(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetFloat32(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetFloat64(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetInt8(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetInt16(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetInt32(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUint8(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUint16(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue SetUint32(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }
    }
}