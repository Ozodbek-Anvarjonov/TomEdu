namespace TomEdu.Application.Abstractions.Notifications.Templates.Contexts;

public class LoginNotificationTemplateContext : NotificationTemplateContext
{
    public string FirstName { get; set; } = default!;

    public string LoginAt { get; set; } = default!;
}