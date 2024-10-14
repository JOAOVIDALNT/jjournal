namespace jjournal.Exception.Base
{
    public class InvalidLoginException : AppBaseException
    {
        public InvalidLoginException() : base(ResourceMessageException.LOGIN_INVALID) { }
    }
}
