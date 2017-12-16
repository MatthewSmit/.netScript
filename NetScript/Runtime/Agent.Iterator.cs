using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public sealed partial class Agent
    {
        //https://tc39.github.io/ecma262/#sec-operations-on-iterator-objects

        internal (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) GetIterator(ScriptValue obj, [CanBeNull] ScriptFunctionObject method = null)
        {
            //https://tc39.github.io/ecma262/#sec-getiterator

            if (method == null)
            {
                method = GetMethod(obj, Symbol.Iterator);
            }

            var iterator = Call(method, obj);
            if (!iterator.IsObject)
            {
                throw CreateTypeError();
            }

            var nextMethod = GetValue(iterator, "next");
            return ((ScriptObject)iterator, (ScriptFunctionObject)(ScriptObject)nextMethod, false);
        }

        [NotNull]
        internal ScriptObject IteratorNext((ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord, ScriptValue? value = null)
        {
            //https://tc39.github.io/ecma262/#sec-iteratornext

            ScriptValue result;
            if (!value.HasValue)
            {
                result = Call(iteratorRecord.NextMethod, iteratorRecord.Iterator);
            }
            else
            {
                result = Call(iteratorRecord.NextMethod, iteratorRecord.Iterator, value.Value);
            }

            if (!result.IsObject)
            {
                throw CreateTypeError();
            }

            return (ScriptObject)result;
        }

        internal bool IteratorComplete([NotNull] ScriptObject iteratorResult)
        {
            //https://tc39.github.io/ecma262/#sec-iteratorcomplete
            return RealToBoolean(iteratorResult.Get("done", iteratorResult));
        }

        internal static ScriptValue IteratorValue([NotNull] ScriptObject iteratorResult)
        {
            return iteratorResult.Get("value", iteratorResult);
        }

        internal ScriptValue IteratorStep((ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord)
        {
            //https://tc39.github.io/ecma262/#sec-iteratorstep

            var result = IteratorNext(iteratorRecord);
            var done = IteratorComplete(result);
            if (done)
            {
                return false;
            }

            return result;
        }

        internal void IteratorClose((ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) iteratorRecord)
        {
            //https://tc39.github.io/ecma262/#sec-iteratorclose
            var returnMethod = GetMethod(iteratorRecord.Iterator, "return");
            if (returnMethod != null)
            {
                var innerResult = Call(returnMethod, iteratorRecord.Iterator);
                if (!innerResult.IsObject)
                {
                    throw CreateTypeError();
                }
            }
        }

        internal (ScriptObject Iterator, ScriptFunctionObject NextMethod, bool Done) CreateListIteratorRecord(IReadOnlyList<ScriptValue> list)
        {
            //https://tc39.github.io/ecma262/#sec-createlistiteratorRecord
            var realm = RunningExecutionContext.Realm;

            var iterator = ObjectCreate(realm.IteratorPrototype, SpecialObjectType.IteratedList);
            iterator.IteratedList = list;
            iterator.ListIteratorNextIndex = 0;
            var next = CreateBuiltinFunction(realm, ListIteratorNext, realm.FunctionPrototype);
            return (Iterator: iterator, NextMethod: next, Done: false);
        }

        private ScriptValue ListIteratorNext([NotNull] ScriptArguments arguments)
        {
            //https://tc39.github.io/ecma262/#sec-listiterator-next
            var thisValue = arguments.ThisValue;
            Debug.Assert(thisValue.IsObject);

            var obj = (ScriptObject)thisValue;
            Debug.Assert(obj.SpecialObjectType == SpecialObjectType.IteratedList);

            var list = obj.IteratedList;
            var index = obj.ListIteratorNextIndex;
            var length = list.Count;
            if (index >= length)
            {
                return CreateIterResultObject(ScriptValue.Undefined, true);
            }
            obj.ListIteratorNextIndex = index + 1;
            return CreateIterResultObject(list[(int)index], false);
        }
    }
}
