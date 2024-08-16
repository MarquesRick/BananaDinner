using System.Net;

namespace BananaDinner.Application.Common.Errors;

public record struct DuplicateEmailError() : IError
{
    public HttpStatusCode StatusCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
