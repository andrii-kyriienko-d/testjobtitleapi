using System.Net;

namespace TestApiJobTitle.Common.Exceptions;

public class BusinessException(HttpStatusCode code, string message) : Exception
{
    public HttpStatusCode Code { get; set; } = code;
    public string ErrorMessage { get; set; } = message;
}