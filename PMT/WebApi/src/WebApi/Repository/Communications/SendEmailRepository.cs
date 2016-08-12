using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebApi.Extensions.Strings;
using WebApi.Interfaces.Communications;
namespace WebApi.Repository
{
    public class SendEmailRepository : ISendEmail
    {
        public async Task Send(string emailTo, string emailFrom, string emailSubject, string emailText,
            string emailAttachment = "", string emailType = "text/plain")
        {
            var apiKey = Startup.AppSettings.EmailGridSettings.ApiKey;
            var sg = new SendGridAPIClient(apiKey.Value);
            if (emailTo.Contains(";"))
            {
                var emails = emailTo.Split(';');
                foreach (var email in emails)
                {
                    if (email.IsValidEmail())
                    {
                        await MailSend(email, emailFrom, emailSubject, emailText, emailAttachment, emailType);
                    }
                }
            }
            else
            {
                if (emailTo.IsValidEmail())
                {
                    await MailSend(emailTo, emailFrom, emailSubject, emailText, emailAttachment, emailType);
                }
            }

        }

        private async Task MailSend(string emailTo, string emailFrom, string emailSubject, string emailText,
            string emailAttachment = "", string emailType = "text/plain")
        {
            var apiKey = Startup.AppSettings.EmailGridSettings.ApiKey;
            var sg = new SendGridAPIClient(apiKey.Value);
            var from = new Email(emailFrom);
            var subject = emailSubject;
            var to = new Email(emailTo);
            var content = new Content(emailType, emailText);
            var mail = new Mail(from, subject, to, content);
            await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
