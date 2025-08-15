using TomEdu.Application.Abstractions.Messaging;

namespace TomEdu.Application.Features.Auth.Commands;

public class LogOutCommandHandler : ICommandHandler<LogoutCommand>
{
    public Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}