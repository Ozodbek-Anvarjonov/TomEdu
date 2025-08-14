using TomEdu.Domain.Entities;

namespace TomEdu.Application.Abstractions.Identity;

public interface IRefreshTokenGeneratorService
{
    Task<string> GenerateAsync(User user, CancellationToken cancellationToken = default);
}