using TomEdu.Domain.Enums;

namespace TomEdu.Application.Abstractions.Notifications.Credentials;

public interface INotificationCredential
{
    NotificationType Type { get; }

    NotificationChannelType ChannelType { get; }
}