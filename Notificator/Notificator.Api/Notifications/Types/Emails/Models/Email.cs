namespace Notificator.Api.Notifications.Types.Emails;

public class Email : IContent
{
    public string? Subject { get; init; }

    public required string Body { get; init; }
}
