namespace Notificator.Api.Models.Emails;

public sealed record class SmtpServer(string Host, int Port);
