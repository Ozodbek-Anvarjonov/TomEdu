using TomEdu.Domain.Enums;

namespace TomEdu.Application.Abstractions.Notifications.Channels;

public interface INotificationChannelProvider
{
    INotificationChannel GetChannel(NotificationChannelType channelType);
}