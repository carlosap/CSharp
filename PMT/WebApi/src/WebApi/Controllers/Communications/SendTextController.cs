//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Mvc;
//using WebApi.TraceInfo;
//using WebApi.Interfaces.Communications;
//namespace WebApi.Controllers
//{
//    //api/sendtext?msg=hello test
//    //api/sendtext?msg=PTM SYSTEM ALERT! It appears the refrigerator is having temperature issues (-10 F) Go to: http://http://www.armandhammer.com/ for more details. Reply to this SMS and give us feedback.

//    [Route("api/[controller]")]
//    public class SendTextController : Controller
//    {
//        public ISendSms Sms { get; set; }
//        public SendTextController(ISendSms msg) { Sms = msg; }
//        public async Task<object> Get([FromQuery] string msg)
//        {
//            return await Task.Run(async () =>
//            {
//                try
//                {
//                    if (msg == null) return new[] { "status", "missing msg input" };
//                    await AddCorOptions();
//                    Sms.Send(msg);
//                    var results = new [] { "status", "OK" };
//                    return results;
//                }
//                catch (Exception ex)
//                {
//                    await Tracer.Exception("SendTextController:Get", ex);
//                    return null;
//                }
//            });
//        }

//        private async Task AddCorOptions()
//        {
//            await Task.Run(() =>
//            {
//                Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});
//                Response.Headers.Add("Access-Control-Allow-Headers",
//                    new[] {"Origin, X-Requested-With, Content-Type, Accept"});
//            });
//        }
//    }
//}
