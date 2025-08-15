using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Application.Abstractions.Notifications.Templates.Contexts;
using TomEdu.Domain.Enums;
using TomEdu.Infrastructure.Notifications.Templates.Base;

namespace TomEdu.Infrastructure.Notifications.Templates.Sms;

public class RegisterSmsNotificationTemplate : RegisterNotificationTemplateBase
{
    public override NotificationChannelType ChannelType => NotificationChannelType.Sms;

    public override TemplateContext GetContext(NotificationTemplateContext? context = null)
    {
        var (title, message) = BuildText(context);

        return new TemplateContext
        {
            Title = title,
            Message = message,
            FormattedTitle = title,
            FormattedMessage = message
        };
    }
}