using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Features.Auth.Response;

namespace TomEdu.Application.Features.Auth.Commands;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}