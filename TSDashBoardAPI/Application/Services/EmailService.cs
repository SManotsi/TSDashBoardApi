using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TSDashBoardApi.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mail = new MailMessage();
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(_smtpUsername);

            using var smtp = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true // Enable SSL if your SMTP provider requires it
            };

            await smtp.SendMailAsync(mail);
        }
    }
}
