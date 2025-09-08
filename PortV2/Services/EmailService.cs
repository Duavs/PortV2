using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
namespace PortV2.Services;

public class EmailService
{
    private readonly EmailSettings _settings;
    public EmailService(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        using var smtp = new SmtpClient(_settings.SmtpServer, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password),
            EnableSsl = true
        };

        var mail = new MailMessage
        {
            From = new MailAddress(_settings.FromAddress, _settings.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mail.To.Add(to);

        await smtp.SendMailAsync(mail);
    }
    
}

public class EmailSettings
{
    public string FromAddress { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public string SmtpServer { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}