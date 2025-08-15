using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Features.Users.Responses;

namespace TomEdu.Application.Features.Users.Queries;

public class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, GetUserResponse>
{
    public Task<GetUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
