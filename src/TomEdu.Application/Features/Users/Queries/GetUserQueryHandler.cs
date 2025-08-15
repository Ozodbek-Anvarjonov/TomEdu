using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Features.Users.Responses;

namespace TomEdu.Application.Features.Users.Queries;

public class GetUserQueryHandler : IQueryHandler<GetUserQuery, IEnumerable<GetUserResponse>>
{
    public Task<IEnumerable<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}