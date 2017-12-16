using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using NetScript.Runtime.Builtins;

namespace NetScript.Runtime.Objects
{
    /// <summary>
    /// An ECMAScript object.
    /// </summary>
    [DebuggerTypeProxy(typeof(ScriptObjectDebugView))]
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

        internal sealed class ArrayBufferInternals
        {
            public byte[] Data;
            public bool Shared;
        }

        internal sealed class RegExpInternals
        {
            public string OriginalSource;
            public string OriginalFlags;
        }

        private sealed class BasicInternal<T>
        {
            public T Value;
        }

        [CanBeNull] private ScriptObject prototype;
        private readonly object specialValue;
        private readonly PropertyCollection properties = new PropertyCollection();

        internal ScriptObject([NotNull] Realm realm, [CanBeNull] ScriptObject prototype, bool extensible, SpecialObjectType specialObjectType)
        {
            Realm = realm;
            this.prototype = prototype;
            SpecialObjectType = specialObjectType;
            IsExtensible = extensible;

            switch (specialObjectType)
            {
                case SpecialObjectType.None:
                case SpecialObjectType.Parameter:
                case SpecialObjectType.TypedArray:
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
                case SpecialObjectType.ArrayBuffer:
                    specialValue = new ArrayBufferInternals();
                    break;
                case SpecialObjectType.RegExp:
                    specialValue = new RegExpInternals();
                    break;
                case SpecialObjectType.RevocableProxy:
                    specialValue = new BasicInternal<ScriptObject>();
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

        /// <summary>
        /// Returns true if the object contains the specified property.
        /// <exception cref="ArgumentException">Throws if property is not a Property Key.</exception>
        /// </summary>
        public bool HasOwnProperty(ScriptValue property)
        {
            if (!Agent.IsPropertyKey(property))
            {
                throw new ArgumentException("Property must be a property key.", nameof(property));
            }

            var descriptor = GetOwnProperty(property);
            return descriptor != null;
        }

        /// <summary>
        /// Returns true if the object or a parent along the prototype chain contains the specified property.
        /// <exception cref="ArgumentException">Throws if property is not a Property Key.</exception>
        /// </summary>
        public virtual bool HasProperty(ScriptValue property)
        {
            //https://tc39.github.io/ecma262/#sec-ordinaryhasproperty
            if (!Agent.IsPropertyKey(property))
            {
                throw new ArgumentException("Property must be a property key.", nameof(property));
            }

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
            if (prototype == this.prototype)
            {
                return true;
            }

            if (!IsExtensible)
            {
                return false;
            }

            var p = prototype;
            var done = false;
            while (!done)
            {
                if (p == null)
                {
                    done = true;
                }
                else if (p == this)
                {
                    return false;
                }
                else
                {
                    if (this is ScriptProxyObject)
                    {
                        done = true;
                    }
                    else
                    {
                        p = p.prototype;
                    }
                }
            }
            this.prototype = prototype;
            return true;
        }

        internal ScriptValue Get(ScriptValue property)
        {
            return Get(property, this);
        }

        internal virtual ScriptValue Get(ScriptValue property, ScriptValue receiver)
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
                return parent.Get(property, receiver);
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

            return Agent.Call(getter, receiver);
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

        private bool OrdinarySetWithOwnDescriptor(ScriptValue property, ScriptValue value, ScriptValue receiver, [CanBeNull] PropertyDescriptor ownDescriptor)
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

        internal static bool ValidateAndApplyPropertyDescriptor([CanBeNull] ScriptObject obj, ScriptValue property, bool extensible, [NotNull] PropertyDescriptor descriptor, [CanBeNull] PropertyDescriptor current)
        {
            //https://tc39.github.io/ecma262/#sec-validateandapplypropertydescriptor
            Debug.Assert(obj == null || Agent.IsPropertyKey(property));

            if (current == null)
            {
                if (!extensible)
                {
                    return false;
                }

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
            {
                return true;
            }

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
                    if (descriptor.Set != null && descriptor.Set != current.Set)
                    {
                        return false;
                    }

                    if (descriptor.Get != null && descriptor.Get != current.Get)
                    {
                        return false;
                    }

                    return true;
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
            get
            {
                if (!Agent.IsPropertyKey(property))
                {
                    throw new ArgumentException("Property must be a property key.", nameof(property));
                }

                return Get(property);
            }
            set
            {
                if (!Agent.IsPropertyKey(property))
                {
                    throw new ArgumentException("Property must be a property key.", nameof(property));
                }

                var result = DefineOwnProperty(property, new PropertyDescriptor(value));
                if (!result)
                {
                    throw new ScriptException();
                }
            }
        }

        [NotNull]
        public Agent Agent => Realm.Agent;

        [NotNull]
        public Realm Realm { get; }

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

        internal ArrayBufferInternals ArrayBuffer
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.ArrayBuffer);
                return (ArrayBufferInternals)specialValue;
            }
        }

        internal RegExpInternals RegExp
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.RegExp);
                return (RegExpInternals)specialValue;
            }
        }

        internal ScriptObject RevocableProxy
        {
            get
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.RevocableProxy);
                return ((BasicInternal<ScriptObject>)specialValue).Value;
            }
            set
            {
                Debug.Assert(SpecialObjectType == SpecialObjectType.RevocableProxy);
                ((BasicInternal<ScriptObject>)specialValue).Value = value;
            }
        }

        [NotNull]
        public virtual string TypeOf => IsCallable ? "function" : "object";
    }
}
