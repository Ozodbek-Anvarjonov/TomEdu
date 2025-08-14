using TomEdu.Domain.Entities;

namespace TomEdu.Application.Abstractions.Identity;

public interface IAccessTokenGeneratorService
{
    Task<string> GenerateAsync(User user, CancellationToken cancellationToken);
}