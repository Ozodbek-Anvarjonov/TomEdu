using TomEdu.Domain.Enums;

namespace TomEdu.Application.Abstractions.Notifications.Credentials;

public interface INotificationCredentialProvider
{
    INotificationCredential GetCredential(NotificationType type, NotificationChannelType channelType);
}