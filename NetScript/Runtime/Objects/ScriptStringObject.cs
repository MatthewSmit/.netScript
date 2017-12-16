using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptStringObject : ScriptObject
    {
        internal ScriptStringObject([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, [NotNull] string data, bool extensible = true) :
            base(realm, prototype, extensible, SpecialObjectType.None)
        {
            StringData = data;
            base.DefineOwnProperty("length", new PropertyDescriptor(data.Length, false, false, false));
        }

        internal override PropertyDescriptor GetOwnProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-string-exotic-objects-getownproperty-p
            Debug.Assert(Agent.IsPropertyKey(property));
            var descriptor = base.GetOwnProperty(property);
            if (descriptor != null)
            {
                return descriptor;
            }

            return StringGetOwnProperty(property);
        }

        internal override bool DefineOwnProperty(ScriptValue property, PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-string-exotic-objects-defineownproperty-p-desc
            Debug.Assert(Agent.IsPropertyKey(property));
            var stringDescriptor = StringGetOwnProperty(property);
            if (stringDescriptor != null)
            {
                return ValidateAndApplyPropertyDescriptor(null, ScriptValue.Undefined, IsExtensible, descriptor, stringDescriptor);
            }

            return base.DefineOwnProperty(property, descriptor);
        }

        internal override IEnumerable<ScriptValue> OwnPropertyKeys()
        {
            //https://tc39.github.io/ecma262/#sec-string-exotic-objects-ownpropertykeys
            for (var i = 0; i < StringData.Length; i++)
            {
                yield return i.ToString(CultureInfo.InvariantCulture);
            }

            foreach (var propertyKey in base.OwnPropertyKeys())
            {
                yield return propertyKey;
            }
        }

        [CanBeNull]
        private PropertyDescriptor StringGetOwnProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-stringgetownproperty
            Debug.Assert(Agent.IsPropertyKey(property));
            if (!property.IsString)
            {
                return null;
            }

            var index = Agent.CanonicalNumericIndexString((string)property);
            if (!index.HasValue)
            {
                return null;
            }

            if (!Agent.IsInteger(index.Value))
            {
                return null;
            }

            if (index.Value == 0 && index.Value.IsNegative())
            {
                return null;
            }

            var realValue = (int)index.Value;
            if (realValue < 0 || realValue >= StringData.Length)
            {
                return null;
            }

            var result = StringData[realValue];
            return new PropertyDescriptor(result.ToString(CultureInfo.InvariantCulture), false, true, false);
        }

        [NotNull]
        public string StringData { get; }
    }
}