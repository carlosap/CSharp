using System;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebApi.Extensions.Strings;
using WebApi.Interfaces.Communications;

namespace WebApi.Repository
{
    public class SendEmailRepository : ISendEmail
    {
        public async Task Send(
            string emailTo,
            string emailFrom,
            string emailSubject,
            string emailText,
            string emailAttachment = "",
            string emailType = "text/plain")
        {
            if (emailTo.Contains(";"))
            {
                var emails = emailTo.Split(';');
                foreach (var email in emails)
                    if (email.IsValidEmail())
                        await MailSend(email, emailFrom, emailSubject, emailText, emailType);
            }
            else if (emailTo.IsValidEmail())
                await MailSend(emailTo, emailFrom, emailSubject, emailText, emailType);
        }

        public async Task SendHtml(
            string emailText,
            string templateName,
            string language = "eng")
        {
            var staticPages = new StaticRepository();
            var pages = await staticPages.Get(templateName, language);
            if (pages.Any())
            {
                if (!string.IsNullOrWhiteSpace(emailText))
                {
                    var contacts = Startup.AppSettings.EmailGridSettings.Contacts;
                    var emailFrom = Startup.AppSettings.EmailGridSettings.From.Value;
                    var emailSubject = Startup.AppSettings.EmailGridSettings.Subject.Value;
                    var isEnabled = (bool) Startup.AppSettings.EmailGridSettings.Enabled;               
                    var template = pages.FirstOrDefault()?.Value;
                    if (!isEnabled) return;
                    foreach (var smsContact in contacts)
                    {
                        try
                        {
                            string strName = smsContact.Name.Value.ToString();
                            string emailTo = smsContact.Email.Value.ToString();
                            var msg = template?.Replace("[NAME]", strName).Replace("[MSG]", emailText);
                            if (emailTo.Contains(";"))
                            {
                                var emails = emailTo.Split(';');
                                foreach (var email in emails)
                                    if (email.IsValidEmail())
                                        await MailSend(email, emailFrom, emailSubject, msg, "text/html");
                            }
                            else if (emailTo.IsValidEmail())
                                await MailSend(emailTo, emailFrom, emailSubject, msg, "text/html");
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
            }
        }

        private async Task MailSend(
            string emailTo,
            string emailFrom,
            string emailSubject,
            string emailText,
            string emailType = "text/plain")
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
