using System.Net;

namespace BananaDinner.Application.Common.Errors;
public interface IError
{
    public HttpStatusCode StatusCode { get; set; }
    public string ErrorMessage { get; set; }
}
