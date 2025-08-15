using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Features.Users.Responses;

namespace TomEdu.Application.Features.Users.Queries;

public class GetByIdUserQuery : IQuery<GetUserResponse>
{
    public long Id { get; set; }
}