using System;

namespace NetScript.Runtime.Builtins
{
    internal sealed class TypeDescription
    {
        public string Name;
        public Action<double, IntPtr> Conversion;
        public uint Size;

        public TypeDescription(string name, Action<double, IntPtr> conversion, uint size)
        {
            Name = name;
            Conversion = conversion;
            Size = size;
        }
    }
}