using TomEdu.Application.Abstractions.Notifications.Templates;
using TomEdu.Application.Common.Exceptions;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Templates;

public class NotificationTemplateProvider : INotificationTemplateProvider
{
    private readonly Dictionary<(NotificationType, NotificationChannelType), INotificationTemplate> templateMap;

    public NotificationTemplateProvider(IEnumerable<INotificationTemplate> templates)
    {
        templateMap = new();

        foreach (var template in templates)
        {
            templateMap[(template.Type, template.ChannelType)] = template;
        }
    }

    public INotificationTemplate GetTemplate(NotificationType type, NotificationChannelType channelType)
    {
        if (templateMap.TryGetValue((type, channelType), out var template)) return template;

        throw new NotFoundException($"Template not found for type{type}.");
    }
}