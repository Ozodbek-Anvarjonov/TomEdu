using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Features.Auth.Response;

namespace TomEdu.Application.Features.Auth.Commands;

public class RefreshTokenCommand : ICommand<LoginResponse>
{
    public string RefreshToken { get; set; } = default!;
}