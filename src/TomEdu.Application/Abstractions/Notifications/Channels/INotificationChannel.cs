using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Domain.Enums;

namespace TomEdu.Application.Abstractions.Notifications.Channels;

public interface INotificationChannel
{
    NotificationChannelType ChannelType { get; }

    Task<SendResult> SendAsync(ChannelContext channel, CancellationToken cancellationToken = default);
}