namespace jjournal.Communication.Responses
{
    public class ResponseErrorJson
    {
        public ResponseErrorJson(IList<string> errorMessages) => this.ErrorMessages = errorMessages;
        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessages = [errorMessage];
        }
        public IList<string> ErrorMessages { get; set; }
    }
}
