using TomEdu.Domain.Enums;

namespace TomEdu.Application.Abstractions.Notifications.Templates;

public interface INotificationTemplateProvider
{
    INotificationTemplate GetTemplate(NotificationType type, NotificationChannelType channelType);
}