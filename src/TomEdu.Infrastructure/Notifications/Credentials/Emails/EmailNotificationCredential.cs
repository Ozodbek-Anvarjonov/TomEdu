using TomEdu.Application.Abstractions.Notifications.Credentials;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Credentials.Emails;

public abstract class EmailNotificationCredential : INotificationCredential
{
    public abstract NotificationType Type { get; }
    public NotificationChannelType ChannelType { get; } = NotificationChannelType.Email;

    public string Host { get; set; } = default!;
    public int Port { get; set; }
    public bool EnableSsl { get; set; }

    public string SenderEmail { get; set; } = default!;
    public string SenderName { get; set; } = default!;

    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}