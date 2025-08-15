using TomEdu.Application.Abstractions.Notifications.Channels;
using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Application.Abstractions.Notifications.Services;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Channels;

public class EmailNotificationChannel(IEmailService emailService) : INotificationChannel
{
    public NotificationChannelType ChannelType { get; } = NotificationChannelType.Email;

    public async Task<SendResult> SendAsync(ChannelContext channel, CancellationToken cancellationToken = default)
    {
        var result = await emailService.SendAsync(channel, cancellationToken);

        return result;
    }
}