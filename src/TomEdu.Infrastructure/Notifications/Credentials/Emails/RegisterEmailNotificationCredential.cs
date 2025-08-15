using Microsoft.Extensions.Options;
using TomEdu.Domain.Enums;
using TomEdu.Infrastructure.Notifications.Credentials.Emails.Options;

namespace TomEdu.Infrastructure.Notifications.Credentials.Emails;

public class RegisterEmailNotificationCredential : EmailNotificationCredential
{
    public override NotificationType Type { get; } = NotificationType.Register;

    public RegisterEmailNotificationCredential(IOptions<RegisterEmailNotificationCredentialOptions> options)
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