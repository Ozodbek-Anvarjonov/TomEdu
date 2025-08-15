using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Application.Abstractions.Notifications.Templates;
using TomEdu.Application.Abstractions.Notifications.Templates.Contexts;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Templates.Base;

public abstract class LoginNotificationTemplateBase : INotificationTemplate
{
    public NotificationType Type { get; } = NotificationType.Login;
    public abstract NotificationChannelType ChannelType { get; }

    public abstract TemplateContext GetContext(NotificationTemplateContext? context = null);

    protected virtual (string Title, string Message) BuildText(NotificationTemplateContext? context)
    {
        var title = "Login successful";
        var message = context is LoginNotificationTemplateContext ctx
            ? $"Hi {ctx.FirstName}, your login was successful. Welcome aboard!"
            : "Your login was successful. Welcome!";

        return (title, message);
    }
}