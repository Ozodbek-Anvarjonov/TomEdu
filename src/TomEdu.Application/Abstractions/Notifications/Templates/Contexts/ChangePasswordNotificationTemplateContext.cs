namespace TomEdu.Application.Abstractions.Notifications.Templates.Contexts;

public class ChangePasswordNotificationTemplateContext : NotificationTemplateContext
{
    public string FirstName { get; set; } = default!;

    public string ChangedAt { get; set; } = default!;
}