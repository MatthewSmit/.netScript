using System.Collections.Generic;
using System.Diagnostics;
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
            //https://tc39.github.io/ecma262/#sec-bound-function-exotic-objects-call-thisargument-argumentslist
            if (arguments.Count == 0)
            {
                return Agent.Call(BoundTargetFunction, BoundThis, BoundArguments);
            }

            if (BoundArguments.Count == 0)
            {
                return Agent.Call(BoundTargetFunction, BoundThis, arguments);
            }

            var args = new ScriptValue[BoundArguments.Count + arguments.Count];
            for (var i = 0; i < BoundArguments.Count; i++)
            {
                args[i] = BoundArguments[i];
            }

            for (var i = 0; i < arguments.Count; i++)
            {
                args[i + BoundArguments.Count] = arguments[i];
            }

            return Agent.Call(BoundTargetFunction, BoundThis, args);
        }

        /// <inheritdoc />
        internal override ScriptValue Construct(IReadOnlyList<ScriptValue> arguments, ScriptObject newTarget)
        {
            //https://tc39.github.io/ecma262/#sec-bound-function-exotic-objects-construct-argumentslist-newtarget
            Debug.Assert(Agent.IsConstructor(BoundTargetFunction));

            if (this == newTarget)
            {
                newTarget = BoundTargetFunction;
            }

            if (arguments.Count == 0)
            {
                return Agent.Construct(BoundTargetFunction, BoundArguments, newTarget);
            }

            if (BoundArguments.Count == 0)
            {
                return Agent.Construct(BoundTargetFunction, arguments, newTarget);
            }

            var args = new ScriptValue[BoundArguments.Count + arguments.Count];
            for (var i = 0; i < BoundArguments.Count; i++)
            {
                args[i] = BoundArguments[i];
            }

            for (var i = 0; i < arguments.Count; i++)
            {
                args[i + BoundArguments.Count] = arguments[i];
            }

            return Agent.Construct(BoundTargetFunction, args, newTarget);
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
