using Notificator.Api.Notifications.Types.Emails;
using Notificator.Api.Services;

namespace Notificator.Api.Endpoints;

public static class NotificationEndpoints
{
    public static WebApplication AddNotificationEndpoints(this WebApplication webApplication)
    {
        return webApplication.PostEmailNotification();
    }

    private static WebApplication PostEmailNotification(this WebApplication webApplication)
    {
        webApplication.MapPost("notify/by/email", async (
            EmailNotification email,
            INotificationSender<EmailNotification, Email> emailSender,
            CancellationToken cancellationToken) =>
        {
            await emailSender.SendAsync(email, cancellationToken);
        });

        return webApplication;
    }
}
