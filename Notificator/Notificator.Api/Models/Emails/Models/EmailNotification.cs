namespace Notificator.Api.Models.Emails;

public class EmailNotification : Notification<EmailContent>
{
    public EmailServer EmailServer { get; init; } = EmailServer.Gmail;
}
