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
            Intrinsics.DefineDataProperty(maths, realm.SymbolToStringTag, "Math", false);

            Intrinsics.DefineFunction(maths, "abs", 1, agent, realm, Abs);
            Intrinsics.DefineFunction(maths, "acos", 1, agent, realm, Acos);
            Intrinsics.DefineFunction(maths, "acosh", 1, agent, realm, Acosh);
            Intrinsics.DefineFunction(maths, "asin", 1, agent, realm, Asin);
            Intrinsics.DefineFunction(maths, "asinh", 1, agent, realm, Asinh);
            Intrinsics.DefineFunction(maths, "atan", 1, agent, realm, Atan);
            Intrinsics.DefineFunction(maths, "atanh", 1, agent, realm, Atanh);
            Intrinsics.DefineFunction(maths, "atan2", 2, agent, realm, Atan2);
            Intrinsics.DefineFunction(maths, "cbrt", 1, agent, realm, Cbrt);
            Intrinsics.DefineFunction(maths, "ceil", 1, agent, realm, Ceiling);
            Intrinsics.DefineFunction(maths, "clz32", 1, agent, realm, Clz32);
            Intrinsics.DefineFunction(maths, "cos", 1, agent, realm, Cos);
            Intrinsics.DefineFunction(maths, "cosh", 1, agent, realm, Cosh);
            Intrinsics.DefineFunction(maths, "exp", 1, agent, realm, Exp);
            Intrinsics.DefineFunction(maths, "expm1", 1, agent, realm, Expm1);
            Intrinsics.DefineFunction(maths, "floor", 1, agent, realm, Floor);
            Intrinsics.DefineFunction(maths, "fround", 1, agent, realm, Fround);
            Intrinsics.DefineFunction(maths, "hypot", 1, agent, realm, Hypot);
            Intrinsics.DefineFunction(maths, "imul", 2, agent, realm, Imul);
            Intrinsics.DefineFunction(maths, "log", 1, agent, realm, Log);
            Intrinsics.DefineFunction(maths, "log1p", 1, agent, realm, Log1P);
            Intrinsics.DefineFunction(maths, "log2", 1, agent, realm, Log2);
            Intrinsics.DefineFunction(maths, "max", 1, agent, realm, Max);
            Intrinsics.DefineFunction(maths, "min", 1, agent, realm, Min);
            Intrinsics.DefineFunction(maths, "pow", 2, agent, realm, Pow);
            Intrinsics.DefineFunction(maths, "random", 0, agent, realm, Random);
            Intrinsics.DefineFunction(maths, "round", 1, agent, realm, Round);
            Intrinsics.DefineFunction(maths, "sign", 1, agent, realm, Sign);
            Intrinsics.DefineFunction(maths, "sin", 1, agent, realm, Sin);
            Intrinsics.DefineFunction(maths, "sinh", 1, agent, realm, Sinh);
            Intrinsics.DefineFunction(maths, "sqrt", 1, agent, realm, Sqrt);
            Intrinsics.DefineFunction(maths, "tan", 1, agent, realm, Tan);
            Intrinsics.DefineFunction(maths, "tanh", 1, agent, realm, Tanh);
            Intrinsics.DefineFunction(maths, "trunc", 1, agent, realm, Trunc);

            return maths;
        }

        private static ScriptValue Abs(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Acos(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Acosh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Asin(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Asinh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Atan(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Atanh(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Atan2(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Clz32(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Cos(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Log(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Random(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Round(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Sign(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Sin(ScriptArguments arg)
        {
            throw new NotImplementedException();
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