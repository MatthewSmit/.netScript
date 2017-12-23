using System;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed partial class Agent
    {
        //https://tc39.github.io/ecma262/#sec-type-conversion

        private const double MAX_DOUBLE = 9007199254740991; // 2^53-1
        internal const long MAX_DOUBLE_L = 9007199254740991L; // 2^53-1

        private const string WHITESPACE = "[\t\v\f \u00A0\uFEFF\u1680\u2000-\u200A\u202F\u205F\u3000\n\r\u2028\u2029]";
        private static readonly Regex whitespaceRegex = new Regex("^" + WHITESPACE + "*$", RegexOptions.Compiled);
        private static readonly Regex binaryIntegerRegex = new Regex("^" + WHITESPACE + "*" + "0[bB]([0-1]+)" + WHITESPACE + "*$", RegexOptions.Compiled);
        private static readonly Regex octalIntegerRegex = new Regex("^" + WHITESPACE + "*" + "0[oO]([0-7]+)" + WHITESPACE + "*$", RegexOptions.Compiled);
        private static readonly Regex hexIntegerRegex = new Regex("^" + WHITESPACE + "*" + "0[xX]([0-9a-fA-F]+)" + WHITESPACE + "*$", RegexOptions.Compiled);
        private static readonly Regex infinityIntegerRegex = new Regex("^" + WHITESPACE + "*" + "([+-]?)Infinity" + WHITESPACE + "*$", RegexOptions.Compiled);

        internal ScriptValue ToPrimitive(ScriptValue input, ScriptValue.Type preferredType = ScriptValue.Type.Undefined)
        {
            if (input.IsObject)
            {
                var exoticToPrimitive = GetMethod(input, Symbol.ToPrimitive);

                if (exoticToPrimitive != null)
                {
                    string hint;
                    if (preferredType == ScriptValue.Type.Undefined)
                    {
                        hint = "default";
                    }
                    else if (preferredType == ScriptValue.Type.String)
                    {
                        hint = "string";
                    }
                    else
                    {
                        hint = "number";
                    }

                    var result = Call(exoticToPrimitive, input, hint);
                    if (!result.IsObject)
                    {
                        return result;
                    }

                    throw CreateTypeError();
                }

                if (preferredType != ScriptValue.Type.String)
                {
                    preferredType = ScriptValue.Type.Number;
                }

                return OrdinaryToPrimitive((ScriptObject)input, preferredType);
            }
            return input;
        }

        internal ScriptValue OrdinaryToPrimitive([NotNull] ScriptObject obj, ScriptValue.Type preferredType)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarytoprimitive
            var methodNames = new string[2];

            if (preferredType == ScriptValue.Type.String)
            {
                methodNames[0] = "toString";
                methodNames[1] = "valueOf";
            }
            else
            {
                methodNames[0] = "valueOf";
                methodNames[1] = "toString";
            }

            foreach (var methodName in methodNames)
            {
                var method = obj.Get(methodName, obj);

                if (IsCallable(method))
                {
                    var result = Call((ScriptObject)method, obj);
                    if (!result.IsObject)
                    {
                        return result;
                    }
                }
            }

            throw CreateTypeError();
        }

        internal static bool ToBoolean(ScriptValue argument)
        {
            switch (argument.ValueType)
            {
                case ScriptValue.Type.Undefined:
                case ScriptValue.Type.Null:
                    return false;
                case ScriptValue.Type.Boolean:
                    return (bool)argument;
                case ScriptValue.Type.Number:
                    var doubleValue = (double)argument;
                    return !double.IsNaN(doubleValue) && doubleValue != 0;
                case ScriptValue.Type.String:
                    return ((string)argument).Length != 0;
                case ScriptValue.Type.Symbol:
                case ScriptValue.Type.Object:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal double ToNumber(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-tonumber
            switch (argument.ValueType)
            {
                case ScriptValue.Type.Undefined:
                    return double.NaN;

                case ScriptValue.Type.Null:
                    return +0;

                case ScriptValue.Type.Boolean:
                    return (bool)argument ? 1 : 0;

                case ScriptValue.Type.Number:
                    return (double)argument;

                case ScriptValue.Type.String:
                    if (double.TryParse((string)argument, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                    {
                        return result;
                    }

                    Match match;
                    if ((match = binaryIntegerRegex.Match((string)argument)).Success)
                    {
                        var digits = match.Groups[1].Value;
                        var number = 0UL;
                        foreach (var digit in digits)
                        {
                            number <<= 1;
                            number |= (byte)(digit - '0');
                        }

                        return number;
                    }

                    if ((match = octalIntegerRegex.Match((string)argument)).Success)
                    {
                        var digits = match.Groups[1].Value;
                        var number = 0UL;
                        foreach (var digit in digits)
                        {
                            number <<= 3;
                            number |= (byte)(digit - '0');
                        }

                        return number;
                    }

                    if ((match = hexIntegerRegex.Match((string)argument)).Success)
                    {
                        var digits = match.Groups[1].Value;
                        var number = 0UL;
                        foreach (var digit in digits)
                        {
                            number <<= 4;

                            if (digit >= '0' && digit <= '9')
                            {
                                number |= (byte)(digit - '0');
                            }
                            else if (digit >= 'a' && digit <= 'f')
                            {
                                number |= (byte)(10 + digit - 'a');
                            }
                            else if (digit >= 'A' && digit <= 'F')
                            {
                                number |= (byte)(10 + digit - 'A');
                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }
                        }

                        return number;
                    }

                    if ((match = infinityIntegerRegex.Match((string)argument)).Success)
                    {
                        return match.Groups[1].Value == "-" ? double.NegativeInfinity : double.PositiveInfinity;
                    }

                    if (whitespaceRegex.Match((string)argument).Success)
                    {
                        return 0;
                    }

                    return double.NaN;

                case ScriptValue.Type.Symbol:
                    throw CreateTypeError();

                case ScriptValue.Type.Object:
                    var primitiveValue = ToPrimitive(argument, ScriptValue.Type.Number);
                    return ToNumber(primitiveValue);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal double ToInteger(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-tointeger
            return ToInteger(ToNumber(argument));
        }

        internal static double ToInteger(double number)
        {
            //https://tc39.github.io/ecma262/#sec-tointeger
            if (double.IsNaN(number))
            {
                return +0;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (number == 0 || double.IsInfinity(number))
            {
                return number;
            }

            return Math.Sign(number) * Math.Floor(Math.Abs(number));
        }

        internal int ToInt32(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-toint32
            var number = ToNumber(argument);
            if (number == 0 || double.IsNaN(number) || double.IsInfinity(number))
            {
                return 0;
            }

            return Math.Sign(number) * (int)(uint)Math.Floor(Math.Abs(number));
        }

        internal uint ToUint32(ScriptValue argument)
        {
            var number = ToNumber(argument);
            if (double.IsNaN(number) || double.IsInfinity(number) || number == 0)
            {
                return 0;
            }

            return (uint)(Math.Sign(number) * Math.Floor(Math.Abs(number)));
        }

        internal short ToInt16(ScriptValue argument)
        {
            throw new NotImplementedException();
        }

        internal ushort ToUint16(ScriptValue argument)
        {
            var number = ToNumber(argument);
            if (double.IsNaN(number) || double.IsInfinity(number) || number == 0)
            {
                return 0;
            }

            return (ushort)(Math.Sign(number) * Math.Floor(Math.Abs(number)));
        }

        internal sbyte ToInt8(ScriptValue argument)
        {
            throw new NotImplementedException();
        }

        internal byte ToUint8(ScriptValue argument)
        {
            throw new NotImplementedException();
        }

        internal byte ToUint8Clamp(ScriptValue argument)
        {
            throw new NotImplementedException();
        }

        [NotNull]
        internal string ToString(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-tostring

            switch (argument.ValueType)
            {
                case ScriptValue.Type.Undefined:
                    return "undefined";
                case ScriptValue.Type.Null:
                    return "null";
                case ScriptValue.Type.Boolean:
                    return (bool)argument ? "true" : "false";
                case ScriptValue.Type.Number:
                    return NumberToString((double)argument);
                case ScriptValue.Type.String:
                    return (string)argument;
                case ScriptValue.Type.Symbol:
                    throw CreateTypeError();
                case ScriptValue.Type.Object:
                    var primitiveValue = ToPrimitive(argument, ScriptValue.Type.String);
                    return ToString(primitiveValue);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [NotNull]
        private static string NumberToString(double value)
        {
            //https://tc39.github.io/ecma262/#sec-tostring-applied-to-the-number-type
            if (double.IsNaN(value))
            {
                return "NaN";
            }

            if (double.IsPositiveInfinity(value))
            {
                return "Infinity";
            }

            if (double.IsNegativeInfinity(value))
            {
                return "-Infinity";
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (value == 0)
            {
                return "0";
            }

            var tmp = DoubleConverter.DoubleToString(value);
            return tmp;
        }

        [NotNull]
        internal ScriptObject ToObject(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-toobject
            switch (argument.ValueType)
            {
                case ScriptValue.Type.Undefined:
                case ScriptValue.Type.Null:
                    throw CreateTypeError();
                case ScriptValue.Type.Boolean:
                    return new ScriptObject(Realm, Realm.BooleanPrototype, true, SpecialObjectType.Boolean)
                    {
                        BooleanValue = (bool)argument
                    };
                case ScriptValue.Type.Number:
                    return new ScriptObject(Realm, Realm.NumberPrototype, true, SpecialObjectType.Number)
                    {
                        NumberValue = (double)argument
                    };
                case ScriptValue.Type.String:
                    return new ScriptStringObject(Realm, Realm.StringPrototype, (string)argument);
                case ScriptValue.Type.Symbol:
                    return new ScriptObject(Realm, Realm.SymbolPrototype, true, SpecialObjectType.Symbol)
                    {
                        SymbolValue = (Symbol)argument
                    };
                case ScriptValue.Type.Object:
                    return (ScriptObject)argument;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal ScriptValue ToPropertyKey(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-topropertykey
            var key = ToPrimitive(argument, ScriptValue.Type.String);
            if (key.IsSymbol)
            {
                return key;
            }

            return ToString(key);
        }

        internal long ToLength(ScriptValue argument)
        {
            //https://tc39.github.io/ecma262/#sec-tolength
            var length = ToInteger(argument);
            if (length <= 0)
            {
                return 0;
            }

            return (long)Math.Min(length, MAX_DOUBLE);
        }

        internal double? CanonicalNumericIndexString([NotNull] string argument)
        {
            //https://tc39.github.io/ecma262/#sec-canonicalnumericindexstring
            if (argument == "-0")
            {
                return -0;
            }

            var number = ToNumber(argument);
            if (!ToString(number).Equals(argument, StringComparison.InvariantCulture))
            {
                return null;
            }

            return number;
        }

        internal long ToIndex(ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-toindex
            if (value == ScriptValue.Undefined)
            {
                return 0;
            }

            var integerIndex = ToInteger(value);
            if (integerIndex < 0)
            {
                throw CreateTypeError();
            }

            var index = ToLength(integerIndex);
            if (!SameValueZero(integerIndex, index))
            {
                throw CreateRangeError();
            }

            return index;
        }
    }
}
