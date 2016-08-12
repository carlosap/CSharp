using System;
using System.Threading.Tasks;
using Twilio;
using WebApi.Extensions.Strings;
using WebApi.Interfaces.Communications;
using System.Collections.Generic;

namespace WebApi.ServerNotifications
{
    public class ServerNotificationsSms: IServerNotification
    {
        private readonly TwilioRestClient _client;
        private readonly string _fromNumber;
        private readonly List<SmsContact> _contacts;
        public ServerNotificationsSms()
        {
            var SID = Startup.AppSettings.SmsSettings.SID.Value.ToString();
            var TOKEN = Startup.AppSettings.SmsSettings.TOKEN.Value.ToString();
            _fromNumber = Startup.AppSettings.SmsSettings.FromNumber.Value.ToString();           
            _client = new TwilioRestClient(SID, TOKEN);
        }

        public ServerNotificationsSms(TwilioRestClient client)
        {
            _client = client;
        }

        public Message SendMessage(string msg)
        {
            var contacts = Startup.AppSettings.SmsSettings.Contacts;
            return _client.SendMessage(_fromNumber, "7275606474", msg);
            //foreach (var smsContact in contacts)
            //{
            //    try
            //    {
            //        string strPhone = smsContact.Telephone.Value.ToString().Replace("+", "");
            //        if (strPhone.IsNumber())
            //            _client.SendMessage(_fromNumber, "+" + strPhone, msg);

            //    }
            //    catch (Exception ex)
            //    {

            //        continue;
            //    }

            //}
        }



    }
}
