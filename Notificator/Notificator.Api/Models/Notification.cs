namespace Notificator.Api.Models;

public class Notification<TContent> where TContent : Content
{
    public required Sender Sender { get; init; }

    public required Recipient Recipient { get; init; }

    public required TContent Content { get; init; }
}
