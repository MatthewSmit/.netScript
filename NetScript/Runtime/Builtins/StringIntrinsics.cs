using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class StringIntrinsics
    {
        public static (ScriptObject stringConstructor, ScriptObject stringIteratorPrototype, ScriptObject stringPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm, [NotNull] ScriptObject objectPrototype, [NotNull] ScriptObject functionPrototype)
        {
            var stringConstructor = Intrinsics.CreateBuiltinFunction(agent, realm, String, functionPrototype, 1, "String", ConstructorKind.Base);
            Intrinsics.DefineFunction(stringConstructor, "fromCharCode", 1, agent, realm, FromCharCode);
            Intrinsics.DefineFunction(stringConstructor, "fromCodePoint", 1, agent, realm, FromCodePoint);
            Intrinsics.DefineFunction(stringConstructor, "raw", 1, agent, realm, Raw);

            var stringPrototype = new ScriptStringObject(agent, objectPrototype, "");
            Intrinsics.DefineFunction(stringPrototype, "charAt", 1, agent, realm, CharAt);
            Intrinsics.DefineFunction(stringPrototype, "charCodeAt", 1, agent, realm, CharCodeAt);
            Intrinsics.DefineFunction(stringPrototype, "codePointAt", 1, agent, realm, CodePointAt);
            Intrinsics.DefineFunction(stringPrototype, "concat", 1, agent, realm, Concat);
            Intrinsics.DefineDataProperty(stringPrototype, "constructor", stringConstructor);
            Intrinsics.DefineFunction(stringPrototype, "endsWith", 1, agent, realm, EndsWith);
            Intrinsics.DefineFunction(stringPrototype, "includes", 1, agent, realm, Includes);
            Intrinsics.DefineFunction(stringPrototype, "indexOf", 1, agent, realm, IndexOf);
            Intrinsics.DefineFunction(stringPrototype, "lastIndexOf", 1, agent, realm, LastIndexOf);
            Intrinsics.DefineFunction(stringPrototype, "localeCompare", 1, agent, realm, LocaleCompare);
            Intrinsics.DefineFunction(stringPrototype, "match", 1, agent, realm, Match);
            Intrinsics.DefineFunction(stringPrototype, "normalize", 0, agent, realm, Normalise);
            Intrinsics.DefineFunction(stringPrototype, "padEnd", 1, agent, realm, PadEnd);
            Intrinsics.DefineFunction(stringPrototype, "padStart", 1, agent, realm, PadStart);
            Intrinsics.DefineFunction(stringPrototype, "repeat", 1, agent, realm, Repeat);
            Intrinsics.DefineFunction(stringPrototype, "replace", 2, agent, realm, Replace);
            Intrinsics.DefineFunction(stringPrototype, "search", 1, agent, realm, Search);
            Intrinsics.DefineFunction(stringPrototype, "slice", 2, agent, realm, Slice);
            Intrinsics.DefineFunction(stringPrototype, "split", 2, agent, realm, Split);
            Intrinsics.DefineFunction(stringPrototype, "startsWith", 1, agent, realm, StartsWith);
            Intrinsics.DefineFunction(stringPrototype, "substring", 2, agent, realm, Substring);
            Intrinsics.DefineFunction(stringPrototype, "toLocaleLowerCase", 0, agent, realm, ToLocaleLowerCase);
            Intrinsics.DefineFunction(stringPrototype, "toLocaleUpperCase", 0, agent, realm, ToLocaleUpperCase);
            Intrinsics.DefineFunction(stringPrototype, "toLowerCase", 0, agent, realm, ToLowerCase);
            Intrinsics.DefineFunction(stringPrototype, "toString", 0, agent, realm, ToString);
            Intrinsics.DefineFunction(stringPrototype, "toUpperCase", 0, agent, realm, ToUpperCase);
            Intrinsics.DefineFunction(stringPrototype, "trim", 0, agent, realm, Trim);
            Intrinsics.DefineFunction(stringPrototype, "valueOf", 0, agent, realm, ValueOf);
            Intrinsics.DefineDataProperty(stringPrototype, realm.SymbolIterator, Intrinsics.CreateBuiltinFunction(agent, realm, Iterator, functionPrototype, 0, "[Symbol.iterator]"));

            var stringIteratorPrototype = agent.ObjectCreate(realm.IteratorPrototype);
            Intrinsics.DefineFunction(stringIteratorPrototype, "next", 0, agent, realm, Next);
            Intrinsics.DefineDataProperty(stringIteratorPrototype, realm.SymbolToStringTag, "String Iterator", false);

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
                    return SymbolIntrinsics.SymbolDescriptiveString(value);
                }

                str = arg.Agent.ToString(value);
            }

            if (arg.NewTarget == null)
            {
                return str;
            }

            return new ScriptStringObject(arg.Agent, Agent.GetPrototypeFromConstructor(arg.NewTarget, arg.Agent.Realm.StringPrototype), str);
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

        private static ScriptValue IndexOf(ScriptArguments arg)
        {
            throw new NotImplementedException();
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

        private static ScriptValue Split(ScriptArguments arg)
        {
            throw new NotImplementedException();
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
    }
}