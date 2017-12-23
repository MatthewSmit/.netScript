using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal struct Reference
    {
        private ScriptValue baseValue;
        private ScriptValue thisValue;
        private BaseEnvironment baseEnvironment;

        public Reference([CanBeNull] BaseEnvironment baseEnvironment, [NotNull] string name, bool strict)
        {
            IsStrictReference = strict;
            baseValue = ScriptValue.Undefined;
            thisValue = ScriptValue.Undefined;
            this.baseEnvironment = baseEnvironment;
            ReferencedName = name;
        }

        public Reference(ScriptValue baseValue, ScriptValue name, bool strict)
        {
            IsStrictReference = strict;
            this.baseValue = baseValue;
            thisValue = ScriptValue.Undefined;
            baseEnvironment = null;
            ReferencedName = name;
        }

        public Reference(ScriptValue baseValue, ScriptValue name, ScriptValue thisValue, bool strict)
        {
            IsStrictReference = strict;
            this.baseValue = baseValue;
            this.thisValue = thisValue;
            baseEnvironment = null;
            ReferencedName = name;
        }

        public void InitialiseReferencedBinding(ScriptValue w)
        {
            //https://tc39.github.io/ecma262/#sec-initializereferencedbinding
            Debug.Assert(!IsUnresolvableReference);
            var baseValue = BaseEnvironment;
            baseValue.InitialiseBinding(ReferencedName, w);
        }

        public ScriptValue BaseValue
        {
            get
            {
                if (baseEnvironment != null)
                    throw new InvalidOperationException();
                return baseValue;
            }
        }

        public ScriptValue ThisValue
        {
            get
            {
                Debug.Assert(IsPropertyReference);
                if (IsSuperReference)
                    return thisValue;
                return baseValue;
            }
        }

        public bool IsSuperReference
        {
            get { return thisValue != ScriptValue.Null && thisValue != ScriptValue.Undefined; }
        }

        public BaseEnvironment BaseEnvironment
        {
            get
            {
                if (baseEnvironment == null)
                    throw new InvalidOperationException();
                return baseEnvironment;
            }
        }

        [NotNull]
        public ScriptValue ReferencedName { get; }

        public bool IsUnresolvableReference
        {
            get { return baseEnvironment == null && baseValue == ScriptValue.Undefined; }
        }

        public bool IsPropertyReference
        {
            get { return baseEnvironment == null && (baseValue.IsObject || HasPrimitiveBase); }
        }

        public bool HasPrimitiveBase
        {
            get { return baseEnvironment == null && (baseValue.IsBoolean || baseValue.IsString || baseValue.IsSymbol || baseValue.IsNumber); }
        }

        public bool IsStrictReference { get; }
    }
}