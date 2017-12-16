using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptArrayObject : ScriptObject
    {
        internal ScriptArrayObject([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, bool extensible, uint length) :
            base(realm, prototype, extensible, SpecialObjectType.None)
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
            var oldLength = (uint)(double)oldLengthDescriptor.Value.Value;

            if (newLength >= oldLength)
            {
                return base.DefineOwnProperty("length", newLengthDescriptor);
            }

            if (!oldLengthDescriptor.Writable)
            {
                return false;
            }

            bool newWritable;
            if (!newLengthDescriptor.Writable.HasValue || newLengthDescriptor.Writable)
            {
                newWritable = true;
            }
            else
            {
                //Need to defer setting the [[Writable]] attribute to false in case any elements cannot be deleted.
                newWritable = false;
                newLengthDescriptor.Writable = true;
            }

            var succeeded = base.DefineOwnProperty("length", newLengthDescriptor);
            if (!succeeded)
            {
                return false;
            }

            while (newLength < oldLength)
            {
                oldLength--;
                var deleteSucceeded = Delete(oldLength.ToString(CultureInfo.InvariantCulture));
                if (!deleteSucceeded)
                {
                    newLengthDescriptor.Value = oldLength + 1;
                    if (!newWritable)
                    {
                        newLengthDescriptor.Writable = false;
                    }

                    base.DefineOwnProperty("length", newLengthDescriptor);
                    return false;
                }
            }

            if (!newWritable)
            {
                return base.DefineOwnProperty("length", new PropertyDescriptor
                {
                    Writable = false
                });
            }

            return true;
        }
    }
}
