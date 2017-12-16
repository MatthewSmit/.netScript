using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class SharedArrayBufferIntrinsics
    {
        public static (ScriptFunctionObject SharedArrayBuffer, ScriptObject SharedArrayBufferPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var sharedArrayBuffer = Intrinsics.CreateBuiltinFunction(realm, SharedArrayBuffer, realm.FunctionPrototype, 1, "SharedArrayBuffer", ConstructorKind.Base);
            Intrinsics.DefineAccessorProperty(sharedArrayBuffer, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            var sharedArrayBufferPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineAccessorProperty(sharedArrayBufferPrototype, "byteLength", Intrinsics.CreateBuiltinFunction(realm, GetByteLength, realm.FunctionPrototype, 0, "get byteLength"), null);
            Intrinsics.DefineDataProperty(sharedArrayBufferPrototype, "constructor", sharedArrayBuffer);
            Intrinsics.DefineFunction(sharedArrayBufferPrototype, "slice", 2, realm, Slice);
            Intrinsics.DefineDataProperty(sharedArrayBufferPrototype, Symbol.ToStringTag, "SharedArrayBuffer", false);

            Intrinsics.DefineDataProperty(sharedArrayBuffer, "prototype", sharedArrayBufferPrototype, false, false, false);

            return (sharedArrayBuffer, sharedArrayBufferPrototype);
        }

        private static ScriptValue SharedArrayBuffer(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetSpecies(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue GetByteLength(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }

        private static ScriptValue Slice(ScriptArguments arg)
        {
            throw new System.NotImplementedException();
        }


        public static bool IsSharedArrayBuffer([NotNull] ScriptObject arrayBuffer)
        {
            //https://tc39.github.io/ecma262/#sec-issharedarraybuffer
            Debug.Assert(arrayBuffer.SpecialObjectType == SpecialObjectType.ArrayBuffer);
            var data = arrayBuffer.ArrayBuffer;
            if (data.Data == null)
            {
                return false;
            }

            return data.Shared;
        }
    }
}