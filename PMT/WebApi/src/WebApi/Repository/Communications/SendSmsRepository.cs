using WebApi.Interfaces.Communications;
using WebApi.ServerNotifications;
namespace WebApi.Repository
{
    public class SendSmsRepository : ISendSms
    {
        private ServerNotificationsSms _notifier;
        public void Send(string msg)
        {
            _notifier = new ServerNotificationsSms();
             _notifier.SendMessage(msg);
        }
    }
}
