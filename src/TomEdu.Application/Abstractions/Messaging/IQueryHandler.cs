using MediatR;

namespace TomEdu.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}