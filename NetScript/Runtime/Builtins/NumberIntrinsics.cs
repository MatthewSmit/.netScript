using System;
using System.Globalization;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class NumberIntrinsics
    {
        public static (ScriptObject number, ScriptObject numberPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var number = Intrinsics.CreateBuiltinFunction(agent, realm, Number, functionPrototype, 1, "Number", ConstructorKind.Base);

            Intrinsics.DefineDataProperty(number, "EPSILON", 2.2204460492503130808472633361816E-16, false, false, false);
            Intrinsics.DefineDataProperty(number, "MAX_SAFE_INTEGER", 9007199254740991, false, false, false);
            Intrinsics.DefineDataProperty(number, "MAX_VALUE", double.MaxValue, false, false, false);
            Intrinsics.DefineDataProperty(number, "MIN_SAFE_INTEGER", -9007199254740991, false, false, false);
            Intrinsics.DefineDataProperty(number, "MIN_VALUE", double.Epsilon, false, false, false);
            Intrinsics.DefineDataProperty(number, "NaN", double.NaN, false, false, false);
            Intrinsics.DefineDataProperty(number, "NEGATIVE_INFINITY", double.NegativeInfinity, false, false, false);
            Intrinsics.DefineDataProperty(number, "POSITIVE_INFINITY", double.PositiveInfinity, false, false, false);

            Intrinsics.DefineFunction(number, "isFinite", 1, agent, realm, IsFinite);
            Intrinsics.DefineFunction(number, "isInteger", 1, agent, realm, IsInteger);
            Intrinsics.DefineFunction(number, "isNaN", 1, agent, realm, IsNaN);
            Intrinsics.DefineFunction(number, "isSafeInteger", 1, agent, realm, IsSafeInteger);
            Intrinsics.DefineFunction(number, "parseFloat", 1, agent, realm, ParseFloat);
            Intrinsics.DefineFunction(number, "parseInt", 2, agent, realm, ParseInt);

            var numberPrototype = agent.ObjectCreate(objectPrototype, SpecialObjectType.Number);

            Intrinsics.DefineDataProperty(numberPrototype, "constructor", number);

            Intrinsics.DefineFunction(numberPrototype, "toExponential", 1, agent, realm, ToExponential);
            Intrinsics.DefineFunction(numberPrototype, "toFixed", 1, agent, realm, ToFixed);
            Intrinsics.DefineFunction(numberPrototype, "toLocaleString", 0, agent, realm, ToLocaleString);
            Intrinsics.DefineFunction(numberPrototype, "toPrecision", 1, agent, realm, ToPrecision);
            Intrinsics.DefineFunction(numberPrototype, "toString", 1, agent, realm, ToString);
            Intrinsics.DefineFunction(numberPrototype, "valueOf", 0, agent, realm, ValueOf);

            Intrinsics.DefineDataProperty(number, "prototype", numberPrototype, false, false, false);

            return (number, numberPrototype);
        }

        private static ScriptValue Number([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-number-constructor-number-value
            var number = arg.Count == 0 ? +0 : arg.Agent.ToNumber(arg[0]);
            if (arg.NewTarget == null)
            {
                return number;
            }

            var obj = arg.Agent.OrdinaryCreateFromConstructor(arg.NewTarget, arg.Agent.Realm.NumberPrototype, SpecialObjectType.Number);
            obj.NumberValue = number;
            return obj;
        }

        private static ScriptValue IsFinite(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IsInteger(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IsNaN(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IsSafeInteger(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ParseFloat(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ParseInt(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToExponential(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToFixed([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-number.prototype.tofixed

            var value = ThisNumberValue(arg.Agent, arg.ThisValue);
            var fractionDigits = arg.Agent.ToInteger(arg[0]);
            if (fractionDigits < 0 || fractionDigits > 100)
            {
                throw arg.Agent.CreateRangeError();
            }

            var fractionDigitsInt = (int)fractionDigits;

            if (double.IsNaN(value))
            {
                return "NaN";
            }

            var sign = "";
            if (value < 0)
            {
                sign = "-";
                value = -value;
            }

            string m;
            if (value >= 10E21)
            {
                m = arg.Agent.ToString(value);
            }
            else
            {
                var n = (ulong)(Math.Pow(10, fractionDigitsInt) * value);
                m = n.ToString(CultureInfo.InvariantCulture);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (fractionDigitsInt != 0)
                {
                    var k = m.Length;
                    if (k <= fractionDigitsInt)
                    {
                        //Let z be the String value consisting of f+1-k occurrences of the code unit 0x0030 (DIGIT ZERO).
                        //Let m be the string-concatenation of z and m.
                        //Let k be f + 1.
                        throw new NotImplementedException();
                    }

                    var a = m.Substring(0, k - fractionDigitsInt);
                    var b = m.Substring(k - fractionDigitsInt);
                    m = a + "." + b;
                }
            }

            return sign + m;
        }

        private static ScriptValue ToLocaleString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToPrecision(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-number.prototype.tostring
            var value = ThisNumberValue(arg.Agent, arg.ThisValue);
            var radixNumber = arg[0] == ScriptValue.Undefined ? 10 : arg.Agent.ToInteger(arg[0]);
            if (radixNumber < 2 || radixNumber > 36)
            {
                throw arg.Agent.CreateRangeError();
            }

            var realRadixNumber = (int)radixNumber;

            if (realRadixNumber == 10)
            {
                return arg.Agent.ToString(value);
            }

            //Return the String representation of this Number value using the radix specified by radixNumber. Letters a-z are used for digits with values 10 through 35. The precise algorithm is implementation-dependent, however the algorithm should be a generalization of that specified in 7.1.12.1.
            throw new NotImplementedException();
        }

        private static ScriptValue ValueOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-number.prototype.valueof
            return ThisNumberValue(arg.Agent, arg.ThisValue);
        }


        private static double ThisNumberValue(Agent agent, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-thisnumbervalue
            if (value.IsNumber)
            {
                return (double)value;
            }

            if (value.IsObject && ((ScriptObject)value).SpecialObjectType == SpecialObjectType.Number)
            {
                return ((ScriptObject)value).NumberValue;
            }

            throw agent.CreateTypeError();
        }
    }
}