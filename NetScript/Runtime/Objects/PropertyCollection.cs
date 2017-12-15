using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class PropertyCollection
    {
        private static readonly Regex integerRegex = new Regex(@"^\d{1,10}$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        // TODO: Try only one sorted list with a comparer?
        private readonly SortedList<uint, PropertyDescriptor> integerDescriptors = new SortedList<uint, PropertyDescriptor>();
        private readonly List<(string, PropertyDescriptor)> stringDescriptors = new List<(string, PropertyDescriptor)>();
        private readonly List<(Symbol, PropertyDescriptor)> symbolDescriptors = new List<(Symbol, PropertyDescriptor)>();

        public bool TryGetValue(ScriptValue property, out PropertyDescriptor value)
        {
            Debug.Assert(Agent.IsPropertyKey(property));

            if (property.IsString)
            {
                var propertyString = (string)property;
                if (IsIntegerIndex(propertyString, out var index))
                {
                    return integerDescriptors.TryGetValue(index, out value);
                }

                foreach (var (key, descriptor) in stringDescriptors)
                {
                    if (propertyString.Equals(key, StringComparison.InvariantCulture))
                    {
                        value = descriptor;
                        return true;
                    }
                }

                value = default;
                return false;
            }

            if (property.IsSymbol)
            {
                var propertySymbol = (Symbol)property;
                foreach (var (key, descriptor) in symbolDescriptors)
                {
                    if (propertySymbol.Equals(key))
                    {
                        value = descriptor;
                        return true;
                    }
                }

                value = default;
                return false;
            }

            throw new InvalidOperationException();
        }

        public void Remove(ScriptValue property)
        {
            Debug.Assert(Agent.IsPropertyKey(property));

            if (property.IsString)
            {
                var propertyString = (string)property;
                if (IsIntegerIndex(propertyString, out var index))
                {
                    integerDescriptors.Remove(index);
                    return;
                }

                for (var i = 0; i < stringDescriptors.Count; i++)
                {
                    var (key, _) = stringDescriptors[i];
                    if (propertyString.Equals(key, StringComparison.InvariantCulture))
                    {
                        stringDescriptors.RemoveAt(i);
                        return;
                    }
                }

                throw new KeyNotFoundException();
            }

            if (property.IsSymbol)
            {
                var propertySymbol = (Symbol)property;
                for (var i = 0; i < symbolDescriptors.Count; i++)
                {
                    var (key, _) = symbolDescriptors[i];
                    if (propertySymbol.Equals(key))
                    {
                        symbolDescriptors.RemoveAt(i);
                        return;
                    }
                }

                throw new KeyNotFoundException();
            }

            throw new InvalidOperationException();
        }

        private static bool IsIntegerIndex([NotNull] string value, out uint result)
        {
            var match = integerRegex.Match(value);
            if (match.Success)
            {
                var tmp = ulong.Parse(value, NumberStyles.None, CultureInfo.InvariantCulture);
                if (tmp > uint.MaxValue)
                {
                    result = default;
                    return false;
                }

                result = (uint)tmp;
                return true;
            }

            result = default;
            return false;
        }

        public IEnumerable<ScriptValue> EnumerateKeys()
        {
            foreach (var value in integerDescriptors)
            {
                yield return value.Key.ToString();
            }

            foreach (var value in stringDescriptors)
            {
                yield return value.Item1;
            }

            foreach (var value in symbolDescriptors)
            {
                yield return value.Item1;
            }
        }

        public PropertyDescriptor this[ScriptValue property]
        {
            get
            {
                if (TryGetValue(property, out var value))
                {
                    return value;
                }

                throw new ArgumentException();
            }
            set
            {
                Debug.Assert(Agent.IsPropertyKey(property));

                if (property.IsString)
                {
                    var propertyString = (string)property;
                    if (IsIntegerIndex(propertyString, out var index))
                    {
                        integerDescriptors[index] = value;
                        return;
                    }

                    for (var i = 0; i < stringDescriptors.Count; i++)
                    {
                        var (key, _) = stringDescriptors[i];
                        if (propertyString.Equals(key, StringComparison.InvariantCulture))
                        {
                            stringDescriptors[i] = (key, value);
                            return;
                        }
                    }

                    stringDescriptors.Add((propertyString, value));
                    return;
                }

                if (property.IsSymbol)
                {
                    var propertySymbol = (Symbol)property;
                    for (var i = 0; i < symbolDescriptors.Count; i++)
                    {
                        var (key, _) = symbolDescriptors[i];
                        if (propertySymbol.Equals(key))
                        {
                            symbolDescriptors[i] = (key, value);
                            return;
                        }
                    }

                    symbolDescriptors.Add((propertySymbol, value));
                    return;
                }

                throw new InvalidOperationException();
            }
        }
    }
}