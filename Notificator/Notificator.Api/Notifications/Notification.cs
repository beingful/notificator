namespace Notificator.Api.Notifications;

public class Notification<TContent> where TContent : IContent
{
    public required AccountFrom AccountFrom { get; init; }

    public required AccountTo AccountTo { get; init; }

    public required TContent Content { get; init; }
}
