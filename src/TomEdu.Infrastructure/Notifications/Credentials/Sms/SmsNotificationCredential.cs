using TomEdu.Application.Abstractions.Notifications.Credentials;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Credentials.Sms;

public abstract class SmsNotificationCredential : INotificationCredential
{
    public abstract NotificationType Type { get; }

    public NotificationChannelType ChannelType { get; } = NotificationChannelType.Sms;

    public string Provider { get; set; } = default!;

    public string ApiUrl { get; set; } = default!;

    public string ApiToken { get; set; } = default!;

    public string SenderName { get; set; } = default!;
}