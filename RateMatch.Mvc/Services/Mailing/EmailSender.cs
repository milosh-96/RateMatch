using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RateMatch.Mvc.Services.Mailing
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration Configuration;

        public EmailSender(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var defaultConf = Configuration.GetSection("Email:Default");

            var client = new SmtpClient(
                defaultConf.GetSection("Host").Value,
                Int32.Parse(defaultConf.GetSection("Port").Value)
                )
            {
                Credentials = new NetworkCredential(
                    defaultConf.GetSection("UserName").Value,
                    defaultConf.GetSection("Password").Value
                )
            };
            var email = new MailMessage(new MailAddress(SiteInfo.NoReplyEmail,SiteInfo.Name, Encoding.UTF8),new MailAddress(toEmail))
            {
                Subject = subject,
                Body =  message,               
            };
             await client.SendMailAsync(email);
        }
    }
}

