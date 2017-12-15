using System;
using System.Globalization;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed partial class Agent
    {
        //https://tc39.github.io/ecma262/#sec-testing-and-comparison-operations

        internal ScriptValue RequireObjectCoercible(ScriptValue argument)
        {
            if (argument == ScriptValue.Undefined || argument == ScriptValue.Null)
            {
                throw CreateTypeError();
            }
            return argument;
        }

        [Pure]
        internal bool IsArray(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-isarray
            if (!argument.IsObject)
            {
                return false;
            }

            if ((ScriptObject)argument is ScriptArrayObject)
            {
                return true;
            }

            if ((ScriptObject)argument is ScriptProxyObject proxyObject)
            {
                //If argument.[[ProxyHandler]] is null, throw a TypeError exception.
                //Let target be argument.[[ProxyTarget]].
                //Return ? IsArray(target).
                throw new NotImplementedException();
            }

            return false;
        }

        [Pure]
        internal static bool IsCallable(ScriptValue argument)
        {
            return argument.IsObject && ((ScriptObject)argument).IsCallable;
        }

        [Pure]
        internal static bool IsConstructor(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-isconstructor
            return argument.IsObject && ((ScriptObject)argument).IsConstructable;
        }

        [Pure]
        internal static bool IsInteger(ScriptValue argument)
        {
            throw new NotImplementedException();
        }

        [Pure]
        internal static bool IsPropertyKey(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-ispropertykey
            return argument.IsString || argument.IsSymbol;
        }

        [Pure]
        internal static bool IsRegExp(ScriptValue argument)
        {
            throw new NotImplementedException();
        }

        [Pure]
        internal static bool IsStringPrefix(ScriptValue p, ScriptValue q)
        {
            throw new NotImplementedException();
        }

        internal ScriptValue AbstractRelationalComparison(ScriptValue x, ScriptValue y, bool leftFirst = true)
        {
            //https://tc39.github.io/ecma262/#sec-abstract-relational-comparison

            // ReSharper disable CompareOfFloatsByEqualityOperator
            ScriptValue primitiveX;
            ScriptValue primitiveY;

            if (leftFirst)
            {
                primitiveX = ToPrimitive(x, ScriptValue.Type.Number);
                primitiveY = ToPrimitive(y, ScriptValue.Type.Number);
            }
            else
            {
                //the order of evaluation needs to be reversed to preserve left to right evaluation,
                primitiveY = ToPrimitive(y, ScriptValue.Type.Number);
                primitiveX = ToPrimitive(x, ScriptValue.Type.Number);
            }

            if (primitiveX.IsString && primitiveY.IsString)
            {
                var stringX = (string)primitiveX;
                var stringY = (string)primitiveY;
                return string.CompareOrdinal(stringX, stringY) < 0;
            }

            //NOTE: Because px and py are primitive values evaluation order is not important.

            var numberX = ToNumber(primitiveX);
            var numberY = ToNumber(primitiveY);

            if (double.IsNaN(numberX) || double.IsNaN(numberY))
            {
                return ScriptValue.Undefined;
            }

//            if (numberX == numberY)
//            {
//                return false;
//            }
//
//            if (numberX == 0 && numberY == 0 && numberX.IsNegative() != numberY.IsNegative())
//            {
//                return false;
//            }
//
//            if (double.IsPositiveInfinity(numberX))
//            {
//                return false;
//            }
//
//            if (double.IsPositiveInfinity(numberY))
//            {
//                return true;
//            }
//
//            if (double.IsNegativeInfinity(numberY))
//            {
//                return false;
//            }
//
//            if (double.IsNegativeInfinity(numberX))
//            {
//                return true;
//            }

            return numberX < numberY;
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        internal bool AbstractEquality(ScriptValue left, ScriptValue right)
        {
            //https://tc39.github.io/ecma262/#sec-abstract-equality-comparison
            if (left.ValueType == right.ValueType)
            {
                return StrictEquality(left, right);
            }

            if (left == ScriptValue.Null && right == ScriptValue.Undefined)
            {
                return true;
            }
            if (left == ScriptValue.Undefined && right == ScriptValue.Null)
            {
                return true;
            }

            if (left.IsNumber && right.IsString)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return (double)left == ToNumber(right);
            }

            if (left.IsString && right.IsNumber)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return ToNumber(left) == (double)right;
            }

            if (left.IsBoolean)
            {
                return AbstractEquality(ToNumber(left), right);
            }

            if (right.IsBoolean)
            {
                return AbstractEquality(left, ToNumber(right));
            }

            if ((left.IsString || left.IsNumber || left.IsSymbol) && right.IsObject)
            {
                return AbstractEquality(left, ToPrimitive(right));
            }

            if (left.IsObject && (right.IsString || right.IsNumber || right.IsSymbol))
            {
                return AbstractEquality(ToPrimitive(left), right);
            }

            return false;
        }        internal static bool StrictEquality(ScriptValue left, ScriptValue right)        {            if (left.ValueType != right.ValueType)            {                return false;            }            if (left.ValueType == ScriptValue.Type.Number)            {                // ReSharper disable once CompareOfFloatsByEqualityOperator                return (double)left == (double)right;            }            return left.SameValueNonNumber(right);        }
    }
}
