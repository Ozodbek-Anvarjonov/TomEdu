using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TomEdu.Api.Extensions;
using TomEdu.Api.Filters;
using TomEdu.Application.Common.Filters;
using TomEdu.Application.Features.Users.Commands;
using TomEdu.Application.Features.Users.Queries;
using TomEdu.Domain.Enums;

namespace TomEdu.Api.Controllers;

[CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.Owner))]
public class UsersController(
    IValidator<CreateUserCommand> createValidator,
    IValidator<UpdateUserCommand> updateValidator,
    IMediator mediator
    ) : BaseController
{
    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] UserFilter filter, CancellationToken cancellationToken)
    {
        var data = await mediator.Send(new GetUserQuery { Filter = filter }, cancellationToken: cancellationToken);

        return Ok(data);
    }

    [AllowAnonymous]
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetById([FromRoute] long id, CancellationToken cancellationToken)
    {
        var data = await mediator.Send(new GetByIdUserQuery { Id = id }, cancellationToken: cancellationToken);

        return Ok(data);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Post([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        await createValidator.EnsureValidationAsync(command, cancellationToken);

        var data = await mediator.Send(command, cancellationToken: cancellationToken);

        return Ok(data);
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> Put([FromRoute] long id, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
    {
        await updateValidator.EnsureValidationAsync(command);
        command.Id = id;
        var data = await mediator.Send(command, cancellationToken);

        return Ok(data);
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
    {
        var data = await mediator.Send(new DeleteUserCommand { Id = id }, cancellationToken: cancellationToken);

        return Ok(data);
    }
}