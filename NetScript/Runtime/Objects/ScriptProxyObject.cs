using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using NetScript.Runtime.Builtins;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptProxyObject : ScriptObject
    {
        internal ScriptProxyObject([NotNull] Realm realm, [NotNull] ScriptObject target, [NotNull] ScriptObject handler) :
            base(realm, null, false, SpecialObjectType.None)
        {
            ProxyTarget = target;
            ProxyHandler = handler;
        }

        internal override ScriptObject GetPrototypeOf()
        {
            throw new NotImplementedException();
        }

        internal override bool SetPrototypeOf(ScriptObject prototype)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-setprototypeof-v
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }

            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            //Let target be O.[[ProxyTarget]].
            var trap = Agent.GetMethod(ProxyHandler, "setPrototypeOf");
            if (trap == null)
            {
                return ProxyTarget.SetPrototypeOf(prototype);
            }

            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget, prototype));
            if (!booleanTrapResult)
            {
                return false;
            }

            var extensibleTarget = ProxyTarget.IsExtensible;
            if (extensibleTarget)
            {
                return true;
            }

            var targetPrototype = ProxyTarget.GetPrototypeOf();
            if (prototype != targetPrototype)
            {
                throw Agent.CreateTypeError();
            }

            return true;
        }

        internal override bool PreventExtensions()
        {
            throw new NotImplementedException();
        }

        internal override PropertyDescriptor GetOwnProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-getownproperty-p
            Debug.Assert(Agent.IsPropertyKey(property));

            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "getOwnPropertyDescriptor");
            if (trap == null)
            {
                return ProxyTarget.GetOwnProperty(property);
            }

            var trapResultObj = Agent.Call(trap, ProxyHandler, ProxyTarget, property);
            if (!trapResultObj.IsObject && trapResultObj != ScriptValue.Undefined)
            {
                throw Agent.CreateTypeError();
            }

            var targetDescriptor = ProxyTarget.GetOwnProperty(property);
            if (trapResultObj == ScriptValue.Undefined)
            {
                if (targetDescriptor == null)
                {
                    return null;
                }

                //If targetDesc.[[Configurable]] is false, throw a TypeError exception.
                //Let extensibleTarget be ? IsExtensible(target).
                //Assert: Type(extensibleTarget) is Boolean.
                //If extensibleTarget is false, throw a TypeError exception.
                //Return undefined.
                throw new NotImplementedException();
            }

            var extensibleTarget = ProxyTarget.IsExtensible;
            var resultDescriptor = ObjectIntrinsics.ToPropertyDescriptor(Agent, trapResultObj);
            resultDescriptor.CompletePropertyDescriptor();
            var valid = ValidateAndApplyPropertyDescriptor(null, ScriptValue.Undefined, extensibleTarget, resultDescriptor, targetDescriptor);
            if (!valid)
            {
                throw Agent.CreateTypeError();
            }

            if (!resultDescriptor.Configurable)
            {
                if (targetDescriptor == null || targetDescriptor.Configurable)
                {
                    throw Agent.CreateTypeError();
                }
            }

            return resultDescriptor;
        }

        internal override bool DefineOwnProperty(ScriptValue property, PropertyDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public override bool HasProperty(ScriptValue property)
        {
            throw new NotImplementedException();
        }

        internal override ScriptValue Get(ScriptValue property, ScriptValue receiver)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-get-p-receiver
            Debug.Assert(Agent.IsPropertyKey(property));
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            //Let target be O.[[ProxyTarget]].
            var trap = Agent.GetMethod(ProxyHandler, "get");
            if (trap == null)
            {
                return ProxyTarget.Get(property, receiver);
            }

            var trapResult = Agent.Call(trap, ProxyHandler, ProxyTarget, property, receiver);
            var targetDescriptor = ProxyTarget.GetOwnProperty(property);
            if (targetDescriptor != null && !targetDescriptor.Configurable)
            {
                if (targetDescriptor.IsDataDescriptor && !targetDescriptor.Writable)
                {
                    Debug.Assert(targetDescriptor.Value != null, "targetDescriptor.Value != null");
                    if (!trapResult.SameValue(targetDescriptor.Value.Value))
                    {
                        throw Agent.CreateTypeError();
                    }
                }

                if (targetDescriptor.IsAccessorDescriptor && targetDescriptor.Get == null)
                {
                    if (trapResult != ScriptValue.Undefined)
                    {
                        throw Agent.CreateTypeError();
                    }
                }
            }

            return trapResult;
        }

        internal override bool Set(ScriptValue property, ScriptValue value, ScriptValue receiver)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-set-p-v-receiver
            Debug.Assert(Agent.IsPropertyKey(property));
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }

            var trap = Agent.GetMethod(ProxyHandler, "set");
            if (trap == null)
            {
                Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");
                return ProxyTarget.Set(property, value, receiver);
            }

            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget, property, value, receiver));
            if (!booleanTrapResult)
            {
                return false;
            }

            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");
            var targetDescriptor = ProxyTarget.GetOwnProperty(property);
            if (targetDescriptor != null && !targetDescriptor.Configurable)
            {
                if (targetDescriptor.IsDataDescriptor && !targetDescriptor.Writable)
                {
                    Debug.Assert(targetDescriptor.Value != null, "targetDescriptor.Value != null");
                    if (!value.SameValue(targetDescriptor.Value.Value))
                    {
                        throw Agent.CreateTypeError();
                    }
                }
                else if (targetDescriptor.IsAccessorDescriptor)
                {
                    if (targetDescriptor.Set == null)
                    {
                        throw Agent.CreateTypeError();
                    }
                }
            }

            return true;
        }

        internal override bool Delete(ScriptValue property)
        {
            throw new NotImplementedException();
        }

        internal override IEnumerable<ScriptValue> OwnPropertyKeys()
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-ownpropertykeys
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "ownKeys");
            if (trap == null)
            {
                return ProxyTarget.OwnPropertyKeys();
            }

            var trapResultArray = Agent.Call(trap, ProxyHandler, ProxyTarget);
            var trapResult = Agent.CreateListFromArrayLike(trapResultArray, new[]
            {
                ScriptValue.Type.String,
                ScriptValue.Type.Symbol
            });

            if (new HashSet<ScriptValue>(trapResult).Count != trapResult.Count)
            {
                throw Agent.CreateTypeError();
            }

            var extensibleTarget = ProxyTarget.IsExtensible;
            var targetKeys = ProxyTarget.OwnPropertyKeys().ToArray();
            Debug.Assert(targetKeys.All(x => x.IsString || x.IsSymbol));
            Debug.Assert(new HashSet<ScriptValue>(targetKeys).Count == targetKeys.Length);

            var targetConfigurableKeys = new List<ScriptValue>();
            var targetNonconfigurableKeys = new List<ScriptValue>();
            foreach (var key in targetKeys)
            {
                var descriptor = ProxyTarget.GetOwnProperty(key);
                if (descriptor != null && !descriptor.Configurable)
                {
                    targetNonconfigurableKeys.Add(key);
                }
                else
                {
                    targetConfigurableKeys.Add(key);
                }
            }

            if (extensibleTarget && targetNonconfigurableKeys.Count == 0)
            {
                return trapResult;
            }

            //Let uncheckedResultKeys be a new List which is a copy of trapResult.
            //For each key that is an element of targetNonconfigurableKeys, do
            //    If key is not an element of uncheckedResultKeys, throw a TypeError exception.
            //    Remove key from uncheckedResultKeys.
            //If extensibleTarget is true, return trapResult.
            //For each key that is an element of targetConfigurableKeys, do
            //    If key is not an element of uncheckedResultKeys, throw a TypeError exception.
            //    Remove key from uncheckedResultKeys.
            //If uncheckedResultKeys is not empty, throw a TypeError exception.
            //Return trapResult.
            throw new NotImplementedException();
        }

        internal override ScriptValue Call(ScriptValue thisValue, IReadOnlyList<ScriptValue> arguments)
        {
            throw new NotImplementedException();
        }

        internal override ScriptValue Construct(IReadOnlyList<ScriptValue> arguments, ScriptObject newTarget)
        {
            throw new NotImplementedException();
        }

        [CanBeNull]
        public ScriptObject ProxyTarget { get; set; }
        [CanBeNull]
        public ScriptObject ProxyHandler { get; set; }

        public override bool IsExtensible
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsCallable
        {
            get
            {
                Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");
                return ProxyTarget.IsCallable;
            }
        }

        public override bool IsConstructable
        {
            get
            {
                Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");
                return ProxyTarget.IsConstructable;
            }
        }
    }
}
