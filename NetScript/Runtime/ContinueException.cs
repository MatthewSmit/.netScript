namespace NetScript.Runtime
{
    internal sealed class ContinueException : ECMARuntimeException
    {
        public ContinueException()
        {
        }

        public ContinueException(string target) :
            base(target)
        {
        }
    }
}