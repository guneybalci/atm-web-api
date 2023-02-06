using Business.Abstract;
using Entities.Dtos;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete
{
    public class EmailManager : IEmailService
    {
        private readonly IConfiguration _config;  
        public EmailManager(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("erna.moore48@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("erna.moore48@ethereal.email"));
            email.Subject = "ATM Bilgilendirme Maili";
            email.Body = new TextPart(TextFormat.Html) { Text = "<!DOCTYPE html><html><body><h1>ATM Bilgilendirme Mail.</h1><p>İçerik Görüntülenemiyor.</p></body></html>" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);

            smtp.Authenticate("erna.moore48@ethereal.email", "vXpSDet1pKJ3kQjQFE");
            smtp.Send(email);

            smtp.Disconnect(true);

        }
    }
}
