namespace TomEdu.Infrastructure.Notifications.Credentials.Emails.Options;

public abstract class EmailNotificationCredentialOptions
{
    public string Host { get; set; } = default!;
    public int Port { get; set; }
    public bool EnableSsl { get; set; }

    public string SenderEmail { get; set; } = default!;
    public string SenderName { get; set; } = default!;

    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}