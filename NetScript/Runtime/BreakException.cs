namespace NetScript.Runtime
{
    internal sealed class BreakException : ECMARuntimeException
    {
        public BreakException()
        {
        }

        public BreakException(string target) :
            base(target)
        {
        }
    }
}