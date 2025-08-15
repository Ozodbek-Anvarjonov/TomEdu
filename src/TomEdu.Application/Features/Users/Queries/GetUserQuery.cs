using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Common.Filters;
using TomEdu.Application.Features.Users.Responses;

namespace TomEdu.Application.Features.Users.Queries;

public class GetUserQuery : IQuery<IEnumerable<GetUserResponse>>
{
    public UserFilter Filter { get; set; } = default!;
}