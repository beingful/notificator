namespace Notificator.Api.Notifications.Types.Emails;

public class EmailNotification : Notification<Email>
{
    public EmailServer EmailServer { get; init; } = EmailServer.Gmail;
}
