using MediatR;
using Microsoft.AspNetCore.Mvc;
using TomEdu.Application.Features.Auth.Commands;

namespace TomEdu.Api.Controllers;

public class AuthController(
    IMediator mediator
    ) : BaseController
{
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login(
        [FromBody] LoginCommand command,
        CancellationToken cancellationToken = default
        )
    {
        var data = await mediator.Send(command, cancellationToken);

        return Ok(data);
    }

    [HttpPost("refresh-token")]
    public async ValueTask<IActionResult> RefreshToken(
        [FromBody] RefreshTokenCommand command,
        CancellationToken cancellationToken = default
        )
    {
        var data = await mediator.Send(command.RefreshToken, cancellationToken);

        return Ok(data);
    }

    [HttpPost("logout")]
    public async ValueTask<IActionResult> Logout([FromBody] LogoutCommand request, CancellationToken cancellationToken = default)
    {
        var data = await mediator.Send(request.RefreshToken, cancellationToken);

        return Ok(data);
    }
}