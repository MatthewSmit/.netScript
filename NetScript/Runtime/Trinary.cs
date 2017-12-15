namespace NetScript.Runtime
{
    internal struct Trinary
    {
        private const byte NULL = 0;
        private const byte FALSE = 1;
        private const byte TRUE = 2;

        private readonly byte value;

        private Trinary(byte value)
        {
            this.value = value;
        }

        public static implicit operator Trinary(bool value)
        {
            return new Trinary(value ? TRUE : FALSE);
        }

        public static implicit operator bool(Trinary trinary)
        {
            return trinary.value == TRUE;
        }

        public bool HasValue => value != NULL;
    }
}