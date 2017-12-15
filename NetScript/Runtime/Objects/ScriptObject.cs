using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Builtins;

namespace NetScript.Runtime.Objects
{
    public class ScriptObject
    {
        private sealed class IteratorInternals
        {
            public IReadOnlyList<ScriptValue> List;
            public uint NextIndex;
        }

        private sealed class ArrayIteratorInternals
        {
            public ScriptObject Array;
            public uint NextIndex;
            public EnumerateType Kind;
        }

        private sealed class BasicInternal<T>
        {
            public T Value;
        }

        [CanBeNull] private ScriptObject prototype;
        private readonly object specialValue;
        private readonly PropertyCollection properties = new PropertyCollection();

        internal ScriptObject([NotNull] Agent agent, [CanBeNull] ScriptObject prototype, bool extensible, SpecialObjectType specialObjectType)
        {
            Agent = agent;
            this.prototype = prototype;
            SpecialObjectType = specialObjectType;
            IsExtensible = extensible;

            switch (specialObjectType)
            {
                case SpecialObjectType.None:
                case SpecialObjectType.Parameter:
                    break;
                case SpecialObjectType.IteratedList:
                    specialValue = new IteratorInternals();
                    break;
                case SpecialObjectType.ArrayIterator:
                    specialValue = new ArrayIteratorInternals();
                    break;
                case SpecialObjectType.Date:
                case SpecialObjectType.Number:
                    specialValue = new BasicInternal<double>();
                    break;
                case SpecialObjectType.Boolean:
                    specialValue = new BasicInternal<bool>();
                    break;
                case SpecialObjectType.Symbol:
                    specialValue = new BasicInternal<Symbol>();
                    break;
                case SpecialObjectType.Error:
                    specialValue = new BasicInternal<ErrorData>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(specialObjectType), specialObjectType, null);
            }
        }

