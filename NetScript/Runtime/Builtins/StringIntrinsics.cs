using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class StringIntrinsics
    {
        public static (ScriptFunctionObject stringConstructor, ScriptObject stringIteratorPrototype, ScriptObject stringPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var stringConstructor = Intrinsics.CreateBuiltinFunction(realm, String, functionPrototype, 1, "String", ConstructorKind.Base);
            Intrinsics.DefineFunction(stringConstructor, "fromCharCode", 1, realm, FromCharCode);
            Intrinsics.DefineFunction(stringConstructor, "fromCodePoint", 1, realm, FromCodePoint);
            Intrinsics.DefineFunction(stringConstructor, "raw", 1, realm, Raw);

            var stringPrototype = new ScriptStringObject(realm, objectPrototype, "");
            Intrinsics.DefineFunction(stringPrototype, "charAt", 1, realm, CharAt);
            Intrinsics.DefineFunction(stringPrototype, "charCodeAt", 1, realm, CharCodeAt);
            Intrinsics.DefineFunction(stringPrototype, "codePointAt", 1, realm, CodePointAt);
            Intrinsics.DefineFunction(stringPrototype, "concat", 1, realm, Concat);
            Intrinsics.DefineDataProperty(stringPrototype, "constructor", stringConstructor);
            Intrinsics.DefineFunction(stringPrototype, "endsWith", 1, realm, EndsWith);
            Intrinsics.DefineFunction(stringPrototype, "includes", 1, realm, Includes);
            Intrinsics.DefineFunction(stringPrototype, "indexOf", 1, realm, IndexOf);
            Intrinsics.DefineFunction(stringPrototype, "lastIndexOf", 1, realm, LastIndexOf);
            Intrinsics.DefineFunction(stringPrototype, "localeCompare", 1, realm, LocaleCompare);
            Intrinsics.DefineFunction(stringPrototype, "match", 1, realm, Match);
            Intrinsics.DefineFunction(stringPrototype, "normalize", 0, realm, Normalise);
            Intrinsics.DefineFunction(stringPrototype, "padEnd", 1, realm, PadEnd);
            Intrinsics.DefineFunction(stringPrototype, "padStart", 1, realm, PadStart);
            Intrinsics.DefineFunction(stringPrototype, "repeat", 1, realm, Repeat);
            Intrinsics.DefineFunction(stringPrototype, "replace", 2, realm, Replace);
            Intrinsics.DefineFunction(stringPrototype, "search", 1, realm, Search);
            Intrinsics.DefineFunction(stringPrototype, "slice", 2, realm, Slice);
            Intrinsics.DefineFunction(stringPrototype, "split", 2, realm, Split);
            Intrinsics.DefineFunction(stringPrototype, "startsWith", 1, realm, StartsWith);
            Intrinsics.DefineFunction(stringPrototype, "substring", 2, realm, Substring);
            Intrinsics.DefineFunction(stringPrototype, "toLocaleLowerCase", 0, realm, ToLocaleLowerCase);
            Intrinsics.DefineFunction(stringPrototype, "toLocaleUpperCase", 0, realm, ToLocaleUpperCase);
            Intrinsics.DefineFunction(stringPrototype, "toLowerCase", 0, realm, ToLowerCase);
            Intrinsics.DefineFunction(stringPrototype, "toString", 0, realm, ToString);
            Intrinsics.DefineFunction(stringPrototype, "toUpperCase", 0, realm, ToUpperCase);
            Intrinsics.DefineFunction(stringPrototype, "trim", 0, realm, Trim);
            Intrinsics.DefineFunction(stringPrototype, "valueOf", 0, realm, ValueOf);
            Intrinsics.DefineDataProperty(stringPrototype, Symbol.Iterator, Intrinsics.CreateBuiltinFunction(realm, Iterator, functionPrototype, 0, "[Symbol.iterator]"));

            var stringIteratorPrototype = agent.ObjectCreate(realm.IteratorPrototype);
            Intrinsics.DefineFunction(stringIteratorPrototype, "next", 0, realm, Next);
            Intrinsics.DefineDataProperty(stringIteratorPrototype, Symbol.ToStringTag, "String Iterator", false);

            Intrinsics.DefineDataProperty(stringConstructor, "prototype", stringPrototype);

            return (stringConstructor, stringIteratorPrototype, stringPrototype);
        }

        private static ScriptValue String([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-string-constructor-string-value
            var str = "";
            if (arg.Count > 0)
            {
                var value = arg[0];
                if (arg.NewTarget == null && value.IsSymbol)
                {
                    return SymbolIntrinsics.SymbolDescriptiveString((Symbol)value);
                }

                str = arg.Agent.ToString(value);
            }

            if (arg.NewTarget == null)
            {
                return str;
            }

            return new ScriptStringObject(arg.NewTarget.Realm, Agent.GetPrototypeFromConstructor(arg.NewTarget, arg.NewTarget.Realm.StringPrototype), str);
        }

        private static ScriptValue FromCharCode(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue FromCodePoint(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Raw(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue CharAt([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-string.prototype.charat
            var obj = arg.Agent.RequireObjectCoercible(arg.ThisValue);
            var str = arg.Agent.ToString(obj);
            var position = arg.Agent.ToInteger(arg[0]);
            var size = str.Length;
            if (position < 0 || position >= size)
            {
                return "";
            }

            return str[(int)position].ToString();
        }

        private static ScriptValue CharCodeAt([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-string.prototype.charcodeat
            var obj = arg.Agent.RequireObjectCoercible(arg.ThisValue);
            var str = arg.Agent.ToString(obj);
            var position = arg.Agent.ToInteger(arg[0]);
            var size = str.Length;
            if (position < 0 || position >= size)
            {
                return double.NaN;
            }

            return str[(int)position];
        }

        private static ScriptValue CodePointAt(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Concat(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue EndsWith(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Includes(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue IndexOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-string.prototype.indexof
            var obj = arg.Agent.RequireObjectCoercible(arg.ThisValue);
            var str = arg.Agent.ToString(obj);
            var searchString = arg.Agent.ToString(arg[0]);
            var position = arg.Agent.ToInteger(arg[1]);
            var start = Math.Min(Math.Max((int)position, 0), str.Length);
            return str.IndexOf(searchString, start, StringComparison.Ordinal);
        }

        private static ScriptValue LastIndexOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue LocaleCompare(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Match(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Normalise(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue PadEnd(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue PadStart(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Repeat(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Replace(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Search(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Slice(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Split([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-string.prototype.split
            var obj = arg.Agent.RequireObjectCoercible(arg.ThisValue);
            if (arg[0] != ScriptValue.Undefined && arg[0] != ScriptValue.Null)
            {
                var splitter = arg.Agent.GetMethod(arg[0], Symbol.Split);
                if (splitter != null)
                {
                    return arg.Agent.Call(splitter, arg[0], obj, arg[1]);
                }
            }

            var str = arg.Agent.ToString(obj);
            var array = ArrayIntrinsics.ArrayCreate(arg.Agent, 0);
            var arrayLength = 0u;
            var limit = arg[1] == ScriptValue.Undefined ? uint.MaxValue : arg.Agent.ToUint32(arg[1]);
            var seperator = arg.Agent.ToString(arg[0]);

            if (limit == 0)
            {
                return array;
            }

            if (arg[0] == ScriptValue.Undefined)
            {
                array.CreateDataProperty("0", str);
                return array;
            }

            if (str.Length == 0)
            {
                var z = SplitMatch(str, 0, seperator);
                if (z.Item1)
                {
                    return array;
                }

                array.CreateDataProperty("0", str);
                return array;
            }

            var p = 0;
            var q = p;
            string substring;
            while (q != str.Length)
            {
                var e = SplitMatch(str, q, seperator);
                if (!e.Item1)
                {
                    q++;
                }
                else
                {
                    if (e.Item2 == p)
                    {
                        q = q + 1;
                    }
                    else
                    {
                        substring = str.Substring(p, q - p);
                        array.CreateDataProperty(arrayLength.ToString(), substring);
                        arrayLength++;
                        if (arrayLength == limit)
                        {
                            return array;
                        }
                        q = p = e.Item2;
                    }
                }
            }

            substring = str.Substring(p);
            array.CreateDataProperty(arrayLength.ToString(), substring);
            return array;
        }

        private static ScriptValue StartsWith(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Substring(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLocaleLowerCase(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLocaleUpperCase(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToLowerCase(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToString([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-string.prototype.tostring
            return ThisStringValue(arg.Agent, arg.ThisValue);
        }

        private static ScriptValue ToUpperCase(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Trim(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ValueOf([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-string.prototype.valueof
            return ThisStringValue(arg.Agent, arg.ThisValue);
        }

        private static ScriptValue Iterator(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Next(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }


        private static ScriptValue ThisStringValue(Agent agent, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-thisstringvalue
            if (value.IsString)
            {
                return value;
            }

            if (value.IsObject && (ScriptObject)value is ScriptStringObject stringObject)
            {
                return stringObject.StringData;
            }

            throw agent.CreateTypeError();
        }

        private static (bool, int) SplitMatch([NotNull] string str, int q, [NotNull] string seperator)
        {
            //https://tc39.github.io/ecma262/#sec-splitmatch
            if (q + seperator.Length > str.Length)
            {
                return (false, 0);
            }

            for (var i = 0; i < seperator.Length; i++)
            {
                if (str[q + i] != seperator[i])
                {
                    return (false, 0);
                }
            }

            return (true, q + seperator.Length);
        }
    }
}