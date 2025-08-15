namespace TomEdu.Application.Features.Users.Commands;

public class CreateUserCommand
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? MiddleName { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Password { get; set; } = default!;
}