using Microsoft.Extensions.Options;
using TomEdu.Domain.Enums;
using TomEdu.Infrastructure.Notifications.Credentials.Emails.Options;

namespace TomEdu.Infrastructure.Notifications.Credentials.Emails;

public class ChangePasswordEmailNotificationCredential : EmailNotificationCredential
{
    public override NotificationType Type { get; } = NotificationType.ChangePassword;

    public ChangePasswordEmailNotificationCredential(IOptions<ChangePasswordEmailNotificationCredentialOptions> options)
    {
        Host = options.Value.Host;
        Port = options.Value.Port;
        EnableSsl = options.Value.EnableSsl;
        SenderName = options.Value.SenderName;
        SenderEmail = options.Value.SenderEmail;
        Username = options.Value.Username;
        Password = options.Value.Password;
    }
}