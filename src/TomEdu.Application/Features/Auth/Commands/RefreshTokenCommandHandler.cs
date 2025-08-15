using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Features.Auth.Response;

namespace TomEdu.Application.Features.Auth.Commands;

public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, LoginResponse>
{
    public Task<LoginResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}