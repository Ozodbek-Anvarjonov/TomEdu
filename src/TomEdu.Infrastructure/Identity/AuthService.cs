using Microsoft.EntityFrameworkCore;
using System.Net;
using TomEdu.Application.Abstractions.Identity;
using TomEdu.Application.Abstractions.Notifications.Services;
using TomEdu.Application.Abstractions.Notifications.Templates.Contexts;
using TomEdu.Application.Abstractions.Persistence.UnitOfWork;
using TomEdu.Application.Common.Exceptions;
using TomEdu.Application.Features.Auth.Dtos;
using TomEdu.Application.Services;
using TomEdu.Domain.Entities;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Identities;

public class AuthService(
    IPasswordHasherService passwordHasherService,
    IAccessTokenGeneratorService accessTokenGeneratorService,
    IRefreshTokenService refreshTokenService,
    IUnitOfWork unitOfWork,
    INotificationSenderService notificationSenderService
    ) : IAuthService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default)
    {
        var user = await unitOfWork.Users
            .Get(entity => entity.FirstName == loginRequest.PhoneNumber)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new BadRequestException("Invalid email or password.");

        return await LoginAsync(user, loginRequest.Password, cancellationToken);
    }

    public async Task<bool> RegisterAsync(User user, CancellationToken cancellationToken = default)
    {
        user.Password = await passwordHasherService.HashAsync(user.Password, cancellationToken: cancellationToken);

        await unitOfWork.Users.CreateAsync(user, cancellationToken: cancellationToken);
        var notification = new Notification
        {
            ReceiverUser = user,
            ReceiverUserId = user.Id,
            Type = NotificationType.Register,
            ChannelType = NotificationChannelType.Sms,
        };
        var context = new RegisterNotificationTemplateContext
        {
            FirstName = user.FirstName,
            RegisteredAt = user.CreatedAt.ToString(),
        };

        await notificationSenderService.SendAsync(notification, context, new List<NotificationChannelType>
        {
            NotificationChannelType.Email,
            NotificationChannelType.Sms
        }, cancellationToken);

        return true;
    }

    public async Task<LoginResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var existToken = await refreshTokenService.GetValidTokenAsync(refreshToken, asNoTracking: false, cancellationToken);

        await unitOfWork.RefreshTokens.DeleteAsync(existToken, cancellationToken: cancellationToken);

        var newRefreshToken = await refreshTokenService.CreateAsync(existToken.User, cancellationToken: cancellationToken);
        var newAccessToken = await accessTokenGeneratorService.GenerateAsync(existToken.User, cancellationToken: cancellationToken);

        return new LoginResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken.Token,
        };
    }

    public async Task<bool> LogoutAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var existToken = await refreshTokenService.GetValidTokenAsync(refreshToken, asNoTracking: false, cancellationToken);

        await unitOfWork.RefreshTokens.DeleteAsync(existToken, cancellationToken: cancellationToken);

        return true;
    }

    private async Task<LoginResponse> LoginAsync(User user, string password, CancellationToken cancellationToken = default)
    {
        var verify = await passwordHasherService.VerifyAsync(password, user.Password, cancellationToken);
        if (!verify)
            throw new BadRequestException("Invalid email or password");

        if (!user.IsActive)
            throw new CustomException("Your account has been blocked. Please contact support.", HttpStatusCode.Forbidden);

        var refreshToken = await refreshTokenService.CreateAsync(user, cancellationToken: cancellationToken);
        var accessToken = await accessTokenGeneratorService.GenerateAsync(user, cancellationToken: cancellationToken);

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
        };
    }
}