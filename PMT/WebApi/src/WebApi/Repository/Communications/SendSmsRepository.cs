using WebApi.Interfaces.Communications;
using WebApi.ServerNotifications;
namespace WebApi.Repository
{
    public class SendSmsRepository : ISendSms
    {
        private Sms _notifier;
        public void Send(string msg)
        {
            _notifier = new Sms();
             _notifier.SendMessage(msg);
        }
    }
}
