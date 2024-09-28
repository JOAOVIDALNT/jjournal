namespace jjournal.Exception.Base
{
    public class ErrorOnValidationException : AppBaseException
    {
        public IList<string> ErrorMessages { get; set; }
        public ErrorOnValidationException(IList<string> errorMessages) : base(string.Empty)
        {
            this.ErrorMessages = errorMessages;
        }
    }
}
