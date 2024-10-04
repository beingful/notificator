using Notificator.Api.Models;

namespace Notificator.Api.Services;

public interface INotificationServices<TNotification, TContent>
    where TNotification : Notification<TContent>
    where TContent : Content
{
    public Task SendAsync(TNotification notification, CancellationToken cancellationToken);
}
