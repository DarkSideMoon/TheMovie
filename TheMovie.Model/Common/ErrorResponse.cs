namespace TheMovie.Model.Common
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public ErrorResponse(string code, string message, string stackTrace)
        {
            Code = code;
            Message = message;
            StackTrace = stackTrace;
        }

        public string Code { get; set; }

        public string Message { get; set; } = "Sorry, an error occurred. Try again later. Thank you for using our service";
        
        public string StackTrace { get; set; }
    }
}
