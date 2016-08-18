using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebApi.Extensions.Strings;
using WebApi.Interfaces.Communications;
using System;
using System.Linq;

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
        public async Task SendHtml(string emailText,string templateName,string language="eng")
        {
            var staticPages = new StaticRepository();
            var pages = await staticPages.Get(templateName, language);
            if (pages.Any())
            {
                if (!string.IsNullOrWhiteSpace(emailText))
                {
                    var contacts = Startup.AppSettings.EmailGridSettings.Contacts;
                    foreach (var smsContact in contacts)
                    {
                        try
                        {
                            string strName = smsContact.Name.Value.ToString();
                            string emailTo = smsContact.Email.Value.ToString();
                            var emailFrom = "pmt-fl@donotreply.com";
                            var emailSubject = "Sensor Notifications";
                            emailText = pages.FirstOrDefault().Value.Replace("[NAME]", strName).Replace("[MSG]", emailText);
                            if (emailTo.Contains(";"))
                            {
                                var emails = emailTo.Split(';');
                                foreach (var email in emails)
                                {
                                    if (email.IsValidEmail())
                                    {
                                        await MailSend(email, emailFrom, emailSubject, emailText, "", "text/html");
                                    }
                                }
                            }
                            else
                            {
                                if (emailTo.IsValidEmail())
                                {
                                    await MailSend(emailTo, emailFrom, emailSubject, emailText, "", "text/html");
                                }
                            }

                        }
                        catch (Exception)
                        {

                            continue;
                        }

                    }
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
