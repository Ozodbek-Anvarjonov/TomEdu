using Force.DeepCloner;
using TomEdu.Application.Abstractions.Notifications.Channels;
using TomEdu.Application.Abstractions.Notifications.Credentials;
using TomEdu.Application.Abstractions.Notifications.Models;
using TomEdu.Application.Abstractions.Notifications.Services;
using TomEdu.Application.Abstractions.Notifications.Templates;
using TomEdu.Application.Abstractions.Notifications.Templates.Contexts;
using TomEdu.Application.Services;
using TomEdu.Domain.Entities;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Services;

public class NotificationSenderService(
    INotificationChannelProvider channelProvider,
    INotificationCredentialProvider credentialProvider,
    INotificationTemplateProvider templateProvider,
    INotificationService notificationService
    ) : INotificationSenderService
{
    public async Task<Notification> SendAsync(Notification notification, NotificationTemplateContext context, CancellationToken cancellationToken = default)
    {
        var template = templateProvider.GetTemplate(notification.Type, notification.ChannelType);
        var credential = credentialProvider.GetCredential(notification.Type, notification.ChannelType);
        var channel = channelProvider.GetChannel(notification.ChannelType);

        var templateContext = template.GetContext(context);
        var sendResult = await channel.SendAsync(new ChannelContext
        {
            Title = templateContext.FormattedTitle,
            Message = templateContext.FormattedMessage,
            Credential = credential,
            ReceiverUserId = notification.ReceiverUserId,
            ReceiverUser = notification.ReceiverUser,
        });

        notification.Title = templateContext.Title;
        notification.Message = templateContext.Message;
        notification.SenderName = sendResult.SenderName;
        notification.SenderContact = sendResult.SenderContact;
        notification.IsDelivered = sendResult.IsSent;
        notification.DeliveredAt = sendResult.DeliveredAt;
        notification.ErrorMessage = sendResult.ErrorMessage;

        await notificationService.CreateAsync(notification, cancellationToken: cancellationToken);

        return notification;
    }

    public async Task<IEnumerable<Notification>> SendAsync(
        Notification notification,
        NotificationTemplateContext context,
        IEnumerable<NotificationChannelType> channelTypes,
        CancellationToken cancellationToken = default
        )
    {
        var notifications = new List<Notification>();

        foreach (var channelType in channelTypes.Distinct())
        {
            var clonedNotification = notification.DeepClone();
            clonedNotification.ChannelType = channelType;
            clonedNotification.ReceiverUser = notification.ReceiverUser;
            await SendAsync(clonedNotification, context, cancellationToken);
            notifications.Add(clonedNotification);
        }

        return notifications;
    }
}