using System;

namespace NetScript.Runtime.Builtins
{
    internal sealed class TypeDescription
    {
        public string Name;
        public Action<double, IntPtr> ConversionToBytes;
        public Func<IntPtr, double> ConversionFromBytes;
        public uint Size;

        public TypeDescription(string name, Action<double, IntPtr> conversionToBytes, Func<IntPtr, double> conversionFromBytes, uint size)
        {
            Name = name;
            ConversionToBytes = conversionToBytes;
            ConversionFromBytes = conversionFromBytes;
            Size = size;
        }
    }
}