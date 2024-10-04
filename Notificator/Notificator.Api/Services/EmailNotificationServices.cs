using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Notificator.Api.Models;
using Notificator.Api.Models.Emails;

namespace Notificator.Api.Services;

public class EmailNotificationServices : INotificationServices<EmailNotification, EmailContent>
{
    private readonly SmtpServersCollection _smtpServers;
    private readonly ILogger _logger;

    public EmailNotificationServices(
        SmtpServersCollection smtpServers,
        ILogger<EmailNotificationServices> logger)
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
            userName: notification.Sender.Account.Id,
            password: notification.Sender.Account.Secret,
            cancellationToken: cancellationToken);

        MimeMessage message = BuildMessage(notification);

        await smtpClient.SendAsync(message, cancellationToken);

        await smtpClient.DisconnectAsync(quit: true, cancellationToken);
    }

    private MimeMessage BuildMessage(Notification<EmailContent> notification)
    {
        MimeMessage message = new()
        {
            Subject = notification.Content.Message.Subject,
            Body = new TextPart(format: TextFormat.Plain)
            {
                Text = notification.Content.Message.Body
            }
        };

        message.From.Add(new MailboxAddress(
            name: notification.Sender.Name,
            address: notification.Sender.Address));

        message.To.Add(new MailboxAddress(
            name: string.Empty,
            address: notification.Recipient.Address));

        return message;
    }
}
