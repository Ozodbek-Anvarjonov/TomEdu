using Microsoft.Extensions.Options;
using TomEdu.Domain.Enums;
using TomEdu.Infrastructure.Notifications.Credentials.Sms.Options;

namespace TomEdu.Infrastructure.Notifications.Credentials.Sms;

public class LoginSmsNotificationCredential : SmsNotificationCredential
{
    public override NotificationType Type { get; } = NotificationType.Login;

    public LoginSmsNotificationCredential(IOptions<LoginSmsNotificationCredentialOptions> options)
    {
        Provider = options.Value.Provider;
        ApiUrl = options.Value.ApiUrl;
        ApiToken = options.Value.ApiToken;
        SenderName = options.Value.SenderName;
    }
}