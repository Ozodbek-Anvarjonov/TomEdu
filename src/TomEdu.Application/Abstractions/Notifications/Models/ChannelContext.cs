using TomEdu.Application.Abstractions.Notifications.Credentials;
using TomEdu.Domain.Entities;

namespace TomEdu.Application.Abstractions.Notifications.Models;

public class ChannelContext
{
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;

    public long ReceiverUserId { get; set; }
    public User ReceiverUser { get; set; } = default!;

    public INotificationCredential Credential { get; set; } = default!;
}