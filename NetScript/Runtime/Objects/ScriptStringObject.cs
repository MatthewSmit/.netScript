using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptStringObject : ScriptObject
    {
        internal ScriptStringObject([NotNull] Agent agent, [CanBeNull] ScriptObject prototype, [NotNull] string data, bool extensible = true) :
            base(agent, prototype, extensible, SpecialObjectType.None)
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
                //Return ! IsCompatiblePropertyDescriptor(extensible, Desc, stringDesc).
                throw new NotImplementedException();
            }

            return base.DefineOwnProperty(property, descriptor);
        }

        internal override IEnumerable<ScriptValue> OwnPropertyKeys()
        {
            throw new NotImplementedException();
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

            //If IsInteger(index) is false, return undefined.
            //If index = -0, return undefined.
            //Let str be the String value of S.[[StringData]].
            //Let len be the length of str.
            //If index < 0 or len ≤ index, return undefined.
            //Let resultStr be the String value of length 1, containing one code unit from str, specifically the code unit at index index.
            //Return a PropertyDescriptor{[[Value]]: resultStr, [[Writable]]: false, [[Enumerable]]: true, [[Configurable]]: false}.
            throw new NotImplementedException();
        }

        [NotNull]
        public string StringData { get; }
    }
}