        internal virtual bool DefineOwnProperty(ScriptValue property, [NotNull] PropertyDescriptor descriptor)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarydefineownproperty
            return ValidateAndApplyPropertyDescriptor(this, property, IsExtensible, descriptor, GetOwnProperty(property));
        }

        [CanBeNull]
        internal virtual PropertyDescriptor GetOwnProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarygetownproperty
            Debug.Assert(Agent.IsPropertyKey(property));

            if (!properties.TryGetValue(property, out var value))
            {
                return null;
            }

            return value;
        }

        public bool HasOwnProperty(ScriptValue property)
        {
            Debug.Assert(Agent.IsPropertyKey(property));
            var descriptor = GetOwnProperty(property);
            return descriptor != null;
        }

        public virtual bool HasProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-ordinaryhasproperty
            Debug.Assert(Agent.IsPropertyKey(property));
            var hasOwn = GetOwnProperty(property);
            if (hasOwn != null)
            {
                return true;
            }

            var parent = GetPrototypeOf();
            if (parent != null)
            {
                return parent.HasProperty(property);
            }

            return false;
        }

        [CanBeNull]
        internal virtual ScriptObject GetPrototypeOf()
        {
            return prototype;
        }

        internal virtual bool PreventExtensions()
        {
            IsExtensible = false;
            return true;
        }

        internal virtual bool SetPrototypeOf([CanBeNull] ScriptObject prototype)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarysetprototypeof
            //Let extensible be O.[[Extensible]].
            //Let current be O.[[Prototype]].
            if (prototype == this.prototype)
                return true;
            if (!IsExtensible)
                return false;
            var p = prototype;
            var done = false;
            while (!done)
            {
                if (p == null)
                    done = true;
                else if (p == this)
                    return false;
                else
                {
                    //If p.[[GetPrototypeOf]] is not the ordinary object internal method defined in 9.1.1, set done to true.
                    if (this is ScriptProxyObject)
                        done = true;
                    else p = p.prototype;
                }
            }
            this.prototype = prototype;
            return true;
        }

        internal ScriptValue Get(ScriptValue property)
        {
            return Get(property, this);
        }

        internal virtual ScriptValue Get(ScriptValue property, ScriptValue reciever)
        {
            //https://tc39.github.io/ecma262/#sec-ordinaryget
            Debug.Assert(Agent.IsPropertyKey(property));
            var descriptor = GetOwnProperty(property);
            if (descriptor == null)
            {
                var parent = GetPrototypeOf();
                if (parent == null)
                {
                    return ScriptValue.Undefined;
                }
                return parent.Get(property, reciever);
            }

            if (descriptor.IsDataDescriptor)
            {
                Debug.Assert(descriptor.Value != null, "descriptor.Value != null");
                return descriptor.Value.Value;
            }

            Debug.Assert(descriptor.IsAccessorDescriptor);

            var getter = descriptor.Get;
            if (getter == null)
            {
                return ScriptValue.Undefined;
            }

            return Agent.Call(getter, reciever);
        }

        internal virtual ScriptValue Call(ScriptValue thisValue, IReadOnlyList<ScriptValue> arguments)
        {
            throw new NotImplementedException();
        }

        internal virtual ScriptValue Construct(IReadOnlyList<ScriptValue> arguments, ScriptObject newTarget)
        {
            throw new NotImplementedException();
        }

        internal virtual bool Set(ScriptValue property, ScriptValue value, ScriptValue receiver)
        {
            //https://tc39.github.io/ecma262/#sec-ordinaryset
            Debug.Assert(Agent.IsPropertyKey(property));
            var ownDescriptor = GetOwnProperty(property);
            return OrdinarySetWithOwnDescriptor(property, value, receiver, ownDescriptor);
        }

        [NotNull]
        internal virtual IEnumerable<ScriptValue> OwnPropertyKeys()
        {
            //https://tc39.github.io/ecma262/#sec-ordinaryownpropertykeys

            return properties.EnumerateKeys();
        }

        internal virtual bool Delete(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarydelete

            Debug.Assert(Agent.IsPropertyKey(property));
            var descriptor = GetOwnProperty(property);
            if (descriptor == null)
            {
                return true;
            }

            if (descriptor.Configurable)
            {
                properties.Remove(property);
                return true;
            }

            return false;
        }

        private bool OrdinarySetWithOwnDescriptor(ScriptValue property, ScriptValue value, [CanBeNull] ScriptValue receiver, [CanBeNull] PropertyDescriptor ownDescriptor)
        {
            //https://tc39.github.io/ecma262/#sec-ordinarysetwithowndescriptor
            Debug.Assert(Agent.IsPropertyKey(property));

            if (ownDescriptor == null)
            {
                var parent = GetPrototypeOf();
                if (parent != null)
                {
                    return parent.Set(property, value, receiver);
                }

                ownDescriptor = new PropertyDescriptor(ScriptValue.Undefined, true, true, true);
            }

            if (ownDescriptor.IsDataDescriptor)
            {
                if (!ownDescriptor.Writable)
                {
                    return false;
                }
                if (!receiver.IsObject)
                {
                    return false;
                }

                var existingDescriptor = ((ScriptObject)receiver).GetOwnProperty(property);
                if (existingDescriptor != null)
                {
                    if (existingDescriptor.IsAccessorDescriptor)
                    {
                        return false;
                    }
                    if (!existingDescriptor.Writable)
                    {
                        return false;
                    }
                    var valueDescriptor = new PropertyDescriptor(value);
                    return ((ScriptObject)receiver).DefineOwnProperty(property, valueDescriptor);
                }

                return ((ScriptObject)receiver).CreateDataProperty(property, value);
            }

            Debug.Assert(ownDescriptor.IsAccessorDescriptor);
            var setter = ownDescriptor.Set;
            if (setter == null)
            {
                return false;
            }
            var result = Agent.Call(setter, receiver, value);
            if (result != ScriptValue.Undefined)
            {
                throw new NotImplementedException();
            }
            return true;
        }

        internal bool CreateDataProperty(ScriptValue property, ScriptValue value)
        {
            //https://tc39.github.io/ecma262/#sec-createdataproperty
            Debug.Assert(Agent.IsPropertyKey(property));

            var newDescriptor = new PropertyDescriptor(value, true, true, true);
            return DefineOwnProperty(property, newDescriptor);
        }

        private static bool ValidateAndApplyPropertyDescriptor([CanBeNull] ScriptObject obj, ScriptValue property, bool extensible, [NotNull] PropertyDescriptor descriptor, [CanBeNull] PropertyDescriptor current)
        {
            //https://tc39.github.io/ecma262/#sec-validateandapplypropertydescriptor
            Debug.Assert(obj == null || Agent.IsPropertyKey(property));

            if (current == null)
            {
                if (!extensible)
                    return false;

                if (descriptor.IsGenericDescriptor || descriptor.IsDataDescriptor)
                {
                    if (obj != null)
                    {
                        obj.properties[property] = new PropertyDescriptor(descriptor.Value ?? ScriptValue.Undefined,
                            (bool)descriptor.Writable,
                            (bool)descriptor.Enumerable,
                            (bool)descriptor.Configurable);
                    }
                }
                else
                {
                    Debug.Assert(descriptor.IsAccessorDescriptor);
                    if (obj != null)
                    {
                        obj.properties[property] = new PropertyDescriptor(descriptor.Get,
                            descriptor.Set,
                            (bool)descriptor.Enumerable,
                            (bool)descriptor.Configurable);
                    }
                }
                return true;
            }

            if (!descriptor.Configurable.HasValue &&
                !descriptor.Enumerable.HasValue &&
                !descriptor.Writable.HasValue &&
                !descriptor.Value.HasValue &&
                descriptor.Get == null &&
                descriptor.Set == null)
                return true;

            if (!current.Configurable)
            {
                if (descriptor.Configurable)
                {
                    return false;
                }
                if (descriptor.Enumerable.HasValue && descriptor.Enumerable != current.Enumerable)
                {
                    return false;
                }
            }

            if (descriptor.IsGenericDescriptor)
            {
            }
            else if (current.IsDataDescriptor != descriptor.IsDataDescriptor)
            {
                if (!current.Configurable)
                {
                    return false;
                }

                if (obj != null)
                {
                    if (current.IsDataDescriptor)
                    {
                        current.Value = default;
                        current.Writable = default;
                    }
                    else
                    {
                        current.Get = default;
                        current.Set = default;
                    }
                }
            }
            else if (current.IsDataDescriptor && descriptor.IsDataDescriptor)
            {
                if (!current.Configurable && !current.Writable)
                {
                    if (descriptor.Writable)
                    {
                        return false;
                    }
                    if (current.Value.HasValue && descriptor.Value.HasValue && !descriptor.Value.Value.SameValue(current.Value.Value))
                    {
                        return false;
                    }
                    return true;
                }
            }
            else if (current.IsAccessorDescriptor && descriptor.IsAccessorDescriptor)
            {
                if (!current.Configurable)
                {
                    //If Desc.[[Set]] is present and SameValue(Desc.[[Set]], current.[[Set]]) is false, return false.
                    //If Desc.[[Get]] is present and SameValue(Desc.[[Get]], current.[[Get]]) is false, return false.
                    //Return true.
                    throw new NotImplementedException();
                }
            }

            if (obj != null)
            {
                if (descriptor.Configurable.HasValue)
                {
                    current.Configurable = descriptor.Configurable;
                }
                if (descriptor.Enumerable.HasValue)
                {
                    current.Enumerable = descriptor.Enumerable;
                }
                if (descriptor.Writable.HasValue)
                {
                    current.Writable = descriptor.Writable;
                }
                if (descriptor.Value.HasValue)
                {
                    current.Value = descriptor.Value;
                }
                if (descriptor.Get != null)
                {
                    current.Get = descriptor.Get;
                }
                if (descriptor.Set != null)
                {
                    current.Set = descriptor.Set;
                }
            }

            return true;
        }

        public ScriptValue this[ScriptValue property]
        {
            get => Get(property);
            set
            {
                var result = DefineOwnProperty(property, new PropertyDescriptor(value));
                if (!result)
                    throw new ScriptException();
            }
        }

        [NotNull]
        public Agent Agent { get; }

        public virtual bool IsCallable => false;
        public virtual bool IsConstructable => false;

        public virtual bool IsExtensible { get; private set; }

        internal SpecialObjectType SpecialObjectType { get; }

        internal IReadOnlyList<ScriptValue> IteratedList
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.IteratedList);
                return ((IteratorInternals)specialValue).List;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.IteratedList);
                ((IteratorInternals)specialValue).List = value;
            }
        }

        internal uint ListIteratorNextIndex
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.IteratedList);
                return ((IteratorInternals)specialValue).NextIndex;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.IteratedList);
                ((IteratorInternals)specialValue).NextIndex = value;
            }
        }

        internal ScriptObject IteratedObject
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.ArrayIterator);
                return ((ArrayIteratorInternals)specialValue).Array;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.ArrayIterator);
                ((ArrayIteratorInternals)specialValue).Array = value;
            }
        }

        internal uint ArrayIteratorNextIndex
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.ArrayIterator);
                return ((ArrayIteratorInternals)specialValue).NextIndex;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.ArrayIterator);
                ((ArrayIteratorInternals)specialValue).NextIndex = value;
            }
        }

        internal EnumerateType ArrayIterationKind
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.ArrayIterator);
                return ((ArrayIteratorInternals)specialValue).Kind;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.ArrayIterator);
                ((ArrayIteratorInternals)specialValue).Kind = value;
            }
        }

        internal double DateValue
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Date);
                return ((BasicInternal<double>)specialValue).Value;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Date);
                ((BasicInternal<double>)specialValue).Value = value;
            }
        }

        internal double NumberValue
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Number);
                return ((BasicInternal<double>)specialValue).Value;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Number);
                ((BasicInternal<double>)specialValue).Value = value;
            }
        }

        internal Symbol SymbolValue
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Symbol);
                return ((BasicInternal<Symbol>)specialValue).Value;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Symbol);
                ((BasicInternal<Symbol>)specialValue).Value = value;
            }
        }

        internal bool BooleanValue
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Boolean);
                return ((BasicInternal<bool>)specialValue).Value;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Boolean);
                ((BasicInternal<bool>)specialValue).Value = value;
            }
        }

        internal ErrorData ErrorData
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Error);
                return ((BasicInternal<ErrorData>)specialValue).Value;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.Error);
                ((BasicInternal<ErrorData>)specialValue).Value = value;
            }
        }

        [NotNull]
        public virtual string TypeOf => IsCallable ? "function" : "object";
    }
}
