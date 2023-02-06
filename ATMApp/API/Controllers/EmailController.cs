using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("sendmail")]
        public IActionResult SendMail(string body)
        {
            if (body == null)
            {
                body = "<!DOCTYPE html><html><body><h1>My First Heading.</h1><p>My first paragraph.</p></body></html>";
            }
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("erna.moore48@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("erna.moore48@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email",587,SecureSocketOptions.StartTls);

            smtp.Authenticate("erna.moore48@ethereal.email", "vXpSDet1pKJ3kQjQFE");
            smtp.Send(email);

            smtp.Disconnect(true);

            return Ok();
        }
    }
}
