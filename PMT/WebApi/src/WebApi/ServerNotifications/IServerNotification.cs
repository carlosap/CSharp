using Twilio;
namespace WebApi.Interfaces.Communications
{
    public interface IServerNotification
    {
        void SendMessage(string telphoneNumber,string body);
    }
}


