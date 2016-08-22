using System;
using Twilio;
using WebApi.Interfaces.Communications;
using WebApi.Extensions.Strings;
namespace WebApi.ServerNotifications
{
    public class Sms: IServerNotification
    {
        private readonly TwilioRestClient _client;
        private readonly string _fromNumber;
        public readonly bool IsEnabled;
        public Sms()
        {
            var SID = Startup.AppSettings.SmsSettings.SID.Value.ToString();
            var TOKEN = Startup.AppSettings.SmsSettings.TOKEN.Value.ToString();
            IsEnabled = (bool)Startup.AppSettings.SmsSettings.Enabled;
            _fromNumber = Startup.AppSettings.SmsSettings.FromNumber.Value.ToString();           
            _client = new TwilioRestClient(SID, TOKEN);
        }

        public Sms(TwilioRestClient client)
        {
            _client = client;
        }

        public void SendMessage(string msg)
        {
            if (!IsEnabled) return;
            var contacts = Startup.AppSettings.SmsSettings.Contacts;
            foreach (var smsContact in contacts)
            {
                try
                {
                    string strPhone = smsContact.Telephone.Value.ToString().Replace("+", "");
                    if (strPhone.IsNumber())
                    {
                        _client?.SendMessage(_fromNumber, strPhone, msg);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}
