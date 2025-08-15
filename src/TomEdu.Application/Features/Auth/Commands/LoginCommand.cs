using TomEdu.Application.Abstractions.Messaging;
using TomEdu.Application.Features.Auth.Response;

namespace TomEdu.Application.Features.Auth.Commands;

public class LoginCommand : ICommand<LoginResponse>
{
    public string PhoneNumber { get; set; } = default!;

    public string Password { get; set; } = default!;
}