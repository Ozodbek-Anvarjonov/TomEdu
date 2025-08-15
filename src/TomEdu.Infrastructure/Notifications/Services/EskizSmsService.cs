using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Application.Abstractions.Notifications.Services;
using TomEdu.Application.Common.Exceptions;
using TomEdu.Infrastructure.Notifications.Credentials.Sms;

namespace TomEdu.Infrastructure.Notifications.Services;

public class EskizSmsService : ISmsService
{
    public async Task<SendResult> SendAsync(ChannelContext context, CancellationToken cancellationToken = default)
    {
        if (context.Credential is not SmsNotificationCredential credential)
            throw new NotFoundException($"Credential is not found for type {context.Credential.Type} and channel {context.Credential.ChannelType}.");

        return new SendResult
        {
            IsSent = true,
            SenderName = credential.SenderName,
            SenderContact = context.ReceiverUser.PhoneNumber,
            DeliveredAt = DateTimeOffset.UtcNow,
        };
    }
}