using HiFiveTravel.Interfaces;
using System.Net;
using System.Net.Mail;

namespace HiFiveTravel.Services
{
    public class MailSend : IMailSend
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogError _logError;
        private readonly IConfiguration _configuration;
        public MailSend(ILogError logErr, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _logError = logErr;
            _env = webHostEnvironment;
            _configuration = configuration;

        }
        public bool Sendmail(string messsg, string subjectofmail)
        {
            try
            {
                string from_email = _configuration["EmailInfo:FromEmail"];
                string from_password = _configuration["EmailInfo:Password"];
                MailMessage msg = new MailMessage();
                msg.To.Add(_configuration["EmailTo:Email"]);
                MailAddress address = new MailAddress(from_email);
                msg.From = address;
                msg.Subject = subjectofmail;
                msg.Body = messsg;
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Host = "relay-hosting.secureserver.net";
                client.Port =25 ;
                NetworkCredential credentials = new NetworkCredential(from_email, from_password);
                client.Credentials = credentials;
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                _logError.LogErrorFile(ex, _env);
            }
            return false;
        }

    }
}
