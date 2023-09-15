/*using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace BankWelcomeApp
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class WelcomeLetterModel
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public interface IWelcomeLetterRepository
    {
        void Add(WelcomeLetterModel welcomeLetter);
    }

    public class WelcomeLetterRepository : IWelcomeLetterRepository
    {
        private List<WelcomeLetterModel> _welcomeLetters = new List<WelcomeLetterModel>();

        public void Add(WelcomeLetterModel welcomeLetter)
        {
            _welcomeLetters.Add(welcomeLetter);
        }
    }

    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body, string attachmentPath);
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;

            _smtpClient = new SmtpClient(_emailSettings.SmtpServer)
            {
                Port = _emailSettings.Port,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("yuvagoonjtrust@gmail.com", "vnhltqfikqhaxxzz"),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, string attachmentPath)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("yuvagoonjtrust@gmail.com"); 
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                // Attach the PDF
                Attachment attachment = new Attachment(attachmentPath, MediaTypeNames.Application.Pdf);
                mailMessage.Attachments.Add(attachment);

                try
                {
                    await _smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error sending email: {ex.Message}");
                }
            }
        }
    }

   
   

}
*/