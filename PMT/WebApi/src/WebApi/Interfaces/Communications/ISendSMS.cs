using System.Threading.Tasks;
namespace WebApi.Interfaces.Communications
{
    public interface ISendSms
    {
        void Send(string telphoneNumber,string msg);
    }
}

