using TomEdu.Application.Abstractions.Notifications.Templates.Contexts;
using TomEdu.Domain.Entities;
using TomEdu.Domain.Enums;

namespace TomEdu.Application.Abstractions.Notifications.Services;

public interface INotificationSenderService
{
    Task<Notification> SendAsync(Notification notification, NotificationTemplateContext context, CancellationToken cancellationToken = default);

    Task<IEnumerable<Notification>> SendAsync(
        Notification notification,
        NotificationTemplateContext context,
        IEnumerable<NotificationChannelType> channelTypes,
        CancellationToken cancellationToken = default
        );
}