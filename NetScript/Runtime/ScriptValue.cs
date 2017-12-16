using System;
using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;
using NetScript.Runtime.Objects;

namespace NetScript.Runtime
{
    public struct ScriptValue : IEquatable<ScriptValue>
    {
        internal enum Type
        {
            Undefined,
            Null,
            Boolean,
            Number,
            String,
            Symbol,
            Object
        }

        public static readonly ScriptValue Undefined = new ScriptValue();
        public static readonly ScriptValue Null = new ScriptValue(Type.Null);

        private readonly Type type;
        private readonly double doubleValue;
        private readonly object objectValue;

        private ScriptValue(Type type)
        {
            this.type = type;
            doubleValue = 0;
            objectValue = null;
        }

        public ScriptValue(bool value)
        {
            type = Type.Boolean;
            doubleValue = value ? 1 : 0;
            objectValue = null;
        }

        public ScriptValue(double value)
        {
            type = Type.Number;
            doubleValue = value;
            objectValue = null;
        }

        public ScriptValue([NotNull] string value)
        {
            type = Type.String;
            doubleValue = 0;
            objectValue = value;
        }

        public ScriptValue([NotNull] Symbol value)
        {
            type = Type.Symbol;
            doubleValue = 0;
            objectValue = value;
        }

        public ScriptValue([NotNull] ScriptObject value)
        {
            type = Type.Object;
            doubleValue = 0;
            objectValue = value;
        }

        public bool HasOwnProperty(ScriptValue property)
        {
            if (type == Type.Object)
            {
                return ((ScriptObject)objectValue).HasOwnProperty(property);
            }
            return false;
        }

        public bool HasProperty(ScriptValue property)
        {
            if (type == Type.Object)
            {
                return ((ScriptObject)objectValue).HasProperty(property);
            }
            return false;
        }

        public bool SameValue(ScriptValue other)
        {
            //https://tc39.github.io/ecma262/#sec-samevalue
            if (type != other.type)
            {
                return false;
            }

            if (type == Type.Number)
            {
                if (double.IsNaN(doubleValue) && double.IsNaN(other.doubleValue))
                {
                    return true;
                }

                if (doubleValue == 0 && other.doubleValue == 0 && doubleValue.IsNegative() != other.doubleValue.IsNegative())
                {
                    return false;
                }

                return doubleValue == other.doubleValue;
            }

            return Agent.SameValueNonNumber(this, other);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            switch (type)
            {
                case Type.Undefined:
                    return "undefined";
                case Type.Null:
                    return "null";
                case Type.Boolean:
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    return doubleValue != 0 ? "true" : "false";
                case Type.String:
                    return (string)objectValue;
                case Type.Symbol:
                    throw new NotImplementedException();
                case Type.Number:
                    return doubleValue.ToString(CultureInfo.InvariantCulture);
                case Type.Object:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool Equals(ScriptValue other)
        {
            if (type != other.type) return false;

            switch (type)
            {
                case Type.Undefined:
                case Type.Null:
                    return true;
                case Type.Boolean:
                case Type.Number:
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    return doubleValue == other.doubleValue;
                case Type.String:
                case Type.Symbol:
                case Type.Object:
                    return objectValue.Equals(other.objectValue);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != GetType()) return false;
            return Equals((ScriptValue)obj);
        }

        public override int GetHashCode()
        {
            switch (type)
            {
                case Type.Undefined:
                case Type.Null:
                    return 0;
                case Type.Boolean:
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    return (doubleValue != 0).GetHashCode();
                case Type.Number:
                    return doubleValue.GetHashCode();
                case Type.String:
                case Type.Symbol:
                case Type.Object:
                    return objectValue.GetHashCode();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ScriptValue this[ScriptValue property]
        {
            get
            {
                if (IsObject)
                {
                    return ((ScriptObject)objectValue)[property];
                }

                throw new InvalidOperationException();
            }
            set
            {
                if (IsObject)
                {
                    ((ScriptObject)objectValue)[property] = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool IsBoolean => type == Type.Boolean;
        public bool IsString => type == Type.String;
        public bool IsSymbol => type == Type.Symbol;
        public bool IsNumber => type == Type.Number;
        public bool IsObject => type == Type.Object;

        internal Type ValueType => type;

        public static bool operator ==(ScriptValue left, ScriptValue right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScriptValue left, ScriptValue right)
        {
            return !Equals(left, right);
        }

        public static implicit operator ScriptValue(bool value)
        {
            return new ScriptValue(value);
        }

        public static implicit operator ScriptValue(double value)
        {
            return new ScriptValue(value);
        }

        public static implicit operator ScriptValue([CanBeNull] string value)
        {
            if (value == null)
                return Null;
            return new ScriptValue(value);
        }

        public static implicit operator ScriptValue([CanBeNull] Symbol value)
        {
            if (value == null)
                return Null;
            return new ScriptValue(value);
        }

        public static implicit operator ScriptValue([CanBeNull] ScriptObject value)
        {
            if (value == null)
                return Null;
            return new ScriptValue(value);
        }

        public static explicit operator bool(ScriptValue value)
        {
            if (value.type != Type.Boolean)
                throw new InvalidOperationException();
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return value.doubleValue != 0;
        }

        public static explicit operator double(ScriptValue value)
        {
            if (value.type != Type.Number)
                throw new InvalidOperationException();
            return value.doubleValue;
        }

        [NotNull]
        public static explicit operator string(ScriptValue value)
        {
            if (value.type != Type.String)
                throw new InvalidOperationException();
            return (string)value.objectValue;
        }

        [NotNull]
        public static explicit operator Symbol(ScriptValue value)
        {
            if (value.type != Type.Symbol)
                throw new InvalidOperationException();
            return (Symbol)value.objectValue;
        }

        [NotNull]
        public static explicit operator ScriptObject(ScriptValue value)
        {
            if (value.type != Type.Object)
                throw new InvalidOperationException();
            return (ScriptObject)value.objectValue;
        }
    }
}
