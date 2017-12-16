using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;
using NetScript.Walkers;

namespace NetScript.Runtime.Builtins
{
    internal static class MathsIntrinsics
    {
        [NotNull]
        public static ScriptObject Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var maths = agent.ObjectCreate(realm.ObjectPrototype);

            Intrinsics.DefineDataProperty(maths, "E", Math.E, false, false, false);
            Intrinsics.DefineDataProperty(maths, "LN10", Math.Log(10), false, false, false);
            Intrinsics.DefineDataProperty(maths, "LN2", Math.Log(2), false, false, false);
            Intrinsics.DefineDataProperty(maths, "LOG10E", Math.Log10(Math.E), false, false, false);
            Intrinsics.DefineDataProperty(maths, "LOG2E", Math.Log10(Math.E) / Math.Log10(2), false, false, false);
            Intrinsics.DefineDataProperty(maths, "PI", Math.PI, false, false, false);
            Intrinsics.DefineDataProperty(maths, "SQRT1_2", Math.Sqrt(0.5), false, false, false);
            Intrinsics.DefineDataProperty(maths, "SQRT2", Math.Sqrt(2), false, false, false);
            Intrinsics.DefineDataProperty(maths, Symbol.ToStringTag, "Math", false);

            Intrinsics.DefineFunction(maths, "abs", 1, realm, Abs);
            Intrinsics.DefineFunction(maths, "acos", 1, realm, Acos);
            Intrinsics.DefineFunction(maths, "acosh", 1, realm, Acosh);
            Intrinsics.DefineFunction(maths, "asin", 1, realm, Asin);
            Intrinsics.DefineFunction(maths, "asinh", 1, realm, Asinh);
            Intrinsics.DefineFunction(maths, "atan", 1, realm, Atan);
            Intrinsics.DefineFunction(maths, "atanh", 1, realm, Atanh);
            Intrinsics.DefineFunction(maths, "atan2", 2, realm, Atan2);
            Intrinsics.DefineFunction(maths, "cbrt", 1, realm, Cbrt);
            Intrinsics.DefineFunction(maths, "ceil", 1, realm, Ceiling);
            Intrinsics.DefineFunction(maths, "clz32", 1, realm, Clz32);
            Intrinsics.DefineFunction(maths, "cos", 1, realm, Cos);
            Intrinsics.DefineFunction(maths, "cosh", 1, realm, Cosh);
            Intrinsics.DefineFunction(maths, "exp", 1, realm, Exp);
            Intrinsics.DefineFunction(maths, "expm1", 1, realm, Expm1);
            Intrinsics.DefineFunction(maths, "floor", 1, realm, Floor);
            Intrinsics.DefineFunction(maths, "fround", 1, realm, Fround);
            Intrinsics.DefineFunction(maths, "hypot", 1, realm, Hypot);
            Intrinsics.DefineFunction(maths, "imul", 2, realm, Imul);
            Intrinsics.DefineFunction(maths, "log", 1, realm, Log);
            Intrinsics.DefineFunction(maths, "log1p", 1, realm, Log1P);
            Intrinsics.DefineFunction(maths, "log2", 1, realm, Log2);
            Intrinsics.DefineFunction(maths, "max", 1, realm, Max);
            Intrinsics.DefineFunction(maths, "min", 1, realm, Min);
            Intrinsics.DefineFunction(maths, "pow", 2, realm, Pow);
            Intrinsics.DefineFunction(maths, "random", 0, realm, Random);
            Intrinsics.DefineFunction(maths, "round", 1, realm, Round);
            Intrinsics.DefineFunction(maths, "sign", 1, realm, Sign);
            Intrinsics.DefineFunction(maths, "sin", 1, realm, Sin);
            Intrinsics.DefineFunction(maths, "sinh", 1, realm, Sinh);
            Intrinsics.DefineFunction(maths, "sqrt", 1, realm, Sqrt);
            Intrinsics.DefineFunction(maths, "tan", 1, realm, Tan);
            Intrinsics.DefineFunction(maths, "tanh", 1, realm, Tanh);
            Intrinsics.DefineFunction(maths, "trunc", 1, realm, Trunc);

            return maths;
        }

        private static ScriptValue Abs([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.abs
            return Math.Abs(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Acos([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.acos
            return Math.Acos(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Acosh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Asin([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.asin
            return Math.Asin(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Asinh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Atan([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.atan
            return Math.Atan(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Atanh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Atan2([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.atan2
            return Math.Atan2(arg.Agent.ToNumber(arg[0]), arg.Agent.ToNumber(arg[1]));
        }

        private static ScriptValue Cbrt(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Ceiling([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.ceil
            return Math.Ceiling(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Clz32([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.clz
            var number = arg.Agent.ToUint32(arg[0]);

            if (number == 0)
            {
                return 32;
            }

            var n = 1u;
            if (number >> 16 == 0)
            {
                n += 16;
                number <<= 16;
            }

            if (number >> 24 == 0)
            {
                n += 8;
                number <<= 8;
            }

            if (number >> 28 == 0)
            {
                n += 4;
                number <<= 4;
            }

            if (number >> 30 == 0)
            {
                n += 2;
                number <<= 2;
            }

            n -= number >> 31;
            return n;
        }

        private static ScriptValue Cos([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.cos
            return Math.Cos(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Cosh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Exp(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Expm1(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Floor([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.floor
            return Math.Floor(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Fround(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Hypot(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Imul(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Log([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.log
            return Math.Log(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Log1P(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Log2(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Max(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Min(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Pow([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-math.pow
            return EvaluateWalker.Exponentiation(arg[0], arg[1], arg.Agent);
        }

        private static ScriptValue Random([NotNull] ScriptArguments arg)
        {
            return arg.Function.Realm.Random.NextDouble();
        }

        private static ScriptValue Round(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Sign(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Sin([NotNull] ScriptArguments arg)
        {
            return Math.Sin(arg.Agent.ToNumber(arg[0]));
        }

        private static ScriptValue Sinh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Sqrt(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Tan(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Tanh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Trunc(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }
    }
}