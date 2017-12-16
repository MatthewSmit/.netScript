using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptBoundFunctionObject : ScriptObject
    {
        internal ScriptBoundFunctionObject([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, bool extensible, SpecialObjectType specialObjectType) :
            base(realm, prototype, extensible, specialObjectType)
        {
        }

        /// <inheritdoc />
        internal override ScriptValue Call(ScriptValue thisValue, IReadOnlyList<ScriptValue> arguments)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        internal override ScriptValue Construct(IReadOnlyList<ScriptValue> arguments, ScriptObject newTarget)
        {
            throw new NotImplementedException();
        }

        public override bool IsCallable => true;
    }
}
