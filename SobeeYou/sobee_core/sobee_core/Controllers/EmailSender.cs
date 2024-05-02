using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace sobee_core.Controllers {
    public class EmailSender : IEmailSender {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "sobeeyoubusiness@gmail.com";
        private readonly string _smtpPassword = "yplu kfwq wufa jpjp";

        public Task SendEmailAsync(string email, string subject, string htmlMessage) {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort)) {
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);

                using (var mailMessage = new MailMessage()) {
                    mailMessage.From = new MailAddress(_smtpUsername);
                    mailMessage.To.Add(email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = htmlMessage;
                    mailMessage.IsBodyHtml = true; // Ensure the body is HTML

                    smtpClient.Send(mailMessage);
                }
            }
            return Task.CompletedTask;
        }
    }

}
