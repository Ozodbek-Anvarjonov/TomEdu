using System.Net;

namespace TomEdu.Application.Common.Exceptions;

public abstract class AppException : Exception, IAppException
{
    protected AppException(string message) : base(message) { }

    protected AppException(string message, Exception? innerException)
        : base(message, innerException) { }

    public abstract string Type { get; }

    public abstract HttpStatusCode StatusCode { get; }

    public abstract string Title { get; }

    public virtual string Detail => Message;

    public virtual IDictionary<string, string[]>? Errors => null;
}