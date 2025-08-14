using MediatR;

namespace TomEdu.Application.Abstractions.Messaging;

public interface IQuery : IRequest
{
}

public interface TQuery<out TResponse> : IRequest<TResponse>
{
}