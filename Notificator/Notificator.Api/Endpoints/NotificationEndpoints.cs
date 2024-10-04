using Notificator.Api.Models.Emails;
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
            INotificationServices<EmailNotification, EmailContent> emailSender,
            CancellationToken cancellationToken) =>
        {
            await emailSender.SendAsync(email, cancellationToken);
        });

        return webApplication;
    }
}
