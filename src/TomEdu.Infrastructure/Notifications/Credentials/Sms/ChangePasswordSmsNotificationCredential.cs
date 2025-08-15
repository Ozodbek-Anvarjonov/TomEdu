using Microsoft.Extensions.Options;
using TomEdu.Domain.Enums;
using TomEdu.Infrastructure.Notifications.Credentials.Sms.Options;

namespace TomEdu.Infrastructure.Notifications.Credentials.Sms;

public class ChangePasswordSmsNotificationCredential : SmsNotificationCredential
{
    public override NotificationType Type { get; } = NotificationType.ChangePassword;

    public ChangePasswordSmsNotificationCredential(IOptions<ChangePasswordSmsNotificationCredentialOptions> options)
    {
        Provider = options.Value.Provider;
        ApiUrl = options.Value.ApiUrl;
        ApiToken = options.Value.ApiToken;
        SenderName = options.Value.SenderName;
    }
}