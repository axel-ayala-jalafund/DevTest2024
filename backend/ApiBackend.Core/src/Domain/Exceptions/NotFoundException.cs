using System.Net;

namespace ApiBackend.Core.src.Domain.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException(string message)
        : base(HttpStatusCode.BadRequest, message, "BAD_REUEST")
    {
    }
}
