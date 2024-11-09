using System.Net;

namespace ApiBackend.Core.src.Domain.Exceptions;

public class InternalServerErrorException : ApiException
{
    public InternalServerErrorException(string message) 
        : base(HttpStatusCode.InternalServerError, message, "INTERNAL_SERVER_ERROR")
    {
    }
}
