using TomEdu.Application.Abstractions.Notifications.Credentials;
using TomEdu.Application.Common.Exceptions;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Credentials;

public class NotificationCredentialProvider : INotificationCredentialProvider
{
    private readonly Dictionary<(NotificationType, NotificationChannelType), INotificationCredential> credentialMap;

    public NotificationCredentialProvider(IEnumerable<INotificationCredential> credentials)
    {
        credentialMap = new();

        foreach (var credential in credentials)
        {
            credentialMap[(credential.Type, credential.ChannelType)] = credential;
        }
    }

    public INotificationCredential GetCredential(NotificationType type, NotificationChannelType channelType)
    {
        if (credentialMap.TryGetValue((type, channelType), out var credential))
            return credential;

        throw new NotFoundException($"$Credential not found for type{type} and channel {channelType}");
    }
}