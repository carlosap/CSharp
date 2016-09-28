using System.Threading.Tasks;
namespace WebApi.Interfaces.Communications
{
    public interface ISendEmail
    {
        Task Send(string emailTo,string emailFrom, string emailSubject, string emailText,string emailAttachment="", string emailType = "text/plain");
        Task SendHtml(string email, string name,string emailText, string templateName, string language = "eng");
    }
}


