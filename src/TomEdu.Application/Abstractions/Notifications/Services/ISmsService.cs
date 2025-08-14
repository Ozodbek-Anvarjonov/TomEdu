using TomEdu.Application.Abstractions.Notifications.Models;

namespace TomEdu.Application.Abstractions.Notifications.Services;

public interface ISmsService
{
    Task<SendResult> SendAsync(ChannelContext context, CancellationToken cancellationToken = default);
}