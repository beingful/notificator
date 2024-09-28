namespace Notificator.Api.Notifications;

public class Account
{
    public required string Id { get; init; }

    public string Owner { get; init; } = string.Empty;
}
