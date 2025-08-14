namespace TomEdu.Application.Abstractions.Notifications.Models;

public class SendResult
{
    public string SenderName { get; set; } = default!;

    public string SenderContact { get; set; } = default!;

    public bool IsSent { get; set; }

    public DateTimeOffset? DeliveredAt { get; set; }

    public string? ErrorMessage { get; set; }
}