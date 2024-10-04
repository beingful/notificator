namespace Notificator.Api.Models;

public class Sender
{
    public required string Name { get; init; }

    public required string Address { get; init; }

    public required Account Account { get; init; }
}
