using TomEdu.Domain.Common.Entities;
using TomEdu.Domain.Enums;

namespace TomEdu.Domain.Entities;

public class User : SoftDeletedEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? MiddleName { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Password { get; set; } = default!;

    public UserRole Role { get; set; }

    public bool IsActive { get; set; } = true;
}