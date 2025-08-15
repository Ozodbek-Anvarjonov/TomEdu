using Microsoft.Extensions.Options;
using TomEdu.Domain.Enums;
using TomEdu.Infrastructure.Notifications.Credentials.Sms.Options;

namespace TomEdu.Infrastructure.Notifications.Credentials.Sms;

public class RegisterSmsNotificationCredential : SmsNotificationCredential
{
    public override NotificationType Type { get; } = NotificationType.Register;

    public RegisterSmsNotificationCredential(IOptions<RegisterSmsNotificationCredentialOptions> options)
    {
        Provider = options.Value.Provider;
        ApiUrl = options.Value.ApiUrl;
        ApiToken = options.Value.ApiToken;
        SenderName = options.Value.SenderName;
    }
}