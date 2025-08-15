using TomEdu.Application.Abstractions.Notifications.Channels;
using TomEdu.Application.Common.Exceptions;
using TomEdu.Domain.Enums;

namespace TomEdu.Infrastructure.Notifications.Channels;

public class NotificationChannelProvider : INotificationChannelProvider
{
    private readonly Dictionary<NotificationChannelType, INotificationChannel> channelMap;

    public NotificationChannelProvider(IEnumerable<INotificationChannel> channels)
    {
        channelMap = new();

        foreach (var channel in channels)
        {
            channelMap[channel.ChannelType] = channel;
        }
    }

    public INotificationChannel GetChannel(NotificationChannelType channelType)
    {
        if (channelMap.TryGetValue(channelType, out var channel)) return channel;

        throw new NotFoundException($"Channel not found for channel {channelType}.");
    }
}