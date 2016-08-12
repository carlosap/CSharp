using System.Threading.Tasks;
namespace WebApi.Interfaces.Communications
{
    public interface ISendEmail
    {
        Task Send(string emailTo,string emailFrom, string emailSubject, string emailText,string emailAttachment="", string emailType = "text/plain");
    }
}


