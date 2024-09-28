using Notificator.Api.Notifications.Types.Emails;
using Notificator.Api.Services;

namespace Notificator.Api.AppServices;

public static class ServiceRegistration
{
    public static IServiceCollection AddEmailServices(this IServiceCollection services)
    {
        return services
            .AddScoped<SmtpServersCollection>()
            .AddScoped<INotificationSender<EmailNotification, Email>, EmailNotificationSender>();
    }
}
