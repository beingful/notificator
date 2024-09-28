using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Notificator.Api.Notifications;
using Notificator.Api.Notifications.Types.Emails;

namespace Notificator.Api.Services;

public class EmailNotificationSender : INotificationSender<EmailNotification, Email>
{
    private readonly SmtpServersCollection _smtpServers;
    private readonly ILogger _logger;

    public EmailNotificationSender(
        SmtpServersCollection smtpServers,
        ILogger<EmailNotificationSender> logger)
    {
        _smtpServers = smtpServers;
        _logger = logger;
    }

    public async Task SendAsync(EmailNotification notification, CancellationToken cancellationToken)
    {
        SmtpServer smtpServer = _smtpServers[notification.EmailServer];

        using SmtpClient smtpClient = new();

        await smtpClient.ConnectAsync(smtpServer.Host, smtpServer.Port, cancellationToken: cancellationToken);

        await smtpClient.AuthenticateAsync(
            userName: notification.AccountFrom.Id,
            password: notification.AccountFrom.Secret,
            cancellationToken: cancellationToken);

        MimeMessage message = BuildMessage(notification);

        await smtpClient.SendAsync(message, cancellationToken);

        await smtpClient.DisconnectAsync(quit: true, cancellationToken);
    }

    private MimeMessage BuildMessage(Notification<Email> notification)
    {
        MimeMessage message = new()
        {
            Subject = notification.Content.Subject,
            Body = new TextPart(format: TextFormat.Plain)
            {
                Text = notification.Content.Body
            }
        };

        message.From.Add(new MailboxAddress(
            name: notification.AccountFrom.Owner,
            address: notification.AccountFrom.Id));

        message.To.Add(new MailboxAddress(
            name: notification.AccountTo.Owner,
            address: notification.AccountTo.Id));

        return message;
    }
}
