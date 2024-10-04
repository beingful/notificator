using Notificator.Api.Models.Emails;
using Notificator.Api.Services;

namespace Notificator.Api.AppServices;

public static class ServiceRegistration
{
    public static IServiceCollection AddEmailServices(this IServiceCollection services)
    {
        return services
            .AddScoped<SmtpServersCollection>()
            .AddScoped<INotificationServices<EmailNotification, EmailContent>, EmailNotificationServices>();
    }
}
