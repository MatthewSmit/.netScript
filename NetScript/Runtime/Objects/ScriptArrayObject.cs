using System;
using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptArrayObject : ScriptObject
    {
        internal ScriptArrayObject([NotNull] Agent agent, [CanBeNull] ScriptObject prototype, bool extensible, uint length) :
            base(agent, prototype, extensible, SpecialObjectType.None)
        {
            base.DefineOwnProperty("length", new PropertyDescriptor(length, true, false, false));
        }

        internal override bool DefineOwnProperty(ScriptValue property, PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-array-exotic-objects-defineownproperty-p-desc
            Debug.Assert(Agent.IsPropertyKey(property));
            if (property.IsString && (string)property == "length")
            {
                return ArraySetLength(descriptor);
            }

            if (property.IsString && uint.TryParse((string)property, NumberStyles.None, CultureInfo.InvariantCulture, out var index))
            {
                var oldLengthDescriptor = GetOwnProperty("length");
                Debug.Assert(oldLengthDescriptor != null, nameof(oldLengthDescriptor) + " != null");
                Debug.Assert(oldLengthDescriptor.Value != null, "oldLengthDescriptor.Value != null");
                var oldLength = (double)oldLengthDescriptor.Value.Value;

                if (index >= oldLength && !oldLengthDescriptor.Writable)
                {
                    return false;
                }

                var succeeded = base.DefineOwnProperty(property, descriptor);
                if (!succeeded)
                {
                    return false;
                }

                if (index >= oldLength)
                {
                    oldLengthDescriptor.Value = index + 1;
                    succeeded = base.DefineOwnProperty("length", oldLengthDescriptor);
                    Debug.Assert(succeeded);
                }

                return true;
            }

            return base.DefineOwnProperty(property, descriptor);
        }

        private bool ArraySetLength([NotNull] PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-arraysetlength

            var descriptorValue = descriptor.Value;
            if (!descriptorValue.HasValue)
            {
                return base.DefineOwnProperty("length", descriptor);
            }

            var newLengthDescriptor = descriptor.Copy();
            var newLength = Agent.ToUint32(descriptorValue.Value);
            var numberLength = Agent.ToNumber(descriptorValue.Value);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (newLength != numberLength)
            {
                throw Agent.CreateRangeError();
            }

            newLengthDescriptor.Value = newLength;
            var oldLengthDescriptor = GetOwnProperty("length");

            Debug.Assert(!oldLengthDescriptor?.IsAccessorDescriptor == true);
            Debug.Assert(oldLengthDescriptor.Value != null, "oldLengthDescriptor.Value != null");
            var oldLength = (double)oldLengthDescriptor.Value.Value;

            if (newLength >= oldLength)
            {
                return base.DefineOwnProperty("length", newLengthDescriptor);
            }

            //If oldLenDesc.[[Writable]] is false, return false.
            //If newLenDesc.[[Writable]] is absent or has the value true, let newWritable be true.
            //Else,
            //    Need to defer setting the [[Writable]] attribute to false in case any elements cannot be deleted.
            //    Let newWritable be false.
            //    Set newLenDesc.[[Writable]] to true.
            //Let succeeded be ! OrdinaryDefineOwnProperty(A, "length", newLenDesc).
            //If succeeded is false, return false.
            //Repeat, while newLen < oldLen,
            //    Set oldLen to oldLen - 1.
            //    Let deleteSucceeded be ! A.[[Delete]](! ToString(oldLen)).
            //    If deleteSucceeded is false, then
            //        Set newLenDesc.[[Value]] to oldLen + 1.
            //        If newWritable is false, set newLenDesc.[[Writable]] to false.
            //        Let succeeded be ! OrdinaryDefineOwnProperty(A, "length", newLenDesc).
            //        Return false.
            //If newWritable is false, then
            //    Return OrdinaryDefineOwnProperty(A, "length", PropertyDescriptor{[[Writable]]: false}). This call will always return true.
            //Return true.
            throw new NotImplementedException();
        }
    }
}
