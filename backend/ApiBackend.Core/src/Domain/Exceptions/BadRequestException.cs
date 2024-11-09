using System.Net;

namespace ApiBackend.Core.src.Domain.Exceptions;

public class BadRequestException : ApiException
{
    public BadRequestException(string message) 
    : base(HttpStatusCode.BadRequest, message, "BAD_REQUEST")
    {
    }
}
