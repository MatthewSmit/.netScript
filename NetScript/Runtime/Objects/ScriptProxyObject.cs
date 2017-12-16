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
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-getprototypeof
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "getPrototypeOf");
            if (trap == null)
            {
                return ProxyTarget.GetPrototypeOf();
            }

            var handlerPrototype = Agent.Call(trap, ProxyHandler, ProxyTarget);
            if (handlerPrototype != ScriptValue.Null && !handlerPrototype.IsObject)
            {
                throw Agent.CreateTypeError();
            }

            var extensibleTarget = ProxyTarget.IsExtensible;
            if (extensibleTarget)
            {
                return handlerPrototype == ScriptValue.Null ? null : (ScriptObject)handlerPrototype;
            }

            var targetPrototype = ProxyTarget.GetPrototypeOf();
            if (!handlerPrototype.SameValue(targetPrototype))
            {
                throw Agent.CreateTypeError();
            }
            return handlerPrototype == ScriptValue.Null ? null : (ScriptObject)handlerPrototype;
        }

        internal override bool SetPrototypeOf(ScriptObject prototype)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-setprototypeof-v
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

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
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-preventextensions
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "preventExtensions");
            if (trap == null)
            {
                return ProxyTarget.PreventExtensions();
            }

            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget));
            if (booleanTrapResult)
            {
                var targetIsExtensible = ProxyTarget.IsExtensible;
                if (targetIsExtensible)
                {
                    throw Agent.CreateTypeError();
                }
            }

            return booleanTrapResult;
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
            bool extensibleTarget;
            if (trapResultObj == ScriptValue.Undefined)
            {
                if (targetDescriptor == null)
                {
                    return null;
                }

                if (!targetDescriptor.Configurable)
                {
                    throw Agent.CreateTypeError();
                }

                extensibleTarget = ProxyTarget.IsExtensible;
                if (!extensibleTarget)
                {
                    throw Agent.CreateTypeError();
                }

                return null;
            }

            extensibleTarget = ProxyTarget.IsExtensible;
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
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-defineownproperty-p-desc
            Debug.Assert(Agent.IsPropertyKey(property));
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "defineProperty");
            if (trap == null)
            {
                return ProxyTarget.DefineOwnProperty(property, descriptor);
            }

            var descriptorObject = ObjectIntrinsics.FromPropertyDescriptor(Agent, descriptor);
            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget, property, descriptorObject));
            if (!booleanTrapResult)
            {
                return false;
            }

            var targetDescriptor = ProxyTarget.GetOwnProperty(property);
            var extensibleTarget = ProxyTarget.IsExtensible;

            var settingConfigFalse = descriptor.Configurable.HasValue && !descriptor.Configurable;

            if (targetDescriptor == null)
            {
                if (!extensibleTarget)
                {
                    throw Agent.CreateTypeError();
                }

                if (settingConfigFalse)
                {
                    throw Agent.CreateTypeError();
                }
            }
            else
            {
                if (!ValidateAndApplyPropertyDescriptor(null, ScriptValue.Undefined, extensibleTarget, descriptor, targetDescriptor))
                {
                    throw Agent.CreateTypeError();
                }
                if (settingConfigFalse && targetDescriptor.Configurable)
                {
                    throw Agent.CreateTypeError();
                }
            }

            return true;
        }

        public override bool HasProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-hasproperty-p
            Debug.Assert(Agent.IsPropertyKey(property));
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "has");
            if (trap == null)
            {
                return ProxyTarget.HasProperty(property);
            }

            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget, property));
            if (!booleanTrapResult)
            {
                var targetDescriptor = ProxyTarget.GetOwnProperty(property);
                if (targetDescriptor != null)
                {
                    if (!targetDescriptor.Configurable)
                    {
                        throw Agent.CreateTypeError();
                    }

                    var extensibleTarget = ProxyTarget.IsExtensible;
                    if (!extensibleTarget)
                    {
                        throw Agent.CreateTypeError();
                    }
                }
            }

            return booleanTrapResult;
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
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "set");
            if (trap == null)
            {
                return ProxyTarget.Set(property, value, receiver);
            }

            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget, property, value, receiver));
            if (!booleanTrapResult)
            {
                return false;
            }

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
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-delete-p
            Debug.Assert(Agent.IsPropertyKey(property));
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "deleteProperty");
            if (trap == null)
            {
                return ProxyTarget.Delete(property);
            }

            var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget, property));
            if (!booleanTrapResult)
            {
                return false;
            }

            var targetDescriptor = ProxyTarget.GetOwnProperty(property);
            if (targetDescriptor == null)
            {
                return true;
            }

            if (!targetDescriptor.Configurable)
            {
                throw Agent.CreateTypeError();
            }

            return true;
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

        internal override ScriptValue Call(ScriptValue thisArgument, [NotNull] IReadOnlyList<ScriptValue> arguments)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-call-thisargument-argumentslist
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "apply");
            if (trap == null)
            {
                return Agent.Call(ProxyTarget, thisArgument, arguments);
            }

            var argumentArray = ArrayIntrinsics.CreateArrayFromList(Agent, arguments);
            return Agent.Call(trap, ProxyHandler, ProxyTarget, thisArgument, argumentArray);
        }

        internal override ScriptValue Construct([NotNull] IReadOnlyList<ScriptValue> arguments, ScriptObject newTarget)
        {
            //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-construct-argumentslist-newtarget
            if (ProxyHandler == null)
            {
                throw Agent.CreateTypeError();
            }
            Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

            var trap = Agent.GetMethod(ProxyHandler, "construct");
            if (trap == null)
            {
                Debug.Assert(Agent.IsConstructor(ProxyTarget));
                return Agent.Construct(ProxyTarget, arguments, newTarget);
            }

            var argumentArray = ArrayIntrinsics.CreateArrayFromList(Agent, arguments);
            var newObject = Agent.Call(trap, ProxyHandler, ProxyTarget, argumentArray, newTarget);
            if (!newObject.IsObject)
            {
                throw Agent.CreateTypeError();
            }

            return newObject;
        }

        [CanBeNull]
        public ScriptObject ProxyTarget { get; set; }
        [CanBeNull]
        public ScriptObject ProxyHandler { get; set; }

        public override bool IsExtensible
        {
            get
            {
                //https://tc39.github.io/ecma262/#sec-proxy-object-internal-methods-and-internal-slots-isextensible
                if (ProxyHandler == null)
                {
                    throw Agent.CreateTypeError();
                }
                Debug.Assert(ProxyTarget != null, nameof(ProxyTarget) + " != null");

                var trap = Agent.GetMethod(ProxyHandler, "isExtensible");
                if (trap == null)
                {
                    return ProxyTarget.IsExtensible;
                }

                var booleanTrapResult = Agent.RealToBoolean(Agent.Call(trap, ProxyHandler, ProxyTarget));
                var targetResult = ProxyTarget.IsExtensible;
                if (booleanTrapResult != targetResult)
                {
                    throw Agent.CreateTypeError();
                }

                return booleanTrapResult;
            }
        }

        public override bool IsCallable => ProxyTarget?.IsCallable ?? false;

        public override bool IsConstructable => ProxyTarget?.IsConstructable ?? false;
    }
}
