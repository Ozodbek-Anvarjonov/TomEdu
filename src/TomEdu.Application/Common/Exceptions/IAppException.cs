using System.Net;

namespace TomEdu.Application.Common.Exceptions;

public interface IAppException
{
    string Type { get; }

    HttpStatusCode StatusCode { get; }

    string Title { get; }

    string Detail { get; }

    IDictionary<string, string[]>? Errors { get; }
}