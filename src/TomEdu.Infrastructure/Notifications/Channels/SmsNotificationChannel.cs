using TomEdu.Application.Abstractions.Notifications.Channels;
using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Application.Abstractions.Notifications.Services;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Channels;

public class SmsNotificationChannel(ISmsService smsService) : INotificationChannel
{
    public NotificationChannelType ChannelType { get; } = NotificationChannelType.Sms;

    public async Task<SendResult> SendAsync(ChannelContext channel, CancellationToken cancellationToken = default)
    {
        var result = await smsService.SendAsync(channel, cancellationToken);

        return result;
    }
}