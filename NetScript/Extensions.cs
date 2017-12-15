using System;

namespace NetScript
{
    internal static class Extensions
    {
        public static bool IsNegative(this double x)
        {
            return BitConverter.DoubleToInt64Bits(x) < 0;
        }
    }
}
