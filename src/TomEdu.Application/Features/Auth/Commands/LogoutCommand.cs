using TomEdu.Application.Abstractions.Messaging;

namespace TomEdu.Application.Features.Auth.Commands;

public class LogoutCommand : ICommand
{
    public string RefreshToken { get; set; } = default!;
}