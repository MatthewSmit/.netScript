using System;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime.Builtins
{
    internal static class RegExpIntrinsics
    {
        public static (ScriptFunctionObject RegExp, ScriptObject RegExpPrototype) Initialise([NotNull] Agent agent, [NotNull] Realm realm)
        {
            var regExp = Intrinsics.CreateBuiltinFunction(realm, RegExp, realm.FunctionPrototype, 2, "RegExp", ConstructorKind.Base);

            var regExpPrototype = agent.ObjectCreate(realm.ObjectPrototype);
            Intrinsics.DefineDataProperty(regExpPrototype, "constructor", regExp);
            Intrinsics.DefineFunction(regExpPrototype, "exec", 1, realm, Exec);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "flags", Intrinsics.CreateBuiltinFunction(realm, GetFlags, realm.FunctionPrototype, 0, "get flags"), null);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "global", Intrinsics.CreateBuiltinFunction(realm, GetGlobal, realm.FunctionPrototype, 0, "get global"), null);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "ignoreCase", Intrinsics.CreateBuiltinFunction(realm, GetIgnoreCase, realm.FunctionPrototype, 0, "get ignoreCase"), null);
            Intrinsics.DefineDataProperty(regExpPrototype, Symbol.Match, Intrinsics.CreateBuiltinFunction(realm, Match, realm.FunctionPrototype, 1, "[Symbol.match]"));
            Intrinsics.DefineAccessorProperty(regExpPrototype, "multiline", Intrinsics.CreateBuiltinFunction(realm, GetMultiline, realm.FunctionPrototype, 0, "get multiline"), null);
            Intrinsics.DefineDataProperty(regExpPrototype, Symbol.Replace, Intrinsics.CreateBuiltinFunction(realm, Replace, realm.FunctionPrototype, 2, "[Symbol.replace]"));
            Intrinsics.DefineDataProperty(regExpPrototype, Symbol.Search, Intrinsics.CreateBuiltinFunction(realm, Search, realm.FunctionPrototype, 1, "[Symbol.search]"));
            Intrinsics.DefineAccessorProperty(regExpPrototype, "source", Intrinsics.CreateBuiltinFunction(realm, GetSource, realm.FunctionPrototype, 0, "get source"), null);
            Intrinsics.DefineDataProperty(regExpPrototype, Symbol.Split, Intrinsics.CreateBuiltinFunction(realm, Split, realm.FunctionPrototype, 2, "[Symbol.split]"));
            Intrinsics.DefineAccessorProperty(regExpPrototype, "sticky", Intrinsics.CreateBuiltinFunction(realm, GetSticky, realm.FunctionPrototype, 0, "get sticky"), null);
            Intrinsics.DefineFunction(regExpPrototype, "test", 1, realm, Test);
            Intrinsics.DefineFunction(regExpPrototype, "toString", 0, realm, ToString);
            Intrinsics.DefineAccessorProperty(regExpPrototype, "unicode", Intrinsics.CreateBuiltinFunction(realm, GetUnicode, realm.FunctionPrototype, 0, "get unicode"), null);

            Intrinsics.DefineDataProperty(regExp, "prototype", regExpPrototype, false, false, false);
            Intrinsics.DefineAccessorProperty(regExp, Symbol.Species, Intrinsics.CreateBuiltinFunction(realm, GetSpecies, realm.FunctionPrototype, 0, "get [Symbol.species]"), null);

            return (regExp, regExpPrototype);
        }

        private static ScriptValue RegExp([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-regexp-pattern-flags
            var pattern = arg[0];
            var flags = arg[1];
            var patternIsRegExp = Agent.IsRegExp(pattern);

            ScriptObject newTarget;
            if (arg.NewTarget == null)
            {
                newTarget = arg.Function;
                if (patternIsRegExp && flags == ScriptValue.Undefined)
                {
                    var patternConstructor = ((ScriptObject)pattern).Get("constructor");
                    if (newTarget == patternConstructor)
                    {
                        return pattern;
                    }
                }
            }
            else
            {
                newTarget = arg.NewTarget;
            }

            ScriptValue realPattern;
            ScriptValue realFlags;
            if (pattern.IsObject && ((ScriptObject)pattern).SpecialObjectType == SpecialObjectType.RegExp)
            {
                realPattern = ((ScriptObject)pattern).RegExp.OriginalSource;
                if (flags == ScriptValue.Undefined)
                {
                    realFlags = ((ScriptObject)pattern).RegExp.OriginalFlags;
                }
                else
                {
                    realFlags = flags;
                }
            }
            else if (patternIsRegExp)
            {
                realPattern = ((ScriptObject)pattern).Get("source");
                if (flags == ScriptValue.Undefined)
                {
                    realFlags = ((ScriptObject)pattern).Get("flags");
                }
                else
                {
                    realFlags = flags;
                }
            }
            else
            {
                realPattern = pattern;
                realFlags = flags;
            }

            var obj = RegExpAlloc(arg.Agent, newTarget);
            return RegExpInitialise(arg.Agent, obj, realPattern, realFlags);
        }

        private static ScriptValue GetSpecies([NotNull] ScriptArguments arg)
        {
            //https://tc39.github.io/ecma262/#sec-get-regexp-@@species
            return arg.ThisValue;
        }

        private static ScriptValue Exec(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetFlags(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetGlobal(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetIgnoreCase(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Match(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetMultiline(ScriptArguments arg)
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

        private static ScriptValue GetSource(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Split(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetSticky(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue Test(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue ToString(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }

        private static ScriptValue GetUnicode(ScriptArguments arg)
        {
            throw new NotImplementedException();
        }


        [NotNull]
        private static ScriptObject RegExpAlloc([NotNull] Agent agent, [NotNull] ScriptObject newTarget)
        {
            //https://tc39.github.io/ecma262/#sec-regexpalloc
            var obj = agent.OrdinaryCreateFromConstructor(newTarget, newTarget.Realm.RegExpPrototype, SpecialObjectType.RegExp);
            agent.DefinePropertyOrThrow(obj, "lastIndex", new PropertyDescriptor(ScriptValue.Undefined, true, false, false));
            return obj;
        }

        [NotNull]
        private static ScriptObject RegExpInitialise([NotNull] Agent agent, [NotNull] ScriptObject obj, ScriptValue argPattern, ScriptValue argFlags)
        {
            //https://tc39.github.io/ecma262/#sec-regexpinitialize

            var pattern = argPattern == ScriptValue.Undefined ? "" : agent.ToString(argPattern);
            var flags = argFlags == ScriptValue.Undefined ? "" : agent.ToString(argFlags);
            //TODO
            //If F contains any code unit other than "g", "i", "m", "u", or "y" or if it contains the same code unit more than once, throw a SyntaxError exception.
            //If F contains "u", let BMP be false; else let BMP be true.
            //If BMP is true, then
            //    Parse P using the grammars in 21.2.1 and interpreting each of its 16-bit elements as a Unicode BMP code point. UTF-16 decoding is not applied to the elements. The goal symbol for the parse is Pattern[~U]. Throw a SyntaxError exception if P did not conform to the grammar, if any elements of P were not matched by the parse, or if any Early Error conditions exist.
            //    Let patternCharacters be a List whose elements are the code unit elements of P.
            //Else,
            //    Parse P using the grammars in 21.2.1 and interpreting P as UTF-16 encoded Unicode code points (6.1.4). The goal symbol for the parse is Pattern[+U]. Throw a SyntaxError exception if P did not conform to the grammar, if any elements of P were not matched by the parse, or if any Early Error conditions exist.
            //    Let patternCharacters be a List whose elements are the code points resulting from applying UTF-16 decoding to P's sequence of elements.
            obj.RegExp.OriginalSource = pattern;
            obj.RegExp.OriginalFlags = flags;
            //Set obj.[[RegExpMatcher]] to the internal procedure that evaluates the above parse of P by applying the semantics provided in 21.2.2 using patternCharacters as the pattern's List of SourceCharacter values and F as the flag parameters.
            agent.Set(obj, "lastIndex", 0, true);
            return obj;
        }

        [NotNull]
        public static ScriptObject RegExpCreate([NotNull] Agent agent, ScriptValue pattern, ScriptValue flags)
        {
            //https://tc39.github.io/ecma262/#sec-regexpcreate
            var obj = RegExpAlloc(agent, agent.Realm.RegExp);
            return RegExpInitialise(agent, obj, pattern, flags);
        }
    }
}