using Notificator.Api.Notifications;

namespace Notificator.Api.Services;

public interface INotificationSender<TNotification, TContent>
    where TNotification : Notification<TContent>
    where TContent : IContent
{
    public Task SendAsync(TNotification notification, CancellationToken cancellationToken);
}
