using System.Net;

namespace BE_FacilityFeedBackWebApi.Middlewares.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message, List<string>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            ErrorMessages = errors;
            StatusCode = statusCode;
        }

        public List<string>? ErrorMessages { get; }

        public HttpStatusCode StatusCode { get; }

    }
}
