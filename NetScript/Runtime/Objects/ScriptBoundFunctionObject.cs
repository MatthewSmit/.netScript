using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptBoundFunctionObject : ScriptObject
    {
        internal ScriptBoundFunctionObject([NotNull] ScriptObject targetFunction, ScriptValue boundThis, [NotNull] IReadOnlyList<ScriptValue> boundArguments) :
            base(targetFunction.Realm, targetFunction.GetPrototypeOf(), true, SpecialObjectType.None)
        {
            BoundTargetFunction = targetFunction;
            BoundThis = boundThis;
            BoundArguments = boundArguments;
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

        /// <inheritdoc />
        public override bool IsConstructable => BoundTargetFunction.IsConstructable;
        public override bool IsCallable => true;

        [NotNull]
        public ScriptObject BoundTargetFunction { get; }

        public ScriptValue BoundThis { get; }

        [NotNull]
        public IReadOnlyList<ScriptValue> BoundArguments { get; }
    }
}
