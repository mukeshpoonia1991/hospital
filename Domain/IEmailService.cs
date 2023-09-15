using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body, string attachmentPath);
    }
}
