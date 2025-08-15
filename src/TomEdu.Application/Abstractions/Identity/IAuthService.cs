using TomEdu.Application.Features.Auth.Commands;
using TomEdu.Application.Features.Auth.Response;
using TomEdu.Domain.Entities;

namespace TomEdu.Application.Abstractions.Identity;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginCommand loginRequest, CancellationToken cancellationToken = default);

    Task<bool> RegisterAsync(User user, CancellationToken cancellationToken = default);

    Task<LoginResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);

    Task<bool> LogoutAsync(string refreshToken, CancellationToken cancellationToken = default);
}