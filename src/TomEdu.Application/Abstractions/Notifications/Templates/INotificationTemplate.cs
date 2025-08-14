using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Application.Abstractions.Notifications.Templates.Contexts;
using TomEdu.Domain.Enums;

namespace TomEdu.Application.Abstractions.Notifications.Templates;

public interface INotificationTemplate
{
    NotificationType Type { get; }
    NotificationChannelType ChannelType { get; }

    TemplateContext GetContext(NotificationTemplateContext? context = null);
}