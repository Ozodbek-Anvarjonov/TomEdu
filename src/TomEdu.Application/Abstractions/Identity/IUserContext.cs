namespace TomEdu.Application.Abstractions.Identity;

public interface IUserContext
{
    long SystemId { get; }

    long? UserId { get; }

    long GetCurrentUserId();
}